using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonShit
{
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

        class treeNode
        {
            #region attributes
            public string tagname;

            public int tagValue;
            public List<string> Value;

            public treeNode parent;
            public List<treeNode> children;

            public treeNode(int data)
            {
                this.tagValue = data;
                this.children = new List<treeNode>();
            }
            public treeNode(string tag, string x)
            {
                this.tagname = tag;
                this.Value = new List<string>();

                //this.Value[0] = x;
                this.children = new List<treeNode>();
            }
            public treeNode()
            {
                this.tagname = null;
                this.parent = null;
                this.Value = new List<string>();
                this.children = new List<treeNode>();
            }


            #endregion

            #region Properties

            public int Tagvalue
            {
                get { return tagValue; }
            }
            public treeNode Parent
            {
                get { return parent; }
                set { parent = value; }
            }
            public string Tvalue
            {
                set { Value.Add(value); }
                //get { return Value; }

            }
            /*
            public List<treeNode> Childern
            {
                get;
                private set;

            }
            */
            public treeNode this[int i]
            {
                get => children[i];
                set => children[i] = value;
            }

            #endregion

            #region Methods

            public int addChild(treeNode data)
            {
                //search in this children
                // if (children.contains(data))
                // same tagname
                /*
                Console.WriteLine(children.Count());
                Console.WriteLine(data.Value[0].ToString());

                if (children.Count()>1)
                {
                    foreach (treeNode item in this.Childern)
                    {
                        if (item.tagname.ToString()==data.tagname.ToString())
                        {
                            item.Value.AddRange(data.Value);
                        }
                        return 0;
                    }
                }*/
                /*
                        for (int i = 0; i < item.Value.Count() - 1; i++)
                        {
                            if (data.Value[0].ToString() == item.Value[i])
                            {
                                item.Value[i] = data.Value[0];
                                return 0;
                            }

                        }*/
                //
                /*
                if (Value.Contains(data.Value[0].ToString()))
                {

                    for (int i = 0; i < this.Value.Count() ; i++)
                    {
                        this.Value[i] = data.Value[0];
                    }
                    return 0;
                }*/
                /*
                foreach (treeNode item in Childern)
                {
                    for (int i = 0; i < item.Value.Count()-1; i++)
                    {
                        if (data.Value[0].ToString()==item.Value[i])
                        {
                            item.Value[i] = data.Value[0];
                            return 0;
                        }

                    }
                }*/

                /*for (int i = 0; i < this.Value.Count() - 1; i++)
                {
                    // seatch for tagname in child
                    if (this.children[i] == data.tagname.ToString())
                    {
                       // if (this.Value[i] == data.tagname.ToString())
                            // this.children.Add(.Value.Add(data.Value[0].ToString()));
                            //this.children[i].Value.Add(data.Value[0].ToString());

                            return 0;

                    }
                }
                */
                data.parent = this;
                this.children.Add(data);
                return 0;


                /*  int q = Value.IndexOf(data.tagname.ToString());
                  Console.WriteLine(q);

                  if (q!=-1)
                  {
                      this.children[q].Value.Add(data.Value.ToString());
                  }
                */



            }

            // copy paste
            public List<int> PreOrder()
            {
                List<int> list = new List<int>();
                list.Add(tagValue);
                foreach (treeNode child in children)
                    list.AddRange(child.PreOrder());
                return list;
            }

            public List<List<string>> print()
            {
                //tagname : user
                // tagvalue : name
                string z = this.tagname;
                List<string> a = this.Value;

                List<List<string>> list = new List<List<string>>();
                //list[0][1] { "is"; "1" };
                List<string> l = new List<string>();
                //list.Add(value);
                foreach (treeNode child in children)
                    list.AddRange(child.print());
                return list;
            }

            // Json printer
            public void jsonPrinter(treeNode data)
            {
                Console.WriteLine("\"" + data.tagname + "\" :");
                /*if (data.Childern.Count()>1)
                {
                    //
                    Console.Write("[");
                }
                else
                {
                    Console.Write("{");
                }*/
                Console.Write("{");
                /*if (true)
                {
                    Console.Write("\""+data.Value+"\"");
                }*/
                for (int i = 0; i < data.Value.Count(); i++)
                {
                    Console.Write("\"" + data.Value[i].ToString() + "\"" + "," + "\n");

                }
                foreach (treeNode ch in data.children)
                {
                    ch.jsonPrinter(ch);
                    Console.Write("}");
                }



            }

            public int length()
            {
                treeNode temp = new treeNode();
                treeNode t2 = new treeNode();

                temp = this.parent;
                t2 = temp;
                int len = 1;
                while (temp.parent != null)
                {
                    len++;
                    temp = temp.parent;
                }
                return len;
            }


            public int search(string tag)
            {


                treeNode temp = new treeNode();

                treeNode pointer = temp;
                // pointer traverse on this children
                // check is tagName = tag
                int index = 0;
                foreach (var item in children)
                {
                    if (item.tagname == tag)
                    {
                        children[index].tagname = "";
                        // special print function
                        //also get the length for its indentation

                        // test
                        return index;
                    }

                }
                return -1;
            }


            #endregion
            static public void Main(string[] args)
            {
                treeNode r = new treeNode("user", "hazem");
                r.Tvalue = "haze";
                treeNode ch = new treeNode("age", "29");
                ch.Tvalue = "29";
                treeNode ch2 = new treeNode("age", "27");
                ch2.Tvalue = "27";
                treeNode ch3 = new treeNode("tasd", "123");
                //ch2.Tvalue = "123";
                ch2.Value.Add("123456789");
                r.addChild(ch);
                //ch.addChild(ch3);
                r.addChild(ch2);
                Console.WriteLine(r.search("age"));




                List<string> xml = new List<string>() { "<?xml version123?>","<catalog>","<book>","<author>","gamnbera","mathew",
            "</author>","<title>","Xml dev guide","</title>","</book>"
            ,"<book>","<author>","Hazem","codm engineer",
            "</author>","<title>","fantastic tree node","</title>","</book>"
            ,  "</catalog>" };

                /*List<string> xml = new List<string>() { "<?xml version123?>","<root>","<book>","<author>",
                "</author>","</book>" ,"</root>" };*/
                int index = 1;
                Stack<string> st = new Stack<string>();
                treeNode root = new treeNode();


                //  Console.Out(de.json);
                // Console.save


                treeNode pointer = root;

                Console.WriteLine(xml.Count());

                while (index < xml.Count())
                {

                    string s = xml[index].ToString();

                    // check last index error
                    // string a = xml[index + 1].ToString();

                    // stack push
                    if (s.Substring(0, 2)[0] == '<' && s.Substring(0, 2)[1] != '/')
                    {


                        // push tag without <>
                        string z = s.Substring(1, xml[index].Count() - 2);
                        st.Push(z);
                        // first time
                        if (root.tagname == null)
                        {
                            root.tagname = z;

                            pointer.tagname = z;

                            /* trivial*/

                            // check next if there are some value

                            /*if (a.Substring(0, 2)[0]!='<')
                            {
                                // then it is value
                                root.Value.Add(a);
                                // next next iteration
                                index += 2;
                                continue;
                            }
                            //next iteration
                            index++;
                            continue;*/
                        }
                        ////\\\\\\
                        ///cool comment\\\\\\
                        ///////\\\\\
                        ///
                        else
                        {
                            treeNode temp = new treeNode();
                            //temp
                            temp.tagname = z;

                            // pointer addChild
                            pointer.addChild(temp);
                            // now point to new child
                            pointer = temp;

                            /* if (a.Substring(0, 2)[0] != '<')
                             {
                                 // then it is value
                                 //temp.Value.Add(a);
                                 pointer.Value.Add(a);
                                 // next next iteration
                                 index += 2;
                                 continue;
                             }
                             //next iteration
                             index++;
                             continue;*/

                        }
                        // string tab_space= "   "
                        // .lenght() * tab_sapce
                        // len =3
                        // string builder a for 3
                        //load(file.json)

                    }
                    // stack pop
                    if (s.Substring(0, 2)[0] == '<' && s.Substring(0, 2)[1] == '/')
                    {
                        // assume tis is same as last in stack
                        // so we wont do a check
                        st.Pop();

                        // go back to parent
                        pointer = pointer.parent;


                    }
                    // normal data
                    if (s.Substring(0, 2)[0] != '<')
                    {

                        pointer.Value.Add(s);

                    }
                    index++;
                }

                root.jsonPrinter(root);
                Console.ReadLine();
            }
            /*static public void Main(string[] args)
            {

                treeNode root = new treeNode(1);

    /*
                TextReader qwe ;
                qwe.ReadToEnd("C:\\Users\\oeb\\Downloads\\tree_work_1.1.txt");
    */
            /*
                        XmlDocument doc = new XmlDocument();
                        doc.Load("C:\\Users\\oeb\\Downloads\\tree_work_1.1.txt");
                        doc.Save("C:\\Users\\oeb\\Downloads\\tree.json");
            *//*
            treeNode r = new treeNode("user", "hazem");
            r.Tvalue = "haze";

            treeNode ch = new treeNode("age", "29");
            ch.Tvalue = "29";

            treeNode ch2 = new treeNode("age", "27");
            ch2.Tvalue = "27";

            treeNode ch3 = new treeNode("tasd", "123");
            //ch2.Tvalue = "123";
            ch2.Value.Add("123456789");

            r.addChild(ch);
            ch.addChild(ch3);
            r.addChild(ch2);
            Console.WriteLine("length c2 exepected 1 : " +
            ch2.length());
            foreach (var item in ch2.Value)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("length c3 exep 2 : " +    ch3.length());


            /*
            foreach (var item in r.children)
            {
                Console.WriteLine(item.tagname);
                Console.WriteLine(item.Value[0]);
            }
            r.xc(r);
            List<string> v =new List<string>() {"name", "age" };
            v.Add("x");
            foreach (string e in v)
            {
                Console.WriteLine(e);
            }
            //Console.WriteLine(v);
            //ch2.tagname.ToString()
            int q = r.Value.FindIndex(0, ch2.Value.Count()-1,"age".StartsWith );

            for (int i = 0; i < v.Count() - 1; i++)
            {
                if (v[i] == "age")
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine(q);

            List<string> xml = new List<string>() { "<?xml version123?>","<catalog>","book","<author>","gamnbera","mathew",
            "</author>","<title>","Xml dev guide","</title>","</book>" ,"</catalog>" };

            string s = xml[1].ToString();
            string g = s.Substring(0,2);
            if (g[0] == '<' && g[1] != '/')
            {
                Console.WriteLine(g);
                string z = s.Substring(1, xml[1].Count() - 2);
                Console.WriteLine(z);

            }
            Console.WriteLine(g);*/

            /*
                        //root.addChild(5);
                        List<int> x=new List<int>();
                        x.Add(2); x.Add(11); x.Add(3); x.Add(4); x.Add(5);
                        //root.children = 2;

                        treeNode temp = new treeNode(2);

                        treeNode t = new treeNode(3);
                        treeNode c1 = new treeNode(9);
                        treeNode c = new treeNode(8);
                        t.addChild(c1);
                        t.addChild(c);
                        treeNode t1 = new treeNode(4);
                        treeNode t2 = new treeNode(5);

                    // root.addChild(temp);
                    for (int i = 0; i < 13; i++)
                      {
                          treeNode t3 = new treeNode(i);
                          //t.tagValue = i;
                          temp.addChild(t3);
                      }
                        temp.addChild(t2);

                        root.addChild(temp);
                  // root.addChild(t);
                   //root.addChild(t1);
                   //root.addChild(t2);


                   // root = Generate(root);
                   List<int> order = root.PreOrder();
                   foreach (int num in order)
                       Console.Write(num + " ");*/
            /*
            Console.ReadKey();
   }*/

        }
        class MyClass
        {
            List<string> xml = new List<string>() { "<?xml version123?>","<catalog>","book","<author>","gamnbera","mathew",
            "</author>","<title>","Xml dev guide","</title>","</book>" ,"</catalog>" };



            //------------------------------------------------------------------------------
            /// <summary>
            // pointer treeNode()
            //read
            // push stack if <>
            /*
             * temp  treeNode()
             *get tagName
             *get value
             * !#search parent
             *addChild to  (parent)
             */
            //pop stack if </> and pointer=this.parent
            ///</summary>
            /////------------------------------------------------------------------------------
            ///

            public void parser()
            {
                List<string> xml = new List<string>() { "<?xml version123?>","<catalog>","book","<author>","gamnbera","mathew",
            "</author>","<title>","Xml dev guide","</title>","</book>" ,"</catalog>" };

                int index = 1;
                Stack<string> st = new Stack<string>();
                treeNode root = new treeNode();


                //  Console.Out(de.json);
                // Console.save


                treeNode pointer = root;

                Console.WriteLine(xml.Count());

                while (index < xml.Count())
                {

                    string s = xml[index].ToString();

                    // check last index error
                    // string a = xml[index + 1].ToString();

                    // stack push
                    if (s.Substring(0, 2)[0] == '<' && s.Substring(0, 2)[1] != '/')
                    {


                        // push tag without <>
                        string z = s.Substring(1, xml[index].Count() - 2);
                        st.Push(z);
                        // first time
                        if (root.tagname == null)
                        {
                            root.tagname = z;

                            pointer.tagname = z;

                            /* trivial*/

                            // check next if there are some value

                            /*if (a.Substring(0, 2)[0]!='<')
                            {
                                // then it is value
                                root.Value.Add(a);
                                // next next iteration
                                index += 2;
                                continue;
                            }
                            //next iteration
                            index++;
                            continue;*/
                        }
                        ////\\\\\\
                        ///cool comment\\\\\\
                        ///////\\\\\
                        ///
                        else
                        {
                            treeNode temp = new treeNode();
                            //temp
                            temp.tagname = z;

                            // pointer addChild
                            pointer.addChild(temp);
                            // now point to new child
                            pointer = temp;

                            /* if (a.Substring(0, 2)[0] != '<')
                             {
                                 // then it is value
                                 //temp.Value.Add(a);
                                 pointer.Value.Add(a);
                                 // next next iteration
                                 index += 2;
                                 continue;
                             }
                             //next iteration
                             index++;
                             continue;*/

                        }
                        // string tab_space= "   "
                        // .lenght() * tab_sapce
                        // len =3
                        // string builder a for 3
                        //load(file.json)

                    }
                    // stack pop
                    if (s.Substring(0, 2)[0] == '<' && s.Substring(0, 2)[1] == '/')
                    {
                        // assume tis is same as last in stack
                        // so we wont do a check
                        st.Pop();

                        // go back to parent
                        pointer = pointer.parent;


                    }
                    // normal data
                    if (s.Substring(0, 2)[0] != '<')
                    {

                        pointer.Value.Add(s);

                    }
                    index++;
                }

            }
        }


    }

}
