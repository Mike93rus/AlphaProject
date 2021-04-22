namespace Alpha
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProjCount = new System.Windows.Forms.TextBox();
            this.textProjCountByStat = new System.Windows.Forms.TextBox();
            this.comboProjStat = new System.Windows.Forms.ComboBox();
            this.projectstatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alphabdDataSet = new Alpha.alphabdDataSet();
            this.project_statusTableAdapter = new Alpha.alphabdDataSetTableAdapters.project_statusTableAdapter();
            this.process1 = new System.Diagnostics.Process();
            this.textDocsCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textSotrCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textKlientCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textProjectSum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectstatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphabdDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицыToolStripMenuItem,
            this.запросыToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(976, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(116, 34);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            this.таблицыToolStripMenuItem.ToolTipText = "Открыть окно просмотра и редактирования таблиц";
            this.таблицыToolStripMenuItem.Click += new System.EventHandler(this.таблицыToolStripMenuItem_Click);
            // 
            // запросыToolStripMenuItem
            // 
            this.запросыToolStripMenuItem.Name = "запросыToolStripMenuItem";
            this.запросыToolStripMenuItem.Size = new System.Drawing.Size(114, 34);
            this.запросыToolStripMenuItem.Text = "Запросы";
            this.запросыToolStripMenuItem.Click += new System.EventHandler(this.запросыToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(111, 34);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.ToolTipText = resources.GetString("справкаToolStripMenuItem.ToolTipText");
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(91, 34);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.ToolTipText = "Выход в окно авторизации";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 399);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(976, 39);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(208, 30);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Проектов:";
            // 
            // textBoxProjCount
            // 
            this.textBoxProjCount.Location = new System.Drawing.Point(198, 120);
            this.textBoxProjCount.Name = "textBoxProjCount";
            this.textBoxProjCount.ReadOnly = true;
            this.textBoxProjCount.Size = new System.Drawing.Size(100, 29);
            this.textBoxProjCount.TabIndex = 3;
            // 
            // textProjCountByStat
            // 
            this.textProjCountByStat.Location = new System.Drawing.Point(580, 120);
            this.textProjCountByStat.Name = "textProjCountByStat";
            this.textProjCountByStat.ReadOnly = true;
            this.textProjCountByStat.Size = new System.Drawing.Size(100, 29);
            this.textProjCountByStat.TabIndex = 7;
            // 
            // comboProjStat
            // 
            this.comboProjStat.CausesValidation = false;
            this.comboProjStat.DataSource = this.projectstatusBindingSource;
            this.comboProjStat.DisplayMember = "status";
            this.comboProjStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProjStat.FormattingEnabled = true;
            this.comboProjStat.Location = new System.Drawing.Point(324, 117);
            this.comboProjStat.Name = "comboProjStat";
            this.comboProjStat.Size = new System.Drawing.Size(250, 32);
            this.comboProjStat.TabIndex = 8;
            this.comboProjStat.ValueMember = "id";
            this.comboProjStat.SelectedIndexChanged += new System.EventHandler(this.comboProjStat_SelectedIndexChanged);
            // 
            // projectstatusBindingSource
            // 
            this.projectstatusBindingSource.DataMember = "project_status";
            this.projectstatusBindingSource.DataSource = this.alphabdDataSet;
            // 
            // alphabdDataSet
            // 
            this.alphabdDataSet.DataSetName = "alphabdDataSet";
            this.alphabdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // project_statusTableAdapter
            // 
            this.project_statusTableAdapter.ClearBeforeFill = true;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // textDocsCount
            // 
            this.textDocsCount.Location = new System.Drawing.Point(200, 177);
            this.textDocsCount.Name = "textDocsCount";
            this.textDocsCount.ReadOnly = true;
            this.textDocsCount.Size = new System.Drawing.Size(100, 29);
            this.textDocsCount.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Документов:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Количество записей в базе:";
            // 
            // textSotrCount
            // 
            this.textSotrCount.Location = new System.Drawing.Point(200, 239);
            this.textSotrCount.Name = "textSotrCount";
            this.textSotrCount.ReadOnly = true;
            this.textSotrCount.Size = new System.Drawing.Size(100, 29);
            this.textSotrCount.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Сотрудников:";
            // 
            // textKlientCount
            // 
            this.textKlientCount.Location = new System.Drawing.Point(198, 298);
            this.textKlientCount.Name = "textKlientCount";
            this.textKlientCount.ReadOnly = true;
            this.textKlientCount.Size = new System.Drawing.Size(100, 29);
            this.textKlientCount.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Клиентов:";
            // 
            // textProjectSum
            // 
            this.textProjectSum.Location = new System.Drawing.Point(526, 177);
            this.textProjectSum.Name = "textProjectSum";
            this.textProjectSum.ReadOnly = true;
            this.textProjectSum.Size = new System.Drawing.Size(154, 29);
            this.textProjectSum.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Проектов на сумму:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(976, 438);
            this.Controls.Add(this.textProjectSum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textKlientCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textSotrCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textDocsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboProjStat);
            this.Controls.Add(this.textProjCountByStat);
            this.Controls.Add(this.textBoxProjCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectstatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphabdDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem запросыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProjCount;
        private System.Windows.Forms.TextBox textProjCountByStat;
        private System.Windows.Forms.ComboBox comboProjStat;
        private alphabdDataSet alphabdDataSet;
        private System.Windows.Forms.BindingSource projectstatusBindingSource;
        private alphabdDataSetTableAdapters.project_statusTableAdapter project_statusTableAdapter;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.TextBox textDocsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textKlientCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textSotrCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textProjectSum;
        private System.Windows.Forms.Label label6;
    }
}