using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    /*
         class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hi");
            Stack at=new Stack();
            at.Push("x");
            Console.WriteLine(at.Pop());
            Console.ReadLine();
        }

    }
     */
    public class Stack
    {

        LinkedList<string> list = new LinkedList<string>();


        public void Push(string value)
        {
            list.AddFirst(value);
        }
        public string Pop()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The Stack is empty");
            }
            string value = list.First.Value;
            list.RemoveFirst();
            return value;
        }
        public string Peek()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("The Stack is empty");
            }
            return list.First.Value;
        }
        public void Clear()
        {
            list.Clear();
        }
        public bool compareWith(string a)
        {
            if (Peek() == a)
            {
                return true;
            }

            return false;
        }
    }
}
