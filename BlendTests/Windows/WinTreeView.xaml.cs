using BlendTests.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static System.Net.Mime.MediaTypeNames;

namespace BlendTests.Windows
{
    /// <summary>
    /// Interaction logic for WinTreeView.xaml
    /// </summary>
    public partial class WinTreeView : Window
    {
        public WinTreeView()
        {
            InitializeComponent();
        }

        public ObservableCollection<AccountHierarchy> AccountHierarchies { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AccountHierarchies = new ObservableCollection<AccountHierarchy>(DataAccess.AccountsDataAccess.GetAccountHierarchiesFromAccounts(DataAccess.AccountsDataAccess.LoadAccounts()));
            treeView1.ItemsSource = AccountHierarchies;
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            var a = treeView1.SelectedItem as AccountHierarchy;
            if (a == null)
            {
                AccountHierarchies.Add(new AccountHierarchy() { Name = txtName.Text , Id = int.Parse(txtId.Text) , ParentAccountId = null });
            }
            else
            {
                a.Children.Add(new AccountHierarchy() { Name = txtName.Text, Id = int.Parse(txtId.Text), ParentAccountId = a.Id });
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var accounts = DataAccess.AccountsDataAccess.GetAccountsFromAccountHierarchies(AccountHierarchies.ToList());
            DataAccess.AccountsDataAccess.SaveAccountsToFile(accounts);
        }
    }
}
