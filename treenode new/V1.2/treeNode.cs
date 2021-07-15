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

        //private (string, string) bute[] ;
        #endregion

        #region Constructors

        /// <summary>
        /// Constructors
        /// </summary>

        public treeNode(string tag, string x)
        {
            this.tagname = tag;
            this.Value = new List<string>();

            //this.Value.Add(x);
            Tagvalue = x;
            this.children = new List<treeNode>();
        }
        public treeNode()
        {
            this.tagname = null;
            this.parent = null;
            this.Value = new List<string>();
            this.children = new List<treeNode>();

            //this.tagAttribute = new List<(string attributeName, string attributeValue)>();
            //this.attribute = new List<Tuple<string ,string >>();

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


        public IEnumerable<string> Tval
        {
            //set { Value.Add(value); }
            get { return Value; }


        }
        public IEnumerable<treeNode> chil
        {
            get { return children; }
        }
        public string Tagname
        {
            get { return tagname; }
            set { tagname=value; }
        }


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

        public void jsonPrinter()
        {
            //make it xml[0]
            Console.WriteLine("begin");
            Console.WriteLine("{");
            jsonPrinter(this);
            Console.WriteLine("}");


        }
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
            for (int i = 0; i < data.Value.Count(); i++)
            {
                Console.Write("\"" + data.Value[i].ToString() + "\"" + "," + "\n");

            }
            foreach (treeNode ch in data.children)
            {
                ch.jsonPrinter(ch);
                Console.Write("}");
            }
            //Console.Write("}");



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



        public void xmlparser(ref List<string> xml)
        {
            int index = 1;

            treeNode pointer = this;

            while (index < xml.Count())
            {

                string s = xml[index].ToString();

                if (s.Substring(0, 2)[0] == '<' && s.Substring(0, 2)[1] != '/')
                {
                    // embedded
                    // make a check first
                    // <dfadfa id="adf">
                    int i = xml[index].ToString().IndexOf('=');

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
                        // string tab_space= "   "
                        // .lenght() * tab_sapce
                        // len =3
                        // string builder a for 3
                        //load(file.json)
                    }
                }
                // stack pop
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
            }
        }


        #endregion
        public void  method()
        {
            foreach (var item in this.chil)
            {
                Console.WriteLine(item.Tagname);
            }
        }
        static public void Main(string[] args)
        {

            treeNode r = new treeNode("user", "hazem");
            r.Tagvalue = "haze";


            treeNode ch = new treeNode("game", "29");
            //ch.Tagvalue = "29";
            //Console.WriteLine(ch.Tagvalue);

            treeNode ch2 = new treeNode("age", "27");
            ch2.Tagvalue = "27";
            treeNode ch3 = new treeNode("tasd", "123");
            //ch2.Tvalue = "123";
            ch2.Value.Add("123456789");
            r.addChild(ch);
            r.addChild(ch3);
            //ch.addChild(ch3);
            r.addChild(ch2);




            List<KeyValuePair<string, string>> Paira = new List<KeyValuePair<string, string>>();

            string phrase = "The quick id=\"123\" over the lazy dog.";
            string[] words = phrase.Split(' ');

            foreach (var word in words)
            {
                int equal = word.IndexOf('=');
                if (equal >= 0)
                {
                    //string before = word[0:equal-1];

                    string before = word.Substring(0, equal);
                    string after = word.Substring(equal + 1, word.Count() - equal-1);
                    //Paira.Add(new KeyValuePair<string, string>(before, after));
                    //System.Console.WriteLine($"<{before} ==== {after}>");
                }
            }


            //List<KeyValuePair<string, string>> Paira;
            //Paira.Add(new KeyValuePair<string, string>("before space", "after"));
            //"before space", "after ="
            foreach (var item in Paira)
            {

                Console.WriteLine(item.Key +":"+"{"+item.Value+"}");
            }
            Console.WriteLine(r.search("age"));


             List<string> xml = new List<string>() { "<?xml version123?>","<catalogs>","<catalog>","<book id=\"123\" >","<author>","gamnbera","mathew",
             "</author>","<title>","Xml dev guide","</title>","</book>"
             ,"<book>","<author>","Hazem","codm engineer",
             "</author>","<title>","fantastic tree node","</title>","</book>",  "</catalog>",

             "<catalog>","<book>","<author>","hazim","ali",
             "</author>","<title>","Xml dev guide","</title>","</book>"
             ,"<book>","<author>","Haidy","mandoba",
             "</author>","<title>","fantastic tree node","</title>","</book>"
             ,  "</catalog>"
             ,"</catalogs>"};

            treeNode root = new treeNode();


            Console.WriteLine("#####!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!####");
            treeNode t = new treeNode();

            t.xmlparser(ref xml);
            t.jsonPrinter();

            Console.WriteLine("#####search####");
            root.method();

            //MyClass.method();

            Console.ReadKey();
        }

    }
    class MyClass
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

    }
}
