using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deport_Go
{
    
    public class usernode
    {
        public string name;
        public string username;
        public string password;
        public string email;
        public string phone;
        public string address;
        public string nic;
        

        public usernode? Next;

        public usernode(string nameget,string usernameget, string passwordget, string emailget, string phoneget, string addressget, string nicget)
        {
            username = usernameget;
            password = passwordget;
            email = emailget;
            phone = phoneget;
            address = addressget;
            nic = nicget;
        }
        
        
    }
}

