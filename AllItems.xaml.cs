using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

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

        private void Print_Click(object sender, EventArgs e)
        {
            if (DataGridAll.Items.Count > 0)
            {
                System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Output.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            System.Windows.MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = DataGridAll.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[DataGridAll.Items.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += DataGridAll.Columns[i].Header.ToString() + ","; 
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < DataGridAll.Items.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    //outputCsv[i] += DataGridAll.Items[i - 1].Cells[j].Value.ToString() + ",";
                                    outputCsv[i] += (DataGridAll.Columns[j].GetCellContent(DataGridAll.Items[i-1]) as TextBlock).Text + ",";
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            System.Windows.MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            System.Windows.MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
}
