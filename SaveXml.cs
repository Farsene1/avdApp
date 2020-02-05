using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Collections;

namespace WpfApp3
{
    class SaveXml
    {
        public static void SaveData(Object obj, String filename)
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

        public static List<Item> getAllItems(string filename)
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
