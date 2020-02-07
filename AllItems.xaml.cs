using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for AllItems.xaml
    /// </summary>
    public partial class AllItems : Page
    {
        ObservableCollection<Item> items = new ObservableCollection<Item>();
        public AllItems()
        {
            InitializeComponent();
            List<Item> all = new List<Item>();
            all = SaveXml.GetAllItems("test.xml");

            items = new ObservableCollection<Item>(all);

            DataGridAll.ItemsSource = items;

            /*
            for (int i = 1; i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            }
            */
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("DATA UPDATED ############################");
            //for (int i = 1; i < items.Count; i++)
            //{
            //Console.WriteLine(items[i]);  
            //}
            SaveXml.Update("test.xml", items);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Item row = (Item)DataGridAll.SelectedItems[0];

            ObservableCollection<Item> data = (ObservableCollection<Item>)DataGridAll.ItemsSource;
            data.Remove(row);

            SaveXml.Update("test.xml", data);
        }
    }
}
