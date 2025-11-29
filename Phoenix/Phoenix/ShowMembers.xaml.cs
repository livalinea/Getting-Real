using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Phoenix
{
    public partial class ShowMember : UserControl
    {
        private MainWindow mainWindow = null!;

        private List<Member> allMembers = new List<Member>();

        public ShowMember(MainWindow mW)
        {
            InitializeComponent();

            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));

            mainWindow = mW;

            LoadMembers();

            Searchfield.Text = "Søg efter navn";
        }
        private void AddNewMember(Member newMember)
        {
            allMembers.Add(newMember);

            HoldMedlemListe.ItemsSource = null;
            HoldMedlemListe.ItemsSource = allMembers;
        }


        private void LoadMembers()
        {
            // LIGE NU: tom liste.
            // Senere kan vi hente rigtige medlemmer.
            allMembers = new List<Member>();

            HoldMedlemListe.ItemsSource = allMembers;
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowMainMenu();
        }

        private void SøgeFelt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Searchfield.Text == "Søg efter navn")
                Searchfield.Text = "";
        }
        private void SøgeFelt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Searchfield.Text))
            {
                Searchfield.Text = "Søg efter navn";
            }
        }

        private void SøgeFelt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Searchfield.Text == "Søg efter navn")
                return;

            string query = Searchfield.Text.ToLower();

            var filtreret = allMembers
                .Where(m => m.Name != null &&
                            m.Name.ToLower().Contains(query))
                .ToList();

            HoldMedlemListe.ItemsSource = filtreret;
        }

        private void Editorremove_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowMemberInfo();
        }

    }
}
