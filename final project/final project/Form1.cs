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

        
        string secondArg; string xmlString;
        int minified_output_file = 0;
        int consistancy_output_file = 0;
        int compress_XML_file = 0;
        int indentation_flag = 0;
        int Decompress_XML_file = 0;
        int XML_TO_JSON = 0;
        string[] consistancy_arr;
        string consistancy;
        List<int> compressed_XML_file = new List <int>();
        string compressed_output="";
        string Decompressed_output;
        string xml_formating;
        string formating_and_minified;
        List<KeyValuePair<long, KeyValuePair<string, string>>> errorList = new List<KeyValuePair<long, KeyValuePair<string, string>>>();



        private void choosereq_SelectedIndexChanged(object sender, EventArgs e)      //elements of combo box
        {
            if (choosereq.SelectedItem.ToString() == "Minify xml file")
            {
                minified_output_file = 1;
                consistancy_output_file = 0;
                indentation_flag = 0;
                compress_XML_file = 0;
                Decompress_XML_file = 0;
                XML_TO_JSON = 0;
            }
            else if (choosereq.SelectedItem.ToString() == "Check cosistancy")
            {
                consistancy_output_file = 1;
                minified_output_file = 0;
                indentation_flag = 0;
                compress_XML_file = 0;
                Decompress_XML_file = 0;
                XML_TO_JSON = 0;
            }
            else if (choosereq.SelectedItem.ToString() == "Compress XML file")
            {
                compress_XML_file = 1;
                consistancy_output_file = 0;
                minified_output_file = 0;
                indentation_flag = 0;
                Decompress_XML_file = 0;
                XML_TO_JSON = 0;

            }
            else if (choosereq.SelectedItem.ToString() == "Check indentation")
            {
                indentation_flag = 1;
                compress_XML_file = 0;
                consistancy_output_file = 0;
                minified_output_file = 0;
                Decompress_XML_file = 0;
                XML_TO_JSON = 0;
            }
            else if (choosereq.SelectedItem.ToString() == "Decompress XML file")
            {
                Decompress_XML_file = 1;
                indentation_flag = 0;
                compress_XML_file = 0;
                consistancy_output_file = 0;
                minified_output_file = 0;
                XML_TO_JSON = 0;
            }
            else if (choosereq.SelectedItem.ToString() == "Convert XML to JSON")
            {
                XML_TO_JSON = 1;
                Decompress_XML_file = 0;
                indentation_flag = 0;
                compress_XML_file = 0;
                consistancy_output_file = 0;
                minified_output_file = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(XML_file_location.Text) || string.IsNullOrEmpty(XML_output_location.Text))
            {
                MessageBox.Show("Please! Insert file location ");
                return;
            }
            else
                MessageBox.Show("file location is inserted ");
            // int index1, index2;
            // int spaces = 0;
            string file_location = XML_file_location.Text;
            string output_file_location = XML_output_location.Text;
            string[] files = System.IO.Directory.GetFiles(file_location, "*.xml"); //get all files in directory with xml extension
            xmlString = System.IO.File.ReadAllText(files[0]);  // get first xml file in files array and convert it to string
           
            // we always check consistancy before any operation selectrd by user
          //  CheckConsistency(ref consistancy_arr, xmlString, ref consistancy);
            if(consistancy_output_file==1)
                CheckConsistency(ref consistancy_arr, xmlString, ref consistancy, ref errorList);

            else if (minified_output_file == 1)
            {
                CheckConsistency(ref consistancy_arr, xmlString, ref consistancy,ref errorList);
                secondArg = minify_XML(consistancy, output_file_location);
            }
            else if (indentation_flag == 1)
            {
                CheckConsistency(ref consistancy_arr, xmlString, ref consistancy, ref errorList);
                formating_and_minified = minify_XML(consistancy, output_file_location);
                //CheckConsistency(ref consistancy_arr, xmlString, ref consistancy, ref errorList);
                File.WriteAllText(output_file_location + "\\consistant_XML_file.xml", formating_and_minified);
                xml_formating = XML_Formating(output_file_location + "\\consistant_XML_file.xml", output_file_location);
            }
            else if (compress_XML_file == 1)
            {
                CheckConsistency(ref consistancy_arr, xmlString, ref consistancy, ref errorList);
                compressed_XML_file = Compress(xmlString);
                for (int i = 0; i < compressed_XML_file.Count; i++)
                {
                    compressed_output += compressed_XML_file[i];
                }
                File.WriteAllText(output_file_location + "\\compressed_output.xml", compressed_output);
            }
            else if (Decompress_XML_file == 1)
            {
                if (compressed_XML_file.Count == 0)
                {
                    MessageBox.Show("Please! you should compress XML file first");
                    return;
                }
                else
                {
                   // CheckConsistency(ref consistancy_arr, xmlString, ref consistancy);
                    Decompressed_output = Decompress(compressed_XML_file);
                    File.WriteAllText( output_file_location + "\\Decompressed.xml", Decompressed_output);
                }
            }
            else if(XML_TO_JSON==1)
            {

                treeNode.xml_to_json(file_location, output_file_location);
            }
        }
            /*string cleaned = xmlString.Replace("\n", "").Replace("\r", "");
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
            //textBox2.Text = secondArg;
            File.WriteAllText("OUTPUT1.xml", secondArg);
            */
        


       
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

        private void button2_Click(object sender, EventArgs e)                      //show input file
        {
            if (minified_output_file == 1)
                richTextBox1.Text = xmlString;
            else if (consistancy_output_file == 1)
                richTextBox1.Text = xmlString;
            else if (indentation_flag == 1)
                richTextBox1.Text = xmlString;
            else if(compress_XML_file==1)
                richTextBox1.Text = xmlString;
            else if(Decompress_XML_file == 1)
                richTextBox1.Text = xmlString;
            else if(XML_TO_JSON==1)
                richTextBox1.Text = xmlString;
        }
        private void button3_Click(object sender, EventArgs e)                     //show output file
        {
            if (minified_output_file == 1)
                richTextBox2.Text = secondArg;
            else if (consistancy_output_file == 1)
            {
                richTextBox2.Text = consistancy;
                List<string> finalList;

                finalList = new List<string>();

                makeList(ref errorList, ref finalList);
                Errors_list.Lines = finalList.ToArray();
            }
            else if (indentation_flag == 1)
                richTextBox2.Text = xml_formating;
            else if (compress_XML_file == 1)
                richTextBox2.Text = compressed_output;
            else if (Decompress_XML_file == 1)
                richTextBox2.Text = Decompressed_output;
            else if (XML_TO_JSON == 1)
            {
                string file_location = XML_file_location.Text;
                string output_file_location = XML_output_location.Text;
                string[] files = System.IO.Directory.GetFiles(output_file_location, "*.txt"); //get all files in directory with xml extension
               string json_string = System.IO.File.ReadAllText(files[0]);                                          // xmlString = System.IO.File.ReadAllText(files[0]);  // get first xml file in files array and convert
                richTextBox2.Text = json_string; 
            }
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click_1(object sender, EventArgs e)                  // clear_button
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            minified_output_file = 0;
            consistancy_output_file = 0;
            indentation_flag = 0;
            compress_XML_file = 0;
            Decompress_XML_file = 0;
        }
       
        private void XML_output_location_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void XML_file_location_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Take_request_Click(object sender, EventArgs e)
        {

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }              //showing input and output xml files
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Errors_list_TextChanged(object sender, EventArgs e)
        {

        }


        /*----------------------------------------------------------------------------*/
        /*------------------------consistancy code------------------------------------*/
        class StackElement
        {
            string Sentence;
            int index;

            int LineNumber;

            public StackElement(string sen, int i, int num)
            {
                this.Sentence = sen;
                this.index = i;
                this.LineNumber = num;
            }

            public void setLineNumber(int n)
            {
                this.LineNumber = n;
            }

            public int getLineNumber()
            {
                return this.LineNumber;
            }

            public void setIndex(int i)
            {
                this.index = i;
            }
            public void setSentence(string Sen)
            {
                this.Sentence = Sen;
            }

            public int getIndex()
            {
                return this.index;
            }

            public string getSentence()
            {
                return this.Sentence;
            }
        }
        static void resizeArraytoDouble(ref string[] arr, int Length)
        {
            string[] newarr = new string[Length * 2];
            for (int i = 0; i < Length; i++)
            {
                newarr[i] = arr[i];
            }
            arr = newarr;

        }
        static bool findTagInStack(Stack<StackElement> S1, string Tag)
        {
            /// <summary>
            /// function to find whether a tag exists in the stack or not.
            /// </summary>
            /// <typeparam name="StackElement"></typeparam>
            /// <returns></returns>
            Stack<StackElement> TempStack = new Stack<StackElement>();
            if (S1.Count == 0)
            {
                return false;
            }

            while (S1.Count != 0)
            {
                if (S1.Peek().getSentence() == Tag)
                {
                    while (TempStack.Count != 0)
                    {
                        S1.Push(TempStack.Peek());
                        TempStack.Pop();
                    }
                    return true;
                }
                TempStack.Push(S1.Peek());
                S1.Pop();
            }

            while (TempStack.Count != 0)
            {
                S1.Push(TempStack.Peek());
                TempStack.Pop();
            }

            return false;
        }
        static void resizeArraybyOne(ref string[] arr, int Length, ref int TagNum, string NewElement)
        {
            // create a new array of size n+1
            string[] newarr = new string[Length + 1];

            // insert the elements from the 
            // old array into the new array
            // insert all elements till pos
            // then insert Tag at pos
            // then insert rest of the elements
            for (int i = 0; i < Length + 1; i++)
            {
                if (i < TagNum)
                    newarr[i] = arr[i];
                else if (i == TagNum)
                    newarr[i] = NewElement;
                else
                    newarr[i] = arr[i - 1];
            }
            TagNum += 2;
            arr = newarr;

        }
        static void CheckConsistency(ref string[] XML_array, string inputText, ref string finalXMLString, ref List<KeyValuePair<long, KeyValuePair<string, string>>> errorList)
        {
            #region Fields
            //Stack for Tags, to check for consistency.
            Stack<StackElement> Tagstack = new Stack<StackElement>();

            //initializing list that will contain where errors are.
            errorList = new List<KeyValuePair<long, KeyValuePair<string, string>>>();

            //Counter to help us predict where to add an opening tag
            //if it is missing
            int OpeningTagNumber = 0;


            string sentence = "";
            int loopIndex = 0;
            bool isSpace = false;
            List<int> lineLengths = new List<int>();
            int lineLength = 0;
            #endregion


            //removing spaces from the input string in order to deal with it better.
            //we also calculate each line length along the way because it will help us
            //in visualizing the errors.
            #region Remove space
            while (loopIndex != inputText.Length)
            {
                if (inputText[loopIndex] == '\r')
                {
                    loopIndex++;
                    if (inputText[loopIndex] == ' ')
                    {
                        isSpace = true;
                    }
                    continue;
                }

                if (isSpace)
                {
                    if (inputText[loopIndex] != ' ')
                    {
                        isSpace = false;
                        loopIndex--;
                        lineLength--;
                    }
                    loopIndex++;
                    lineLength++;
                    continue;
                }
                sentence += inputText[loopIndex];
                if (inputText[loopIndex] == '\n')
                {
                    isSpace = true;
                    lineLengths.Add(lineLength);
                    lineLength = 0;
                }
                else
                {
                    lineLength++;
                }
                loopIndex++;
            }
            #endregion

            //empty array that will contain all elements of XML seperated the right way
            //we first initialize it to the length of the previous XML array
            //and if we need to resize it along the way, we will
            #region Parser and error detector
            #region Parser Fields
            XML_array = new string[sentence.Length];

            //current index of the final array.
            int XML_index = 0;


            //index for looping over each string in the array to split it correctly
            int j;

            //a temporary array to store each splitted part before storing it
            string temp = "";


            //we assume generic structure <tag1><tag2>sentence</tag2></tag1> etc

            //in case tag contains id or something, ex <book id = "1">
            //we want to store it in final array that way but not in the tag stack
            string sentence2 = "";
            bool isLongTag = false;

            ///index used to loop over a string
            j = 0;

            //determines the line number so we can use it in case of an error
            int LineNumber = 0;

            #endregion
            //Code for parsing the string
            while (j != sentence.Trim().Length)
            {
                if (sentence[j] == '\n')
                {
                    j++;
                    LineNumber++;
                    continue;
                }

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
                            if (sentence[j] == ' ')
                            {
                                isLongTag = true;
                                sentence2 = temp;
                                while (sentence[j] != '>')
                                {
                                    sentence2 += sentence[j];
                                    j++;
                                }
                                sentence2 += ">";

                            }
                            else
                            {
                                temp += sentence[j];
                                j++;
                            }
                        }
                        temp += ">";
                        j++;
                        if (temp.Contains("xml"))
                        {
                            //in order to skip the first line
                            //but also add it to the final array
                            XML_array[XML_index] = sentence2;
                            XML_index++;
                            temp = "";
                            sentence2 = "";
                            isLongTag = false;
                            continue;
                        }
                        //if stack is empty, then current tag number index is 1
                        if (Tagstack.Count == 0)
                        {
                            OpeningTagNumber = 1;
                        }
                        else
                        {
                            OpeningTagNumber++;
                        }


                        //add opening tag to stack
                        StackElement s1 = new StackElement(temp, OpeningTagNumber, LineNumber);
                        Tagstack.Push(s1);


                        //add tag to the final array and increase index
                        string storedValue = "";
                        if (isLongTag)
                        {
                            storedValue = sentence2;
                            isLongTag = false;
                        }
                        else
                        {
                            storedValue = temp;
                        }
                        if (XML_index != XML_array.Length)
                        {
                            XML_array[XML_index] = storedValue;
                            XML_index++;
                        }
                        else
                        {
                            //array is full, resize it.
                            resizeArraytoDouble(ref XML_array, XML_array.Length);
                            XML_array[XML_index] = storedValue;
                            XML_index++;
                        }


                        //empty temp string after adding it to array.
                        temp = "";

                    }

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
                        //if stack is empty then the tags are inconsistent
                        //we have to fix the error and add a closing tag

                        if (temp != Tagstack.Peek().getSentence() || Tagstack.Count == 0)
                        {

                            //we first try to find opening tag for the closing tag, if it exists
                            //but very far behind in stack, so we add closing tags
                            //for current opening tags until we reach the closing tag

                            //if not, then it is non existent, we create an opening tag for it

                            //if the stack is originally empty, we just add the opening tag and
                            //then the closing tag

                            if (Tagstack.Count == 0) //empty stack, so opening tag is missing.
                            {
                                //add opening tag for the current closing tag
                                //then add the closing tag

                                resizeArraybyOne(ref XML_array, XML_array.Length, ref OpeningTagNumber, temp);
                                XML_index++;
                                XML_array[XML_index] = temp.Substring(0, 1) + "/" + temp.Substring(1);
                                XML_index++;
                                temp = "";
                                continue;
                            }

                            else
                            {
                                //stack is not empty
                                //so we try to find opening tag of closing tag or add it if not found

                                string temp2 = "";


                                //searching for opening tag in stack.

                                bool isFound = findTagInStack(Tagstack, temp);

                                //if found, we add closing tags for all current opening tags till we reach it.

                                if (isFound)
                                {
                                    while (Tagstack.Count != 0 && Tagstack.Peek().getSentence().Trim() != temp.Trim())
                                    {

                                        //adding closing tags to current tags until we find
                                        //opening tag for current closing tag
                                        //if we find it, we exit
                                        temp2 = Tagstack.Peek().getSentence();
                                        int index2 = Tagstack.Peek().getIndex();
                                        int LineNum = Tagstack.Peek().getLineNumber();

                                        addtoList(ref errorList, LineNum, temp2.Substring(0, 1) + "/" + temp2.Substring(1), "Missing Closing Tag");

                                        resizeArraybyOne(ref XML_array, XML_array.Length, ref index2, temp2.Substring(0, 1) + "/" + temp2.Substring(1));
                                        XML_index++;
                                        OpeningTagNumber++;
                                        int current_index = Tagstack.Peek().getIndex() + 1;
                                        Tagstack.Pop();
                                        if (Tagstack.Count != 0) //test if also the last element in the final array is a string or not
                                                                 //before increasing it.
                                        {

                                            int index = Tagstack.Peek().getIndex(); //index of current tag
                                            if (XML_array[index - 1][0] == '<')
                                            {
                                                Tagstack.Peek().setIndex(current_index);
                                            }
                                        }
                                    }

                                    if (Tagstack.Peek().getSentence().Trim() == temp.Trim())
                                    {
                                        if (XML_index != XML_array.Length)
                                        {
                                            XML_array[XML_index] = temp.Substring(0, 1) + "/" + temp.Substring(1); ;
                                            XML_index++;
                                        }
                                        else
                                        {
                                            resizeArraytoDouble(ref XML_array, XML_array.Length);
                                            XML_array[XML_index] = temp.Substring(0, 1) + "/" + temp.Substring(1); ;
                                            XML_index++;
                                        }
                                        int current_index = Tagstack.Peek().getIndex() + 1;
                                        Tagstack.Pop();
                                        if (Tagstack.Count != 0)
                                        {
                                            int index = Tagstack.Peek().getIndex();
                                            if (XML_array[index - 1][0] == '<')
                                            {
                                                Tagstack.Peek().setIndex(current_index);

                                            }
                                        }
                                        temp = "";
                                        OpeningTagNumber++;
                                        continue;
                                    }
                                    temp = "";
                                }

                                else //empty stack, so opening tag is missing.
                                {


                                    addtoList(ref errorList, LineNumber, temp, "Missing Opening Tag");

                                    //add opening tag and closing tag.
                                    resizeArraybyOne(ref XML_array, XML_array.Length, ref OpeningTagNumber, temp);
                                    XML_index++;
                                    XML_array[XML_index] = temp.Substring(0, 1) + "/" + temp.Substring(1);
                                    XML_index++;
                                    temp = "";
                                    continue;
                                }

                            }

                        }
                        else
                        {
                            if (XML_index != XML_array.Length)
                            {
                                XML_array[XML_index] = temp.Substring(0, 1) + "/" + temp.Substring(1); ;
                                XML_index++;
                            }
                            else
                            {
                                resizeArraytoDouble(ref XML_array, XML_array.Length);
                                XML_array[XML_index] = temp.Substring(0, 1) + "/" + temp.Substring(1); ;
                                XML_index++;
                            }
                            int current_index = Tagstack.Peek().getIndex() + 1;
                            Tagstack.Pop();
                            if (Tagstack.Count != 0)
                            {
                                int index = Tagstack.Peek().getIndex();
                                if (XML_array[index - 1][0] == '<')
                                {
                                    Tagstack.Peek().setIndex(current_index);

                                }
                            }
                            temp = "";
                            OpeningTagNumber++;

                        }
                    }
                }
                else
                {
                    //not an opening tag or a closing tag
                    //just a sentence
                    //needed for the final array
                    while (j != sentence.Trim().Length && sentence[j] != '<')
                    {
                        if (sentence[j] == '\n')
                        {
                            j++;
                            LineNumber++;
                            continue;
                        }
                        temp += sentence[j];
                        j++;
                    }




                    if (XML_index != XML_array.Length)
                    {
                        XML_array[XML_index] = temp;
                        XML_index++;
                    }
                    else
                    {
                        resizeArraytoDouble(ref XML_array, XML_array.Length);
                        XML_array[XML_index] = temp;
                        XML_index++;
                    }
                    OpeningTagNumber++;
                    StackElement element = Tagstack.Peek();
                    int index = element.getIndex() + 2;
                    if (XML_index == index)
                    {
                        element.setIndex((index));
                    }
                    Tagstack.Pop();
                    Tagstack.Push(element);
                    temp = "";
                }
            }

            #endregion


            #region finishing
            //After finishing, if there are tags still in stack we add them
            while (Tagstack.Count != 0)
            {
                temp = Tagstack.Peek().getSentence();
                int index = Tagstack.Peek().getIndex();
                int LineNum = Tagstack.Peek().getLineNumber();

                addtoList(ref errorList, LineNum, temp.Substring(0, 1) + "/" + temp.Substring(1), "Missing Closing Tag");

                resizeArraybyOne(ref XML_array, XML_array.Length, ref index, temp.Substring(0, 1) + "/" + temp.Substring(1));
                OpeningTagNumber++;
                int current_index = Tagstack.Peek().getIndex() + 1;
                string current_Tag = Tagstack.Peek().getSentence();
                Tagstack.Pop();
                if (Tagstack.Count != 0)
                {
                    int ind = Tagstack.Peek().getIndex();
                    if (XML_array[ind - 1][0] == '<')
                    {
                        if (current_Tag == XML_array[XML_index])
                        {
                            Tagstack.Peek().setIndex(current_index);
                        }
                        else
                        {
                            Tagstack.Peek().setIndex(XML_index);
                        }
                    }
                }
                XML_index++;
            }

            #endregion

             finalXMLString = "";
            //to group all of them again

            for (int i = 0; i < XML_index; i++)
            {
                finalXMLString += XML_array[i];
                if (i != XML_index - 1)
                {
                    finalXMLString += "\n";
                }
            }

        }
        public static void makeList(ref List<KeyValuePair<long, KeyValuePair<string, string>>> error, ref List<string> output)
        {
            foreach (var item in error)
            {
                string x = "Line number : " + item.Key + " , " + "Error : " + item.Value.Key + " , " + "Error type : " + item.Value.Value;
                output.Add(x);
            }
        }
        public static void addtoList(ref List<KeyValuePair<long, KeyValuePair<string, string>>> errorList, long line, string err_location, string errType)
        {
            errorList.Add(new KeyValuePair<long, KeyValuePair<string, string>>(line, new KeyValuePair<string, string>(err_location, errType)));
        }

        /*------------------------------------------------------------------------------*/
        /*-------------------------minifying code---------------------------------------*/
        string minify_XML(string not_minified_XML, string output_file_loc )                                               //o(n)
        {
            int index1, index2;
            int spaces = 0;
            string cleaned = not_minified_XML;
            cleaned = not_minified_XML.Replace("\n", "").Replace("\r", "");



            index1 = cleaned.IndexOf('<');
            index2 = cleaned.IndexOf('>');
            secondArg = cleaned.Substring(index1, (index2 - index1) + 1);
            cleaned = cleaned.Remove(0, index2 + 1);

            do
            {
                spaces = 0;
                index1 = cleaned.IndexOf('<');
                index2 = cleaned.IndexOf('>');
                //secondArg += xmlString.Substring(index1, (index2-index1)+1 );
                //xmlString = xmlString.Remove(0, index2+1 );
                for (int i = 0; i < index1; i++)
                {
                    if (cleaned[i] != ' ')
                    {
                        secondArg += cleaned.Substring(0, index2 + 1);  //(index2 - index1) + 1
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
            while (cleaned.Length != 0);
            File.WriteAllText(output_file_loc +"\\Minified XML file.xml", secondArg);
            return secondArg;

        }


       /*----------------------------------------------------------------------------*/
        /*------------------------------compress XML FILE----------------------------*/
        public static List<int> Compress(string uncompressed)
        {
            // build the dictionary
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < 256; i++)
                dictionary.Add(((char)i).ToString(), i);

            string w = string.Empty;
            List<int> compressed = new List<int>();

            foreach (char c in uncompressed)
            {
                string wc = w + c;
                if (dictionary.ContainsKey(wc))
                {
                    w = wc;
                }
                else
                {
                    // write w to output
                    compressed.Add(dictionary[w]);
                    // wc is a new sequence; add it to the dictionary
                    dictionary.Add(wc, dictionary.Count);
                    w = c.ToString();
                }
            }

            // write remaining output if necessary
            if (!string.IsNullOrEmpty(w))
                compressed.Add(dictionary[w]);

            return compressed;
        }

        /*---------------------------------------------------------------------------*/
        /*----------------------XML_Formating----------------------------------------*/
        static string XML_Formating(string file_location, string output_file_location)
        {

            /*XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\salma\Desktop\new1.xml");
            doc.Save(Console.Out);*/
            XmlDocument doc = new XmlDocument();
            XmlTextReader xtr = new XmlTextReader(file_location);
            // XmlTextReader xtr = new XmlTextReader(@"C:\Users\salma\Desktop\new1.xml");

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

                    //Console.WriteLine(S1);

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
                            while (count > 0)
                            {
                                S_parent = (XmlElement)S_parent.ParentNode;
                                count -= 1;
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
                    


                }
            }
            

        
            doc.Save(output_file_location + "\\formating.xml");
            // Console.ReadLine();
            string formatted_String = System.IO.File.ReadAllText(output_file_location + "\\formating.xml");
            return formatted_String;


        }         //o(n)

        /*---------------------------------------------------------------------------*/
        /*----------------------Decompress XML FILE----------------------------------*/

        public static string Decompress(List<int> compressed)                                    //o(n)
        {
            // build the dictionary
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            for (int i = 0; i < 256; i++)
                dictionary.Add(i, ((char)i).ToString());

            string w = dictionary[compressed[0]];
            compressed.RemoveAt(0);
            StringBuilder decompressed = new StringBuilder(w);

            foreach (int k in compressed)
            {
                string entry = null;
                if (dictionary.ContainsKey(k))
                    entry = dictionary[k];
                else if (k == dictionary.Count)
                    entry = w + w[0];

                decompressed.Append(entry);

                // new sequence; add it to the dictionary
                dictionary.Add(dictionary.Count, w + entry[0]);

                w = entry;
            }

            return decompressed.ToString();
        }

        /*------------------------------------------------------------------------------*/
        /*---------------------------------------XML_TO_JSON----------------------------------*/
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

            private List<KeyValuePair<string, string>> Pairattribute;

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
                #region opening bracket indentation
                Helper.indentation_space(data.length(data));

                Console.Write("\"" + data.tagname + "\" :");

                if (data.children.Count() > 1)
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
                    Helper.indentation_space(data.length(data) + 1);
                    Console.Write("@" + "\"" + attribute.Key + "\"" + ":" + attribute.Value);
                    Console.Write("\n");
                }

                #endregion

                #region tag value
                // value
                for (int i = 0; i < data.Value.Count(); i++)
                {
                    if (data.Value.Count() == 1)
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

            ///\\\
            /// wrapper function
            /// \\\
            ///

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
                    #region opening tag

                    if (s.Substring(0, 2)[0] == '<' && s.Substring(0, 2)[1] != '/')
                    {
                        // embedded
                        // make a check first
                        int i = xml[index].ToString().IndexOf('=');
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
                                    string before = word.Substring(0, equal);
                                    string after = word.Substring(equal + 1, word.Count() - equal - 2);
                                    temp.Pairattribute.Add(new KeyValuePair<string, string>(before, after));
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
                    #region closing tag
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
}
