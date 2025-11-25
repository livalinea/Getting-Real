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
    /// Interaction logic for AddMemberInfo.xaml
    /// </summary>
    public partial class AddMemberInfo : UserControl
    {
        public AddMemberInfo()
        {
            InitializeComponent();
        }

        public void BackButton(object sender, RoutedEventArgs e)
        {
            var mW = (MainWindow)Application.Current.MainWindow;
            //mW.ShowAddMembers();
        }
        public void ConfirmButton(object sender, RoutedEventArgs e)
        {
            var mW = (MainWindow)Application.Current.MainWindow;
            //mW.ShowAddMembers();
        }

    }
}
