using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class treeNode
    {
        #region attributes
        private string tagname;
        private List<string> Value;

        private treeNode parent;
        private List<treeNode> children;

        // att and attValue
        //public List<Tuple<string , string>> attribute;
        //public List<(string attributeName, string attributeValue)> tagAttribute;

        private List<KeyValuePair<string ,string >> Pairattribute;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>

        public treeNode(string tag, string tagval)
        {
            this.tagname = tag;
            this.Value = new List<string>();

            Tagvalue = tagval;
            this.children = new List<treeNode>();
        }
        public treeNode()
        {
            this.tagname = null;
            this.parent = null;
            this.Value = new List<string>();
            this.children = new List<treeNode>();
            this.Pairattribute = new List<KeyValuePair<string, string>>();
        }


        #endregion

        #region Properties

        /// <summary>
        /// Properties
        /// </summary>
        /// getters setters


        public treeNode Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public string Tagvalue
        {
            set { Value.Add(value); }
            get { return Value.LastOrDefault(); }


        }
        public string Tagname
        {
            get { return tagname; }
            set { tagname=value; }
        }


        public IEnumerable<string> Tval
        {
            //set { Value.Add(value); }
            get { return Value; }


        }
        public IEnumerable<treeNode> chil
        {
            get { return children; }
        }
        // override indexer operator for children
        public treeNode this[int i]
        {
            get => children[i];
            set => children[i] = value;
        }



        #endregion

        #region Methods

        public int addChild(treeNode data)
        {
            data.parent = this;
            this.children.Add(data);
            return 0;

        }

        ///\\\
        /// wrapper function
        /// \\\
        public void jsonPrinter()
        {
            //make it xml[0]
            Console.WriteLine("Json convert UWU ");
            Console.WriteLine("{");
            jsonPrinter(this);
            Console.WriteLine("}");


        }
        //----------------------------------------------------------------
        // <summary>
        //1) print the indentation
        //2) print tag attribute if any
        //3) print the tag value
        //4) recursion
        //5) closing brackets with the correct indentation
        // </summary>
        //-----------------------------------------------------------------

        public void jsonPrinter(treeNode data)
        {
            #region opening bracket indentation
            Helper.indentation_space(data.length(data));

            Console.Write("\"" + data.tagname + "\" :");

            if (data.children.Count() > 1)
            {
                Console.Write("{\n");
            }
            else if (data.Value.Count>1)
            {
                Console.Write("[\n");
            }
            #endregion


            #region tag attribute
            foreach (var attribute in data.Pairattribute)
            {
                Helper.indentation_space(data.length(data) + 1);
                Console.Write("@"+ "\"" + attribute.Key + "\"" + ":" + attribute.Value );
                Console.Write("\n");
            }

            #endregion

            #region tag value
            // value
            for (int i = 0; i < data.Value.Count(); i++)
            {
                if (data.Value.Count() ==1)
                {
                    Console.Write("\"" + data.Value[i].ToString() + "\"");
                }
                else
                {
                    Helper.indentation_space(data.length(data) + 1);
                    Console.Write("\"" + data.Value[i].ToString() + "\"");
                    if (i < data.Value.Count() - 1)
                    {
                        Console.Write(",");
                    }
                }
                Console.Write("\n");
            }
            #endregion
            //recursion
            #region recursion
            foreach (treeNode ch in data.children)
            {
                //do the closing value check here
                // then check under
                int c = ch.children.Count();
                int v = ch.Value.Count;

                ch.jsonPrinter(ch);
                #region closing bracket indentation
                //closing
                if (c > 1)
                {
                    Helper.indentation_space(ch.length(ch));
                    Console.Write("}\n");
                }
                else if (v > 1)
                {
                    Helper.indentation_space(ch.length(ch));
                    Console.Write("]\n");
                }
                #endregion
            }
            #endregion

        }

        int length(treeNode tr)
        {

            if (tr == null)
                return 0;
            else
            {
                int len = tr.length(tr.parent);
                return len + 1;
            }
        }

        // the bitch stackoverflow error
        /*public int length(treeNode tr)
        {

            if (tr.parent == null)
                return 0;
            else
                // right here
                return length(tr) +1;
        }*/

        // wrong need some edits
        /*
        public int length(treeNode tr)
        {
            treeNode temp = new treeNode();
            int len = 1;
            if (this.parent == null)
                return len;

            temp = this.parent;

                while (temp.parent != null)
                {
                    len++;
                    temp = temp.parent;
                }
            return len;
        }*/

        ///\\\----------
        /// <summary>
        /// not complete and i won't---
        /// </summary>
        ///\\\----------

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

        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// 1) check for opening tag
        /// 1.1)check for tag attribute
        /// 1.11) assign the attribute
        /// 2) make new node and assign the tag name then add it as child to current node
        /// 3) closing tag point to the parent
        /// 5) normal data value assignment
        /// repeat
        /// </summary>
        //----------------------------------------------------------------------------------------------
        public void xmlparser(ref List<string> xml)
        {
            int index = 1;

            treeNode pointer = this;

            while (index < xml.Count())
            {

                string s = xml[index].ToString();
                # region opening tag

                if (s.Substring(0, 2)[0] == '<' && s.Substring(0, 2)[1] != '/')
                {
                    // embedded
                    // make a check first
                    int i = xml[index].ToString().IndexOf('=');
                    # region tag attribute
                    if (i>=0)
                    {
                        string[] words = xml[index].ToString().Split(' ');

                        // assume that first is the tag name
                        treeNode temp = new treeNode();
                        // <book  => book

                        //temp
                        temp.tagname = words[0].Substring(1, words[0].Count() - 1);

                        // push tag without <>

                        foreach (var word in words)
                        {
                            int equal= word.IndexOf('=');
                            if (equal>=0)
                            {
                                string before = word.Substring(0,equal);
                                string after = word.Substring(equal+1,word.Count()-equal-1);
                                temp.Pairattribute.Add(new KeyValuePair<string, string>(before, after));
                            }
                        }
                        // pointer addChild
                        pointer.addChild(temp);

                        // now point to new child
                        pointer = temp;
                    }
                    #endregion
                    # region add child
                    else
                    {
                        // push tag without <>
                        string z = s.Substring(1, xml[index].Count() - 2);
                        // first time
                        if (this.tagname == null)
                        {
                            pointer.tagname = z;
                        }
                        else
                        {
                            treeNode temp = new treeNode();
                            //temp
                            temp.tagname = z;

                            // pointer addChild
                            pointer.addChild(temp);
                            // now point to new child
                            pointer = temp;

                        }
                    }
                    #endregion
                }
                #endregion
                // stack pop
                # region closing tag
                if (s.Substring(0, 2)[0] == '<' && s.Substring(0, 2)[1] == '/')
                {
                    // assume tis is same as last in stack
                    // so we wont do a check

                    // go back to parent
                    pointer = pointer.parent;
                }
                // normal data
                if (s.Substring(0, 2)[0] != '<')
                {
                    pointer.Value.Add(s);
                }
                index++;
                #endregion
            }
        }

        public void iterate_children()
        {
            foreach (var item in this.chil)
            {
                Console.WriteLine(item.Tagname);
            }
        }

        #endregion

        static public void Main(string[] args)
        {


            string[] ad = {  "<?xml version123?>","<catalogs>","<catalog>","<book id=\"123\" >","<author>","gamnbera","mathew",
             "</author>","<title>","Xml dev guide","</title>","</book>"
             ,"<book>","<author>","Hazem","codm engineer",
             "</author>","<title>","fantastic tree node","</title>","</book>",  "</catalog>",

             "<catalog>","<book>","<author>","hazim","ali",
             "</author>","<title>","Xml dev guide","</title>","</book>"
             ,"<book>","<author>","Haidy","mandoba",
             "</author>","<title>","fantastic tree node","</title>","</book>"
             ,  "</catalog>"
             ,"</catalogs>"};

            List<string> bn = new List<string>();
            bn=Helper.haidyCode(ref ad);

            treeNode t = new treeNode();
            t.xmlparser(ref bn);
            t.jsonPrinter();

            Console.ReadKey();
        }

    }
    //--------------------------------------
    /// <summary>
    /// helper methods
    /// </summary>
    //--------------------------------------
    class Helper
    {
        public static void method()
        {
            treeNode root = new treeNode("user", "hazem");
            root.Tagvalue = "ashraf";
            root.Tagvalue = "mondy";
            foreach (var item in root.Tval)
            {

                Console.WriteLine(item);
            }
        }

        public static List<string> haidyCode(ref string[] arr)
        {
            List<string> t = new List<string>();
            t.AddRange(arr);
            return t;
        }

        public static string indentation_space(int L)
        {
            string tab_spcae_value = "   ";
            string val="";
            for (int i = 0; i < L; i++)
            {
                val += tab_spcae_value;
                Console.Write(tab_spcae_value);
            }
            return val;
        }

    }
}
