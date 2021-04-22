using System;
using System.Windows.Forms;

namespace Alpha
{
    public partial class FormQueries : Form
    {
        public FormQueries()
        {
            InitializeComponent();
        }

        private void FormQueries_Load(object sender, EventArgs e)
        {
            RefreshAll();
            toolStripStatusLabel1.Text = "Вы вошли как: " + Program.EnterForm.fiodolznost + "; Ваши документы: " + Program.EnterForm.docCountSotr;
        }

        private void вернутьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void закрытьПриложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                getProjectDetailTableAdapter.Fill(alphabdDataSet.GetProjectDetail, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void RefreshAll()
        {
            getProjectAndDocsTableAdapter.Fill(alphabdDataSet.GetProjectAndDocs);
            getSotrAndDocsGroupTableAdapter.Fill(alphabdDataSet.GetSotrAndDocsGroup);
            getSotrAndDocsTableAdapter.Fill(alphabdDataSet.GetSotrAndDocs, SotrSearch.Text);
            getKlientsAndProjectGroupTableAdapter.Fill(alphabdDataSet.GetKlientsAndProjectGroup);
            getKlientsAndProjectGroupTableAdapter.Fill(alphabdDataSet.GetKlientsAndProjectGroup);
            getKlientsAndProjectsTableAdapter.Fill(alphabdDataSet.GetKlientsAndProjects, KlientSearch.Text);
            getProjectDetailTableAdapter.Fill(alphabdDataSet.GetProjectDetail, dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void SotrSearch_TextChanged(object sender, EventArgs e)
        {
            getSotrAndDocsTableAdapter.Fill(alphabdDataSet.GetSotrAndDocs, SotrSearch.Text);
        }

        private void KlientSearch_TextChanged(object sender, EventArgs e)
        {
            getKlientsAndProjectsTableAdapter.Fill(alphabdDataSet.GetKlientsAndProjects, KlientSearch.Text);
        }
    }
}
