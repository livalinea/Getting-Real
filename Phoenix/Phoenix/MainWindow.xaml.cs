using Phoenix.Repositories;
using Phoenix.ViewModels;
using System.CodeDom;
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
        public PaymentRepository paymentRepository;
        public int NextMemberID;
        private MainMenu mainMenu;
        private TeamMenu teamMenu;
        private PaymentMenu paymentMenu;
        private TeamViewer teamViewer;
        private TeamList teamList;
        private TeamPayment teamPayment;
        private AddPayment addPayment;
        private SeeMemberInfo seeMemberInfo;


        public MainWindow()
        {

                InitializeComponent();

                mainMenu = new MainMenu();
                teamMenu = new TeamMenu(this);
                paymentMenu = new PaymentMenu(this);
                memberRepository = new MemberRepository();
                teamRepository = new TeamRepository();
                paymentRepository = new PaymentRepository();
                if (memberRepository.GetAll().Any())
                {
                    NextMemberID = memberRepository.GetAll().Max(m => m.MemberID) + 1;
                }
                else
                {
                    NextMemberID = 1;
                }

                // 3. Fordel medlemmerne på teams
                foreach (var member in memberRepository.GetAll())
                {
                    teamRepository.AddMember(member.Team, member);
                }

                ShowMainMenu();
            
        }
       
       public void ShowMainMenu()
        {
            MainContent.Content = mainMenu;
        }

        public void ShowTeamMenu()
        {
            MainContent.Content = teamMenu;
        }


        //public void ShowTeamViewer(string holdnavn)
        //{
        //    var teamViewer = new TeamViewer(holdnavn, this, teamType);
        //    MainContent.Content = teamViewer;
        //}

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
            else
            {
                throw new ArgumentException("kunne ikke udføre");
            }
        }

        public void ShowMemberMenu()
        {
            showMemberPage = new ShowMembers(this);
            MainContent.Content = showMemberPage;

        }

        public void ShowPaymentMenu()
        {
            var paymentMenu = new PaymentMenu(this);
            MainContent.Content = paymentMenu;
        }

        public void ShowTeamPayment(string holdnavn)
        {
            if (Enum.TryParse<Team.TeamName>(holdnavn, out var teamType))
            {
                var selectedTeam = teamRepository.GetTeam(teamType);
                if (selectedTeam != null)
                {
                    var vm = new TeamViewModel(selectedTeam);
                    var teamPayment = new TeamPayment(holdnavn, this);
                    teamPayment.DataContext = vm;
                    MainContent.Content = teamPayment;
                }
            }
        }
        public void ShowMemberInfo()
        {
            var addMemberInfo= new AddMemberInfo(this);
            MainContent.Content = addMemberInfo;
        }
        public void ShowSeeMemberInfo(Member member)
        {
         var seeMemberInfo = new SeeMemberInfo(this, member);
        MainContent.Content = seeMemberInfo;
        }

        public void ShowAddPayment(string holdnavn, Member member)
        {
            var addPayment = new AddPayment(holdnavn, this, member);
            MainContent.Content = addPayment;
        }


    }

}