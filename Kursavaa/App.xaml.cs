using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;

namespace Kursavaa
{
    public partial class App : Application
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
        }
    }

}
