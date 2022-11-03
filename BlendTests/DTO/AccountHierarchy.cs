using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BlendTests.DTO
{
    public class AccountHierarchy:Account
    {
        public ObservableCollection<AccountHierarchy> Children { get; set; } = new ObservableCollection<AccountHierarchy>();
        public bool IsSelected { get; set; }
        public SolidColorBrush Foreground 
        {
            get
            {
                return IsSelected ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Black);
            }
        }
    }
}
