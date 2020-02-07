using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Item
    {
        public string ItemName { get; set; }
        public string FactoryNo { get; set; }
        public string CompanyName { get; set; }
        public DateTime Deadline { get; set; }

        //INFO HERE
        public DateTime FactoryDate { get; set; }
        public string IscirNo { get; set; }
        public string Parameters { get; set; }
        public string Type { get; set; } // in functiune sau conservare
        public string Observations { get; set; }

        public Item()
        {

        }

        public Item(string ItemName, string CompanyName, string FactoryNo, DateTime Deadline,
            DateTime FactoryDate, string IscirNo, string Parameters, string Type, string Observations)
        {
            this.ItemName = ItemName;
            this.CompanyName = CompanyName;
            this.FactoryNo = FactoryNo;
            this.Deadline = Deadline;

            //info here

            this.FactoryDate = FactoryDate;
            this.IscirNo = IscirNo;
            this.Parameters = Parameters;
            this.Type = Type;
            this.Observations = Observations;
        }

        //DATES ARE NOT ASSIGNED HERE
        public Item(string itemName, string companyName, string factoryNo, DateTime? selectedDate,
            DateTime? selectedDate2, string IscirNo, string Parameters, string Type, string Observations)
        {
            ItemName = itemName;
            CompanyName = companyName;
            FactoryNo = factoryNo;

            //INFO HERE

            this.IscirNo = IscirNo;
            this.Parameters = Parameters;
            this.Type = Type;
            this.Observations = Observations;
        }

        override
        public String ToString()
        {
            return "Item{ ItemName = " + this.ItemName +
                ", CompanyName = " + this.CompanyName +
                ", FactoryNo = " + this.FactoryNo +
                ", Deadline =  " + this.Deadline;
        }
    }
}
