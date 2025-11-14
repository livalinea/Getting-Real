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
        public MainWindow()
        {
            InitializeComponent();

            ShowMainMenu();

            //MainMenu mainMenu = new MainMenu();
            //var test = new MainMenu();
            //MessageBox.Show(test.ToString());
        }

        public void ShowMainMenu()
        {
            MainContent.Content = new MainMenu();

        }

        public void ShowTeamMenu()
        {

            MainContent.Content = new TeamMenu();
            
        }

        public void ShowMemberMenu()
        {
            //MainContent.Content = new MemberMenu();
        }

        public void ShowContingentMenu()
        {
            //MainContent.Content = new ContingentMenu();
        }
    }
}