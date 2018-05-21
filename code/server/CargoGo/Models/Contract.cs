using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class Contract
    {
        public int ID { get; set; }
        public string ContractCode { get; set; }
        public DateTime ContractDate { get; set; }
        public string CompanyCode { get; set; }
        public string ProductCode { get; set; }
        public decimal ContractAmount { get; set; }
        public decimal ContractPrice { get; set; }
        public decimal ContractExcutedAmount { get; set; }
        public string Note { get; set; }
    }
}