using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class PaymentType
    {
        public int ID { get; set; }
        public string PaymentTypeCode { get; set; }
        public string PaymentTypeDesc { get; set; }
    }
}