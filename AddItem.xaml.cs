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
            string ItemName = textBoxItemName.Text;
            string CompanyName = textBoxCompanyName.Text;
            string FactoryNo = textBoxFactoryNo.Text;
            string dateVal = deadLinePicker.SelectedDate.Value.ToString("dd/MM/yyyy");
            DateTime deadline = DateTime.ParseExact(dateVal, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            string dateVal2 = factoryDatePicker.SelectedDate.Value.ToString("dd/MM/yyyy");
            DateTime FactoryDate = DateTime.ParseExact(dateVal2, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string IscirNo = textBoxIscirNo.Text;
            string Parameters = textBoxParameters.Text;
            string Type = textBoxType.Text;
            string Observations = textBoxObservations.Text; 

            textBoxItemName.Clear();
            textBoxCompanyName.Clear();
            textBoxFactoryNo.Clear();
            //info boxes
            textBoxIscirNo.Clear();
            textBoxParameters.Clear();
            textBoxType.Clear();
            textBoxObservations.Clear();

            Item item = new Item(ItemName, CompanyName, FactoryNo, deadline, FactoryDate, IscirNo, Parameters, Type, Observations);

            SaveXml.Append("test.xml", item);
            //Console.WriteLine(dateVal);
        }
    }
}
