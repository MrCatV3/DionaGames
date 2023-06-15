using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (log.Text == "" && pas.Password == "" && passordTrue.Password == "" && phone.Text == "" && ema.Text == "")
            {
                MessageBox.Show("Вы не ввели данные", "Некорректнвый ввод!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(log.Text == "" || pas.Password == "" || passordTrue.Password == "" || phone.Text == "" || ema.Text == "")
            {
                MessageBox.Show("Вы заполнили данные не до конца", "Некорректнвый ввод!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (pas.Password != passordTrue.Password)
            {
                MessageBox.Show("Пароли не совпадают", "Некорректный ввод!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string Query = "insert into user(Login, Password, Phone_number, Email, Role) values (@login, @password, @phone, @email, @role)";
                MySqlConnection con = Connect.Neko();
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@login", log.Text);
                cmd.Parameters.AddWithValue("@password", pas.Password);
                cmd.Parameters.AddWithValue("@phone", phone.Text);
                cmd.Parameters.AddWithValue("@email", ema.Text);
                cmd.Parameters.AddWithValue("@role", 0);
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Закройте это окно", "Успешная регистрация!", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
            }

            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
