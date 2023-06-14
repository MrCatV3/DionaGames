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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DionaGames
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            App.GlobalVariable = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(tb_l.Text=="admin" && tb_p.Text=="admin123")
            {
                AdmiPanel ad = new AdmiPanel();
                ad.Show();
                this.Close();

                App.GlobalVariable = 1;
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
            Registration reg = new Registration();
            reg.Show();
            this.Close();
        }
    }
}
