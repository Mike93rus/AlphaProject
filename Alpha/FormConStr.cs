using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Configuration;

namespace Alpha
{
    public partial class FormConStr : Form
    {
        public MySqlConnectionStringBuilder ConBuild = new MySqlConnectionStringBuilder();
        public FormConStr()
        {
            InitializeComponent();
            ConBuild.ConnectionString = ConfigurationManager.ConnectionStrings["Alpha.Properties.Settings.alphabdConnectionString"].ConnectionString;
            serverText.Text = ConBuild.Server;
            userText.Text = ConBuild.UserID;
            passText.Text = ConBuild.Password;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(serverText.Text) && !string.IsNullOrEmpty(userText.Text) && !string.IsNullOrEmpty(passText.Text))
                {
                    ConBuild.Server = serverText.Text;
                    ConBuild.UserID = userText.Text;
                    ConBuild.Password = passText.Text;
                    //Изменение конфигурации
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings["Alpha.Properties.Settings.alphabdConnectionString"].ConnectionString = ConBuild.ConnectionString;
                    config.ConnectionStrings.ConnectionStrings["Alpha.Properties.Settings.alphabdConnectionString"].ProviderName = "MySql.Data.MySqlClient";
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("connectionStrings");
                    Program.ChangeConnectionString(ConBuild.ConnectionString); //Изменение строки подключения в настройках
                }
                else
                {
                    MessageBox.Show("Недопустимы пустые поля.", "Ошибка");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка изменения конфигурации");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
