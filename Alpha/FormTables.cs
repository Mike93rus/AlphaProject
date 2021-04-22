using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Alpha.alphabdDataSetTableAdapters;
using System.IO;

namespace Alpha
{
    public partial class FormTables : Form
    {
        public FormTables()
        {
            InitializeComponent();           
        }

        public string savepath; //Путь сохранения файлов

        //Дополнительные таблицы и привязка для поиска по таблицам
        public BindingSource SearchBS = null;
        public alphabdDataSet.sotrudnikDataTable SotrSearchDT = null;       
        public alphabdDataSet.klientDataTable KlientSearchDT = null;
        public alphabdDataSet.projectDataTable ProjectSearchDT = null;
        public alphabdDataSet.docsDataTable DocsSearchDT = null;

        private void Form3_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Вы вошли как: " + Program.EnterForm.fiodolznost + "; Ваши документы: " + Program.EnterForm.docCountSotr;
            Refill_All();
            DT.Visible = false;
            toolStripFilePath.Text = "C:\\";
            //ID таблиц
            ProjectID.Visible = false;
            DocID.Visible = false;
            SotrudnikID.Visible = false;
            KlientID.Visible = false;
            ProjectStatID.Visible = false;
            DocStateID.Visible = false;
            DocTypeID.Visible = false;
            DolznostID.Visible = false;

