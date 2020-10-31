using System;
using System.Threading;

namespace Hello_LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListEx<int> list1 = new LinkedListEx<int>();
            LinkedListEx<int> list2 = new LinkedListEx<int>();
            LinkedListEx<int> result = new LinkedListEx<int>(); 

            Console.WriteLine("==========LinkedListEx (Singly) ==========");

            int num, operation;
            string strLine = "\n\nInitializing the list with data.Please wait" ;
            Console.Write(strLine);

            Random rand = new Random(); 
            for(int n = 1; n < 3; n++)
            {
                list1.Insert(rand.Next(1, 50));
            }
            for (int n = 1; n < 4; n++)
            {
                list2.Insert(rand.Next(1, 50));
            }

            Console.WriteLine("list 1:");
            Console.WriteLine(list1.ToString() + "\n");

            Console.WriteLine("list 2:");
            Console.WriteLine(list2.ToString() + "\n");

            Console.WriteLine("\n\nList Ready!!!\n\n");

            // merge l1, l2 (sorted) 
            SNode<int> currL1 = list1.GetHead();
            SNode<int> currL2 = list2.GetHead();
            while(currL1 != null || currL2 != null)
            {
                if (currL1 != null && currL2 != null)
                {
                    if (currL1.Data <= currL2.Data)
                    {
                        result.Insert(currL1.Data);
                        currL1 = currL1.NextSNode;
                    }
                    else if (currL2.Data <= currL1.Data)
                    {
                        result.Insert(currL2.Data);
                        currL2 = currL2.NextSNode;
                    }
                }
                else if(currL1 != null && currL2 == null)
                {
                    result.Insert(currL1.Data);
                    currL1 = currL1.NextSNode;
                }
                else if(currL1 == null && currL2 != null)
                {
                    result.Insert(currL2.Data);
                    currL2 = currL2.NextSNode;
                }
            }

            Console.WriteLine("result:");
            Console.WriteLine(result.ToString() + "\n");

            // now reverse the result linked list
            SNode<int> prev = result.GetHead();
            SNode<int> curr = result.GetHead()?.NextSNode; 

            while(curr!= null)
            {
                prev.NextSNode = curr.NextSNode;
                curr.NextSNode = result.GetHead();
                result.SetHead(curr);
                curr = prev.NextSNode; 
            }

            Console.WriteLine("result (reversed):");
            Console.WriteLine(result.ToString() + "\n");

            #region commented code
            /*
                while (true)
                {
                    Console.WriteLine("2: Delete key, 3: Search key, 4: Print List, 5:Quit");
                    while (!int.TryParse(Console.ReadLine().ToString(), out operation))
                        Console.WriteLine("INVALID INPUT: Try again!");
                    if (operation == 5)
                        break;

                    switch(operation)
                    {
                        case 1:
                            Console.WriteLine("Input key to insert into LinkedListEx:");
                            while (!int.TryParse(Console.ReadLine().ToString(), out num))
                                Console.WriteLine("INVALID INPUT: Try again!");
                            list.Insert(num);
                            break;
                        case 2:
                            Console.WriteLine("Input number to delete from LinkedListEx:");
                            while (!int.TryParse(Console.ReadLine().ToString(), out num))
                                Console.WriteLine("INVALID INPUT: Try again!");
                            list.Delete(num);
                            break;
                        case 3:
                            Console.WriteLine("Input key to search in LinkedListEx:");
                            while (!int.TryParse(Console.ReadLine().ToString(), out num))
                                Console.WriteLine("INVALID INPUT: Try again!");
                            if (list.SearchKey(num))
                                Console.WriteLine("Key found in the list");
                            else
                                Console.WriteLine("Key is not present in the list");
                            break;
                        case 4:
                            Console.WriteLine("\nThe list contents:");
                            Console.WriteLine(list.ToString());
                            break;
                        default:
                            Console.WriteLine("Invalid input. Try again!");
                            break; 
                    }   
                }
                */
            #endregion

            Console.ReadKey(); 
        }       


    }
}
