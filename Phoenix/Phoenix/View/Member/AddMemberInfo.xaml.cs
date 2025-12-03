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

            TeamComboBox.ItemsSource = Enum.GetValues(typeof(Team.TeamName));
            RoleComboBox.ItemsSource = Enum.GetValues(typeof(ClubRole));

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
                    MessageBox.Show("Ugyldig fødselsdato. formatet skal være: DD.MM.YYYY");
                    return;
                }

                string address = AdressField.Text.Trim();




                if (string.IsNullOrWhiteSpace(TelephoneNumber1Field.Text) ||
                     !int.TryParse(TelephoneNumber1Field.Text, out int phone1))
                {
                    MessageBox.Show("Hovedtelefonnummeret skal udfyldes og må kun indeholde 8 tal.",
                                    "Fejl i telefonnummer",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                    return;
                }
                int? phone2 = null;
                if (!string.IsNullOrWhiteSpace(TelephoneNumber2Field.Text))
                {
                    // Hvis feltet er udfyldt, SKAL det være et gyldigt tal.
                    if (!int.TryParse(TelephoneNumber2Field.Text, out int tempphone2))
                    {
                        MessageBox.Show("Ekstra telefonnummer må kun indeholde tal, hvis det udfyldes.",
                                        "Fejl i telefonnummer",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Warning);
                        return;
                        phone2 = tempphone2;
                    }
                }


                string mail = EmailField.Text.Trim();
                string rank = RankField.Text.Trim();
                if (!rank.All(char.IsDigit))
                {
                    MessageBox.Show("Rank må kun indeholde tal",
                        " ", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                double weight = 0;
                if (!string.IsNullOrWhiteSpace(WeightField.Text))
                    double.TryParse(WeightField.Text, out weight);

                bool judoPass = YesToJudoPass.IsChecked == true;
                bool judoLicens = YesToJudoLicens.IsChecked == true;



                var selectedTeam = (Team.TeamName)TeamComboBox.SelectedItem;


                var selectedRole = (ClubRole)RoleComboBox.SelectedItem;





                // LAV MEDLEM
                Member newMember = new Member(
                    memberID,
                    firstName,
                    lastName,
                    birthDate,
                    address,
                    mail,
                    phone1,
                    phone2.GetValueOrDefault(),
                    rank,
                    judoPass,
                    judoLicens,
                    selectedTeam,
                    weight,
                    selectedRole
                );

                mainWindow.memberRepository.Add(newMember);
                mainWindow.teamRepository.AddMember(selectedTeam, newMember);

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