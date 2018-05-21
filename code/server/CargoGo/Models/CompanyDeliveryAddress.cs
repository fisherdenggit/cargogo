using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class CompanyDeliveryAddress
    {
        public int ID { get; set; }
        public string CompanyCode { get; set; }
        public string CargoDeliveryAddress { get; set; }
        public string CargoDeliveryContact { get; set; }
        public string CargoDeliveryContactMobile { get; set; }
    }
}