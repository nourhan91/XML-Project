using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;



namespace final_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void choosereq_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string secondArg;
        private void button1_Click(object sender, EventArgs e)
        {
            int index1, index2;
            int spaces = 0;
            string file_location = XML_file_location.Text;
            string[] files = System.IO.Directory.GetFiles(file_location, "*.xml"); //get all files in directory with xml extension
            string xmlString = System.IO.File.ReadAllText(files[0]);  // get first xml file in files array and convert it to string
            string cleaned = xmlString.Replace("\n", "").Replace("\r", "");
            


             index1 = cleaned.IndexOf('<');
             index2 = cleaned.IndexOf('>');
             secondArg = cleaned.Substring(index1, (index2-index1)+1 );
            cleaned = cleaned.Remove(0, index2+1 );

            do
            {
                spaces = 0;
                index1 = cleaned.IndexOf('<');
                index2 = cleaned.IndexOf('>');
                //secondArg += xmlString.Substring(index1, (index2-index1)+1 );
                //xmlString = xmlString.Remove(0, index2+1 );
                for(int i=0; i<index1; i++)
                {
                    if(cleaned[i] != ' ')
                    {
                        secondArg += cleaned.Substring(0, index2+1);  //(index2 - index1) + 1
                        cleaned = cleaned.Remove(0, index2 + 1);
                        spaces = 1;
                        break;
                    }
                }
                if (spaces == 0)
                {
                    secondArg += cleaned.Substring(index1, (index2 - index1) + 1);
                    cleaned = cleaned.Remove(0, index2 + 1);
                }
            }
            while (cleaned.Length !=0);
            
           


            textBox2.Text = secondArg;
            File.WriteAllText("OUTPUT1.xml", secondArg);
        }












        // string file_name = textBox1.Text;
        // get_file_name(files, file_name);

        //label1.Text = files[0];
        // textBox2.Text = xmlString;
        // XmlDocument xmlDoc = new XmlDocument();
        // string exampleTrimmed = String.Concat(xmlString.Where(c => !Char.IsWhiteSpace(c)));

        // xmlDoc.LoadXml(exampleTrimmed);
        //xmlDoc.Save("E:\\3rd year computer 2nd term\\Data structure\\pro123.xml");
        // MessageBox.Show("DONE");
        // XmlDocument
        // XmlDocument xmlDoc = new XmlDocument();
        //xmlDoc.Load("E:\\3rd year computer 2nd term\\Data structure\\xml2233.xml");
        // xmlDoc.Save(file_location + "\\c.txt");
        //XmlElement root = xmlDoc.DocumentElement;
        //xmlDoc.PreserveWhitespace = true; // no whitespaces in the xml file
        //xmlDoc.Save("E:\\3rd year computer 2nd term\\Data structure\\product1.xml");
        //E:\\3rd year computer 2nd term\\Data structure\\product.xml

        /* int get_file_name(string []stringArray,string stringToCheck)
         {
             foreach (string x in stringArray)
             {
                 if (stringToCheck.Contains(x))
                 {
                     return 1;
                 }
             }
         }*/
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void XML_file_location_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
