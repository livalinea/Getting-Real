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

namespace Phoenix
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        private MainWindow mainWindow;
        
        public MainMenu()
        {
            InitializeComponent();

            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));
        }

        private void TeamMenu_Button(object sender, RoutedEventArgs e)
        {
            var mW = (MainWindow)Application.Current.MainWindow;
            mW.ShowTeamMenu();


        }

        private void MemberMenu_Button(Object sender, RoutedEventArgs e)
        {

        }

        private void ContingentMenu_Button(Object sender, RoutedEventArgs e)
        {

        }
    }
}
