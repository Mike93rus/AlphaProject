using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Alpha
{
    public partial class FormEnter : Form
    {
        public string fiodolznost;
        public int userid;
        public sbyte accesslvl;
        public string docCountSotr;

        public bool UserRemember = Properties.Settings.Default.Remember;
        public string UserEmail = Properties.Settings.Default.UserEmail;
        public string UserPass = Properties.Settings.Default.UserPass;

        public FormEnter()
        {
            InitializeComponent();
            if (UserRemember == true)
            {
                checkRemember.Checked = true;
                textEmail.Text = UserEmail;
                textPass.Text = UserPass;
            }
        }


        private void EnterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textEmail.Text) && !string.IsNullOrEmpty(textPass.Text))
                {
                    if (checkRemember.Checked)
                    {
                        Properties.Settings.Default.Remember = true;
                        UserEmail = Properties.Settings.Default.UserEmail = textEmail.Text;
                        Properties.Settings.Default.UserPass = textPass.Text;
                        Properties.Settings.Default.Save();
                    }
                    var Connect = ConfigurationManager.ConnectionStrings["Alpha.Properties.Settings.alphabdConnectionString"].ConnectionString;
                    string CommandText = "SELECT * FROM sotrudnik JOIN dolznost ON sotrudnik.dolznost_id=dolznost.id WHERE email = '" + textEmail.Text + "' AND password = '" + textPass.Text + "' LIMIT 1";
                    MySqlConnection myConnection = new MySqlConnection(Connect);
                    myConnection.Open();
                    MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
                    MySqlDataReader myReader;

                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows == true)
                    {
                        myReader.Read();
                        accesslvl = (sbyte)myReader["accesslvl"];
                        fiodolznost = ((string)myReader["fam"] + " " + (string)myReader["name"] + " " + (string)myReader["otch"] + ", " + (string)myReader["dolznost"]);
                        userid = (int)myReader["id"];
                        FormMain form2 = new FormMain();
                        myReader.Close();
                        myConnection.Close();
                        Hide();
                        form2.Show();
                    }
                    else
                        MessageBox.Show("Почта или пароль не верны!");
                    myReader.Close();
                    myConnection.Close();
                }
                else
                    MessageBox.Show("Введите почту и пароль!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\nПроверте настройки подключения.", "Ошибка поключения");
            }
        }

        private void linkLabelConnect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormConStr formCon = new FormConStr();
            formCon.ShowDialog();
        }

        private void FormEnter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
