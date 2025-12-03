using Phoenix.Models;
using Phoenix.Repositories;
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
    /// Interaction logic for TeamPayment.xaml
    /// </summary>
    public partial class TeamPayment : UserControl
    {
        MainWindow mainWindow;
        private TeamRepository teamRepository;
        public TeamPayment(string holdnavn, MainWindow mw)
        {
            InitializeComponent();
            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));

            TeamTitle.Text = holdnavn;
            mainWindow = mw;
            var teamRepo = new TeamRepository();

            this.Loaded += TeamPaymentLoaded;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowPaymentMenu();
            //teamMenu.Show();

        }

        private void RegPayment_Click(object sender, RoutedEventArgs e)
        {
            var selectedMember = HoldMedlemListe.SelectedItem as Member;

            if (selectedMember == null)
            {
                MessageBox.Show("Vælg først et medlem i listen.");
                return;
            }

            mainWindow.ShowAddPayment(TeamTitle.Text, selectedMember);
        }
        private void TeamPaymentLoaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is Phoenix.ViewModels.TeamViewModel vm &&
                vm.SelectedTeam != null)
            {
                var allPeople = vm.SelectedTeam.Coaches
                    .Concat(vm.SelectedTeam.AsCoaches)
                    .Concat(vm.SelectedTeam.Members)
                    .ToList();

                HoldMedlemListe.ItemsSource = allPeople;
            }
        }
    }
}
