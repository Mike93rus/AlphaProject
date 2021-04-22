namespace Alpha
{
    partial class FormEnter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEnter));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.EnterBtn = new System.Windows.Forms.Button();
            this.linkLabelConnect = new System.Windows.Forms.LinkLabel();
            this.checkRemember = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Электронная почта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(61, 76);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(273, 29);
            this.textEmail.TabIndex = 2;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(61, 142);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(273, 29);
            this.textPass.TabIndex = 3;
            this.textPass.UseSystemPasswordChar = true;
            // 
            // EnterBtn
            // 
            this.EnterBtn.Location = new System.Drawing.Point(61, 195);
            this.EnterBtn.Name = "EnterBtn";
            this.EnterBtn.Size = new System.Drawing.Size(273, 41);
            this.EnterBtn.TabIndex = 4;
            this.EnterBtn.Text = "Войти";
            this.EnterBtn.UseVisualStyleBackColor = true;
            this.EnterBtn.Click += new System.EventHandler(this.EnterBtn_Click);
            // 
            // linkLabelConnect
            // 
            this.linkLabelConnect.AutoSize = true;
            this.linkLabelConnect.Location = new System.Drawing.Point(141, 304);
            this.linkLabelConnect.Name = "linkLabelConnect";
            this.linkLabelConnect.Size = new System.Drawing.Size(243, 25);
            this.linkLabelConnect.TabIndex = 5;
            this.linkLabelConnect.TabStop = true;
            this.linkLabelConnect.Text = "Настроить подключение";
            this.linkLabelConnect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelConnect_LinkClicked);
            // 
            // checkRemember
            // 
            this.checkRemember.AutoSize = true;
            this.checkRemember.Location = new System.Drawing.Point(185, 256);
            this.checkRemember.Name = "checkRemember";
            this.checkRemember.Size = new System.Drawing.Size(199, 29);
            this.checkRemember.TabIndex = 6;
            this.checkRemember.Text = "Запомнить меня";
            this.checkRemember.UseVisualStyleBackColor = true;
            // 
            // FormEnter
            // 
            this.AcceptButton = this.EnterBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(396, 338);
            this.Controls.Add(this.checkRemember);
            this.Controls.Add(this.linkLabelConnect);
            this.Controls.Add(this.EnterBtn);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(420, 400);
            this.MinimumSize = new System.Drawing.Size(420, 400);
            this.Name = "FormEnter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEnter_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Button EnterBtn;
        private System.Windows.Forms.LinkLabel linkLabelConnect;
        private System.Windows.Forms.CheckBox checkRemember;
    }
}

