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
    /// Interaction logic for TeamViewer.xaml
    /// </summary>
    public partial class TeamViewer : UserControl
    {
        MainWindow mainWindow;

        public TeamViewer(string holdnavn, MainWindow mW)
        {
            InitializeComponent();

            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));

            TeamTitle.Text = holdnavn;
            mainWindow = mW;
            var teamRepo = new TeamRepository();
            if (Enum.TryParse<Team.TeamName>(holdnavn, out var teamType))
            {
                var selectedTeam = teamRepo.GetTeam(teamType);
                if (selectedTeam != null)
                {
                    this.DataContext = new TeamViewModel(selectedTeam);
                }
            }

        }


        private void Label_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowTeamMenu();
            //teamMenu.Show();
            //this.Close();
        }

        private void Editorremove_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowAddTeamMember(holdnavn: TeamTitle.Text);

        }

        private void SeeList_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                string holdnavn = TeamTitle.Text;
                
                mainWindow.ShowTeamList(holdnavn);
            }
        }

    }
}
