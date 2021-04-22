using Alpha.alphabdDataSetTableAdapters;
using System;
using System.Windows.Forms;

namespace Alpha
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public CountTableAdapter countTA = new CountTableAdapter(); //Адаптер запросов

        private void Form2_Load(object sender, EventArgs e)
        {
            this.project_statusTableAdapter.Fill(this.alphabdDataSet.project_status);
            //Получение количества
            comboProjStat.SelectedIndex = 0;
            textBoxProjCount.Text = countTA.projectCount().ToString();
            textProjCountByStat.Text = countTA.projectCountByStatus(comboProjStat.Text).ToString();
            textDocsCount.Text = countTA.docsCount().ToString();
            textSotrCount.Text = countTA.sotrCount().ToString();
            textKlientCount.Text = countTA.klientCount().ToString();
            int sum = int.Parse(countTA.projectSum().ToString());
            textProjectSum.Text = string.Format("{0:C}", sum);
            Program.EnterForm.docCountSotr = countTA.GetDocCountBySotr(Program.EnterForm.userid).ToString();//Кол-во документов пользователя
            toolStripStatusLabel1.Text = "Вы вошли как: " + Program.EnterForm.fiodolznost + "; Ваши документы: " + Program.EnterForm.docCountSotr;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEnter form1 = new FormEnter();
            form1.Show();
            Hide();
        }

        private void Form2_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void таблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool find = false;
            FormCollection fc = Application.OpenForms; 
            foreach (Form form in fc) //Проверка на существования открытой формы FormTables
            {
                if (form.Name == "FormTables")
                {
                    form.Show();
                    find = true;
                }
            }
            if (find == false)
            {
                FormTables form3 = new FormTables();
                form3.Show();
            }
        }

        private void запросыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool find = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form form in fc) //Проверка на существования открытой формы FormQueries
            {
                if (form.Name == "FormQueries")
                {
                    form.Show();
                    find = true;
                }
            }
            if (find == false)
            {
                FormQueries form5 = new FormQueries();
                form5.Show();
            }
        }

        private void comboProjStat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Получение кол-ва проектов в зависимости от статуса
            textProjCountByStat.Text = countTA.projectCountByStatus(comboProjStat.Text).ToString(); 
        }
    }
}
