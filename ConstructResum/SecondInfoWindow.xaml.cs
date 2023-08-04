using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ConstructResum
{
    public partial class SecondInfoWindow : Window
    {
        private double _textSize = 12;

        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private string surname;
        private string email;
        private string phone;
        private string sex;
        private string data;
        private string photo;
        private string posada;
        private string city;
        private string opis;
        private string studylvl;
        private string navchalka;
        private string facult;
        private string about;

        bool nextStep = false;

        public SecondInfoWindow(string name, string surname, string email, string phone, string sex, string data, string photo)
        {
            InitializeComponent();
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
            this.sex = sex;
            this.data = data;
            this.photo = photo;

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

        private void validation()
        {
            string posada = txtbPosada.Text;
            string city = txtbCity.Text;
            string opis = txtbInfo.Text;
            string studylvl = coomboxStudyLevel.Text;
            string navchalka = txtbStudy.Text;
            string facult = txtbFacult.Text;
            string about = txtbAbout.Text;

            if (posada.Length == 0 || city.Length == 0 || opis.Length == 0 
                || studylvl.Length == 0 || navchalka.Length == 0 
                || facult.Length == 0 || about.Length == 0)
            {
                MessageBox.Show("Перевірьте коректність даних");
                nextStep = false;
            }
            else
            {
                nextStep = true;
            }

            sendData(posada, city, opis, studylvl, navchalka, facult, about);
        }

        public void sendData(string posada, string city, string opis, string studylvl, string navchalka, string facult, string about)
        {
            this.posada = posada;
            this.city = city;
            this.opis = opis;
            this.studylvl = studylvl;
            this.navchalka = navchalka;
            this.facult = facult;
            this.about = about;
        }

        private void btnNextStep_Click(object sender, RoutedEventArgs e)
        {
            validation();

            if (nextStep == true)
            {
                SelectResumWindow selectResumWindow = new SelectResumWindow(name, surname, email, phone, sex, data, photo, posada, city, opis, studylvl, navchalka, facult, about);
                selectResumWindow.Show();
                this.Close();
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

        private void btnStep_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            this.Close();
        }
    }
}
