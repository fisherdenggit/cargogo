using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public string InvoiceCode { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string InvoiceDirectionCode { get; set; }
        public string CompanyCode { get; set; }
        public string Note { get; set; }
    }
}