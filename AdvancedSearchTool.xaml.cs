using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

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
                System.Windows.MessageBox.Show(msgCount + " echipamente gasite");
            }
            textBox.Clear();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (ListViewFiltered.Items.Count > 0)
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
                            int columnCount = ListViewFiltered.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[ListViewFiltered.Items.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += ListViewFiltered.Columns[i].Header.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < ListViewFiltered.Items.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    //outputCsv[i] += DataGridAll.Items[i - 1].Cells[j].Value.ToString() + ",";
                                    outputCsv[i] += (ListViewFiltered.Columns[j].GetCellContent(ListViewFiltered.Items[i - 1]) as TextBlock).Text + ",";
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
