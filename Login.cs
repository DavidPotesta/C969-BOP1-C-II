using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace C969_BOP1_Potesta_David_001243829
{
    public partial class Login : Form
    {
        public Login()
        {
            // RUBRIC A:     COMMENT THIS LINE OUT TO USE DEFAULT CULTURE, UNCOMMENT THIS LINE TO SIMULATE CULTURE TO BE SPANISH.  THIS IS TO TEST TRANSLATIONS.
            //Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-ES");
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblLoginError.Text = "";
            if (userLogin(txtUsername.Text,txtPassword.Text))
            {
                this.Hide();
                AppointmentMain appointmentMain = new AppointmentMain();
                Logging.Login(txtUsername.Text);
                appointmentMain.Show();
             
            }
            else
            {
                lblLoginError.Text = Properties.translations.res_login_error_message;
                txtUsername.Text = "";
                txtPassword.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.translations.res_login_exit_message);
            Application.Exit();
        }

        private bool userLogin(string userName, string password)
        {
            using (MySqlConnection con = new MySqlConnection(Properties.Resources.connectionString.ToString()))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM user WHERE userName = '{userName}' AND password = '{password}'");
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (loginSuccessful)
                {
                    Controller.setUserId(Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]));
                    Controller.setUserName(ds.Tables[0].Rows[0].ItemArray[1].ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
