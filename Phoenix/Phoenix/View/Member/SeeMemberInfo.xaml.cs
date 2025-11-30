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
    /// Interaction logic for SeeMemberInfo.xaml
    /// </summary>
    public partial class SeeMemberInfo : UserControl
    {
        MainWindow mainWindow;

        public Member SelectedMember { get; set; }

        public SeeMemberInfo(MainWindow mW, Member member)
        {
            InitializeComponent();

            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));

            mainWindow = mW;
            SelectedMember = member;
            DataContext = SelectedMember;

        }
        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowMemberMenu();

        }

        private void JudoPassLabel_Loaded(object sender, RoutedEventArgs e)
        {
            var member = (Member)JudoPassLabel.DataContext;
            JudoPassLabel.Content = member.JudoPass ? "Ja" : "Nej";


        }


        private void JudoLicensLabel_Loaded_1(object sender, RoutedEventArgs e)
        {
            var member = (Member)JudoLicensLabel.DataContext;
            JudoLicensLabel.Content = member.JudoLicens ? "Ja" : "Nej";


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
        $"Er du sikker på at du vil slette {SelectedMember.FirstName} {SelectedMember.LastName}?",
        "Bekræft sletning",
        MessageBoxButton.YesNo,
        MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                mainWindow.memberRepository.Delete(SelectedMember.MemberID);
                
            }
            mainWindow.ShowMemberMenu();

        }
    }
}
