using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Phoenix
{
    public partial class AddMemberInfo : UserControl
    {

        private MainWindow mainWindow;

        public AddMemberInfo(MainWindow mw)
        {
            InitializeComponent();

            mainWindow = mw;



            IdField.Text = mainWindow.NextMemberID.ToString();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowMemberMenu();
        }

        private void SaveMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int memberID = mainWindow.NextMemberID;
                mainWindow.NextMemberID++;

                string firstName = FirstnamField.Text.Trim();
                string lastName = LastnameField.Text.Trim();

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    MessageBox.Show("Du skal skrive fornavn og efternavn.");
                    return;
                }

                if (!DateTime.TryParse(BirthDateField.Text, out DateTime birthDate))
                {
                    MessageBox.Show("Ugyldig fødselsdato.");
                    return;
                }

                string address = AdressField.Text.Trim();
                string mail = EmailField.Text.Trim();
                string rank = RankField.Text.Trim();

                double weight = 0;
                if (!string.IsNullOrWhiteSpace(WeightField.Text))
                    double.TryParse(WeightField.Text, out weight);

                bool judoPass = YesToJudoPass.IsChecked == true;
                bool judoLicens = YesToJudoLicens.IsChecked == true;

                // Her bruger vi TeamField.Text direkte
                if (!Enum.TryParse<Team.TeamName>(TeamField.Text.Trim(), out var parsedTeamType))
                {
                    MessageBox.Show("Ugyldigt holdnavn. Prøv igen.");
                    return;
                }

                Team team = new Team(parsedTeamType);
                ClubRole role = ClubRole.Member;

                // LAV MEDLEM
                Member newMember = new Member(
                    memberID,
                    firstName,
                    lastName,
                    birthDate,
                    address,
                    mail,
                    rank,
                    judoPass,
                    judoLicens,
                    team,
                    weight,
                    role
                );

                mainWindow.memberRepository.Add(newMember);

                // Hvis du vil opdatere UI
                // if (mainWindow.showMemberPage != null)
                // {
                //     mainWindow.showMemberPage.AddNewMember(newMember);
                // }

                // Gå tilbage til medlemsoversigten
                mainWindow.ShowMemberMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Der opstod en fejl: " + ex.Message,
                    "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}