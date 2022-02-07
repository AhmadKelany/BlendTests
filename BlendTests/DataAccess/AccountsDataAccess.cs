using BlendTests.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlendTests.DataAccess
{
    public class AccountsDataAccess
    {
        static string AccountsFilePath = @"Data\accounts.json";
        public static void SaveAccountsToFile(List<Account> accounts)
        {
            string serializedAccounts = JsonSerializer.Serialize(accounts);
            File.WriteAllText(AccountsFilePath, serializedAccounts);
        }
        public static List<Account> LoadAccounts()
        {
            string serializedAccounts = File.ReadAllText(AccountsFilePath);
            var result = new List<Account>();
            try
            {
                result = JsonSerializer.Deserialize<List<Account>>(serializedAccounts);
            }
            catch (Exception)
            {

            }
            return result;
        }

        public static List<AccountHierarchy> GetAccountHierarchiesFromAccounts(List<Account> accounts)
        {
            List<AccountHierarchy> result = new List<AccountHierarchy>();
            result = accounts.Select(a => new AccountHierarchy { Id = a.Id, Name = a.Name, AlternateId = a.AlternateId , ParentAccountId = a.ParentAccountId  }).ToList();
            foreach (var a in result)
            {
                a.Children = new ObservableCollection<AccountHierarchy>(result.Where(h => h.ParentAccountId == a.Id).ToList());
            }
            return result;
        }
        public static List<Account> GetAccountsFromAccountHierarchies(List<AccountHierarchy> accountHierarchies)
        {
            List<Account> result = new List<Account>();
            result = accountHierarchies.Select(h => new Account { Id = h.Id, Name = h.Name, AlternateId = h.AlternateId , ParentAccountId= h.ParentAccountId }).ToList();

            return result;

        }
    }
}
