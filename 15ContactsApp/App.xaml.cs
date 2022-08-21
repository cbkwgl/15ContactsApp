using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _15ContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string DataBaseName = "contacts.db";
        public static string FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        
        public static string DataBasePath = System.IO.Path.Combine(FolderPath, DataBaseName);
    }
}
