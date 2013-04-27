using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PS2Outfit.Data.Services;

namespace PS2Outfit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e) {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
    }
}
