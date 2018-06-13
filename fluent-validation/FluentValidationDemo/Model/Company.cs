using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationDemo.Model
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string SocialNumber { get; set; }
        public string TaxNumber { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> Start { get; set; }
        public Nullable<DateTime> End { get; set; }
        public Nullable<bool> Flag { get; set; }
    }
}
