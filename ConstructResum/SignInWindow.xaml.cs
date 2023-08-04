using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConstructResum
{
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }

        private const string pathToData = @"Data";

        public static string userName = ""; // Ім'я користувача яке береться з текст боксу login
        public static string UserPassword = ""; // Пароль користувача яке береться з текст боксу 

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(pathToData + "\\Users"))
            {
                Directory.CreateDirectory(pathToData + "\\Users");
            }

            userName = txtbUserName.Text;

            if (userName.Length == 0)
            {
                MessageBox.Show("Логін не може бути пустий");
                return;
            }

            UserPassword = pswbPassword.Password;

            if (UserPassword.Length == 0)
            {
                MessageBox.Show("Пароль не може бути пустий");
                return;
            }

            try
            {
                string[] tmpStringArray = File.ReadAllLines(pathToData + "\\Users\\" + userName + "\\" + "Info.txt");

                string hashOfPassword = BCrypt.Net.BCrypt.HashPassword(UserPassword);

                if (BCrypt.Net.BCrypt.Verify(UserPassword, tmpStringArray[0]) == true)
                {
                    MessageBox.Show("Авторизація успішна");
                    MainMenuWindow mainWindow = new MainMenuWindow();
                    mainWindow.Show();
                    this.Close();
                    Close();
                }
                else
                {
                    MessageBox.Show("Не вірний логін або пароль");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Проблеми з автризацією");
            }
        }

        private void btnRegisterWay_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            this.Close();
        }
    }
}
