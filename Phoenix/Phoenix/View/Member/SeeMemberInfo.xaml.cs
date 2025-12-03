using Phoenix.ViewModels;
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
        private bool isEditing = false;
        public Member SelectedMember { get; set; }
        public MemberViewModel ViewModel { get; set; }
        public SeeMemberInfo(MainWindow mW, Member member)
        {
            InitializeComponent();

            mainWindow = mW;
            SelectedMember = member;
            DataContext = SelectedMember;

            TeamComboBox.ItemsSource = Enum.GetValues(typeof(Team.TeamName));
            RoleComboBox.ItemsSource = Enum.GetValues(typeof(ClubRole));

            TeamComboBox.SelectedItem = SelectedMember.Team;
            

            RoleComboBox.SelectedItem = SelectedMember.Role;

            YesToJudoPass.IsChecked = SelectedMember.JudoPass;
            NoToJudoPass.IsChecked = !SelectedMember.JudoPass;
            YesToJudoLicens.IsChecked = SelectedMember._JudoLicens;
            NoToJudoLicens.IsChecked = !SelectedMember._JudoLicens;

            SetEditing(false);

            ViewModel = new MemberViewModel();
            ViewModel.SearchText = "";

            // Hent alle betalinger for dette medlem
            var paymentsForMember = mainWindow.paymentRepository.GetAllPayments().Where(p => p.MemberID == member.MemberID).OrderByDescending(p => p.DatePaid ?? p.DateToPay).ToList();

            // Vis dem i listen nederst
            MedlemListesInfo.ItemsSource = paymentsForMember;

        }

        private void SetEditing(bool editing)
        {
            isEditing = editing;
            Edit.Content = editing ? "Gem" : "Rediger";

            bool editable = editing;

            FirstnameLabel.IsReadOnly = !editable;
            LastnameLabel.IsReadOnly = !editable;
            BirthdateLabel.IsReadOnly = !editable;
            AdressLabel.IsReadOnly = !editable;
            EmailLabel.IsReadOnly = !editable;
            TelephoneNumber1Label.IsReadOnly = !editable;
            TelephoneNumber2Label.IsReadOnly = !editable;
            WeightLabel.IsReadOnly = !editable;

            YesToJudoPass.IsEnabled = editable;
            NoToJudoPass.IsEnabled = editable;
            YesToJudoLicens.IsEnabled = editable;
            NoToJudoLicens.IsEnabled = editable;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowMemberMenu();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (!isEditing)
            {
                // Gå i REDIGER-tilstand
                isEditing = true;
                Edit.Content = "Gem";

                FirstnameLabel.IsReadOnly = false;
                LastnameLabel.IsReadOnly = false;
                BirthdateLabel.IsReadOnly = false;
                AdressLabel.IsReadOnly = false;
                EmailLabel.IsReadOnly = false;
                TelephoneNumber1Label.IsReadOnly = false;
                TelephoneNumber2Label.IsReadOnly = false;
                WeightLabel.IsReadOnly = false;

                YesToJudoPass.IsEnabled = true;
                NoToJudoPass.IsEnabled = true;
                YesToJudoLicens.IsEnabled = true;
                NoToJudoLicens.IsEnabled = true;
            }

            else
            {
                // GEM ændringerne
                isEditing = false;
                Edit.Content = "Rediger";

                FirstnameLabel.IsReadOnly = true;
                LastnameLabel.IsReadOnly = true;
                BirthdateLabel.IsReadOnly = true;
                AdressLabel.IsReadOnly = true;
                EmailLabel.IsReadOnly = true;
                TelephoneNumber1Label.IsReadOnly = true;
                TelephoneNumber2Label.IsReadOnly = true;
                WeightLabel.IsReadOnly = true;

                YesToJudoPass.IsEnabled = false;
                NoToJudoPass.IsEnabled = false;
                YesToJudoLicens.IsEnabled = false;
                NoToJudoLicens.IsEnabled = false;

                SelectedMember.FirstName = FirstnameLabel.Text;
                SelectedMember.LastName = LastnameLabel.Text;
                SelectedMember.Address = AdressLabel.Text;
                SelectedMember.Mail = EmailLabel.Text;

                if (int.TryParse(TelephoneNumber1Label.Text, out int newPhone1))
                {
                    SelectedMember.PhoneNumber1 = newPhone1;
                }
                else
                {
                    MessageBox.Show("Hovedtelefonnummeret skal kun indeholde tal.",
                                    "Fejl i telefonnummer",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TelephoneNumber2Label.Text))
                {
                    // Hvis feltet er tomt, sæt den fx til 0 (eller lad den være)
                    SelectedMember.PhoneNumber2 = 0;
                }
                else if (int.TryParse(TelephoneNumber2Label.Text, out int newPhone2))
                {
                    SelectedMember.PhoneNumber2 = newPhone2;
                }
                else
                {
                    MessageBox.Show("Ekstra telefonnummer må kun indeholde tal.",
                                    "Fejl i telefonnummer",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                    return;
                }

                if (TeamComboBox.SelectedItem is Team.TeamName newTeam)
                    SelectedMember.Team = newTeam;

                if (RoleComboBox.SelectedItem is ClubRole newRole)
                    SelectedMember.Role = newRole;

                SelectedMember.JudoPass = YesToJudoPass.IsChecked == true;
                SelectedMember._JudoLicens = YesToJudoLicens.IsChecked == true;
                mainWindow.memberRepository.Update(SelectedMember);

                MessageBox.Show("Medlemsoplysninger gemt.");

                mainWindow.ShowMemberMenu();
            }
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                $"Er du sikker på at du vil slette {SelectedMember.FirstName} {SelectedMember.LastName}?",
                "Bekræft sletning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            mainWindow.memberRepository.Delete(SelectedMember.MemberID);
            mainWindow.ShowMemberMenu();
        }

        private void YesToJudoPass_Checked(object sender, RoutedEventArgs e)
        {
            if (YesToJudoPass.IsChecked == true)
                NoToJudoPass.IsChecked = false;
        }

        private void NoToJudoPass_Checked(object sender, RoutedEventArgs e)
        {
            if (NoToJudoPass.IsChecked == true)
                YesToJudoPass.IsChecked = false;
        }

        private void YesToJudoLicens_Checked(object sender, RoutedEventArgs e)
        {
            if (YesToJudoLicens.IsChecked == true)
                NoToJudoLicens.IsChecked = false;
        }

        private void NoToJudoLicens_Checked(object sender, RoutedEventArgs e)
        {
            if (NoToJudoLicens.IsChecked == true)
                YesToJudoLicens.IsChecked = false;
        }
    }
}

