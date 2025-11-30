using Phoenix.ViewModels;
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
        public ShowMembers? showMemberPage;
        public MemberRepository memberRepository;
        public TeamRepository teamRepository;
        public int NextMemberID;
        private MainMenu mainMenu;
        private TeamMenu teamMenu;
        private PaymentMenu paymentMenu;
        private TeamViewer teamViewer;
        private TeamList teamList;
        private TeamPayment teamPayment;
        private SeeMemberInfo seeMemberInfo;


        public MainWindow()
        {
            InitializeComponent();

            mainMenu = new MainMenu();
            teamMenu = new TeamMenu(this);
            paymentMenu = new PaymentMenu(this);
            memberRepository = new MemberRepository();
            teamRepository = new TeamRepository();
            if (memberRepository.GetAll().Any())
            {
                NextMemberID = memberRepository.GetAll().Max(m => m.MemberID) + 1;
            }
            else
            {
                NextMemberID = 1;
            }

            memberRepository.LoadFromFile();

            // 3. Fordel medlemmerne på teams
            foreach (var member in memberRepository.GetAll())
            {
                if (Enum.TryParse<Team.TeamName>(member.Team.ToString(), out var teamType));

                {
                    teamRepository.AddMember(teamType, member);
                }
            }

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

        public void ShowTeamList(string holdnavn)
        {


            if (Enum.TryParse<Team.TeamName>(holdnavn, out var teamType))
            {
                var selectedTeam = teamRepository.GetTeam(teamType);
                if (selectedTeam != null)
                {
                    var vm = new TeamViewModel(selectedTeam);
                    var teamList = new TeamList(holdnavn, this);
                    teamList.DataContext = vm;
                    MainContent.Content = teamList;
                }

            }
        }

        public void ShowMemberMenu()
        {
            showMemberPage = new ShowMembers(this);
            MainContent.Content = showMemberPage;
           


        }

        public void ShowPaymentMenu()
        {
            MainContent.Content = paymentMenu;
        }
        public void ShowTeamPayment(string holdnavn)
        {
            var teamPayment = new TeamPayment(holdnavn, this);
            MainContent.Content = teamPayment;
        }

        public void ShowMemberInfo()
        {
            var addMemberInfo = new AddMemberInfo(this);
            MainContent.Content = addMemberInfo;
        }
        public void ShowSeeMemberInfo(Member member)
        {
         var seeMemberInfo = new SeeMemberInfo(this, member);
        MainContent.Content = seeMemberInfo;
        }

        


    }

}