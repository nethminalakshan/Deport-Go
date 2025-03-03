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
            usernode newNode = new usernode(nameget,usernameget, passwordget, emailget, phoneget, addressget, nicget);
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
            usernode newNode = new usernode(nameget,usernameget, passwordget, emailget, phoneget, addressget, nicget);
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
                    
                    if(current.email.Length< 16)
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
                AddFront(nameget,usernameget, passwordget, emailget, phoneget, addressget, nicget);
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

        

    }
}