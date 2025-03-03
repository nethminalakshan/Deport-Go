using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deport_Go
{
    public class distnode
    {
        public float distance;
        public string distname;
        public float price;
        public int rootno;

        public distnode? Next;

        public distnode(string distnameget,float distanceget,float priceget,int rootnoget )
        {
            distance = distanceget;
            distname = distnameget;
            price = priceget;
            rootno = rootnoget;
        }
    }
}

