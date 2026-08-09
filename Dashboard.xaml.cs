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

namespace MyDairy
{
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void BtnMyDairy_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new pages.MyDairyPage());
        }



        private void BtnNewEntry_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new pages.MyNewEntryPage());
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new pages.MyProfilePage());
        }

        private void BtnExpenses_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new pages.MyExpensesPage());
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            Session.LoggedInUsername = string.Empty;

            Application.Current.Shutdown();
        }
    }
}
