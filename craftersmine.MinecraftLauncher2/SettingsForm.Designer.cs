namespace craftersmine.MinecraftLauncher2
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.memAlloc = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enableLogging = new System.Windows.Forms.CheckBox();
            this.firstStart = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.downloadedContentStorage = new System.Windows.Forms.Label();
            this.jreInstalled = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logPath = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.memAlloc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // memAlloc
            // 
            this.memAlloc.Increment = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.memAlloc.Location = new System.Drawing.Point(128, 12);
            this.memAlloc.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.memAlloc.Minimum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.memAlloc.Name = "memAlloc";
            this.memAlloc.Size = new System.Drawing.Size(127, 22);
            this.memAlloc.TabIndex = 0;
            this.memAlloc.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выделение памяти:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "МБ";
            // 
            // enableLogging
            // 
            this.enableLogging.AutoSize = true;
            this.enableLogging.Checked = true;
            this.enableLogging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableLogging.Location = new System.Drawing.Point(9, 21);
            this.enableLogging.Name = "enableLogging";
            this.enableLogging.Size = new System.Drawing.Size(174, 17);
            this.enableLogging.TabIndex = 3;
            this.enableLogging.Text = "Включить журналирование";
            this.enableLogging.UseVisualStyleBackColor = true;
            // 
            // firstStart
            // 
            this.firstStart.AutoSize = true;
            this.firstStart.Location = new System.Drawing.Point(9, 163);
            this.firstStart.Name = "firstStart";
            this.firstStart.Size = new System.Drawing.Size(105, 17);
            this.firstStart.TabIndex = 4;
            this.firstStart.Text = "Первый запуск";
            this.firstStart.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 79);
            this.label3.TabIndex = 5;
            this.label3.Text = "Если вы хотите переустановить лаунчер, установите данный флажок.\r\n\r\nВНИМАНИЕ! Это" +
    " не удалит все данные лаунчера и установленных клиентов. Если вы хотите удалить " +
    "их, вы можете найти их здесь:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.downloadedContentStorage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.firstStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 165);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 186);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Первый запуск";
            // 
            // downloadedContentStorage
            // 
            this.downloadedContentStorage.Location = new System.Drawing.Point(6, 97);
            this.downloadedContentStorage.Name = "downloadedContentStorage";
            this.downloadedContentStorage.Size = new System.Drawing.Size(260, 63);
            this.downloadedContentStorage.TabIndex = 6;
            this.downloadedContentStorage.Text = "{downloadedContentStorage}";
            // 
            // jreInstalled
            // 
            this.jreInstalled.AutoSize = true;
            this.jreInstalled.Enabled = false;
            this.jreInstalled.Location = new System.Drawing.Point(15, 357);
            this.jreInstalled.Name = "jreInstalled";
            this.jreInstalled.Size = new System.Drawing.Size(230, 17);
            this.jreInstalled.TabIndex = 7;
            this.jreInstalled.Text = "Java Runtime Environment установлена";
            this.jreInstalled.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.logPath);
            this.groupBox2.Controls.Add(this.enableLogging);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 119);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Журналирование";
            // 
            // logPath
            // 
            this.logPath.Location = new System.Drawing.Point(12, 71);
            this.logPath.Name = "logPath";
            this.logPath.Size = new System.Drawing.Size(260, 45);
            this.logPath.TabIndex = 4;
            this.logPath.Text = "{logPath}";
            // 
            // ok
            // 
            this.ok.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.ok;
            this.ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok.Location = new System.Drawing.Point(88, 415);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(92, 23);
            this.ok.TabIndex = 10;
            this.ok.Text = "ОК";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.cancel;
            this.cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.Location = new System.Drawing.Point(186, 415);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(98, 23);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // button1
            // 
            this.button1.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.log;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(9, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Открыть журнал";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 450);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.jreInstalled);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.memAlloc);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.memAlloc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown memAlloc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox enableLogging;
        private System.Windows.Forms.CheckBox firstStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label downloadedContentStorage;
        private System.Windows.Forms.CheckBox jreInstalled;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label logPath;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
    }
}