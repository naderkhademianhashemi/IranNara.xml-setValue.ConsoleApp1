using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IranNara.xml_setValue.ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            string address = "";
            const string msg = "Enter XML file address or press d (g:\\XMLConfig.xml)";

            string input = Enter(msg);

            address = (input == "d") ? "g:\\XMLConfig.xml" : input;

            while (!File.Exists(address))
            {
                Console.WriteLine("File not exist");
                input = Enter(msg);
                address = (input == "d") ? "g:\\XMLConfig.xml" : input;
            }

            SetNewValue(address);
        }

        private static string Enter(string msg)
        {
            Console.WriteLine(msg);
            string input = Console.ReadLine();
            return input;
        }

        private static void SetNewValue(string address)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(address);
            XmlNode root = doc.DocumentElement;
            XmlNode myNode = root.SelectSingleNode("descendant::XmlParam");

            Console.WriteLine("enter new value");
            string value = Console.ReadLine();
            myNode.Attributes["Value"].Value = value;
            doc.Save(address);
        }


    }
}
