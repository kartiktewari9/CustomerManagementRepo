using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Common.Objects.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
    }
}
