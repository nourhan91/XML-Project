using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

//on working with a txt file and converting it to string

namespace ProjectThree
{
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

        static string addIndentation(int indent)
        {
            string str = " ";
            if (indent == 0)
            {
                return "";
            }
            while (indent != 0)
            {
                str = str + " ";
                indent--;
            }
            return str;

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
        static void Main(string[] args)
        {
            string fileDestination = @"C:\Users\Haidy\Downloads\DS_Project\";
            string[] files = System.IO.Directory.GetFiles(fileDestination, "*.xml");
            string inputText = System.IO.File.ReadAllText(files[0]);
            //Console.WriteLine($"[{inputText[0]}]");

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
            Console.WriteLine(inputText.Length);
            while (loopIndex != inputText.Length)
            {
                // Console.WriteLine($"Currently [{inputText[loopIndex]} , {loopIndex}]");
                if (inputText[loopIndex] == '\r' || inputText[loopIndex] == '\n')
                {
                    loopIndex++;
                    if(inputText[loopIndex] == ' ')
                    {
                        isSpace = true;
                    }
                    continue;
                }
                if(isSpace)
                {
                    if(inputText[loopIndex] != ' ')
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

            //Console.WriteLine(sentence);
            //empty array that will contain all elements of XML seperated the right way
            //we first initialize it to the length of the previous XML array
            //and if we need to resize it along the way, we will
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
                            //Console.WriteLine($"{temp} tag number is {OpeningTagNumber}");
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

                        //Console.WriteLine($"Temp is currently {temp}");

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

                                //Console.WriteLine($"Index to add tag in is {OpeningTagNumber}");

                                resizeArraybyOne(ref XML_array, XML_array.Length, ref OpeningTagNumber, temp);
                                XML_index++;
                                // Console.Write("Tag Added!\n");
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

                                //Console.WriteLine(temp);

                                //searching for opening tag in stack.

                                bool isFound = findTagInStack(Tagstack, temp);
                                // Console.Write($"Searching for tag {temp} now.\n");
                                // if(Tagstack.Count == 0)
                                // {
                                //     Console.Write("Emptyy!\n");
                                // }

                                //if found, we add closing tags for all current opening tags till we reach it.

                                if (isFound)
                                {
                                    // Console.Write("Found Tag!\n");
                                    while (Tagstack.Count != 0 && Tagstack.Peek().getSentence().Trim() != temp.Trim())
                                    {
                                        // Console.Write($"[{Tagstack.Peek().getSentence()} , {Tagstack.Peek().getIndex()}]\n");
                                        // Console.Write($"[{temp}]\n");

                                        //adding closing tags to current tags until we find
                                        //opening tag for current closing tag
                                        //if we find it, we exit
                                        temp2 = Tagstack.Peek().getSentence();
                                        int index2 = Tagstack.Peek().getIndex();
                                        resizeArraybyOne(ref XML_array, XML_array.Length, ref index2, temp2.Substring(0, 1) + "/" + temp2.Substring(1));
                                        XML_index++;
                                        // Console.Write($"Tag Added! {temp2} at {index2}\n");
                                        OpeningTagNumber++;

                                        //***********************//


                                        int current_index = Tagstack.Peek().getIndex() + 1;
                                        // Console.WriteLine($"{Tagstack.Peek().getSentence()} its index is {current_index}");
                                        Tagstack.Pop();
                                        if (Tagstack.Count != 0) //test if also the last element in the final array is a string or not
                                                                 //before increasing it.
                                        {

                                            int index = Tagstack.Peek().getIndex(); //index of current tag
                                            if (XML_array[index - 1][0] == '<')
                                            {
                                                // Console.WriteLine($"{Tagstack.Peek().getSentence()} indddex is {index}");
                                                Tagstack.Peek().setIndex(current_index);
                                                // Console.WriteLine($"{Tagstack.Peek().getSentence()} iiindex is {Tagstack.Peek().getIndex()}");
                                            }
                                        }
                                    }

                                    if (Tagstack.Peek().getSentence().Trim() == temp.Trim())
                                    {
                                        //Console.WriteLine($"Temp is currently {temp}");
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
                                        // Console.WriteLine($"{Tagstack.Peek().getSentence()} index is {current_index}");
                                        Tagstack.Pop();
                                        if (Tagstack.Count != 0)
                                        {
                                            int index = Tagstack.Peek().getIndex();
                                            if (XML_array[index - 1][0] == '<')
                                            {
                                                // Console.WriteLine($"{Tagstack.Peek().getSentence()} inddex is {index}");
                                                Tagstack.Peek().setIndex(current_index);
                                                // Console.WriteLine($"{Tagstack.Peek().getSentence()} iindex is {Tagstack.Peek().getIndex()}");
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
                                    // Console.WriteLine("Tag not found, unfortunately");

                                    //add opening tag and closing tag.
                                    // Console.WriteLine($"Index to add tag in is {OpeningTagNumber}");
                                    resizeArraybyOne(ref XML_array, XML_array.Length, ref OpeningTagNumber, temp);
                                    XML_index++;
                                    // Console.WriteLine("Tag Added!");
                                    XML_array[XML_index] = temp.Substring(0, 1) + "/" + temp.Substring(1);
                                    XML_index++;
                                    temp = "";
                                    continue;
                                }

                            }

                        }
                        else
                        {
                            //Console.WriteLine($"Temp is currently {temp}");
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
                            // Console.WriteLine($"{Tagstack.Peek().getSentence()} indeex is {current_index}");
                            Tagstack.Pop();
                            if (Tagstack.Count != 0)
                            {
                                int index = Tagstack.Peek().getIndex();
                                if (XML_array[index - 1][0] == '<')
                                {
                                    // Console.WriteLine($"{Tagstack.Peek().getSentence()} index iss {index}");
                                    Tagstack.Peek().setIndex(current_index);
                                    // Console.WriteLine($"{Tagstack.Peek().getSentence()} indexx is {Tagstack.Peek().getIndex()}");
                                }
                            }
                            temp = "";
                            OpeningTagNumber++;

                        }
                    }
                }
                else
                {
                    // Console.WriteLine($"Currently {sentence}");
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
                        //Console.WriteLine($"Temp is currently {temp} and j is {j}");
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
                    // Console.WriteLine($"Currently increasing this one {element.getSentence()}");
                    int index = element.getIndex() + 2;
                    // Console.WriteLine($"{index} is the index of {Tagstack.Peek().getSentence()}");
                    // Console.WriteLine($"XML INDEX IS {XML_index}");
                    if (XML_index == index)
                    {
                        // Console.WriteLine("Adding");
                        element.setIndex((index));

                    }
                    Tagstack.Pop();
                    Tagstack.Push(element);
                    temp = "";
                }
            }




            // Console.WriteLine("END");

            if (Tagstack.Count == 0)
            {
                Console.WriteLine("All good!");
            }
            else
            {
                Console.WriteLine("Missing Closing Tags!");
                while (Tagstack.Count != 0)
                {
                    temp = Tagstack.Peek().getSentence();
                    int index = Tagstack.Peek().getIndex();
                    Console.WriteLine($"{temp} index is {index} and Length is {XML_array.Length}");
                    resizeArraybyOne(ref XML_array, XML_array.Length, ref index, temp.Substring(0, 1) + "/" + temp.Substring(1));
                    // if (XML_index != XML_array.Length)
                    // {
                    //     XML_array[XML_index] = temp.Substring(0, 1) + "/" + temp.Substring(1); ;
                    //     XML_index++;
                    // }
                    // else
                    // {
                    //     resizeArraytoDouble(ref XML_array, XML_array.Length);
                    //     XML_array[XML_index] = temp.Substring(0, 1) + "/" + temp.Substring(1); ;
                    //     XML_index++;
                    // }
                    OpeningTagNumber++;
                    int current_index = Tagstack.Peek().getIndex() + 1;
                    string current_Tag = Tagstack.Peek().getSentence();
                    // Console.WriteLine($"{Tagstack.Peek().getSentence()} indeex is {current_index}");
                    Tagstack.Pop();
                    if (Tagstack.Count != 0)
                    {
                        int ind = Tagstack.Peek().getIndex();
                        if (XML_array[ind - 1][0] == '<')
                        {
                            // Console.WriteLine($"{Tagstack.Peek().getSentence()} index iss {index}");
                            if (current_Tag == XML_array[XML_index])
                            {
                                Tagstack.Peek().setIndex(current_index);
                            }
                            else
                            {
                                Tagstack.Peek().setIndex(XML_index);
                            }
                            // Console.WriteLine($"{Tagstack.Peek().getSentence()} indexx is {Tagstack.Peek().getIndex()}");
                        }
                    }
                    XML_index++;
                }
            }



            printArray(XML_array, XML_index);

            string finalXMLString = "";
            //to group all of them again

            for(int i = 0;i < XML_index;i++)
            {
                finalXMLString+= XML_array[i];
            }

            Console.WriteLine(finalXMLString);
            File.WriteAllText("Output.xml", finalXMLString);
        }
    }
}
