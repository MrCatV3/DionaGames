using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Editing.xaml
    /// </summary>
    public partial class Editing : Window
    {
        public Editing()
        {
            InitializeComponent();
            
            string querycom = "select Place_number from Place where Device = 'ПК'";
            MySqlConnection con = Connect.Neko();
            con.Open();

            

            MySqlCommand cmd = new MySqlCommand(querycom, con);
            MySqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                Combo.Items.Add(DR[0]);
            }
            DR.Close();
            con.Close();
        }

        private void clic_Click(object sender, RoutedEventArgs e)
        {
            AdmiPanel up = new AdmiPanel();
            up.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string queryUp = "update place set Processor = @proc, RAM = @ram, Video_card = @vid, Place_status = @Stat where Place_number = @place";
            MySqlConnection con = Connect.Neko();
            con.Open();
            MySqlCommand cmd2 = new MySqlCommand(queryUp, con);
            cmd2.Parameters.AddWithValue("@proc", ComboProc.Text);
            cmd2.Parameters.AddWithValue("@ram", ComboRam.Text);
            cmd2.Parameters.AddWithValue("@vid", ComboVid.Text);
            cmd2.Parameters.AddWithValue("@Stat", Combo2.Text);
            cmd2.Parameters.AddWithValue("@place", Combo.SelectedItem.ToString());
            int rows = cmd2.ExecuteNonQuery();
            if (rows > 0) { MessageBox.Show("Запись успешно обновлена"); }
            else { MessageBox.Show("Запись успешно не обновлена"); }
            AdmiPanel up = new AdmiPanel();
            up.Show();
            this.Close();
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }

        private void Combo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
