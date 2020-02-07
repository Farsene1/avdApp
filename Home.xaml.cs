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
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void All_Items_Click(object sender, RoutedEventArgs e)
        {
            AllItems allItems = new AllItems();
            this.NavigationService.Navigate(allItems);
        }

        private void Add_Item_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            this.NavigationService.Navigate(addItem);
        }

        private void Deadlines_Click(object sender, RoutedEventArgs e)
        {
            Deadlines deadlines = new Deadlines();
            this.NavigationService.Navigate(deadlines);
        }
    }
}
