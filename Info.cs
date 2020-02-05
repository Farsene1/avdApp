using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    class Info
    {
        public DateTime FactoryDate;
        public int IscirNo;
        public String Parameters;
        public String Working; // in functiune sau conservare
        public String Observations;

        public Info(DateTime FactoryDate, int IscirNo, String Parameters,
             String Working, String Observations)
        {
            this.FactoryDate = FactoryDate;
            this.IscirNo = IscirNo;
            this.Parameters = Parameters;
            this.Working = Working;
            this.Observations = Observations;
        }
    }
}
