namespace craftersmine.MinecraftLauncher2
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.launch = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.selectedBuild = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.percentage = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.status = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.launcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinstallWithUserDataSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullReinstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.openClientFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 328);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(322, 39);
            this.label6.TabIndex = 0;
            this.label6.Text = "Новостной блок временно недоступен!\r\n\r\nПроверьте соединение с Интернет или попроб" +
    "уйте позже";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // controlsPanel
            // 
            this.controlsPanel.BackColor = System.Drawing.Color.Transparent;
            this.controlsPanel.BackgroundImage = global::craftersmine.MinecraftLauncher2.Properties.Resources.panelBg;
            this.controlsPanel.Controls.Add(this.launch);
            this.controlsPanel.Controls.Add(this.settings);
            this.controlsPanel.Controls.Add(this.selectedBuild);
            this.controlsPanel.Controls.Add(this.label2);
            this.controlsPanel.Controls.Add(this.label1);
            this.controlsPanel.Controls.Add(this.username);
            this.controlsPanel.Enabled = false;
            this.controlsPanel.Location = new System.Drawing.Point(12, 361);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(344, 77);
            this.controlsPanel.TabIndex = 1;
            // 
            // launch
            // 
            this.launch.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.run;
            this.launch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.launch.Location = new System.Drawing.Point(130, 47);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(207, 23);
            this.launch.TabIndex = 5;
            this.launch.Text = "Запустить";
            this.launch.UseVisualStyleBackColor = true;
            this.launch.Click += new System.EventHandler(this.launch_Click);
            // 
            // settings
            // 
            this.settings.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.settings;
            this.settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settings.Location = new System.Drawing.Point(6, 47);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(118, 23);
            this.settings.TabIndex = 4;
            this.settings.Text = "Настройки";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // selectedBuild
            // 
            this.selectedBuild.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedBuild.FormattingEnabled = true;
            this.selectedBuild.Location = new System.Drawing.Point(160, 21);
            this.selectedBuild.Name = "selectedBuild";
            this.selectedBuild.Size = new System.Drawing.Size(177, 21);
            this.selectedBuild.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Клиент:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя игрока:";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(6, 21);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(148, 22);
            this.username.TabIndex = 0;
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.Transparent;
            this.statusPanel.BackgroundImage = global::craftersmine.MinecraftLauncher2.Properties.Resources.panelBg;
            this.statusPanel.Controls.Add(this.cancel);
            this.statusPanel.Controls.Add(this.label5);
            this.statusPanel.Controls.Add(this.percentage);
            this.statusPanel.Controls.Add(this.progress);
            this.statusPanel.Controls.Add(this.status);
            this.statusPanel.Location = new System.Drawing.Point(362, 361);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(426, 77);
            this.statusPanel.TabIndex = 2;
            // 
            // cancel
            // 
            this.cancel.Enabled = false;
            this.cancel.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.cancel_operation;
            this.cancel.Location = new System.Drawing.Point(387, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(36, 36);
            this.cancel.TabIndex = 4;
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Подождите пока идет проверка и установка клиента...";
            // 
            // percentage
            // 
            this.percentage.AutoSize = true;
            this.percentage.Location = new System.Drawing.Point(374, 52);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(35, 13);
            this.percentage.TabIndex = 2;
            this.percentage.Text = "{perc}";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(6, 52);
            this.progress.MarqueeAnimationSpeed = 50;
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(362, 13);
            this.progress.Step = 1;
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress.TabIndex = 1;
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(3, 36);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(44, 13);
            this.status.TabIndex = 0;
            this.status.Text = "{status}";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launcherToolStripMenuItem,
            this.serviceToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // launcherToolStripMenuItem
            // 
            this.launcherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.launcherToolStripMenuItem.Name = "launcherToolStripMenuItem";
            this.launcherToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.launcherToolStripMenuItem.Text = "Лаунчер";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.exitToolStripMenuItem.Text = "Выйти";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // serviceToolStripMenuItem
            // 
            this.serviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientToolStripMenuItem,
            this.toolStripMenuItem1,
            this.settingsToolStripMenuItem});
            this.serviceToolStripMenuItem.Name = "serviceToolStripMenuItem";
            this.serviceToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.serviceToolStripMenuItem.Text = "Сервис";
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reinstallWithUserDataSaveToolStripMenuItem,
            this.fullReinstallToolStripMenuItem,
            this.toolStripMenuItem3,
            this.openClientFolderToolStripMenuItem});
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.clientToolStripMenuItem.Text = "Клиент";
            // 
            // reinstallWithUserDataSaveToolStripMenuItem
            // 
            this.reinstallWithUserDataSaveToolStripMenuItem.Name = "reinstallWithUserDataSaveToolStripMenuItem";
            this.reinstallWithUserDataSaveToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.reinstallWithUserDataSaveToolStripMenuItem.Text = "Переустановить клиент с сохранением данных";
            this.reinstallWithUserDataSaveToolStripMenuItem.Click += new System.EventHandler(this.reinstallWithUserDataSaveToolStripMenuItem_Click);
            // 
            // fullReinstallToolStripMenuItem
            // 
            this.fullReinstallToolStripMenuItem.Name = "fullReinstallToolStripMenuItem";
            this.fullReinstallToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.fullReinstallToolStripMenuItem.Text = "Полная переустановка клиента";
            this.fullReinstallToolStripMenuItem.Click += new System.EventHandler(this.fullReinstallToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(331, 6);
            // 
            // openClientFolderToolStripMenuItem
            // 
            this.openClientFolderToolStripMenuItem.Name = "openClientFolderToolStripMenuItem";
            this.openClientFolderToolStripMenuItem.Size = new System.Drawing.Size(334, 22);
            this.openClientFolderToolStripMenuItem.Text = "Открыть папку клиента";
            this.openClientFolderToolStripMenuItem.Click += new System.EventHandler(this.openClientFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.settings;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.settingsToolStripMenuItem.Text = "Настройки";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settings_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendIssueToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aboutToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.помощьToolStripMenuItem.Text = "?";
            // 
            // sendIssueToolStripMenuItem
            // 
            this.sendIssueToolStripMenuItem.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.git;
            this.sendIssueToolStripMenuItem.Name = "sendIssueToolStripMenuItem";
            this.sendIssueToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.sendIssueToolStripMenuItem.Text = "Отправить отзыв";
            this.sendIssueToolStripMenuItem.Click += new System.EventHandler(this.sendIssueToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::craftersmine.MinecraftLauncher2.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Launcher by craftersmine";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.statusPanel.ResumeLayout(false);
            this.statusPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Button launch;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.ComboBox selectedBuild;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label percentage;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem launcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reinstallWithUserDataSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullReinstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem openClientFolderToolStripMenuItem;
    }
}

