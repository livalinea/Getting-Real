using Phoenix.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Phoenix
{
    public partial class ShowMembers : UserControl
    {
        MainWindow mainWindow;
        public MemberViewModel ViewModel { get; set; }

        public ShowMembers(MainWindow mW)
        {
            InitializeComponent();

            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));

            mainWindow = mW;
            this.Loaded += ShowMembersLoaded;

            ViewModel = new MemberViewModel();
            DataContext = ViewModel;
            ViewModel.SearchText = "";

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowMainMenu();
        }

        private void ShowMembersLoaded(object sender, RoutedEventArgs e)
        {
            var allPeople = mainWindow.teamRepository.Teams
                .SelectMany(team =>
                    team.Coaches
                        .Concat(team.AsCoaches)
                        .Concat(team.Members))
                .OrderBy(m =>
                    m.Role == ClubRole.Coach ? 0 :
                    m.Role == ClubRole.AsCoach ? 1 : 2)
                .ThenBy(m => m.Team)
                .ThenBy(m => m.FirstName)
                .ThenBy(m => m.LastName)
                .ToList();

            HoldMedlemListe.ItemsSource = allPeople;
        }


        private void RemoveOrEditFromMembers_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedMember != null)
            {

                mainWindow.ShowSeeMemberInfo(ViewModel.SelectedMember);

                // eller mainWindow.ShowEditMember(editView);
            }
            else
            {
                MessageBox.Show("Vælg et medlem først.");
            }


        }

        private void AddToMember_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowMemberInfo();


        }
    }
}
