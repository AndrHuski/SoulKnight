namespace SoulKnight
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.button_start = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.checkSound = new System.Windows.Forms.CheckBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.Transparent;
            this.button_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.ForeColor = System.Drawing.Color.Aqua;
            this.button_start.Location = new System.Drawing.Point(350, 250);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(87, 79);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "СТАРТ";
            this.button_start.UseCompatibleTextRendering = true;
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.ButtonStartClick);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.Transparent;
            this.button_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.ForeColor = System.Drawing.Color.Aqua;
            this.button_exit.Location = new System.Drawing.Point(710, 540);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(78, 48);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "Выход";
            this.button_exit.UseCompatibleTextRendering = true;
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.ButtonExitClick);
            // 
            // check_sound
            // 
            this.checkSound.AutoSize = true;
            this.checkSound.BackColor = System.Drawing.Color.Transparent;
            this.checkSound.Checked = true;
            this.checkSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSound.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkSound.ForeColor = System.Drawing.Color.Aqua;
            this.checkSound.Location = new System.Drawing.Point(12, 540);
            this.checkSound.Name = "check_sound";
            this.checkSound.Size = new System.Drawing.Size(89, 24);
            this.checkSound.TabIndex = 2;
            this.checkSound.Text = "Звук ВКЛ";
            this.checkSound.UseVisualStyleBackColor = false;
            this.checkSound.CheckedChanged += new System.EventHandler(this.SoundCheckChanged);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(9, 8);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 4;
            this.axWindowsMediaPlayer1.Visible = false;
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.AxWindowsMediaPlayer1Enter1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(615, 10);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 5;
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Click += new System.EventHandler(this.Label1Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.Aqua;
            this.button2.Location = new System.Drawing.Point(513, 540);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 48);
            this.button2.TabIndex = 7;
            this.button2.Text = "Управление";
            this.button2.UseCompatibleTextRendering = true;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // FormMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.checkSound);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_start);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoulKnight";
            this.Load += new System.EventHandler(this.MenuLoad);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_start;
        public System.Windows.Forms.CheckBox checkSound;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}