            //Настройка отображения в зависимости от полномочий
            switch (Program.EnterForm.accesslvl)
            {
                case 2:
                    DocSotrCombo.ReadOnly = true;
                    DopTablesTapControl.TabPages.Remove(Tabprojectstat);
                    DopTablesTapControl.TabPages.Remove(Tabdolznost);
                    MainTablesTabControl.TabPages.Remove(Tabklient);
                    sotrudnikDataGridView.ReadOnly = true;
                    SotrPass.Visible = false;
                    break;
                case 3:
                    DocSotrCombo.ReadOnly = true;
                    DopTablesTapControl.TabPages.Remove(Tabprojectstat);
                    DopTablesTapControl.TabPages.Remove(Tabdolznost);
                    MainTablesTabControl.TabPages.Remove(Tabsotrudnik);
                    MainTablesTabControl.TabPages.Remove(Tabklient);
                    doc_stateDataGridView.ReadOnly = true;
                    doc_typeDataGridView.ReadOnly = true;
                    projectDataGridView.ReadOnly = true;
                    break;
                case 4:
                    DopTablesTapControl.TabPages.Remove(Tabdocstate);
                    DopTablesTapControl.TabPages.Remove(Tabdoctype);
                    Access.Visible = false;
                    dolznostDataGridView.ReadOnly = true;
                    docsDataGridView.ReadOnly = true;
                    docsDataGridView.CellContentClick -= docsDataGridView_CellContentClick;
                    docsDataGridView.CellClick -= docsDataGridView_CellClick;
                    break;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Сохранение таблиц по отдельности
        private void SaveTable(object sender, EventArgs e)
        {
            ToolStripButton Btn = (ToolStripButton)sender;
            string btn_name = Btn.Name;          
            try
            {
                Validate();
                alphabdDataSet.EnforceConstraints = false;
                switch (btn_name)
                {
                    case "SaveProject":
                        if (ProjectSearchDT != null)
                        {
                            alphabdDataSet.project.Merge(ProjectSearchDT);
                        }
                        projectBindingSource.EndEdit();
                        klientBindingSource.EndEdit();
                        project_statusBindingSource.EndEdit();
                        projectTableAdapter.Update(alphabdDataSet.project);
                        alphabdDataSet.project.AcceptChanges();
                        projectTableAdapter.Fill(alphabdDataSet.project);
                        break;
                    case "SaveDocs":
                        if (DocsSearchDT != null)
                        {
                            alphabdDataSet.docs.Merge(DocsSearchDT);
                        }
                        docsBindingSource.EndEdit();
                        sotrudnikBindingSource.EndEdit();
                        projectBindingSource.EndEdit();
                        doc_typeBindingSource.EndEdit();
                        doc_stateBindingSource.EndEdit();
                        docsTableAdapter.Update(alphabdDataSet.docs);
                        alphabdDataSet.docs.AcceptChanges();
                        docsTableAdapter.Fill(alphabdDataSet.docs);
                        break;
                    case "SaveSotr":
                        if (SotrSearchDT != null)
                        {
                            alphabdDataSet.sotrudnik.Merge(SotrSearchDT);
                        }
                        dolznostBindingSource.EndEdit();
                        sotrudnikBindingSource.EndEdit();
                        sotrudnikTableAdapter.Update(alphabdDataSet.sotrudnik);
                        alphabdDataSet.sotrudnik.AcceptChanges();
                        sotrudnikTableAdapter.Fill(alphabdDataSet.sotrudnik);
                        break;
                    case "SaveKlient":
                        if (KlientSearchDT != null)
                        {
                            alphabdDataSet.klient.Merge(KlientSearchDT);
                        }
                        klientBindingSource.EndEdit();
                        klientTableAdapter.Update(alphabdDataSet.klient);
                        alphabdDataSet.klient.AcceptChanges();
                        klientTableAdapter.Fill(alphabdDataSet.klient);
                        break;
                    case "SaveProjStat":
                        project_statusBindingSource.EndEdit();
                        project_statusTableAdapter.Update(alphabdDataSet.project_status);
                        alphabdDataSet.project_status.AcceptChanges();
                        project_statusTableAdapter.Fill(alphabdDataSet.project_status);
                        break;
                    case "SaveDocState":
                        doc_stateBindingSource.EndEdit();
                        doc_stateTableAdapter.Update(alphabdDataSet.doc_state);
                        alphabdDataSet.doc_state.AcceptChanges();
                        doc_stateTableAdapter.Fill(alphabdDataSet.doc_state);
                        break;
                    case "SaveDocType":
                        doc_typeBindingSource.EndEdit();
                        doc_typeTableAdapter.Update(alphabdDataSet.doc_type);
                        alphabdDataSet.doc_type.AcceptChanges();
                        doc_typeTableAdapter.Fill(alphabdDataSet.doc_type);
                        break;
                    case "SaveDolzn":                        
                        dolznostBindingSource.EndEdit();
                        dolznostTableAdapter.Update(alphabdDataSet.dolznost);
                        alphabdDataSet.dolznost.AcceptChanges();
                        dolznostTableAdapter.Fill(alphabdDataSet.dolznost);
                        break;
                }
                alphabdDataSet.EnforceConstraints = true;
            }
            catch (DBConcurrencyException dbcx)
            {
                alphabdDataSet.EnforceConstraints = true;
                MessageBox.Show(dbcx.Message + " Обновите страницу.", "Нарушение параллелизма");
            }
            catch (Exception ex)
            {
                alphabdDataSet.EnforceConstraints = true;
                MessageBox.Show(ex.Message, "Ошибка сохранения");
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Поиск в таблицах
        private void DocSearch_TextChanged(object sender, EventArgs e)
        {
            DocsSearchDT = new alphabdDataSet.docsDataTable();
            SearchBS = new BindingSource();
            docsDataGridView.DataSource = SearchBS;
            docsTableAdapter.FillDocByName(DocsSearchDT, DocsSearchText.Text);
            SearchBS.DataSource = DocsSearchDT;
            if (string.IsNullOrEmpty(DocsSearchText.Text))
            {
                docsDataGridView.DataSource = docsBindingSource;
                alphabdDataSet.EnforceConstraints = false;
                docsTableAdapter.Fill(alphabdDataSet.docs);
                alphabdDataSet.EnforceConstraints = true;
                DocsSearchDT = null;
            }
        }

        private void ProjectSearch_TextChanged(object sender, EventArgs e)
        {
            ProjectSearchDT = new alphabdDataSet.projectDataTable();
            SearchBS = new BindingSource();
            projectDataGridView.DataSource = SearchBS;
            projectTableAdapter.FillProjectByName(ProjectSearchDT, ProjectSearchText.Text);
            SearchBS.DataSource = ProjectSearchDT;
            if (string.IsNullOrEmpty(ProjectSearchText.Text))
            {
                projectDataGridView.DataSource = projectBindingSource;
                alphabdDataSet.EnforceConstraints = false;
                projectTableAdapter.Fill(alphabdDataSet.project);
                alphabdDataSet.EnforceConstraints = true;
                ProjectSearchDT = null;
            }
        }

        private void SotrSearch_TextChanged(object sender, EventArgs e)
        {
            SotrSearchDT = new alphabdDataSet.sotrudnikDataTable();
            SearchBS = new BindingSource();
            sotrudnikDataGridView.DataSource = SearchBS;
            sotrudnikTableAdapter.FillSotrByFIO(SotrSearchDT, SotrSearchText.Text);
            SearchBS.DataSource = SotrSearchDT;
            if (string.IsNullOrEmpty(SotrSearchText.Text))
            {
                sotrudnikDataGridView.DataSource = sotrudnikBindingSource;
                alphabdDataSet.EnforceConstraints = false;
                sotrudnikTableAdapter.Fill(alphabdDataSet.sotrudnik);
                alphabdDataSet.EnforceConstraints = true;
                SotrSearchDT = null;
            }
        }

        private void KlientSearch_TextChanged(object sender, EventArgs e)
        {
            KlientSearchDT = new alphabdDataSet.klientDataTable();
            SearchBS = new BindingSource();
            klientDataGridView.DataSource = SearchBS;
            klientTableAdapter.FillKlientByFIOOrg(KlientSearchDT, KlientSearchText.Text);
            SearchBS.DataSource = KlientSearchDT;
            if (string.IsNullOrEmpty(KlientSearchText.Text))
            {
                klientDataGridView.DataSource = klientBindingSource;
                alphabdDataSet.EnforceConstraints = false;
                klientTableAdapter.Fill(alphabdDataSet.klient);
                alphabdDataSet.EnforceConstraints = true;
                KlientSearchDT = null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Обновление талиц по отдельности
        private void RefreshTable(object sender, EventArgs e)
        {
            ToolStripButton Btn = (ToolStripButton)sender;
            string btn_name = Btn.Name;
            try
            {
                alphabdDataSet.EnforceConstraints = false;
                switch (btn_name)
                {
                    case "RefreshProject":
                        projectDataGridView.DataSource = projectBindingSource;
                        projectTableAdapter.Fill(alphabdDataSet.project);
                        break;
                    case "RefreshDocs":
                        docsDataGridView.DataSource = docsBindingSource;
                        docsTableAdapter.Fill(alphabdDataSet.docs);
                        break;
                    case "RefreshSotr":
                        sotrudnikDataGridView.DataSource = sotrudnikBindingSource;
                        sotrudnikTableAdapter.Fill(alphabdDataSet.sotrudnik);
                        break;
                    case "RefreshKlient":
                        klientDataGridView.DataSource = klientBindingSource;
                        klientTableAdapter.Fill(alphabdDataSet.klient);
                        break;
                    case "RefreshProjStat":
                        project_statusTableAdapter.Fill(alphabdDataSet.project_status);                     
                        break;
                    case "RefreshDocState":
                        doc_stateTableAdapter.Fill(alphabdDataSet.doc_state);
                        break;
                    case "RefreshDocType":
                        doc_typeTableAdapter.Fill(alphabdDataSet.doc_type);
                        break;
                    case "RefreshDolzn":
                        dolznostTableAdapter.Fill(alphabdDataSet.dolznost);
                        break;
                }
                alphabdDataSet.EnforceConstraints = true;
            }
            catch (Exception ex)
            {
                alphabdDataSet.EnforceConstraints = true;
                MessageBox.Show(ex.Message, "Ошибка обновления");
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Сохранение изменений всех таблиц
        private void сохранитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProjectSearchDT != null)
                {
                    alphabdDataSet.project.Merge(ProjectSearchDT);
                }
                if (DocsSearchDT != null)
                {
                    alphabdDataSet.docs.Merge(DocsSearchDT);
                }
                if (SotrSearchDT != null)
                {
                    alphabdDataSet.sotrudnik.Merge(SotrSearchDT);
                }
                if (KlientSearchDT != null)
                {
                    alphabdDataSet.klient.Merge(KlientSearchDT);
                }
                Validate();
                tableAdapterManager.UpdateAll(alphabdDataSet);
                alphabdDataSet.AcceptChanges();
                Refill_All();
            }
            catch (DBConcurrencyException dbcx)
            {
                MessageBox.Show(dbcx.Message + "Обновите страницу.", "Нарушение параллелизма");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения");
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refill_All();
        }

        //Обновление содержания
        private void Refill_All()
        {
            projectDataGridView.DataSource = projectBindingSource;
            docsDataGridView.DataSource = docsBindingSource;
            sotrudnikDataGridView.DataSource = sotrudnikBindingSource;
            klientDataGridView.DataSource = klientBindingSource;
            alphabdDataSet.EnforceConstraints = false;
            this.dolznostTableAdapter.Fill(this.alphabdDataSet.dolznost);
            this.doc_typeTableAdapter.Fill(this.alphabdDataSet.doc_type);
            this.doc_stateTableAdapter.Fill(this.alphabdDataSet.doc_state);
            this.project_statusTableAdapter.Fill(this.alphabdDataSet.project_status);
            this.klientTableAdapter.Fill(this.alphabdDataSet.klient);
            this.sotrudnikTableAdapter.Fill(this.alphabdDataSet.sotrudnik);
            this.docsTableAdapter.Fill(this.alphabdDataSet.docs);
            this.projectTableAdapter.Fill(this.alphabdDataSet.project);
            alphabdDataSet.EnforceConstraints = true;
        }

        private void закрытьПриложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {           
            e.Cancel = !ValidateChildren();
        }

        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Выбор даты проекта
        private void projectDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                DataGridView dgw = (DataGridView)sender;
                DT = new DateTimePicker();
                DT.CustomFormat = "yyyy-mm-dd";
                if (dgw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                {
                    DT.Value = (DateTime)dgw.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
                DT.CausesValidation = false;
                projectDataGridView.CausesValidation = false;
                projectDataGridView.Controls.Add(DT);  
                DT.Format = DateTimePickerFormat.Short;  
                Rectangle oRectangle = projectDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                DT.Size = new Size(oRectangle.Width, oRectangle.Height); 
                DT.Location = new Point(oRectangle.X, oRectangle.Y);
                DT.CloseUp += new EventHandler(DT_CloseUp);
                DT.TextChanged += new EventHandler(DT_ValueChanged);
                DT.Visible = true;
            }
        }

        private void DT_ValueChanged(object sender, EventArgs e)
        {
            projectDataGridView.CurrentCell.Value = DT.Value.Date;          
        }

        void DT_CloseUp(object sender, EventArgs e)
        {  
            DT.Visible = false;
            projectDataGridView.CausesValidation = true;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Обработка ошибки DataGridViewComboBoxCell value is not valid
        void DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "Недопустимое значение DataGridViewComboBoxCell.")
            {
               e.ThrowException = false;
            }
            else
            {
                MessageBox.Show(e.Exception.Message, "Ошибка данных");
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Работа с файлами
        private void docsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgw = (DataGridView)sender;
            ////Загрузка файла
            if (dgw.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 6 && e.RowIndex >= 0)
            {
                docsDataGridView.CausesValidation = false;
                try
                {
                    byte[] rawData;
                    var filePath = string.Empty;
                    var fileName = string.Empty;
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Title = "Выберете файл";
                        openFileDialog.Multiselect = false;
                        openFileDialog.Filter = "Документация|*.doc;*.xls;*.xlsx;*.xml;*.pdf";
                        openFileDialog.RestoreDirectory = true;
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            filePath = openFileDialog.FileName;
                            fileName = Path.GetFileName(filePath);
                            FileStream fileStream = File.OpenRead(filePath);
                            int fileSize = (int)fileStream.Length;
                            rawData = new byte[fileSize];
                            fileStream.Read(rawData, 0, fileSize);
                            fileStream.Close();
                            dgw.Rows[e.RowIndex].Cells["DocFileName"].Value = fileName;
                            dgw.Rows[e.RowIndex].Cells["DocFileByteArray"].Value = rawData;
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка загрузки");
                }
                docsDataGridView.CausesValidation = true;
            }
            ////Сохранение файла
            else if (dgw.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                docsDataGridView.CausesValidation = false;
                if (dgw.Rows[e.RowIndex].Cells["DocFileByteArray"].Value != DBNull.Value)
                {
                    try
                    {
                        byte[] rawData = (byte[])dgw.Rows[e.RowIndex].Cells["DocFileByteArray"].Value;
                        string fileName = (string)dgw.Rows[e.RowIndex].Cells["DocFileName"].Value;
                        savepath = toolStripFilePath.Text;
                        if (checkBoxDir.Checked) //Создание подпапок
                        {
                            string projectName = (string)projectTableAdapter.GetProjectNameByID((int)dgw.Rows[e.RowIndex].Cells[2].Value);
                            string docState = doc_stateTableAdapter.GetDocStateByID((short)dgw.Rows[e.RowIndex].Cells[3].Value);
                            string docType = doc_typeTableAdapter.GetDocTypeByID((short)dgw.Rows[e.RowIndex].Cells[4].Value);
                            savepath += "\\" + projectName + "\\" + docState + "\\" + docType;
                        }                        
                        Directory.CreateDirectory(savepath);
                        FileStream fileStream = new FileStream(savepath + "\\" + fileName, FileMode.OpenOrCreate, FileAccess.Write);
                        fileStream.Write(rawData, 0, rawData.Length);
                        fileStream.Close();
                    }
                    catch (UnauthorizedAccessException accessex)
                    {
                        MessageBox.Show(accessex.Message, "Ошибка сохранения");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка сохранения");
                    }
                }
                else
                {
                    MessageBox.Show("Отсутствует загруженный файл.", "Ошибка сохранения");
                }
                docsDataGridView.CausesValidation = true;
            }
        }
        //Выбор пути сохранения файла
        private void toolStripFilePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = toolStripFilePath.Text;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    savepath = fbd.SelectedPath;
                    toolStripFilePath.Text = savepath;
                }
            }
        }
        //Открытие директории сохранения в проводнике
        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            string selectedPath = toolStripFilePath.Text;
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = selectedPath,
                UseShellExecute = true,
                Verb = "open"
            });
        }
        //Подстановка пользователя
        private void docsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgw = (DataGridView)sender;
            if (dgw.Rows[e.RowIndex].Cells["DocSotrCombo"].Value == DBNull.Value && e.RowIndex >= 0)
            {
                dgw.Rows[e.RowIndex].Cells["DocSotrCombo"].Value = Program.EnterForm.userid;
            }
        }
    }
}