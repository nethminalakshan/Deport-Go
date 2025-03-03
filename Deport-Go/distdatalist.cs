using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Deport_Go
{
    public class distdatalist
    {
        private distnode? Head;
        private distnode? Tail;
        public int Count { get; private set; }



        public distdatalist()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddFront(string distnameget, float distanceget, float priceget, int rootnoget)
        {
            distnode newNode = new distnode(distnameget, distanceget, priceget, rootnoget);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            Count++;
        }

        public void AddBack(string distnameget, float distanceget, float priceget, int rootnoget)
        {
            distnode newNode = new distnode(distnameget, distanceget, priceget, rootnoget);
            if (Tail == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            Count++;
        }

        public void Print()
        {
            distnode? current = Head;
            while (current != null)
            {

                if (current.distname.Length < 8)
                {
                    Console.WriteLine(current.distname + "\t\t" + current.distance + "\t" + current.price + "\t" + current.rootno);
                }
                else
                {
                    Console.WriteLine(current.distname + "\t" + current.distance + "\t" + current.price + "\t" + current.rootno);

                }
                current = current.Next;
            }
        }

        public void AddAt(string distnameget, float distanceget, float priceget, int rootnoget, int index)
        {
            distnode newNode = new distnode(distnameget, distanceget, priceget, rootnoget);

            if (index < 0 || index > Count)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            if (index == 0)
            {
                AddFront(distnameget, distanceget, priceget, rootnoget);
            }
            else if (index == Count)
            {
                AddBack(distnameget, distanceget, priceget, rootnoget);
            }
            else
            {
                distnode? temp = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    temp = temp.Next;
                }
                newNode.Next = temp.Next;
                temp.Next = newNode;
                Count++;
            }


        }
        public void printdistbyroot(int rootno)
        {
            distnode? current = Head;
            while (current != null)
            {
                if (current.rootno == rootno)
                {
                    if (current.distname.Length < 8)
                    {
                        Console.WriteLine(current.distname + "\t\t" + current.distance + "\t" + current.price + "\t" + current.rootno);
                    }
                    else
                    {
                        Console.WriteLine(current.distname + "\t" + current.distance + "\t" + current.price + "\t" + current.rootno);
                    }
                }
                current = current.Next;
            }
            Console.WriteLine("***************");
            Console.WriteLine("Sort By:");
            Console.WriteLine("1.Distance");
            Console.WriteLine("2.Price");
            Console.WriteLine("***************");
            int sortby = Convert.ToInt32(Console.ReadLine());
            if (sortby == 1)
            {
                printdistbyroot(rootno);
            }
            else if (sortby == 2)
            {
                printsortprice(rootno);
            }
        }
        public void printsortprice(int rootno)
        {
            distnode? current = Head;
            distdatalist x = new distdatalist();
            while (current != null)
            {
                if (current.rootno == rootno)
                {
                    x.AddFront(current.distname, current.distance, current.price, current.rootno);
                }
                current = current.Next;
            }

            
            if (x.Head == null || x.Head.Next == null)
            {
                return;
            }

            distnode? sorted = null;
            current = x.Head;
            while (current != null)
            {
                distnode? next = current.Next;
                if (sorted == null || sorted.distance >= current.distance)
                {
                    current.Next = sorted;
                    sorted = current;
                }
                else
                {
                    distnode? temp = sorted;
                    while (temp.Next != null && temp.Next.distance < current.distance)
                    {
                        temp = temp.Next;
                    }
                    current.Next = temp.Next;
                    temp.Next = current;
                }
                current = next;
            }
            x.Head = sorted;

            
            x.Print();

        }
        public void printsortedsitbyroot(int rootno)
        {
            distnode? current = Head;
            distdatalist x = new distdatalist();
            while (current != null)
            {
                if (current.rootno == rootno)
                {
                    x.AddFront(current.distname, current.distance, current.price, current.rootno);
                }
                current = current.Next;
            }

            // Perform quicksort on the distdatalist x based on price
            x.Head = QuickSort(x.Head);

            // Print the sorted list
            x.Print();
        }

        private distnode? QuickSort(distnode? head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            distnode? pivot = head;
            distnode? lessHead = null, lessTail = null;
            distnode? greaterHead = null, greaterTail = null;
            distnode? current = head.Next;

            while (current != null)
            {
                distnode? next = current.Next;
                current.Next = null;
                if (current.price < pivot.price)
                {
                    if (lessHead == null)
                    {
                        lessHead = current;
                        lessTail = current;
                    }
                    else
                    {
                        lessTail.Next = current;
                        lessTail = current;
                    }
                }
                else
                {
                    if (greaterHead == null)
                    {
                        greaterHead = current;
                        greaterTail = current;
                    }
                    else
                    {
                        greaterTail.Next = current;
                        greaterTail = current;
                    }
                }
                current = next;
            }

            lessHead = QuickSort(lessHead);
            greaterHead = QuickSort(greaterHead);

            return Concatenate(lessHead, pivot, greaterHead);
        }

        private distnode? Concatenate(distnode? lessHead, distnode? pivot, distnode? greaterHead)
        {
            if (lessHead == null)
            {
                pivot.Next = greaterHead;
                return pivot;
            }

            distnode? current = lessHead;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = pivot;
            pivot.Next = greaterHead;

            return lessHead;
        }

        public int findroot(string destination)
        {
            distnode? current = Head;
            while (current != null)
            {
                if (current.distname == destination)
                {
                    return current.rootno;
                }
                current = current.Next;
            }
            return -1;
        }


    }
}





