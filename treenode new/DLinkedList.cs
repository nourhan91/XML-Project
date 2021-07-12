using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree
{
    class DLinkedList<T>
    {
        #region attributes
        private string tagData;

        private DLinkedList<T> nextNode;
        private DLinkedList<T> previousNode;

        #endregion

        #region CONSTRUCTORS
        public DLinkedList()
        {
            tagData = null;
            nextNode = null;
            previousNode = null;
        }

        public DLinkedList(string value)
        {
            tagData = value;
            nextNode = null;
            previousNode = null;
        }

        #endregion

        #region methods
        public DLinkedList<T> InsertNext(string value)
        {
            DLinkedList<T> node = new DLinkedList<T>(value);
            if (this.nextNode == null)
            {

                // Easy to handle
                node.previousNode = this;
                node.nextNode = null; // already set in constructor
                this.nextNode = node;
            }
            else
            {
                // Insert in the middle
                DLinkedList<T> tempNode = this.nextNode;
                node.previousNode = this;
                node.nextNode = tempNode;
                this.nextNode = node;
                tempNode.previousNode = node;
                // tempNode.nextNode does not have to be changed
            }
            return node;
        }

        public DLinkedList<T> InsertPrev(string value)
        {
            DLinkedList<T> node = new DLinkedList<T>(value);
            if (this.previousNode == null)
            {
                node.previousNode = null; // already set on constructor
                node.nextNode = this;
                this.previousNode = node;
            }
            else
            {

                // Insert in the middle
                DLinkedList<T> tempNode = this.previousNode;
                node.previousNode = tempNode;
                node.nextNode = this;
                this.previousNode = node;
                tempNode.nextNode = node;
                // tempNode.previousNode does not have to be changed
            }
            return node;
        }

        public void TraverseFront()
        {
            TraverseFront(this);
        }

        public void TraverseFront(DLinkedList<T> node)
        {
            if (node == null)
                node = this;
            System.Console.WriteLine("\n\nTraversing in Forward Direction\n\n");

            while (node != null)
            {
                System.Console.WriteLine(node.tagData);
                node = node.nextNode;
            }
        }

        public void TraverseBack()
        {
            TraverseBack(this);
        }

        public void TraverseBack(DLinkedList<T> node)
        {
            if (node == null)
                node = this;
            System.Console.WriteLine("\n\nTraversing in Backward Direction\n\n");
            while (node != null)
            {
                System.Console.WriteLine(node.tagData);
                node = node.previousNode;
            }
        }

        #endregion

        /*
Error	CS5001	Program does not contain a static 'Main' method suitable for an entry point*/
/* static public void Main()
 {
     DLinkedList<T> node1 = new DLinkedList<T>("1");
     DLinkedList<T> node3 = node1.InsertNext("3");
     DLinkedList<T> node2 = node3.InsertPrev("2");
     DLinkedList<T> node5 = node3.InsertNext("5");
     DLinkedList<T> node4 = node5.InsertPrev("4");

     node1.TraverseFront();
     node5.TraverseBack();
     Console.ReadLine();
 }*/

}
}
