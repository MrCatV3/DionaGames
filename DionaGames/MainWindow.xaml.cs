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
            if(tb_l.Text == "" && tb_p.Password == "")
            {
                MessageBox.Show("Вы не ввели данные", "Некорректнвый ввод!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (tb_l.Text == "" || tb_p.Password == "")
            {
                MessageBox.Show("Вы заполнили данные не до конца", "Некорректнвый ввод!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MySqlConnection con = Connect.Neko();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("aboba2", con);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_username", MySqlDbType.VarChar, 50).Value = tb_l.Text;
                cmd.Parameters.Add("@p_password", MySqlDbType.VarChar, 50).Value = tb_p.Password;
                cmd.Parameters.Add("@aut", MySqlDbType.VarChar, 255).Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                App.GlobalVariableString = cmd.Parameters["@aut"].Value.ToString();
                if (tb_l.Text == "admin" && tb_p.Password == "admin123")
                {
                    AdmiPanel ad = new AdmiPanel();
                    ad.Show();
                    this.Close();

                    App.GlobalVariable = 1;
                }
                else if (App.GlobalVariableString != "false")
                {
                    UserPanel us = new UserPanel();
                    us.Show();
                    this.Close();
                }
                if (App.GlobalVariableString == "false")
                {
                    MessageBox.Show("Такого пользователя нет, повторите попытку!", "Такого пользователя нет, повторите попытку!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                con.Close();
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
