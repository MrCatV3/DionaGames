using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для ViewHall.xaml
    /// </summary>
    public partial class ViewHall : Window
    {
        public ObservableCollection<Device> Devices { get; set; }
        public ViewHall()
        {
            
            InitializeComponent();
            Devices = new ObservableCollection<Device>
            {
                new Device { Name = "ПК", Place = 1, Processor = "Intel Core i9 13900K", Ram = "32 ГБ", VideoCard = "NVIDIA GeForce RTX 4090", Status = "Работает"},
                new Device { Name = "ПК", Place = 2, Processor = "Intel Core i9 13900K", Ram = "32 ГБ", VideoCard = "NVIDIA GeForce RTX 4090", Status = "Ремонт"},
                new Device { Name = "PlayStation 5", Place = 3, Processor = "", Ram = "", VideoCard = "", Status = "Работает"}
            };
            ItemC.ItemsSource = Devices; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
    }
}
