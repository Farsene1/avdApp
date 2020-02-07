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
        public static XElement convertToXmlObject(Item obj)
        {
            return new XElement("item",
                //main parameters
                new XElement("ItemName", obj.ItemName),
                new XElement("CompanyName", obj.CompanyName),
                new XElement("FactoryNo", obj.FactoryNo),
                new XElement("Deadline", obj.Deadline),
                //info here
                new XElement("FactoryDate", obj.FactoryDate),
                new XElement("IscirNo", obj.IscirNo),
                new XElement("Parameters", obj.Parameters),
                new XElement("Type", obj.Type),
                new XElement("Observations", obj.Observations)
                );
        }
        
        public static void Append(string filename, Item obj)
        {
            var item = convertToXmlObject(obj);

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

                var item = convertToXmlObject(obj);
                
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
                    FactoryNo = d.Element("FactoryNo").Value,
                    Deadline = DateTime.Parse(d.Element("Deadline").Value),
                    //info here
                    FactoryDate = DateTime.Parse(d.Element("FactoryDate").Value),
                    IscirNo = d.Element("IscirNo").Value,
                    Parameters = d.Element("Parameters").Value,
                    Type = d.Element("Type").Value,
                    Observations = d.Element("Observations").Value
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
                    FactoryNo = d.Element("FactoryNo").Value,
                    Deadline = DateTime.Parse(d.Element("Deadline").Value),
                    //info here
                    FactoryDate = DateTime.Parse(d.Element("FactoryDate").Value),
                    IscirNo = d.Element("IscirNo").Value,
                    Parameters = d.Element("Parameters").Value,
                    Type = d.Element("Type").Value,
                    Observations = d.Element("Observations").Value
                }).ToList();
            }

            return items;
        }
    }
}
