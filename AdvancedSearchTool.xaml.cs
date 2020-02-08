using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AdvancedSearchTool.xaml
    /// </summary>
    public partial class AdvancedSearchTool : Page
    {
        List<Item> items = new List<Item>();
       
        public AdvancedSearchTool()
        {
            InitializeComponent();

            items = SaveXml.GetAllItems("test.xml");
            //ListViewFiltered.ItemsSource = items;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            String compName = textBox.Text;
            if(compName != "")
            {
                ListViewFiltered.ItemsSource = items.Where(x => x.CompanyName.ToUpper().StartsWith(compName.ToUpper())).ToList();
                String msgCount = items.Where(x => x.CompanyName.ToUpper().StartsWith(compName.ToUpper())).ToList().Count.ToString();
                MessageBox.Show(msgCount + " echipamente gasite");
            }
            textBox.Clear();
        }
    }
}
