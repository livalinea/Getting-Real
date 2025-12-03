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
    public partial class AddPayment : UserControl
    {
       private MainWindow mainWindow;
        private Member currentMember;
        private Team.TeamName currentTeam;

        private PaymentViewModel viewModel;
        

        public AddPayment(string holdnavn, MainWindow mW, Member member)
        {

            InitializeComponent();

            currentMember = member;
            currentTeam = (Team.TeamName)Enum.Parse(typeof(Team.TeamName), holdnavn);
            mainWindow = mW;

            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));
            
            viewModel = new PaymentViewModel
                {
                    MemberName = $"{member.FirstName} {member.LastName}",
                    TeamName = holdnavn,
                    Description = "",
                    PaymentDate = DateTime.Today.ToString("dd-MM-yyyy"),
                    Amount = "",
                    HasJudoPass = false
                };
            DataContext = viewModel;
            viewModel.TeamName = holdnavn;

        }
        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowPaymentMenu();
            //teamMenu.Show();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // 1. Tjek at felter er udfyldt
            if (string.IsNullOrWhiteSpace(viewModel.Description) ||
                string.IsNullOrWhiteSpace(viewModel.Amount) ||
                string.IsNullOrWhiteSpace(viewModel.PaymentDate))
            {
                MessageBox.Show("Udfyld beskrivelse, betalingsdato og beløb.");
                return;
            }

            // 2. Beløb
            if (!double.TryParse(viewModel.Amount, out double price))
            {
                MessageBox.Show("Beløb skal være et tal.");
                return;
            }

            // 3. Dato
            if (!DateTime.TryParse(viewModel.PaymentDate, out DateTime payDate))
            {
                MessageBox.Show("Ugyldig dato.");
                return;
            }

            // 4. Nyt PaymentID (simpelt: antal + 1)
            int newPaymentId = mainWindow.paymentRepository
                                         .GetAllPayments()
                                         .Count() + 1;

            // 5. Lav Payment-objekt
            var payment = new Payment(
                paymentID: newPaymentId,
                memberID: currentMember.MemberID,
                price: price,
                dateToPay: payDate,
                datePaid: payDate,
                payDescription: viewModel.Description
            );

            // 6. Gem i repository
            mainWindow.paymentRepository.AddPayment(payment);

            MessageBox.Show("Betaling gemt.");

            // 7. Tilbage til betalingsoversigten for holdet
            mainWindow.ShowTeamPayment(currentTeam.ToString());
        }
    }
}
