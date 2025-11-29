using Phoenix.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Phoenix
{
    public partial class ShowMembers : UserControl
    {
        MainWindow mainWindow;
        public MemberViewModel ViewModel { get; set; }



        public ShowMembers(MainWindow mW)
        {
            InitializeComponent();

            string url = "https://impro.usercontent.one/appid/oneComWsb/domain/phoenixjudo.dk/media/phoenixjudo.dk/onewebmedia/F%C3%B8nix-logo_collection_Logo%20horisontal%20lille-10.png?etag=%22855d9-670d96f6%22&sourceContentType=image%2Fpng&ignoreAspectRatio&resize=555%2B336";
            logo.Source = new BitmapImage(new Uri(url, UriKind.Absolute));

            mainWindow = mW;

           
            ViewModel = new MemberViewModel();
            DataContext = ViewModel;
            ViewModel.SearchText = "";

        }
        

        private void BackButton(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowMainMenu();
        }

      

        private void SøgeFelt_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            // Lad ViewModel håndtere filteret
            ViewModel.SearchText = Searchfield.Text;

        }

        private void Editorremove_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ShowMemberInfo();
        }

        private void RemoveOrEditFromMembers_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedMember != null)
            {
                var infoView = new SeeMemberInfo(mainWindow,ViewModel.SelectedMember);
                mainWindow.Content = infoView; // eller mainWindow.ShowEditMember(editView);
            }
            else
            {
                MessageBox.Show("Vælg et medlem først.");
            }


        }
    }
}
