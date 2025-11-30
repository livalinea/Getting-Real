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
        public int NextMemberID = 1;
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
            var teamList = new TeamList(holdnavn, this);
            MainContent.Content = teamList;
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
            var teamPayment = new TeamPayment(holdnavn, this);
            MainContent.Content = teamPayment;
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

        public void ShowAddPayment(string holdnavn)
        {
            var addPayment = new AddPayment(holdnavn,this);
            MainContent.Content = addPayment;
        }

    }

}