using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
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
            Device[] lists;

            MySqlConnection con = Connect.Neko();
            con.Open();
            string query = "select Device, Processor, RAM, Video_card, Place_number, Place_status from place; ";

            lists = GetParam(query).ToArray();
            if (lists.Length == 0) MessageBox.Show("Нет услуг");
            else { ItemC.ItemsSource = lists; }
            
            //Devices = new ObservableCollection<Device>
            //{
            //    new Device { Name = "ПК", Place = 1, Processor = "Intel Core i9 13900K", Ram = "32 ГБ", VideoCard = "NVIDIA GeForce RTX 4090", Status = "Работает"},
            //    new Device { Name = "ПК", Place = 2, Processor = "Intel Core i9 13900K", Ram = "32 ГБ", VideoCard = "NVIDIA GeForce RTX 4090", Status = "Ремонт"},
            //    new Device { Name = "PlayStation 5", Place = 3, Processor = "", Ram = "", VideoCard = "", Status = "Работает"}
            //};
            //ItemC.ItemsSource = Devices; 
        }
        IEnumerable<Device> GetParam(string sql)
        {
            using (MySqlConnection con = Connect.Neko())
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader read = cmd.ExecuteReader();
                using (read)
                {
                    while (true)
                    {
                        if (read.Read() == false) break;
                        Device merch = new Device()
                        {
                            Name = read.GetString(0),
                            Processor = read.GetString(1),
                            Ram = read.GetString(2),
                            VideoCard = read.GetString(3),
                            Place = read.GetInt32(4),
                            Status = read.GetString(5)
                        };

                        yield return merch;
                    }
                }
                read.Close();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Rent r = new Rent();
            r.Show();
            this.Close();
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
