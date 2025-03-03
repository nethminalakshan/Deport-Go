using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deport_Go
{
    public class busnode
    {
        public string regno;
        public string busname;
        public float time;
        public int aviseat;
        public int rootno;

        public busnode? Next;

        public busnode(string regnoget, string busnameget, float timeget, int rootno,int seat)
        {
            regno = regnoget;
            busname = busnameget;
            time = timeget;
            aviseat = seat;
            rootno = rootno;
        }
        public void bookseat(int count)
        {
            if (aviseat >= count)
            {
                aviseat = aviseat - count;
                Console.WriteLine("Seat Booked Successfully");
            }
            else
            {
                Console.WriteLine("Seat Not Available");
            }
        }
    }
}

