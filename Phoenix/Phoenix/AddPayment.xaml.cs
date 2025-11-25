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
    /// Interaction logic for AddPayment.xaml
    /// </summary>
    public partial class AddPayment : UserControl
    {
        MainWindow mainWindow;
        public AddPayment(MainWindow mW)
        {
            InitializeComponent();
            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));
            mainWindow = mW;
        }
        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowPaymentMenu();
            //teamMenu.Show();

        }

        private void Searchfield_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Searchfield.Text))
            {
                Searchfield.Text = "Søg efter navn";
            }

        }

        private void Searchfield_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Searchfield.Text == "Søg efter navn")
            {
                Searchfield.Text = "";
            }
        }

        private void Searchfield_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = Searchfield.Text.ToLower();

            
        }
    }
}
