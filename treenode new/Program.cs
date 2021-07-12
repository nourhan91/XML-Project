using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace ConsoleApp2
{
    class Program
    {


       /* public static void Main()
        {
            // Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            string xmlData = "<book xmlns:bk='urn:samples'></book>";
            doc.Load(new StringReader(xmlData));

            doc.Save(Console.Out);

            Console.WriteLine("\nold");


            // Create a new element and add it to the document.
            XmlElement elem = doc.CreateElement("bk", "genre", "urn:samples");
            elem.InnerText = "fantasy";
            doc.DocumentElement.AppendChild(elem);
            Console.WriteLine("\nDisplay the modified XML...");
            doc.Save(Console.Out);
            Console.ReadLine();
        }


        */
       /*
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\oeb\\Downloads\\sample.xml");
            doc.Save("C:\\Users\\oeb\\Downloads\\c.txt");
            doc.Save(Console.Out);

            string filePath = "C:\\Users\\oeb\\Downloads\\sample.xml";
            XmlTextReader xtr = new XmlTextReader(filePath);

            while (xtr.Read())
            {
                Console.WriteLine("Customer CustomerID=\"GREAL");
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "Customer CustomerID=\"GREAL")
                {
                    string s = xtr.ReadElementContentAsString();
                    string s3 = xtr.ReadContentAsString();

                    Console.WriteLine("id : " + s3);
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "ContactName")
                {
                    string s = xtr.ReadElementString();
                    Console.WriteLine("name : " + s);
                }
                if (xtr.NodeType==XmlNodeType.Element && xtr.Name== "Phone")
                {
                    string s = xtr.ReadElementContentAsString();
                    Console.WriteLine("phone : " + s);

                }
                try
                {

                }
                catch (Exception)
                {
                    // treeNode.value=null
                    throw;
                }
            }
            Console.ReadLine();
        }*/
    }

  

}
