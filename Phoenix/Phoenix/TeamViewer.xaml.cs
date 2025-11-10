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
    public partial class TeamViewer : Window
    {
        public TeamViewer(string holdnavn)
        {
            InitializeComponent();
            TitleTeam.Content = holdnavn;
            this.Title = holdnavn;
        }

        private void Label_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TeamMenu teamMenu = new TeamMenu();
            teamMenu.Show();
            this.Close();
        }
    }
}
