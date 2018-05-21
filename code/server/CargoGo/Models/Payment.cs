using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentDirectionCode { get; set; }
        public string CompanyCode { get; set; }
        public string PaymentTypeCode { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Note { get; set; }
       
    }
}