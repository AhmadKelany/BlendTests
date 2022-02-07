using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendTests.DTO
{
    public class AccountHierarchy:Account
    {
        public ObservableCollection<AccountHierarchy> Children { get; set; } = new ObservableCollection<AccountHierarchy>();
    }
}
