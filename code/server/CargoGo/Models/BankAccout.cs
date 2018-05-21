using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class BankAccout
    {
        public int ID { get; set; }

        public string CompanyCode { get; set; }

        public string BankName { get; set; }

        public string BankAccount { get; set; }

        public string CurrencyCode { get; set; }

        public string Note { get; set; }
    }
}