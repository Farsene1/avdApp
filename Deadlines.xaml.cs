using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Deadlines: Page
    {
        List<Item> items = new List<Item>();
        public Deadlines()
        {
            InitializeComponent();

            items = SaveXml.GetItemsByDeadline("test.xml");
            ListViewAll.ItemsSource = items;
        }
    }
}
