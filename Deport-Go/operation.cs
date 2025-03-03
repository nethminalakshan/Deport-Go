using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Deport_Go
{
    public class operation
    {

        distdatalist distlist = new distdatalist();
        busdatalist busdatalist = new busdatalist();


        ///admin side
        ///

        public void addbus(busdatalist busdatalist)
        {
            Console.WriteLine("Enter the bus registration number");
            string regno = Console.ReadLine();
            Console.WriteLine("Enter the bus name");
            string busname = Console.ReadLine();
            Console.WriteLine("Enter the time");
            float time = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the root number");
            int rootno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Avilable seat count");
            int seat = int.Parse(Console.ReadLine());
            busdatalist.AddBack(regno, busname, time, rootno,seat);
        }

        public void removebus(busdatalist busdatalist)
        {
            
            Console.WriteLine("Enter bus Reg number");
            string reg=Console.ReadLine();
            busdatalist.deleteatreg(reg);

        }
        public void timesort(busdatalist y)
        {
            float time;
            busdatalist x= new busdatalist();
            Console.WriteLine("Enter the time now");
            time = float.Parse(Console.ReadLine());
            x.timesort(y, time);
        }

        ///user side
        ///
        
        public void printdist(int rootno)
        {
            distdatalist x = new distdatalist();
            x.printdistbyroot(rootno);

        }

        public void printbus(int rootno)
        {
            busdatalist x = new busdatalist();
            x.printbuslistbyroot(rootno);
        }

        public void searchbus(busdatalist x,string destination, float time)
        {
            Console.WriteLine("Destination: " + destination);
            int rootno = findroot(destination);
            findbus(busdatalist, rootno, time);

        }

        private int findroot(string destination)
        {
            distdatalist x = new distdatalist();
            return x.findroot(destination);
        }
        private void findbus(busdatalist x, int rootno, float time)
        {
   
            x.timeandrootbussarch(x,rootno, time);
        }









    }
}
