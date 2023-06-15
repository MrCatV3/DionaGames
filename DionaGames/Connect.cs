using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace DionaGames
{
    public class Connect
    {
        public static MySqlConnection Neko(string host, int port, string database, string username, string password)
        {
            String con = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conNeko = new MySqlConnection(con);

            return conNeko;
        }

        public static MySqlConnection Neko()
        {
            string host = "localhost";
            int port = 3306;
            string database = "dio";
            string username = "root";
            string password = "Qwerty_08642";

            return Neko(host, port, database, username, password);

        }
    }
}
