using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Collections;
using System.Collections.ObjectModel;

namespace WpfApp3
{
    class SaveXml
    {
        public static void SaveData(String filename, Item obj)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();
        }

        public static void Append(string filename, Item obj)
        {
            var item = new XElement("item",
                new XElement("ItemName", obj.ItemName),
                new XElement("CompanyName", obj.CompanyName),
                new XElement("FactoryNo", obj.FactoryNo),
                new XElement("Deadline", obj.Deadline));

            var doc = new XDocument();

            if (File.Exists(filename))
            {
                doc = XDocument.Load(filename);
                doc.Element("items").Add(item);
            }
            else
            {
                doc = new XDocument(new XElement("items", item));
            }
            doc.Save(filename);
        }

        public static void Update(string filename, ObservableCollection<Item> items)
        {
            XDocument doc = new XDocument(new XElement("items"));
            for(int i = 0; i < items.Count; i++)
            {
                Item obj = items[i];

                var item = new XElement("item",
                new XElement("ItemName", obj.ItemName),
                new XElement("CompanyName", obj.CompanyName),
                new XElement("FactoryNo", obj.FactoryNo),
                new XElement("Deadline", obj.Deadline)
                
                );

                doc.Element("items").Add(item);
            }
            doc.Save(filename);
        }

        /**
         * gett all items within 2 months from the current time
         */
        public static List<Item> GetItemsByDeadline(string filename)
        {
            List<Item> items = new List<Item>();
            List<Item> result = new List<Item>();

            var doc = XDocument.Load(filename);

            if (File.Exists(filename))
            {
                items = doc.Descendants("item").Select(d => new Item
                {
                    ItemName = d.Element("ItemName").Value,
                    CompanyName = d.Element("CompanyName").Value,
                    FactoryNo = Int32.Parse(d.Element("FactoryNo").Value),
                    Deadline = DateTime.Parse(d.Element("Deadline").Value)
                }).ToList();
            }

            DateTime now = DateTime.Now;
            for(int i = 0; i < items.Count; i++)
            {
                if((items[i].Deadline - now).TotalDays <= 33 && (items[i].Deadline - now).TotalDays >= 0)
                {
                    result.Add(items[i]);
                }
            }

            return result;
        }

        public static List<Item> GetAllItems(string filename)
        {
            List<Item> items = new List<Item>();
            var doc = XDocument.Load(filename);
            if (File.Exists(filename))
            {
                items = doc.Descendants("item").Select(d => new Item
                {
                    ItemName = d.Element("ItemName").Value,
                    CompanyName = d.Element("CompanyName").Value,
                    FactoryNo = Int32.Parse(d.Element("FactoryNo").Value),
                    Deadline = DateTime.Parse(d.Element("Deadline").Value)
                }).ToList();
            }

            return items;
        }
    }
}
