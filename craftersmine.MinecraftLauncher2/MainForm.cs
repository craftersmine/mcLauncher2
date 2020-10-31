using craftersmine.MinecraftLauncher2.Core;
using craftersmine.MinecraftLauncher2.Extensions;
using craftersmine.MinecraftLauncher2.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace craftersmine.MinecraftLauncher2
{
    public partial class MainForm : Form
    {
        Downloader downloader;
        ClientDownloader clientDownloader;
        ClientInstaller clientInstaller;
        JreInstaller jreInstaller;
        List<string> filesToUnpack = new List<string>();
        ClientLauncher launcher;
        CurrentLauncherState state = CurrentLauncherState.Idle;

        public MainForm()
        {
            InitializeComponent();
            DisableControls();
            downloader = new Downloader();
            clientDownloader = new ClientDownloader();
            jreInstaller = new JreInstaller();
            launcher = new ClientLauncher();
            jreInstaller.JREDownloadCompleted += jreDownloadCompleted;
            jreInstaller.JREDownloadProgressChanged += jreDownloadProgressChanged;
            jreInstaller.JREInstallCancelled += jreInstallCancelled;
            clientDownloader.ClientArchiveDownloaded += clientArchiveDownloaded;
            clientDownloader.ClientArchiveDownloadProgress += clientArchiveDownloadProgress;
            clientDownloader.ClientArchiveDownloadQueueCancelled += clientDownloadCancelled;
            clientDownloader.ClientArchivesDownloaded += clientDownloadCompleted;
        }

        private void jreInstallCancelled(object sender, EventArgs e)
        {
            Invoke(new Action(() => {
                percentage.Text = "";
                status.Text = "Выполняется отмена установки Java Runtime Environment...";
                progress.Value = 0;
                progress.Style = ProgressBarStyle.Marquee;
            }));
            //await CleanupManager.ClearTemp();
            MessageBox.Show("Установка Java Runtime Environment была отменена! Так как JRE не была установленна, продолжение невозможно, лаунчер будет закрыт!", "Установка JRE отменена!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Exit();
        }

        private void jreDownloadProgressChanged(object sender, JREDownloadProgressChangedEventArgs e)
        {
            Invoke(new Action(() => {
                percentage.Text = String.Format("{0:F2} %", e.Percentage);
                status.Text = "Выполняется загрузка Java Runtime Environment...";
                progress.Value = (int)Math.Truncate(e.Percentage);
            }));
        }

        private async void jreDownloadCompleted(object sender, EventArgs e)
        {
            Invoke(new Action(() => {
                percentage.Text = "";
                status.Text = "Выполняется установка Java Runtime Environment...";
                progress.Style = ProgressBarStyle.Marquee;
                cancel.Enabled = false;
                state = CurrentLauncherState.Idle;
            }));

            if (!jreInstaller.IsInstallCompleted)
            {
                await jreInstaller.Install(StaticData.JrePath);
                SettingsManager.IsJreInstalled = true;

                MessageBox.Show("Java Runtime Environment был загружена и установлена во внутреннюю директорию лаунчера. Будет выполнен перезапуск лаунчера!", "JRE установлена!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Restart();
            }
        }

        private async void clientDownloadCompleted(object sender, EventArgs e)
        {
            state = CurrentLauncherState.Idle;
            Logger.Instance.Log(LogEntryType.Done, "Client archives downloaded!");
            string id = "";
            Invoke(new Action(() => { 
                id = ((MCBuildInfo)selectedBuild.SelectedItem).Id;
                percentage.Text = "";
            cancel.Enabled = false;
                status.Text = "Выполняется установка клиента...";
                progress.Style = ProgressBarStyle.Marquee;
            }));

            if (id.IsNullEmptyOrWhitespace())
            {
                Logger.Instance.Log(LogEntryType.Warning, "Reverting client installation due to error...");
                Invoke(new Action(() => {
                    id = ((MCBuildInfo)selectedBuild.SelectedItem).Id;
                    percentage.Text = "";
                    status.Text = "Откат установки клиента из-за ошибки...";
                    progress.Style = ProgressBarStyle.Marquee;
                }));
                await CleanupManager.ClearTemp();
                MessageBox.Show("Не удалось инициализировать установку клиента! Попробуйте произвести установку клиента повторно, если проблема осталась, обратитесь к разработчику! Больше информации можно найти в журнале лаунчера!", "Неопознаная ошибка лаунчера при установке клиента!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Logger.Instance.Log(LogEntryType.Info, "Proceeding to install archives...");
            string destinationDir = Path.Combine(StaticData.ClientsRootPath, id);
            Logger.Instance.Log(LogEntryType.Info, "Client install destination directory: " + destinationDir);
            clientInstaller = new ClientInstaller(filesToUnpack.ToArray(), destinationDir);
            clientInstaller.InstallingArchive += installingArchive;
            clientInstaller.InstallationCompleted += installationComplete;
            clientInstaller.IsInstallAllowed = true;
            await clientInstaller.Install();
        }

        private async void installationComplete(object sender, EventArgs e)
        {
            Logger.Instance.Log(LogEntryType.Done, "Installation completed!");
            MCBuildInfo clientData = null;
            Invoke(new Action(() => {
                status.Text = "Завершение установки...";
                percentage.Text = "";
                progress.Style = ProgressBarStyle.Marquee;
                progress.Value = 0;
            }));
            await CleanupManager.ClearTemp();

            Invoke(new Action(() => {
                clientData = ((MCBuildInfo)selectedBuild.SelectedItem);
                status.Text = "Подготовка к запуску...";
                percentage.Text = "";
                progress.Style = ProgressBarStyle.Marquee;
                progress.Value = 0;
            }));

            if (clientData != null)
            {
                MCBuildInfo selBuild = null;
                Invoke(new Action(() => {
                    status.Text = "Проверка данных установленного клиента...";
                    selBuild = (MCBuildInfo)selectedBuild.SelectedItem;
                    SettingsManager.LastBuildId = selBuild.Id; SettingsManager.Username = username.Text; 
                    Logger.Instance.Log(LogEntryType.Info, "Selected client: " + selBuild.Id);
                    Logger.Instance.Log(LogEntryType.Info, "Username: " + SettingsManager.Username);

                }));

                if (selBuild != null)
                {
                    string clientMetaPath = Path.Combine(StaticData.ClientsRootPath, selBuild.Id + ".json");

                    MCClientInfo cClientInfo = new MCClientInfo();
                    cClientInfo.IsInstalled = true;
                    List<string> installedPatches = new List<string>();

                    foreach (var patch in selBuild.Patches)
                    {
                        installedPatches.Add(patch.Id);
                    }
                    cClientInfo.InstalledPatches = installedPatches.ToArray();

                    string clientInfoJson = JsonConvert.SerializeObject(cClientInfo);
                    File.WriteAllText(clientMetaPath, clientInfoJson);

                    if (File.Exists(clientMetaPath))
                    {
                        Logger.Instance.Log(LogEntryType.Info, "Reading installed client metadata...");

                        string metadata = File.ReadAllText(clientMetaPath);
                        MCClientInfo clientInfo = JsonConvert.DeserializeObject<MCClientInfo>(metadata);
                        if (clientInfo.IsInstalled)
                        {
                            Logger.Instance.Log(LogEntryType.Info, "Client installed! Proceeding launch...");

                            launcher.MinecraftExited += minecraftExited;

                            Invoke(new Action(() => {
                                status.Text = "Проверка обновлений клиента...";
                            }));
                            if (launcher.CheckInstalledPatches(selBuild.Patches, clientInfo.InstalledPatches))
                            {
                                Logger.Instance.Log(LogEntryType.Info, "Launching client...");

                                Invoke(new Action(() => {
                                    status.Text = "Клиент запущен! Если окно не появилось, подождите немного";
                                }));
                                launcher.Launch(selBuild.Id, selBuild.Arguments, "craftersmine", SettingsManager.MaxAllocatedMemory, selBuild.AssetIndex);
                                return;
                            }
                        }
                        else throw new LauncherException("Minecraft client wasn't installed properly!", LauncherExceptionErrorCode.ClientInstallationCorrupted);
                    }
                }
            }
            else throw new LauncherException("Unable to launch client!", LauncherExceptionErrorCode.ClientLaunchFailed);
        }

        private void installingArchive(object sender, InstallingArchiveEventArgs e)
        {
            Logger.Instance.Log(LogEntryType.Info, "Installing archive " + e.InstallingArchiveIndex + "/" + e.TotalArchivesCount + "...");
            Invoke(new Action(() =>
            {
                status.Text = "Выполняется установка архива " + e.InstallingArchiveIndex + "/" + e.TotalArchivesCount + "...";
            }));
        }

        private void clientDownloadCancelled(object sender, EventArgs e)
        {
            Invoke(new Action(() => {
                percentage.Text = "";
                status.Text = "Выполняется отмена установки клиента...";
                progress.Value = 0;
                progress.Style = ProgressBarStyle.Marquee;
            }));
            //await CleanupManager.ClearTemp();
            if (clientInstaller != null)
                clientInstaller.IsInstallAllowed = false;
            EnableControls();
        }

        private void clientArchiveDownloadProgress(object sender, ClientArchiveDownloadProgressEventArgs e)
        {
            Invoke(new Action(() =>
            {
                status.Text = "Загружаются архивы клиента " + clientDownloader.Downloaded + "/" + clientDownloader.TotalQueueSize + "...";
                percentage.Text = String.Format("{0:F2} %", e.Percentage);
                progress.Value = (int)Math.Truncate(e.Percentage);
            }));
        }

        private void clientArchiveDownloaded(object sender, ClientArchiveDownloadedEventArgs e)
        {
            Logger.Instance.Log(LogEntryType.Done, "Client archive \"" + e.FileName + "\" downloaded!");
            Invoke(new Action(() =>
            {
                percentage.Text = String.Format("{0:F2} %", 0f);
                progress.Value = 0;
            }));
            filesToUnpack.Add(e.FileName);

            Logger.Instance.Log(LogEntryType.Info, "Starting downloading next archive...");
            clientDownloader.DownloadNext();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                status.Text = "Обновляются данные лаунчера...";
                var launcherMetadata = await downloader.DownloadLauncherData();

                Logger.Instance.Log(LogEntryType.Info, "Checking JRE installation...");
                status.Text = "Проверка уствновки Java Runtime Environment...";
                if (!SettingsManager.IsJreInstalled)
                {
                    state = CurrentLauncherState.DownloadingJre;
                    cancel.Enabled = true;
                    status.Text = "Загрузка Java Runtime Environment...";
                    progress.Style = ProgressBarStyle.Continuous;
                    await jreInstaller.DownloadJre(launcherMetadata.JRE);
                }
                else
                {
                    status.Text = "Обновляется список доступных сборок...";

                    var data = await downloader.DownloadBuildlist();
                    username.Text = SettingsManager.Username;

                    if (data != null)
                    {
                        EnableControls();
                        selectedBuild.Items.AddRange(data);
                        selectedBuild.SelectedIndex = 0;
                        if (!SettingsManager.LastBuildId.IsNullEmptyOrWhitespace())
                        {
                            MCBuildInfo lastSelected = null;
                            foreach (var build in data)
                            {
                                if (build.Id == SettingsManager.LastBuildId)
                                {
                                    lastSelected = build;
                                    break;
                                }
                                else continue;
                            }
                            if (lastSelected != null)
                                selectedBuild.SelectedItem = lastSelected;
                        }
                    }
                }
            }
            catch (LauncherException ex)
            {
                Logger.Instance.Log(LogEntryType.Error, "A launcher error has occured! Here some cookies.");
                Logger.Instance.Log(LogEntryType.Error, "Error code: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix());
                Logger.Instance.LogException(LogEntryType.Error, ex);
                Logger.Instance.Log(LogEntryType.Error, "Additional exception:");
                Logger.Instance.LogException(LogEntryType.Error, ex.InnerException);
                Logger.Instance.LogException(LogEntryType.Error, ex);
                switch (ex.ErrorCode)
                {
                    case LauncherExceptionErrorCode.UnableToDownloadBuildList:
                        MessageBox.Show("Не удалось загрузить список доступных сборок! Проверьте соединение с сетью и повторите попытку. Продолжение невозможно! Больше информации можно найти в журнале лаунчера. \r\n\r\nКод ошибки: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix(), "Ошибка получения информации о сборках!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        break;
                    case LauncherExceptionErrorCode.UnableToDownloadLauncherData:
                        MessageBox.Show("Не удалось получить информацию о лаунчере! Проверьте соединение с сетью и повторите попытку. Продолжение невозможно! Больше информации можно найти в журнале лаунчера. \r\n\r\nКод ошибки: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix(), "Ошибка получения информации о лаунчере!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (!SettingsManager.IsJreInstalled)
                            Application.Exit();
                        break;
                }
            }
        }

        private async void launch_Click(object sender, EventArgs e)
        {
            DisableControls();
            try
            {
                Logger.Instance.Log(LogEntryType.Info, "Checking installed client...");
                status.Text = "Проверка данных установленного клиента...";
                var selBuild = (MCBuildInfo)selectedBuild.SelectedItem;
                SettingsManager.LastBuildId = selBuild.Id; SettingsManager.Username = username.Text;
                Logger.Instance.Log(LogEntryType.Info, "Selected client: " + selBuild.Id);
                Logger.Instance.Log(LogEntryType.Info, "Username: " + SettingsManager.Username);

                string clientMetaPath = Path.Combine(StaticData.ClientsRootPath, selBuild.Id + ".json");
                if (File.Exists(clientMetaPath))
                {
                    Logger.Instance.Log(LogEntryType.Info, "Reading installed client metadata...");
                    string metadata = File.ReadAllText(clientMetaPath);
                    MCClientInfo clientInfo = JsonConvert.DeserializeObject<MCClientInfo>(metadata);
                    if (clientInfo.IsInstalled)
                    {
                        Logger.Instance.Log(LogEntryType.Info, "Client installed! Proceeding launch...");
                        launcher.MinecraftExited += minecraftExited;

                        status.Text = "Проверка обновлений клиента...";
                        Logger.Instance.Log(LogEntryType.Info, "Checking client updates...");
                        if (launcher.CheckInstalledPatches(selBuild.Patches, clientInfo.InstalledPatches))
                        {
                            status.Text = "Клиент запущен! Если окно не появилось, подождите немного";
                            Logger.Instance.Log(LogEntryType.Info, "Launching client...");
                            cancel.Enabled = true;
                            state = CurrentLauncherState.LaunchedClient;
                            launcher.Launch(selBuild.Id, selBuild.Arguments, SettingsManager.Username, SettingsManager.MaxAllocatedMemory, selBuild.AssetIndex);
                            return;
                        }
                    }
                    else throw new LauncherException("Minecraft client wasn't installed properly!", LauncherExceptionErrorCode.ClientInstallationCorrupted);
                }

                status.Text = "Обновляется список доступных версий Minecraft...";

                var data = await downloader.DownloadClientList();

                status.Text = "Подготовка к скачиванию клиента...";

                string coreDownloadLink = null, assetsDownloadLink = null;

                foreach (var mcVer in data)
                {
                    if (mcVer.Version == selBuild.MCVersion)
                    {
                        coreDownloadLink = mcVer.Core;
                        assetsDownloadLink = mcVer.Assets;
                        break;
                    }
                    else continue;
                }

                if (!coreDownloadLink.IsNullEmptyOrWhitespace() && !assetsDownloadLink.IsNullEmptyOrWhitespace())
                {
                    Logger.Instance.Log(LogEntryType.Info, "Adding needed files to download queue...");
                    clientDownloader.AddToQueue(coreDownloadLink, Path.Combine(StaticData.TempPath, "core.zip"));
                    clientDownloader.AddToQueue(assetsDownloadLink, Path.Combine(StaticData.TempPath, "assets.zip"));

                    clientDownloader.AddToQueue(selBuild.Core, Path.Combine(StaticData.TempPath, "build_core.zip"));
                    for (int i = 0; i < selBuild.Patches.Length; i++)
                    {
                        clientDownloader.AddToQueue(selBuild.Patches[i].DownloadUrl, Path.Combine(StaticData.TempPath, "build_patch_" + selBuild.Patches[i].Id + ".zip"));
                    }

                    progress.Style = ProgressBarStyle.Continuous;

                    cancel.Enabled = true;
                    state = CurrentLauncherState.DownloadingClient;
                    clientDownloader.DownloadNext();
                }
                else throw new LauncherException("Unable to download client core!", LauncherExceptionErrorCode.UnableToDownloadClientCore);
            }
            catch (LauncherException ex)
            {
                Logger.Instance.Log(LogEntryType.Error, "A launcher error has occured! Here some cookies.");
                Logger.Instance.Log(LogEntryType.Error, "Error code: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix());
                Logger.Instance.LogException(LogEntryType.Error, ex);
                Logger.Instance.Log(LogEntryType.Error, "Additional exception:");
                Logger.Instance.LogException(LogEntryType.Error, ex.InnerException);
                Logger.Instance.LogException(LogEntryType.Error, ex);
                switch (ex.ErrorCode)
                {
                    case LauncherExceptionErrorCode.UnableToDownloadClientList:
                        MessageBox.Show("Не удалось загрузить список доступных версий клиентов! Проверьте соединение с сетью и повторите попытку. Больше информации можно найти в журнале лаунчера. \r\n\r\nКод ошибки: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix(), "Ошибка получения информации о версиях клиентов!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case LauncherExceptionErrorCode.ClientInstallationCorrupted:
                        MessageBox.Show("Не удалось запустить клиент, так как он не был установлен или поврежден! Выполните переустановку клиента выбрав в меню пункт \"Переустановить основные файлы клиента\". Больше информации можно найти в журнале лаунчера. \r\n\r\nКод ошибки: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix(), "Ошибка запуска клиента!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case LauncherExceptionErrorCode.UnableToDownloadClientCore:
                        MessageBox.Show("Не удалось загрузить ядро клиента! Версия ядра клиента не найдена на сервере! Возможно она удалена, обновлена или устарела! Обратитесь к администратору! \r\n\r\nКод ошибки: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix(), "Ошибка загрузки ядра клиента!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clientDownloader.Cancel();
                        break;
                    case LauncherExceptionErrorCode.ArchiveInstallFailed:
                        string id = "";
                        Invoke(new Action(() => {
                            id = ((MCBuildInfo)selectedBuild.SelectedItem).Id;
                            status.Text = "Откат установки клиента...";
                            percentage.Text = "";
                            progress.Style = ProgressBarStyle.Marquee;
                            progress.Value = 0;
                        }));
                        await CleanupManager.ClearClientDirectory(id, true);
                        MessageBox.Show("Не удалось установить клиент по неопознанной ошибке! Больше информации можно найти в журнале лаунчера. \r\n\r\nКод ошибки: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix(), "Ошибка установки клиента!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case LauncherExceptionErrorCode.JreInstallationFailed:
                        MessageBox.Show("Не удалось установить Java Runtime Environment из-за ошибки! Продолжение невозможно! Больше информации можно найти в журнале лаунчера. \r\n\r\nКод ошибки: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix(), "Ошибка загрузки JRE!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clientDownloader.Cancel();
                        break;
                }
                await CleanupManager.ClearTemp();
                EnableControls();
            }
            catch (MinecraftLaunchException ex)
            {
                Logger.Instance.Log(LogEntryType.Error, "A launcher error has occured while trying launching Minecraft client! Here some cookies.");
                Logger.Instance.Log(LogEntryType.Error, "Error code: " + ((int)ex.ErrorCode).ToHexademicalStringWithPrefix());
                Logger.Instance.LogException(LogEntryType.Error, ex);
                Logger.Instance.Log(LogEntryType.Error, "Additional exception:");
                Logger.Instance.LogException(LogEntryType.Error, ex.InnerException);
                Logger.Instance.LogException(LogEntryType.Error, ex);
                MessageBox.Show("Не удалось запустить Minecraft! Больше информации можно узнать в журнале лаунчера. \r\n\r\nКод ошибки: " + ((int)ex.ProcessExitCode).ToHexademicalStringWithPrefix(), "Ошибка запуска Minecraft!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(LogEntryType.Crash, "Unexpected launcher exception! Launcher will be halted! Here some cookies.");
                Logger.Instance.LogException(LogEntryType.Crash, ex);
                MessageBox.Show("Произошла непредвиденная ошибка лаунчера. Продолжение невозможно! Больше информации можно найти в журнале лаунчера. \r\n\r\nКод ошибки: " + ex.HResult.ToHexademicalStringWithPrefix(), "Непредвиденная ошибка лаунчера!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void minecraftExited(object sender, MinecraftExitedEventArgs e)
        {
            if (e.ExitCode != 0) MessageBox.Show("Произошла непредвиденная ошибка при выполнении процесса Minecraft! Возможно процесс клиента был завершен или возникла критическая ошибка! Попробуйте перезапустить клиент! Если вы закрыли клиент с помощью завершения процесса, эту ошибку можно проигнорировать. Больше информации можно узнать в журнале лаунчера или клиента. \r\n\r\nКод завершения: " + e.ExitCode, "Ошибка выполнения Minecraft!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            EnableControls();
        }

        public void EnableControls()
        {
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    statusPanel.Visible = false;
                    controlsPanel.Enabled = true;
                    status.Text = "";
                    progress.Style = ProgressBarStyle.Continuous;
                    cancel.Enabled = false;
                    state = CurrentLauncherState.Idle;
                }));
            else
            {
                statusPanel.Visible = false;
                controlsPanel.Enabled = true;
                status.Text = "";
                progress.Style = ProgressBarStyle.Continuous;
                cancel.Enabled = false;
                state = CurrentLauncherState.Idle;
            }
        }

        public void DisableControls()
        {
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    statusPanel.Visible = true;
                    controlsPanel.Enabled = false;
                    percentage.Text = "";
                    progress.Style = ProgressBarStyle.Marquee;
                    cancel.Enabled = false;
                    state = CurrentLauncherState.Idle;
                }));
            else
            {
                statusPanel.Visible = true;
                controlsPanel.Enabled = false;
                percentage.Text = "";
                progress.Style = ProgressBarStyle.Marquee;
                cancel.Enabled = false;
                state = CurrentLauncherState.Idle;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case CurrentLauncherState.Idle:
                    break;
                case CurrentLauncherState.DownloadingClient:
                    clientDownloader.Cancel();
                    break;
                case CurrentLauncherState.DownloadingJre:
                    jreInstaller.Cancel();
                    break;
                case CurrentLauncherState.LaunchedClient:
                    switch (MessageBox.Show("Вы действительно хотите остановить процесс Minecraft? Несохраненные данные могут быть утеряны!", "Остановка процесса Minecraft", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            launcher.Exit();
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private void settings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void reinstallWithUserDataSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите переустановить выбранный клиент? Все пользовательские данные будут сохранены. Продолжить?", "Переустановка клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DisableControls();
                progress.Style = ProgressBarStyle.Marquee;
                status.Text = "Удаление данных клиента...";

                var selBuild = (MCBuildInfo)selectedBuild.SelectedItem;
                await CleanupManager.ClearClientDirectory(selBuild.Id, true);
                EnableControls();
            }
        }

        private async void fullReinstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите переустановить выбранный клиент? Все пользовательские данные будут УДАЛЕНЫ! Продолжить?", "Переустановка клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DisableControls();
                progress.Style = ProgressBarStyle.Marquee;
                status.Text = "Удаление данных клиента...";

                var selBuild = (MCBuildInfo)selectedBuild.SelectedItem;
                await CleanupManager.ClearClientDirectory(selBuild.Id, false);
                EnableControls();
            }
        }

        private void openClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selBuild = (MCBuildInfo)selectedBuild.SelectedItem;
            string clientRootPath = Path.Combine(StaticData.ClientsRootPath, selBuild.Id);
            System.Diagnostics.Process.Start(clientRootPath);
        }

        private void sendIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/craftersmine/mcLauncher2/issues");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Minecraft Launcher by craftersmine\r\n" +
                "\r\n" +
                "Minecraft зарегистрированный торговый знак Mojang AB\r\n" +
                "все права защищены\r\n" +
                "Fugue Icons от Yusuke Kamiyamane и лицензированы под собственной лицензией\r\n" +
                "https://p.yusukekamiyamane.com/icons/license/ \r\n" +
                "\r\n" +
                "Версия лаунчера: " + LauncherSystemSettings.LauncherInternalVersion + "\r\n" +
                "Редакция лаунчера: " + LauncherSystemSettings.LauncherBuildRevision,
                "О лаунчере",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public enum CurrentLauncherState
    {
        Idle,
        DownloadingClient,
        DownloadingJre,
        LaunchedClient
    }
}
