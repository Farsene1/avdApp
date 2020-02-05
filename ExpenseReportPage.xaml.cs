using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for ExpenseReportPage.xaml
    /// </summary>
    public partial class ExpenseReportPage : Page
    {
        public ExpenseReportPage()
        {
            InitializeComponent();
        }

        // Custom constructor to pass expense report data
        public ExpenseReportPage(object data) : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
            
            //FOR TESTING PURPOSES
            /*Console.WriteLine("TRYING TO READ FILE");
            Item item1 = new Item("item1", "companyname1", 1, new DateTime(2008,6,1));
            Item item2 = new Item("item2", "companyname2", 2, new DateTime(2020, 12, 2));
            SaveXml.Append("test.xml", item1);
            SaveXml.Append("test.xml", item2);
            Console.WriteLine("WRITTEN TO FILE");
            List<Item> items = SaveXml.getAllItems("test.xml");
            Console.WriteLine("No. of Items is " + items.Count);
            for(int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            } */
        }
    }
}
