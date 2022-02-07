using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace BlendTests.DTO
{
    public class Account
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AlternateId { get; set; }

        public int? ParentAccountId { get; set; }


    }
}
