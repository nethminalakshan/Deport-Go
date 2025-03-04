using Deport_Go;
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
    public class userlist
    {
        private usernode? Head;
        private usernode? Tail;
        public int Count { get; private set; }



        public userlist()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public void AddFront(string nameget, string usernameget, string passwordget, string emailget, string phoneget, string addressget, string nicget)
        {
            usernode newNode = new usernode(nameget, usernameget, passwordget, emailget, phoneget, addressget, nicget);
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

        public void AddBack(string nameget, string usernameget, string passwordget, string emailget, string phoneget, string addressget, string nicget)
        {
            usernode newNode = new usernode(nameget, usernameget, passwordget, emailget, phoneget, addressget, nicget);
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
            usernode? current = Head;
            Console.WriteLine("User List");
            Console.WriteLine("========================================");
            Console.WriteLine("Username\tPassword\tEmail\tPhone\tAddress\tNIC");
            while (current != null)
            {
                if (current.username.Length < 8)
                {

                    if (current.email.Length < 16)
                    {
                        Console.WriteLine($"{current.username}\t\t{current.password}\t\t\t{current.email}\t{current.phone}\t{current.address}\t{current.nic}");
                    }
                    else
                    {
                        Console.WriteLine($"{current.username}\t\t{current.password}\t{current.email}\t{current.phone}\t{current.address}\t{current.nic}");
                    }
                }
                else
                {
                    if (current.email.Length < 16)
                    {
                        Console.WriteLine($"{current.username}\t{current.password}\t\t\t{current.email}\t{current.phone}\t{current.address}\t{current.nic}");
                    }
                    else
                    {
                        Console.WriteLine($"{current.username}\t{current.password}\t{current.email}\t{current.phone}\t{current.address}\t{current.nic}");

                    }
                }

                current = current.Next;

            }

        }

        public void AddAt(string nameget, string usernameget, string passwordget, string emailget, string phoneget, string addressget, string nicget)
        {
            Console.WriteLine("Enter the index to add the user");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index < 0 || index > Count)
            {
                Console.WriteLine("Invalid Index");
                return;
            }
            if (index == 0)
            {
                AddFront(nameget, usernameget, passwordget, emailget, phoneget, addressget, nicget);
            }
            else if (index == Count)
            {
                AddBack(nameget, usernameget, passwordget, emailget, phoneget, addressget, nicget);
            }
            else
            {
                usernode newNode = new usernode(nameget, usernameget, passwordget, emailget, phoneget, addressget, nicget);
                usernode? current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current?.Next;
                }
                newNode.Next = current?.Next;
                current.Next = newNode;
                Count++;
            }


        }
        public void deleteuser(string username)
        {
            usernode? current = Head;
            usernode? previous = null;
            while (current != null)
            {
                if (current.username == username)
                {
                    if (previous == null)
                    {
                        Head = current.Next;
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                    Count--;
                    return;
                }
                previous = current;
                current = current.Next;
            }

        }

        public bool verification(string username, string password)
        {
            usernode? current = Head;
            while (current != null)
            {
                if (current.username == username && current.password == password)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public string searchname(string username)
        {
            usernode? current = Head;
            while (current != null)
            {
                if (current.username == username)
                {
                    return current.name;
                }
                current = current.Next;
            }
            return null;
        }
        ///////////////////////////////////////////////selection sort//////////////////////////////////
        public void sortbynic(userlist x)
        {

            if (x.Head == null || x.Head.Next == null)
            {
                Console.WriteLine("The list is empty or has only one user. No sorting needed.");
                return;
            }

            usernode current = x.Head;


            while (current != null)
            {

                usernode min = current;
                usernode next = current.Next;


                while (next != null)
                {
                    if (string.Compare(next.nic, min.nic) < 0)
                    {
                        min = next;
                    }
                    next = next.Next;
                }

                if (min != current)
                {

                    string tempName = current.name;
                    string tempUsername = current.username;
                    string tempPassword = current.password;
                    string tempEmail = current.email;
                    string tempPhone = current.phone;
                    string tempAddress = current.address;
                    string tempNic = current.nic;

                    current.name = min.name;
                    current.username = min.username;
                    current.password = min.password;
                    current.email = min.email;
                    current.phone = min.phone;
                    current.address = min.address;
                    current.nic = min.nic;

                    min.name = tempName;
                    min.username = tempUsername;
                    min.password = tempPassword;
                    min.email = tempEmail;
                    min.phone = tempPhone;
                    min.address = tempAddress;
                    min.nic = tempNic;
                }


                current = current.Next;
            }


            Console.WriteLine("Sorted by NIC number:");
            x.Print();
        }


        ////////////////////////////////////////////////////quick sort////////////////////////////////////////

        public void sortbyusername(userlist x)
        {
            if (x.Head == null || x.Head.Next == null)
            {
                Console.WriteLine("The list is empty or has only one user. No sorting needed.");
                return;
            }

            int count = 0;
            usernode current = x.Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }

            usernode[] nodesArray = new usernode[count];
            current = x.Head;
            for (int i = 0; i < count; i++)
            {
                nodesArray[i] = current;
                current = current.Next;
            }

            QuickSort(nodesArray, 0, count - 1);

            x.Head = nodesArray[0];
            for (int i = 0; i < count - 1; i++)
            {
                nodesArray[i].Next = nodesArray[i + 1];
            }
            nodesArray[count - 1].Next = null;

            Console.WriteLine("Sorted by username:");
            x.Print();
        }

        private void QuickSort(usernode[] nodesArray, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(nodesArray, low, high);
                QuickSort(nodesArray, low, pivotIndex - 1);
                QuickSort(nodesArray, pivotIndex + 1, high);
            }
        }

        private int Partition(usernode[] nodesArray, int low, int high)
        {
            string pivot = nodesArray[high].username;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (string.Compare(nodesArray[j].username, pivot) <= 0)
                {
                    i++;
                    Swap(nodesArray, i, j);
                }
            }

            Swap(nodesArray, i + 1, high);
            return i + 1;
        }

        private void Swap(usernode[] nodesArray, int i, int j)
        {
            usernode temp = nodesArray[i];
            nodesArray[i] = nodesArray[j];
            nodesArray[j] = temp;
        }




    
    //insertion sort/////////////    

    public void sortbyphone(userlist x)
        {
            if (x.Head == null || x.Head.Next == null)
            {
                Console.WriteLine("The list is empty or has only one user. No sorting needed.");
                return;
            }

            usernode sorted = null;
            usernode current = x.Head;

            while (current != null)
            {
                usernode next = current.Next;

                if (sorted == null || string.Compare(current.phone, sorted.phone) < 0)
                {
                    current.Next = sorted;
                    sorted = current;
                }
                else
                {
                    usernode temp = sorted;
                    while (temp.Next != null && string.Compare(current.phone, temp.Next.phone) > 0)
                    {
                        temp = temp.Next;
                    }
                    current.Next = temp.Next;
                    temp.Next = current;
                }

                current = next;
            }

            x.Head = sorted;

            Console.WriteLine("Sorted by phone number:");
            x.Print();
        }


        
                



    }
}






