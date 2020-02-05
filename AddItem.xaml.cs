using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void Save_Item_Click(object sender, RoutedEventArgs e)
        {
            String ItemName = textBoxItemName.Text;
            String CompanyName = textBoxCompanyName.Text;
            int FactoryNo = Int32.Parse(textBoxFactoryNo.Text);
            String dateVal = deadLinePicker.SelectedDate.Value.ToString("dd/MM/yyyy");
            DateTime dateTime = DateTime.ParseExact(dateVal, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            textBoxItemName.Clear();
            textBoxCompanyName.Clear();
            textBoxFactoryNo.Clear();

            Item item = new Item(ItemName, CompanyName, FactoryNo, dateTime);
            SaveXml.Append("test.xml", item);
            //Console.WriteLine(dateVal);
        }
    }
}
