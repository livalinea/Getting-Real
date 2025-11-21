using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Phoenix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainMenu mainMenu;
        private TeamMenu teamMenu;
        private ShowMember showMember;
        private AddMemberInfo addMemberInfo;
        //private TeamViewer teamViewer;


        public MainWindow()
        {
            InitializeComponent();

            mainMenu = new MainMenu();
            teamMenu = new TeamMenu(this);
            showMember = new ShowMember(this);
            addMemberInfo = new AddMemberInfo();

            ShowMainMenu();

            //var test = new MainMenu();
            //MessageBox.Show(test.ToString());
        }

        public void ShowMainMenu()
        {
            MainContent.Content = mainMenu;
        }

        public void ShowTeamMenu()
        {
            MainContent.Content = teamMenu;
        }


        public void ShowTeamViewer(string holdnavn)
        {
            var teamViewer = new TeamViewer(holdnavn, this);
            MainContent.Content = teamViewer;
        }

        public void ShowAddTeamMember(string holdnavn)
        {
            var addTeamMember = new AddTeamMember(holdnavn, this);
            MainContent.Content = addTeamMember;
        }

        public void ShowMemberMenu()
        {
           
            MainContent.Content = showMember;
        }
        public void ShowAddMemberInfo()
        {
            MainContent.Content = addMemberInfo;
        }

        public void ShowContingentMenu()
        {
            //MainContent.Content = new ContingentMenu(this);
        }
    }
}