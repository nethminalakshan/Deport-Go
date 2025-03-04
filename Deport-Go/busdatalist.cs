using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Deport_Go
{
    public class busdatalist
    {
        private busnode? Head;
        private busnode? Tail;
        public int Count { get; private set; }



        public busdatalist()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddFront(string regnoget, string busnameget, float timeget, int rootno, int seat)
        {
            busnode newNode = new busnode(regnoget, busnameget, timeget, rootno, seat);
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

        public void AddBack(string regnoget, string busnameget, float timeget, int rootno, int seat)
        {
            busnode newNode = new busnode(regnoget, busnameget, timeget, rootno, seat);
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
            busnode? current = Head;
            while (current != null)
            {

                if (current.busname.Length < 8)
                {
                    Console.WriteLine(current.busname + "\t\t" + current.regno + "\t" + current.time + "\t" + current.aviseat + "\t" + current.rootno);
                }
                else
                {
                    Console.WriteLine(current.busname + "\t" + current.regno + "\t" + current.time + "\t" + current.aviseat + "\t" + current.rootno);

                }
                current = current.Next;
            }
        }

        public void AddAt(string regnoget, string busnameget, float timeget, int rootno, int seat, int index)
        {
            busnode newNode = new busnode(regnoget, busnameget, timeget, rootno, seat);

            if (index < 0 || index > Count)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            if (index == 0)
            {
                AddFront(regnoget, busnameget, timeget, rootno, seat);
            }
            else if (index == Count)
            {
                AddBack(regnoget, busnameget, timeget, rootno, seat);
            }
            else
            {
                busnode? temp = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    temp = temp.Next;
                }
                newNode.Next = temp.Next;
                temp.Next = newNode;
                Count++;
            }


        }
        public void deleteatreg(string regno)
        {
            if (Head == null)
            {
                Console.WriteLine("Bus list is empty.");
                return;
            }

            busnode? temp = Head;
            busnode? prev = null;


            if (temp != null && temp.regno == regno)
            {
                Head = temp.Next;
                Console.WriteLine($"Bus {regno} removed successfully.");
                return;
            }


            while (temp != null && temp.regno != regno)
            {
                prev = temp;
                temp = temp.Next;
            }


            if (temp == null)
            {
                Console.WriteLine($"Bus {regno} not found.");
                return;
            }


            prev.Next = temp.Next;
            Console.WriteLine($"Bus {regno} removed successfully.");
        }
/////////////////////////////////////////////////////bubble sort//////////////////////////////////////////////

        public void timesort(busdatalist x, float time)
        {
            if (x.Head == null || x.Head.Next == null)
                return;

            bool swapped;
            busnode? current;
            busnode? nextNode;

            do
            {
                swapped = false;
                current = x.Head;

                while (current != null && current.Next != null)
                {
                    nextNode = current.Next;

                    if (current.time > nextNode.time)
                    {

                        SwapBusNodes(current, nextNode);
                        swapped = true;
                    }

                    current = current.Next;
                }
            } while (swapped);


            PrintBusList(x, time);
        }


        private void SwapBusNodes(busnode a, busnode b)
        {
            float tempTime = a.time;
            string tempRegNo = a.regno;
            string tempBusName = a.busname;
            int tempRootNo = a.rootno;

            a.time = b.time;
            a.regno = b.regno;
            a.busname = b.busname;
            a.rootno = b.rootno;

            b.time = tempTime;
            b.regno = tempRegNo;
            b.busname = tempBusName;
            b.rootno = tempRootNo;
        }


        private void PrintBusList(busdatalist x, float t)
        {
            busnode? temp = x.Head;
            while (temp != null)
            {
                if (temp.time >= t)
                {
                    Console.WriteLine(temp.busname + "\t" + temp.regno + "\t" + temp.time + "\t" + temp.aviseat + "\t" + temp.rootno);
                }

                temp = temp.Next;
            }
        }
        public void printbuslistbyroot(int rootno)
        {
            busnode? temp = Head;
            Console.WriteLine("Bus Name\tReg No\t\tTime\tAvailable Seats\tRoot No\n");
            while (temp != null)
            {

                if (temp.rootno == rootno)
                {

                    Console.WriteLine(temp.busname + "\t\t" + temp.regno + "\t" + temp.time + "\t" + temp.aviseat + "\t\t" + temp.rootno);
                }
                temp = temp.Next;
            }
            Console.WriteLine("***************");
            Console.WriteLine("Sort By:");
            Console.WriteLine("1.Arrival Time");
            Console.WriteLine("2.Available Seats");
            Console.WriteLine("3.Back to User Panel");
            Console.WriteLine("***************");
            int sortby = Convert.ToInt32(Console.ReadLine());
            if (sortby == 1)
            {
                timesortbyroot(this, rootno);
            }
            else if (sortby == 2)
            {
                availablesortbyroot(this, rootno);
            }
            else if (sortby == 3)
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid Input");

            }

        }

        public void timesortbyroot(busdatalist x, int rootno)
        {
            x.Head = MergeSort(x.Head, rootno);
            printbuslistbyroot(rootno);
        }
        /////////////////////////////////////////////merge sort/////////////////////////////////////////////////////////
        private busnode? MergeSort(busnode? head, int rootno)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            busnode? middle = GetMiddle(head);
            busnode? nextOfMiddle = middle.Next;
            middle.Next = null;

            busnode? left = MergeSort(head, rootno);
            busnode? right = MergeSort(nextOfMiddle, rootno);

            return SortedMerge(left, right, rootno);
        }

        private busnode? GetMiddle(busnode? head)
        {
            if (head == null)
            {
                return head;
            }

            busnode? slow = head;
            busnode? fast = head.Next;

            while (fast != null)
            {
                fast = fast.Next;
                if (fast != null)
                {
                    slow = slow.Next;
                    fast = fast.Next;
                }
            }

            return slow;
        }

        private busnode? SortedMerge(busnode? left, busnode? right, int rootno)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            busnode? result = null;

            if (left.time <= right.time && left.rootno == rootno)
            {
                result = left;
                result.Next = SortedMerge(left.Next, right, rootno);
            }
            else
            {
                result = right;
                result.Next = SortedMerge(left, right.Next, rootno);
            }

            return result;
        }


        public void availablesortbyroot(busdatalist x, int rootno)
        {
            x.Head = MergeSortBySeats(x.Head, rootno);
            printbuslistbyroot(rootno);
        }

        private busnode? MergeSortBySeats(busnode? head, int rootno)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            busnode? middle = GetMiddle2(head);
            busnode? nextOfMiddle = middle.Next;
            middle.Next = null;

            busnode? left = MergeSortBySeats(head, rootno);
            busnode? right = MergeSortBySeats(nextOfMiddle, rootno);

            return SortedMergeBySeats(left, right, rootno);
        }

        private busnode? SortedMergeBySeats(busnode? left, busnode? right, int rootno)
        {
            if (left == null)
            {
                return right;
            }

            if (right == null)
            {
                return left;
            }

            busnode? result = null;

            if (left.aviseat <= right.aviseat && left.rootno == rootno)
            {
                result = left;
                result.Next = SortedMergeBySeats(left.Next, right, rootno);
            }
            else
            {
                result = right;
                result.Next = SortedMergeBySeats(left, right.Next, rootno);
            }

            return result;
        }

        private busnode? GetMiddle2(busnode? head)
        {
            if (head == null)
            {
                return head;
            }

            busnode? slow = head;
            busnode? fast = head.Next;

            while (fast != null)
            {
                fast = fast.Next;
                if (fast != null)
                {
                    slow = slow.Next;
                    fast = fast.Next;
                }
            }

            return slow;
        }


        public void timeandrootbussarch(busdatalist x, int rootno, float time)
        {
            if (rootno > 0 && time > 0)
            {
                busnode? temp = x.Head;
                if (x.Head == null)
                {
                    Console.WriteLine("No buses found in this root");
                }

                while (temp != null)
                {
                    if (temp.rootno == rootno && temp.time >= time)
                    {
                        Console.WriteLine("Bus Name\tReg No\tTime\tAvailable Seats\tRoot No");
                        Console.WriteLine(temp.busname + "\t" + temp.regno + "\t" + temp.time + "\t" + temp.aviseat + "\t" + temp.rootno);
                    }
                    temp = temp.Next;
                }



            }
            else
            {
                { Console.WriteLine("Invalid input"); }
            }





        }
        public void bookseat(string regno, int count)
        {
            busnode? temp = Head;
            while (temp != null)
            {
                if (temp.regno == regno)
                {
                    temp.bookseat(count);
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Bus not found");
        }
    }
}





