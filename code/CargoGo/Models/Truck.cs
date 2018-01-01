using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoGo.Models
{
    public class Truck
    {
        public string TruckID { get; set; }
        public string TruckType { get; set; }
        public string Driver1Name { get; set; }
        public string Driver1MPhone { get; set; }

        public Truck(string InTruckID, string InTruckType)
        {
            TruckID = InTruckID;
            TruckType = InTruckType;
            Driver1Name = "";
            Driver1MPhone = "";
        }

        public Truck(string InTruckID,string InTruckType,string InDriver1Name)
        {
            TruckID = InTruckID;
            TruckType = InTruckType;
            Driver1Name = InDriver1Name;
            Driver1MPhone = "";
        }

        public Truck(string InTruckID, string InTruckType, string InDriver1Name,string InDriver1MPhone)
        {
            TruckID = InTruckID;
            TruckType = InTruckType;
            Driver1Name = InDriver1Name;
            Driver1MPhone = InDriver1MPhone;
        }
        public Truck()
        {
            TruckID = "";
            TruckType = "";
            Driver1Name = "";
            Driver1MPhone = "";
        }
    }
}