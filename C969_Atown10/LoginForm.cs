using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Atown10
{
    public partial class LoginForm : Form
    {
        public string userName;
        public string password;
        private UserService _userService;
        private string logFilePath;
        public LoginForm()
        {
            InitializeComponent();
            this.Shown += LoginForm_Shown;
            _userService = new UserService();
            logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "user_login_log.txt");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            userName = textBoxUsername.Text;
            password = textBoxPassword.Text;

            try
            {
                _userService.Login(userName, password);

                using (StreamWriter sw = new StreamWriter(logFilePath, append: true))
                {
                    sw.WriteLine($"{DateTime.UtcNow}: {userName} logged in.");
                }

                MainForm mainForm = new MainForm(this);
                mainForm.Show();

                textBoxUsername.Text = "";
                textBoxPassword.Text = "";

                this.Hide();
            }
            catch (Exception ex)
            {
                // Default English error message
                string errorMessageEng = "The username and password are incorrect.";
                labelErrorEng.Text = errorMessageEng;

                // Localized error message
                string errorMessage = string.Empty;

                if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName != "en")
                {
                    switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                    {
                        case "es": // Spanish
                            errorMessage = "El nombre de usuario y la contraseña no coinciden.";
                            break;
                        default:
                            errorMessage = errorMessageEng; // Default to English if the language isn't specifically supported
                            break;
                    }

                    labelErrorLocal.Text = errorMessage;
                    labelErrorLocal.Visible = true;
                }
                labelErrorEng.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
