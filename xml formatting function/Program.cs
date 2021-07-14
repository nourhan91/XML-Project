using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            /*XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\salma\Desktop\new1.xml");
            doc.Save(Console.Out);*/
            XmlDocument doc = new XmlDocument();
            // XmlTextReader xtr = new XmlTextReader(@"D:\Salma\college\3rd CSE\2end-term\DataStructures\XML project\data.adj.xml");
            XmlTextReader xtr = new XmlTextReader(@"C:\Users\salma\Desktop\new2.xml");

            XmlElement S = doc.DocumentElement;
            XmlElement S22 = doc.DocumentElement;
            XmlElement S_parent = doc.DocumentElement;
            int prev_depth = 0;
            int Flag = 0;

            while (xtr.Read())
            {

                string S1 = xtr.Name;
                
                if (xtr.NodeType == XmlNodeType.XmlDeclaration)
                {
                    string[] String_array = new string[3];
                    for (int attInd = 0; attInd < xtr.AttributeCount; attInd++)
                    {
                        xtr.MoveToAttribute(attInd);
                        // Console.WriteLine(xtr.Name);
                        // Console.WriteLine(xtr.Value);
                        // XmlAttribute id = doc.CreateAttribute(xtr.Name);
                        //id.Value = xtr.Value;
                        //S.Attributes.Append(id);
                        String_array[attInd] = xtr.Value;
                    }
                    xtr.MoveToElement();
                    XmlDeclaration x = doc.CreateXmlDeclaration(String_array[0], String_array[1], String_array[2]);
                    doc.AppendChild(x);

                }
                if (Flag == 1)
                {

                    if (xtr.NodeType == XmlNodeType.Text)
                    {
                        string s3 = xtr.ReadString();
                        S22.InnerText = s3;
                    }

                    S_parent.AppendChild(S22);
                    Flag = 0;
                }
                if (S1 != "" && xtr.NodeType != XmlNodeType.EndElement && xtr.NodeType != XmlNodeType.XmlDeclaration)
                {

                    Console.WriteLine(S1);

                    S = doc.CreateElement(S1);


                    if (xtr.Depth == 0)
                    {

                        if (xtr.NodeType == XmlNodeType.Element)
                        {
                            for (int attInd = 0; attInd < xtr.AttributeCount; attInd++)
                            {
                                xtr.MoveToAttribute(attInd);
                                // Console.WriteLine(xtr.Name);
                                // Console.WriteLine(xtr.Value);
                                XmlAttribute id = doc.CreateAttribute(xtr.Name);
                                id.Value = xtr.Value;
                                S.Attributes.Append(id);
                            }
                            xtr.MoveToElement();

                        }
                        doc.AppendChild(S);

                        S_parent = S;
                    }


                    else
                    {

                        if (xtr.Depth > prev_depth && xtr.Depth > 1)
                            S_parent = S22;
                        else if (xtr.Depth < prev_depth)
                        {
                          
                            S_parent = (XmlElement)S22.ParentNode;
                            int count = prev_depth - xtr.Depth;
                            while (count>0)
                            {
                                S_parent = (XmlElement)S_parent.ParentNode;
                                count-= 1;
                            }
                        }

                        else
                        { 
                        }


                        S22 = doc.CreateElement(S1);
                        //S_parent.AppendChild(S22);
                        prev_depth = xtr.Depth;
                        Flag = 1;
                        if (xtr.NodeType == XmlNodeType.Element)
                        {
                            for (int attInd = 0; attInd < xtr.AttributeCount; attInd++)
                            {
                                xtr.MoveToAttribute(attInd);
                                //Console.WriteLine(xtr2.Name);
                                //Console.WriteLine(xtr2.Value);
                                XmlAttribute id = doc.CreateAttribute(xtr.Name);
                                id.Value = xtr.Value;
                                S22.Attributes.Append(id);
                            }
                            xtr.MoveToElement();

                        }

                    }
                      /* S_parent2 = S_parent;

                        XmlReader xtr2 = xtr.ReadSubtree();
                        
                        while (xtr2.Read())
                        {
                            string S2 = xtr2.Name;

                            if (Flag == 1)
                            {

                                if (xtr2.NodeType == XmlNodeType.Text)
                                {
                                    string s3 = xtr2.ReadString();
                                    S22.InnerText = s3;
                                }
                                
                                S_parent2.AppendChild(S22);
                                Flag = 0;
                            }

                            if (S2 != "" && xtr2.NodeType != XmlNodeType.EndElement)
                            {
                                if (xtr2.Depth > prev_depth)
                                    S_parent2 = S22;

                                S22 = doc.CreateElement(S2);

                                S_prev = S22;
                                prev_depth = xtr2.Depth;
                                Flag = 1;
                                if (xtr2.NodeType == XmlNodeType.Element)
                                {
                                    for (int attInd = 0; attInd < xtr2.AttributeCount; attInd++)
                                    {
                                        xtr2.MoveToAttribute(attInd);
                                        //Console.WriteLine(xtr2.Name);
                                        //Console.WriteLine(xtr2.Value);
                                        XmlAttribute id = doc.CreateAttribute(xtr2.Name);
                                        id.Value = xtr2.Value;
                                        S22.Attributes.Append(id);
                                    }
                                    xtr2.MoveToElement();

                                }



                            }

                        }
                    }
                    prev_depth = xtr.Depth;
                    if (xtr.Depth != 0)
                    {
                        xtr.Skip();
                    }
                }







            }
            doc.Save(@"C:\Users\salma\Desktop\new3.xml");
            Console.ReadLine();

        }

    }

}*/


                }
            }
            doc.Save(@"C:\Users\salma\Desktop\new3.xml");
            Console.ReadLine();

        }
    }
}
                     