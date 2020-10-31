namespace craftersmine.MinecraftLauncher2
{
    partial class FirstStartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstStartForm));
            this.downloadedContentStorage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.memAlloc = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.enableLogging = new System.Windows.Forms.CheckBox();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.memAlloc)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadedContentStorage
            // 
            this.downloadedContentStorage.Location = new System.Drawing.Point(12, 54);
            this.downloadedContentStorage.Name = "downloadedContentStorage";
            this.downloadedContentStorage.Size = new System.Drawing.Size(413, 22);
            this.downloadedContentStorage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите месторасположение файлов лаунчера, таких как данные клиентов, JRE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(536, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выполняется первичная настройка лаунчера, выполните первичную настройку для продо" +
    "лжения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выделение памяти:";
            // 
            // memAlloc
            // 
            this.memAlloc.Increment = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.memAlloc.Location = new System.Drawing.Point(145, 82);
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
            this.memAlloc.Size = new System.Drawing.Size(120, 22);
            this.memAlloc.TabIndex = 5;
            this.memAlloc.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "МБ";
            // 
            // enableLogging
            // 
            this.enableLogging.AutoSize = true;
            this.enableLogging.Checked = true;
            this.enableLogging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableLogging.Location = new System.Drawing.Point(12, 110);
            this.enableLogging.Name = "enableLogging";
            this.enableLogging.Size = new System.Drawing.Size(174, 17);
            this.enableLogging.TabIndex = 7;
            this.enableLogging.Text = "Включить журналирование";
            this.enableLogging.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.ok;
            this.ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ok.Location = new System.Drawing.Point(312, 140);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(113, 23);
            this.ok.TabIndex = 9;
            this.ok.Text = "ОК";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.cancel;
            this.cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cancel.Location = new System.Drawing.Point(431, 140);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(109, 23);
            this.cancel.TabIndex = 8;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // browse
            // 
            this.browse.Image = global::craftersmine.MinecraftLauncher2.Properties.Resources.browse;
            this.browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browse.Location = new System.Drawing.Point(431, 53);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(109, 24);
            this.browse.TabIndex = 3;
            this.browse.Text = "Обзор...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // FirstStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 175);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.enableLogging);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.memAlloc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downloadedContentStorage);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FirstStartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Первый запуск";
            ((System.ComponentModel.ISupportInitialize)(this.memAlloc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox downloadedContentStorage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown memAlloc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox enableLogging;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
    }
}