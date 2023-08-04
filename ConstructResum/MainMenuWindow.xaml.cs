using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Shapes;
using System.Windows.Forms;
using Path = System.IO.Path;
using System.Text.RegularExpressions;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ConstructResum
{
    public partial class MainMenuWindow : Window
    {
        private double _textSize = 12;

        public event PropertyChangedEventHandler PropertyChanged;

        private const string pathToData = @"Data\\";

        bool nextStep = false;
        bool validEmail = false;

        private string name;
        private string surname;
        private string email;
        private string phone;
        private string sex;
        private string data;
        private string photo;


        public MainMenuWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        public double FontSizeValue
        {
            get { return _textSize; }
            set
            {
                if (_textSize != value)
                {
                    _textSize = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FontSizeValue"));
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateFontSize();
        }

        private void UpdateFontSize()
        {
            FontSizeValue = ActualWidth / 10;
            FontSizeValue = Math.Min(ActualWidth / 12, 18);
        }

        private void validation()
        {
            string name = txtbUserName.Text;
            string surname = txtbUserSecondName.Text;
            string email = txtbEmail.Text;
            string phone = txtbPhone.Text;
            string sex = coomboxSex.Text;
            string data = dtpData.Text;
            string photo = Photo.Source.ToString();

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // регулярний вираз для перевірки, чи є текст електронною поштою

            if (name.Length == 0 || surname.Length == 0 || phone.Length > 13 || sex.Length == 0 || data.Length == 0)
            {
                MessageBox.Show("Перевірьте коректність даних");
                nextStep = false;
            }
            else
            {
                nextStep = true;
            }

            if (Regex.IsMatch(txtbEmail.Text, emailPattern))
            {
                validEmail = true;
            }
            else
            {
                MessageBox.Show("Не коректний емайл");
                validEmail = false;
            }

            sendData(name, surname, email, phone, sex, data, photo);   
        }

        public void sendData(string name, string surname, string email, string phone, string sex, string data, string photo)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
            this.sex = sex;
            this.data = data;
            this.photo = photo;
        }

        private void btnChoseImg_Click(object sender, RoutedEventArgs e)
        {
            string oSelectedFile = "";
            System.Windows.Forms.OpenFileDialog oDlg = new System.Windows.Forms.OpenFileDialog();
            if (System.Windows.Forms.DialogResult.OK == oDlg.ShowDialog())
            {
                oSelectedFile = oDlg.FileName;
                string destinationPath = pathToData + "Users\\" + SignInWindow.userName + "\\" + Path.GetFileName(oSelectedFile);
                if (File.Exists(destinationPath))
                {
                    Image image = new Image();
                    BitmapImage bitmapImage = new BitmapImage();

                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(oSelectedFile);
                    bitmapImage.EndInit();

                    image.Source = bitmapImage;

                    Photo.Source = bitmapImage;
                }
                else
                {
                    File.Copy(oSelectedFile, destinationPath);
                    Image image = new Image();
                    BitmapImage bitmapImage = new BitmapImage();

                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(oSelectedFile);
                    bitmapImage.EndInit();

                    image.Source = bitmapImage;

                    Photo.Source = bitmapImage;
                }
            }
        }

        private void btnNextStep_Click(object sender, RoutedEventArgs e)
        {
            validation();
            
            if(nextStep == true && validEmail == true)
            {
                SecondInfoWindow secondInfoWindow = new SecondInfoWindow(name, surname, email, phone, sex, data, photo);
                secondInfoWindow.Show();
                this.Close();
            }
        }
    }
}
