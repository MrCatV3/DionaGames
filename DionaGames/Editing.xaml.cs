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
    /// Логика взаимодействия для Editing.xaml
    /// </summary>
    public partial class Editing : Window
    {
        public Editing()
        {
            InitializeComponent();
        }

        private void clic_Click(object sender, RoutedEventArgs e)
        {
            AdmiPanel up = new AdmiPanel();
            up.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdmiPanel up = new AdmiPanel();
            up.Show();
            this.Close();
        }
    }
}
