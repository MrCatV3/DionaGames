﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DionaGames
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static int GlobalVariable { get; set; }
        public static string GlobalVariableString { get; set; }
        public static string GlobalVariableString2 { get; set; }
    }
}
