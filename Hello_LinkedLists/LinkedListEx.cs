using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_LinkedLists
{
    class SNode<T>
    {
        public SNode() 
        { NextSNode = null; }

        public T Data;

        public SNode<T> NextSNode;
    }

    class DNode
    {
        public DNode()
        {
            Data = null;
            NextNode = null;
            PrevNode = null;
        }

        public object Data;

        
        public DNode NextNode;
        public DNode PrevNode;


    }
    
    class LinkedListEx<T>
    {
        private SNode<T> head = null; 

        public LinkedListEx()
        {

        }

        public SNode<T> GetHead()
        {
            return head; 
        }

        public void SetHead(SNode<T> newHead)
        {
            head = newHead;
        }

        public void Insert(T data)
        {
            if(head == null)
            {
                head = new SNode<T>();
                head.Data = data;
                return; 
            }

            SNode<T> newNode = new SNode<T>();
            newNode.Data = data;

            SNode<T> prevNode = null; 

            SNode<T> tmpNode = head; 
            while(tmpNode != null)
            {
                if(Comparer<T>.Default.Compare(data, tmpNode.Data) <= 0) // insert before 
                {
                    newNode.NextSNode = tmpNode; 
                    if(prevNode == null)
                        head = newNode; 
                    else
                        prevNode.NextSNode = newNode;
                    break;
                }
                else 
                {
                    // either insert or continue in the loop to find the right place to insert 
                    prevNode = tmpNode;
                    if (tmpNode.NextSNode == null)
                    {
                        // we have reached the end of list, add as last node and return 
                        tmpNode.NextSNode = newNode;
                        break;
                    }
                    else
                    {
                        tmpNode = tmpNode.NextSNode;
                    }
                }
            }
        }

        public override string ToString()
        {
            if (head == null)
                return "Empty List!";

            StringBuilder returnString = new StringBuilder();
            //string returnString = "";
            SNode<T> tmp = head;
            while(tmp != null)
            {
                returnString.Append(tmp.Data.ToString() + " -> ");
                //returnString += tmp.Data.ToString() + " -> ";
                
                tmp = tmp.NextSNode;
            }
            returnString.Append("NULL");
            //returnString += "NULL";

            string ret = returnString.ToString();
            returnString.Clear(); 
            return ret;
            //return returnString;
        }

        public void Delete(T data)
        {
            var item = CoreSearchKey(data); 
            if(item.Item1)
            {
                item.Item3.NextSNode = item.Item2.NextSNode;
            }
        }

        public bool SearchKey(T data)
        {
            var isFound = CoreSearchKey(data);
            return isFound.Item1;
        }

        private Tuple<bool, SNode<T>, SNode<T>> CoreSearchKey(T data)
        {
            return SearchKey_OofN(data); 
        }

        // Time complexity of O(n)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>
        /// item 1: found or not 
        /// item 2: key node
        /// item 3: previous node
        /// </returns>
        private Tuple<bool, SNode<T>, SNode<T>> SearchKey_OofN(T data)
        {
            SNode<T> tmp = head;
            SNode<T> prev = null; 
            
            while(tmp != null)
            {
                if (Comparer<T>.Default.Compare(data, tmp.Data) == 0)
                    return Tuple.Create<bool, SNode<T>, SNode<T>>(true, tmp, prev);
                prev = tmp; 
                tmp = tmp.NextSNode; 
            }
            return Tuple.Create<bool, SNode<T>, SNode<T>>(false, null, null);
        }


    }
}
