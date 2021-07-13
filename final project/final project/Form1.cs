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
            if (choosereq.SelectedItem.ToString() == "Minify xml file")
            {
                minified_output_file = 1;
            }
            else if(choosereq.SelectedItem.ToString() == "Check cosistancy")
                consistancy_output_file = 1;
        }

        string secondArg; string xmlString;
        int minified_output_file = 0;
        int consistancy_output_file = 0;
        string[] consistancy_arr;
        string consistancy;
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(XML_file_location.Text))
                MessageBox.Show("Please! Insert data first.", "Error");
           // int index1, index2;
           // int spaces = 0;
            string file_location = XML_file_location.Text;
            string[] files = System.IO.Directory.GetFiles(file_location, "*.xml"); //get all files in directory with xml extension
            xmlString = System.IO.File.ReadAllText(files[0]);  // get first xml file in files array and convert it to string
            CheckConsistency(ref consistancy_arr, xmlString,ref consistancy);
            if (minified_output_file == 1)
                secondArg= minify_XML(consistancy);


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

        private void button2_Click(object sender, EventArgs e)
        {
            if (minified_output_file==1)
            richTextBox1.Text = xmlString;   
            else if(consistancy_output_file==1)
            richTextBox1.Text = xmlString;   
                
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

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (minified_output_file == 1)
                richTextBox2.Text = secondArg;
            else if (consistancy_output_file == 1)
                richTextBox2.Text = consistancy;
        }

        /*----------------------------------------------------------------------------*/
        /*------------------------consistancy code------------------------------------*/
        class StackElement
        {
            string Sentence;
            int index;

            public StackElement(string sen, int i)
            {
                this.Sentence = sen;
                this.index = i;
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

        static void CheckConsistency(ref string[] XML_array, string inputText,ref string finalXMLString)
        {
            //string fileDestination = @"C:\Users\Haidy\Downloads\DS_Project\";
           // string[] files = System.IO.Directory.GetFiles(fileDestination, "*.xml");
            //string inputText = System.IO.File.ReadAllText(files[0]);

            //Stack for Tags, to check for consistency.
            Stack<StackElement> Tagstack = new Stack<StackElement>();


            //Counter to help us predict where to add an opening tag
            //if it is missing
            int OpeningTagNumber = 0;

            //we remove the newline characters in the string in order to deal with it better
            //this can also be using in minifying the string

            string sentence = "";
            int loopIndex = 0;
            bool isSpace = false;
            //Console.WriteLine(inputText.Length);
            while (loopIndex != inputText.Length)
            {
                if (inputText[loopIndex] == '\r' || inputText[loopIndex] == '\n')
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
                    }
                    loopIndex++;
                    continue;
                }
                sentence += inputText[loopIndex];
                loopIndex++;
            }

            //empty array that will contain all elements of XML seperated the right way
            //we first initialize it to the length of the previous XML array
            //and if we need to resize it along the way, we will
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


            j = 0;
            while (j != sentence.Trim().Length)
            {

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
                        StackElement s1 = new StackElement(temp, OpeningTagNumber);
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
                            // Console.Write("Inconsistent, either opening tag is missing!\n");
                            // Console.Write("Or tags in stack missing closing tag!\n");

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

                                // Console.Write("Found empty Stack, Adding new Opening Tag\n");



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
                                        resizeArraybyOne(ref XML_array, XML_array.Length, ref index2, temp2.Substring(0, 1) + "/" + temp2.Substring(1));
                                        XML_index++;
                                        OpeningTagNumber++;

                                        //***********************//


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
                        temp += sentence[j];
                        // if(sentence[j] == ',')
                        // {
                        //     temp+="\n";
                        // }
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





            if (Tagstack.Count == 0)
            {
                Console.WriteLine("All good!");
            }
            else
            {
               // Console.WriteLine("Missing Closing Tags!");
                while (Tagstack.Count != 0)
                {
                    temp = Tagstack.Peek().getSentence();
                    int index = Tagstack.Peek().getIndex();
                    Console.WriteLine($"{temp} index is {index} and Length is {XML_array.Length}");
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
            }

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
    /*------------------------------------------------------------------------------*/
    /*-------------------------minifying code---------------------------------------*/
    string minify_XML(string not_minified_XML)
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
            File.WriteAllText("OUTPUT1.xml", secondArg);
            return secondArg;

        }

    }
}
