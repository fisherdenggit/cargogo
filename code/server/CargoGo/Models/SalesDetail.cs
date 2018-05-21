using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class SalesDetail
    {
        public int ID { get; set; }
        public DateTime OutDate { get; set; }
        public string CompanyCode { get; set; }
        public string ProductCode { get; set; }
        public string ContractCode { get; set; }
        public decimal PricePerTon { get; set; }
        public decimal OutWeightAmount { get; set; }
        public decimal ValuationPercentage { get; set; }
        public decimal ValuationWeightAmount { get; set; }
        public decimal ValuationSalesAmount { get; set; }
        public string Note { get; set; }
        public bool InvoiceBooked { get; set; }
        public string InvoiceCode { get; set; }
        public decimal ShippingPricePerTon { get; set; }
        public decimal ValuationShippingWeightAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public string ShippingCompanyCode { get; set; }
        public string TruckCode { get; set; }
        public string TruckDriverMobile { get; set; }
        public string Note2 { get; set; }
        public bool ShippingCostInvoiceBooked { get; set; }
        public string ShippingCostInvoiceCode { get; set; }
    }
}