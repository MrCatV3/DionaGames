using System;
using System.Collections.Generic;
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

namespace DionaGames
{
    /// <summary>
    /// Логика взаимодействия для Rent.xaml
    /// </summary>
    public partial class Rent : Window
    {
        public Rent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.GlobalVariable == 1)
            {
                AdmiPanel ad = new AdmiPanel();
                ad.Show();
                this.Close();
            }
            else
            {
                UserPanel us = new UserPanel();
                us.Show();
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (App.GlobalVariable == 1)
            {
                ViewHall vh = new ViewHall();
                vh.Show();
                this.Close();
            }
            else
            {
                UserPanel us = new UserPanel();
                us.Show();
                this.Close();
            }
        }
    }
}
