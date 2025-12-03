//using System;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Media.Imaging;

//namespace Phoenix
//{
//    public partial class AddMemberInfo : UserControl
//    {
//        private MainWindow mainWindow;

//        public AddMemberInfo(MainWindow mw)
//        {
//            InitializeComponent();

//            mainWindow = mw;

//            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
//            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));

//            IdField.Text = mainWindow.NextMemberID.ToString();
//        }

//        private void BackButton(object sender, RoutedEventArgs e)
//        {
//            mainWindow.ShowMemberMenu();
//        }

//        private void SaveMember_Click(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                int memberID = mainWindow.NextMemberID;
//                mainWindow.NextMemberID++;

//                string firstName = FirstnamField.Text.Trim();
//                string lastName = LastnameField.Text.Trim();
//                string fullName = firstName + " " + lastName;

//                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
//                {
//                    MessageBox.Show("Du skal skrive fornavn og efternavn.");
//                    return;
//                }

//                if (!DateTime.TryParse(BirthDateField.Text, out DateTime birthDate))
//                {
//                    MessageBox.Show("Ugyldig fødselsdato.");
//                    return;
//                }

//                string address = AdressField.Text.Trim();
//                string mail = EmailField.Text.Trim();

//                string rank = RankField.Text.Trim();

//                double weight = 0;
//                if (!string.IsNullOrWhiteSpace(WeightField.Text))
//                    double.TryParse(WeightField.Text, out weight);

//                bool judoPass = YesToJudoPass.IsChecked == true;

//                Team team = new Team
//                {
//                    Type = TeamField.Text.Trim()
//                };
//                //Team team = new Team(TeamField.Text.Trim());

//                ClubRole role = ClubRole.Member;

//                // LAV MEDLEM
//                Member newMember = new Member(
//                    memberID,
//                    fullName,
//                    birthDate,
//                    address,
//                    mail,
//                    rank,
//                    judoPass,
//                    team,
//                    weight,
//                    role
//                );


//                //if (mainWindow.showMemberPage != null)
//                //{
//                //    mainWindow.showMemberPage.AddNewMember(newMember);
//                //}

//                //// 4) Gå tilbage til medlemsoversigten
//                mainWindow.ShowMemberMenu();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Der opstod en fejl: " + ex.Message, "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
//            }

//        }
//    }
//}
