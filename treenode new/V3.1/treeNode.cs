///\\\
/*fixed the length method.
add tag attribute feild
, parse it and converted to json format correcttly.
fixed xmlparser and added extra checks.
fixed json printer method adding indentation .
and some alot more checks for a correct format printing.
adding some helper methods:
one for indentation,
and another to convert xml string array to list.
*/
/*V3.1
 *  1) parsing :
 *  adding more test cases:
 *   1.1) ignore the version xml tag
 *   1.2) bug fixed if xml[index] has less than 3 char considered as tag value
 *   1.3) if one attribute has
 *  2) json printing more test cases:
 *  2.1) stack overflow error fixed
 *  2.2) error in pointer solved
 *  2.3) if tagName is null do not print and skip to next
 *  2.4) properly print indentation in tag attribute and tag value
 *  2.4) beautify test cases after the recursion
 */
///\\\
///\\\

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


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

        public List<KeyValuePair<string, string>> Pairattribute;

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
            set { tagname = value; }
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
            // for any reason it parsed wrong
            if (data.Tagname == null)
            {
                //  int x = 0;
                data.jsonPrinter(data.children[0]);
            }
            else
            {
                #region opening bracket indentation
                Helper.indentation_space(data.length(data));

                Console.Write("\"" + data.tagname + "\" :");

                if (data.children.Count() >= 1)
                {
                    Console.Write("{\n");
                }
                else if (data.Value.Count > 1)
                {
                    Console.Write("[\n");
                }
                #endregion


                #region tag attribute
                foreach (var attribute in data.Pairattribute)
                {
                    //first
                    string g = attribute.Key;
                    string g1 = attribute.Value;
                    KeyValuePair<string, string> a = data.Pairattribute[0];
                    string b = a.Key;
                    string c = a.Value;

                    // has attribute or first attribute
                    // print new line

                    if (data.Pairattribute.Count() == 1 || (g == b && g1 == c))
                    {
                        if (data.children.Count() <= 0)
                        {
                            Console.Write("\n");
                        }
                    }

                    Helper.indentation_space(data.length(data) + 1);
                    // if value was parsed wrong "value not "value"
                    // check istead for last if equal " do nothing
                    if (attribute.Value[attribute.Value.Count() - 1] == '\"')
                    {
                        // do nothing
                        Console.Write("@" + "\"" + attribute.Key + "\"" + ":" + attribute.Value);
                    }
                    else
                    {
                        // change
                        Console.Write("@" + "\"" + attribute.Key + "\"" + ":" + attribute.Value + "\"");
                    }
                    Console.Write("\n");
                }

                #endregion

                #region tag value
                // value
                for (int i = 0; i < data.Value.Count(); i++)
                {
                    //no need to print new line if printed before
                    if (data.Pairattribute.Count() <= 0)
                    {

                        Console.Write("\n");
                    }
                    Helper.indentation_space(data.length(data) + 1);
                    Console.Write("\"" + data.Value[i].ToString() + "\"");
                    if (i < data.Value.Count() - 1)
                    {
                        Console.Write(",");
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

                        Console.Write("},\n");
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


        }

        ///\\\
        /// wrapper function
        /// \\\
        ///

        // print output.json
        public void jsonPrinter(string output_loc)
        {
            //make it xml[0]
            string UserName = System.Environment.UserName;
            ///\\\
            /// <NOTE>
            /// put the path and name here please
            /// </NOTE>

            string fileName = output_loc + "\\1json.json";
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);

            Console.WriteLine("{");
            jsonPrinter(this);
            Console.WriteLine("}");

            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
        }

        ///\\\
        /// wrapper function
        /// \\\

        // print output.txt
        public void jsonPrinterTXT(string output_loc)
        {

            string UserName = System.Environment.UserName;
            ///\\\
            /// <NOTE>
            /// put the path and name here please
            /// </NOTE>

            string fileName = output_loc + "\\out_json.txt";
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);

            Console.WriteLine("{");
            jsonPrinter(this);
            Console.WriteLine("}");

            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();

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
            // ignore the version xml tag
            // <?x>
            if (xml[0].Substring(0, 2) == "<?")
            {
                index = 1;
            }
            else
            {
                index = 0;
            }


            treeNode pointer = this;

            while (index < xml.Count())
            {

                string s = xml[index].ToString();
                # region opening tag
                s.Count();
                // smaller than 3 then it is considered as a value
                if (s.Count() > 3)
                {

                    if (s.Substring(0, 2)[0] == '<' && s.Substring(0, 2)[1] != '/')
                    {
                        // embedded
                        // make a check first
                        int i = xml[index].ToString().IndexOf('=');
                        int apperacne = xml[index].ToString().Count(zx => zx == '=');

                        #region tag attribute
                        if (i >= 0)
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
                                int equal = word.IndexOf('=');
                                if (equal >= 0)
                                {
                                    // to take all after the "=" not just to next space
                                    if (apperacne == 1)
                                    {
                                        string before = word.Substring(0, equal);
                                        string after = xml[index].ToString().Substring(i + 1, xml[index].ToString().Count() - i - 2);
                                        temp.Pairattribute.Add(new KeyValuePair<string, string>(before, after));
                                    }
                                    else
                                    {


                                        string before = word.Substring(0, equal);
                                        string after = word.Substring(equal + 1, word.Count() - equal - 2);
                                        temp.Pairattribute.Add(new KeyValuePair<string, string>(before, after));
                                    }
                                }
                            }
                            // pointer addChild
                            pointer.addChild(temp);

                            // now point to new child
                            pointer = temp;
                        }
                        #endregion
                        #region add child
                        else
                        {
                            // push tag without <>
                            string z = s.Substring(1, xml[index].Count() - 2);
                            // first time
                            if (pointer.tagname == null)
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

                }
                // value
                else
                {
                    pointer.Value.Add(s);
                    index++;
                    continue;
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
            string path = @"C:\Users\oeb\Downloads\in";
            string outp = @"C:\Users\oeb\Downloads\in";
            treeNode t = new treeNode();


            treeNode.xml_to_json(path, outp);
            Console.ReadKey();

        }

        public static void xml_to_json(string loc, string output_loc)
        {
            List<string> bn = new List<string>();
            bn = Helper.xml_to_arr(loc);

            treeNode t = new treeNode();
            t.xmlparser(ref bn);
            t.jsonPrinterTXT(output_loc);
        }
    }
    //--------------------------------------
    /// <summary>
    /// helper methods
    /// </summary>
    //--------------------------------------
    class Helper
    {

        public static string indentation_space(int L)
        {
            string tab_spcae_value = "   ";
            string val = "";
            for (int i = 0; i < L; i++)
            {
                val += tab_spcae_value;
                Console.Write(tab_spcae_value);
            }
            return val;
        }

        public static List<string> xml_to_arr(string path)
        {
            string fileDestination = path;
            string[] files = System.IO.Directory.GetFiles(fileDestination, "*.xml");
            string text = System.IO.File.ReadAllText(files[0]);
            int loopIndex = 0;
            bool isSpace = false;
            string finalText = "";


            while (loopIndex != text.Length)
            {
                if (text[loopIndex] == '\r' || text[loopIndex] == '\t')
                {
                    loopIndex++;
                    if (text[loopIndex] == ' ')
                    {
                        isSpace = true;
                    }
                    continue;
                }

                if (isSpace)
                {
                    if (text[loopIndex] != ' ')
                    {
                        isSpace = false;
                        loopIndex--;
                    }
                    loopIndex++;
                    continue;
                }
                finalText += text[loopIndex];
                if (text[loopIndex] == '\n')
                {
                    isSpace = true;
                }
                loopIndex++;
            }

            Console.WriteLine(finalText);


            string[] sentences = finalText.Split('\n');

            //empty array that will contain all elements of XML seperated the right way
            List<string> XML_array = new List<String>();


            //current index of the final array.
            //int XML_index = 0;
            //index for looping over each string in the array to split it
            int j;

            //a temporary array to store each splitted part before storing it
            string temp = "";



            foreach (string sentence in sentences)
            {
                //Console.WriteLine(sentence);
                j = 0;
                while (j != sentence.Trim().Length)
                {
                    //Console.WriteLine($"Current j is {j}");

                    //check for tag
                    if (sentence[j] == '<')
                    {
                        temp += "<";
                        //check if opening tag
                        if (sentence[j + 1] != '/')
                        {
                            j++;
                            while (sentence[j] != '>')
                            {
                                temp += sentence[j];
                                j++;
                            }
                            temp += ">";
                            j++;
                            if (temp.Contains("xml"))
                            {
                                XML_array.Add(temp);
                                //Console.WriteLine($"Currently {temp} at {sentence}");
                                temp = "";
                                continue;
                            }

                            //Console.WriteLine($"Currently {temp} at {sentence}");
                            XML_array.Add(temp);

                            temp = "";

                        }

                        //if not opening tag, then it is closing tag
                        else
                        {

                            j += 2;
                            while (sentence[j] != '>')
                            {
                                temp += sentence[j];
                                j++;
                            }
                            temp += ">";
                            j++;
                            XML_array.Add(temp.Substring(0, 1) + "/" + temp.Substring(1));
                            temp = "";
                        }
                    }
                    else
                    {
                        //Console.WriteLine($"Currently {sentence}");
                        //not an opening tag or a closing tag
                        //just a sentence
                        //needed for the final array
                        while (j != sentence.Trim().Length && sentence[j] != '<')
                        {
                            temp += sentence[j];
                            //Console.WriteLine($"Temp is currently {temp} and j is {j}");
                            j++;
                        }
                        XML_array.Add(temp);
                        temp = "";
                    }
                }
            }


            return XML_array;
        }

    }
}