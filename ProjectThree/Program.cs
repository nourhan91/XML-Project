using System;
using System.Collections.Generic;
using System.IO;


namespace ProjectThree
{
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




    class Program
    {

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
        static void printArray(string[] arr, int Length)
        {
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

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

        static void resizeArraytoDouble(ref string[] arr, int Length)
        {
            string[] newarr = new string[Length * 2];
            for (int i = 0; i < Length; i++)
            {
                newarr[i] = arr[i];
            }
            arr = newarr;
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


        static void Main(string[] args)
        {
            string fileDestination = @"C:\Users\Haidy\Downloads\DS_Project\";
            string[] files = System.IO.Directory.GetFiles(fileDestination, "*.xml");
            string inputText = System.IO.File.ReadAllText(files[0]);

            #region Fields
            //Stack for Tags, to check for consistency.
            Stack<StackElement> Tagstack = new Stack<StackElement>();

            //initializing list that will contain where errors are.
            List<KeyValuePair<long, KeyValuePair<string, string>>> errorList = new List<KeyValuePair<long, KeyValuePair<string, string>>>();

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
            string[] XML_array = new string[sentence.Length];

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

            string finalXMLString = "";
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
    }
}
