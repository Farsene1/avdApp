using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Item
    {
        public string ItemName;
        public int FactoryNo;
        public string CompanyName;
        public DateTime Deadline;
        public Info Info;

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
