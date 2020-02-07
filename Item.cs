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
        public int FactoryNo { get; set; }
        public string CompanyName { get; set; }
        public DateTime Deadline { get; set; } 
        public Info Info { get; set; }

        public Item()
        {

        }

        public Item(string ItemName, string CompanyName, int FactoryNo, DateTime Deadline)
        {
            this.ItemName = ItemName;
            this.CompanyName = CompanyName;
            this.FactoryNo = FactoryNo;
            this.Deadline = Deadline;
        }

        public Item(string itemName, string companyName, int factoryNo, DateTime? selectedDate)
        {
            ItemName = itemName;
            CompanyName = companyName;
            FactoryNo = factoryNo;
        }

        public void SetInfo(Info info)
        {
            this.Info = info;
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
