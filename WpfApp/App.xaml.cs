using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            //wymuszenie kultury en-US dla całej aplikacji, aby daty i liczby były wyświetlane w formacie amerykańskim
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }
            
    }

}
