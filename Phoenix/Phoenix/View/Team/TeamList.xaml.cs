using Phoenix.Repositories;
using Phoenix.ViewModels;
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
    /// Interaction logic for TeamList.xaml
    /// </summary>
    public partial class TeamList : UserControl
    {
        MainWindow mainWindow;
        private TeamRepository teamRepository;
        public Member SelectedMember { get; set; }

        public TeamList(string holdnavn, MainWindow mW)
        {
            InitializeComponent();

            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));
         
            TeamTitle.Text = holdnavn;
            mainWindow = mW;
            var teamRepo = new TeamRepository();
            this.Loaded += TeamListLoaded;
        }
        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowTeamMenu();
            //teamMenu.Show();

        }

        private void TeamListLoaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is TeamViewModel vm && vm.SelectedTeam != null)
            {
                var team = vm.SelectedTeam;

                var allPeople = team.Coaches
                    .Concat(team.AsCoaches)
                    .Concat(team.Members)
                    .ToList();

                HoldMedlemListe.ItemsSource = allPeople;
            }
        }

        private void RemoveMember_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as TeamViewModel;

            if (vm?.SelectedMember == null)
            {
                MessageBox.Show("Ingen medlem valgt.");
                return;
            }

            var member = vm.SelectedMember;
            var result = MessageBox.Show(
                $"Er du sikker på at du vil slette {member.FirstName} {member.LastName}?",
                "Bekræft sletning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                mainWindow.memberRepository.Delete(member.MemberID);
                vm.TeamMembers.Remove(member); // fjern fra listen i UI
                MessageBox.Show("Medlem fjernet.");
            }
        }
    }
}
    

