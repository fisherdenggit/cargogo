using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class Company
    {
        public int ID { get; set; }

        public string CompanyCode { get; set; }

        public string ShortName { get; set; }

        public string FullName { get; set; }

        public string BusinessDirectionCode { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string Website { get; set; }

        public string Address { get; set; }

        public string TaxNumber { get; set; }

        public string SalesContactAddress { get; set; }

        public string SalesContact { get; set; }

        public string SalesContactMobile { get; set; }

        public string SalesContactEmail { get; set; }

        public string AccountingContactAddress { get; set; }

        public string AccountingContact { get; set; }

        public string AccountingContactMobile { get; set; }

        public string AccountingContactEmail { get; set; }

        public decimal TotalDeliveryAmount { get; set; }

        public decimal TotalPaymentAmount { get; set; }

        public decimal TotalBalanceAmount { get; set; }

        public decimal TotalUninvoiceAmount { get; set; }

        public string CurrencyCode { get; set; }
    }
}