using Deport_Go;
bool t = true;
bool t_admin = true;

operation operationcall = new operation();
distdatalist distlist = new distdatalist();
busdatalist busdatalist = new busdatalist();
userlist userlist = new userlist();
void bydefault()
{
    string[] distnamelist = new string[] {
    "Alawwa", "Pothuhera", "Kurunegala", "Mahakeliya", "Wariyapola",
    "Maho", "Ambanpola", "Galgamuwa", "Thabuttegama", "Talawa",
    "Anuradhapura", "Maharagama", "Piliyandala", "Panadura", "Wadduwa",
    "Kalutara", "Katukurunda", "Maggona", "Beruwala", "Bentota",
    "Balapitiya", "Ambalangoda", "Hikkaduwa", "Rathgama", "Galle",
    "Kadawatha", "Gampaha", "Pasyala", "Weweldeniya", "Warakapola",
    "Galigamuwa", "Kegalle", "Molagoda", "Mawanella", "Kadugannawa",
    "Pilimathalawa", "Peradeniya", "Kandy"
};

    float[] distancelist = new float[] {
    60, 70, 80, 90, 100,
    110, 120, 130, 140, 150,
    196, 16, 22, 27, 35,
    40, 45, 50, 56, 60,
    75, 80, 90, 95, 105,
    16, 25, 45, 50, 60,
    70, 78, 85, 90, 100,
    105, 110, 115
};

    float[] pricelist = new float[] {
    120, 140, 160, 180, 200,
    220, 240, 260, 280, 300,
    350, 50, 70, 90, 110,
    130, 150, 170, 190, 210,
    230, 250, 270, 290, 320,
    50, 80, 120, 140, 160,
    180, 200, 220, 250, 280,
    300, 320, 350
};

    int[] rootnolist = new int[] {
    57, 57, 57, 57, 57,
    57, 57, 57, 57, 57,
    57, 2, 2, 2, 2,
    2, 2, 2, 2, 2,
    2, 2, 2, 2, 2,
    1, 1, 1, 1, 1,
    1, 1, 1, 1, 1,
    1, 1, 1
};

    for (int i = 0; i < distnamelist.Length; i++)
    {
        distlist.AddBack(distnamelist[i], distancelist[i], pricelist[i], rootnolist[i]);
    }

    string[] busnamelist = new string[] {
    "Bus-1", "Bus-2", "Bus-3", "Bus-4", "Bus-5", "Bus-6", "Bus-7", "Bus-8", "Bus-9", "Bus-10",
    "Bus-11", "Bus-12", "Bus-13", "Bus-14", "Bus-15", "Bus-16", "Bus-17", "Bus-18", "Bus-19", "Bus-20"
};

    string[] regnolist = new string[] {
    "WP NG-4172", "NW NG-2141", "EP NH-8199", "CP NK-6723", "SP NH-5118", "WP NG-3463", "UVA NE-3666",
    "UVA NE-5451", "NW NG-4308", "SP NF-7961", "CP NB-4610", "SB NF-4645", "SP NB-5216", "EP NJ-8698",
    "EP ND-9911", "EP ND-7612", "UVA NA-1627", "CP NB-1569", "SP NB-6366", "WP ND-7483"
};

    float[] timelist = new float[] {
    14.42f, 4.54f, 15.43f, 13.09f, 17.13f, 10.01f, 8.40f, 13.50f, 12.25f, 16.01f,
    13.04f, 5.38f, 18.32f, 13.20f, 18.20f, 7.50f, 15.20f, 13.38f, 12.03f, 7.17f
};

    int[] rootnolist2 = new int[] { 2, 57, 1, 1, 2, 1, 1, 57, 57, 1, 1, 2, 1, 1, 1, 2, 1, 2, 2, 1 };

    for (int i = 0; i < busnamelist.Length; i++)
    {
        busdatalist.AddBack(regnolist[i], busnamelist[i], timelist[i], rootnolist2[i], 40);
    }


    string[] names = {
    "*","Kamal Perera", "Nimal Silva", "Saman Fernando", "Sunil Wickramasinghe", "Chamara Rajapaksha", "Kasun Jayawardena", "Amila Gunawardena", "Tharindu Dissanayake", "Dilshan Weerasinghe", "Gayan Pathirana",
    "Janaka Chandrasekara", "Ruwan Tennakoon", "Indunil Mendis", "Lahiru Zoysa", "Ravindu Karunaratne", "Asanka Vithanage", "Dulshan Ranasinghe", "Isuru Nanayakkara", "Prabath Liyanage", "Nishan Perera",
    "Thilina Bandara", "Udara Dissanayake", "Sandun Xavier", "Harsha Madushanka", "Lakmal Rodrigo", "Roshan Dias"
};




    string[] usernames = {
    "*","Kamal123", "Nimal456", "Saman789", "Sunil007", "Chamara99", "Kasun77", "Amila85", "TharinduX", "Dilshan22", "GayanP",
    "JanakaC", "RuwanT", "IndunilM", "LahiruZ", "RavinduK", "AsankaV", "DulshanR", "IsuruN", "PrabathL", "NishanP",
    "ThilinaB", "UdaraD", "SandunX", "HarshaM", "LakmalR", "RoshanD"
};

    string[] passwords = {
    "*","Pass@123", "Secure@456", "Hello@789", "Strong#007", "Test@999", "Random@77", "Welcome@85", "Tharindu@X", "Super@22", "Safe@Gayan",
    "Janaka@Pass", "Ruwan@T99", "Indu@Mil2022", "Lahiru#Z", "Ravindu@K!!", "Asanka#V20", "Dulshan@R", "Isuru@N99", "Prabath@L33", "Nishan@P!!",
    "Thilina@B12", "Udara@D55", "Sandun@X", "Harsha@M", "Lakmal@R", "Roshan@D99"
};

    string[] emails = {
    "*","kamal@gmail.com", "nimal@yahoo.com", "saman@hotmail.com", "sunil@outlook.com", "chamara@gmail.com", "kasun@mail.com", "amila85@gmail.com", "tharindu_x@gmail.com", "dilshan22@mail.com", "gayan_p@hotmail.com",
    "janaka_c@gmail.com", "ruwan_t@yahoo.com", "indunil_m@gmail.com", "lahiru_z@mail.com", "ravindu_k@yahoo.com", "asanka_v@hotmail.com", "dulshan_r@gmail.com", "isuru_n@yahoo.com", "prabath_l@mail.com", "nishan_p@hotmail.com",
    "thilina_b@gmail.com", "udara_d@yahoo.com", "sandun_x@gmail.com", "harsha_m@yahoo.com", "lakmal_r@hotmail.com", "roshan_d@gmail.com"
};

    string[] phones = {
    "*","0712345678", "0723456789", "0774567890", "0755678901", "0716789012", "0767890123", "0708901234", "0789012345", "0740123456", "0711122334",
    "0722233445", "0733344556", "0754455667", "0775566778", "0766677889", "0707788990", "0788899001", "0719900112", "0720011223", "0751122334",
    "0762233445", "0773344556", "0784455667", "0745566778", "0756677889", "0767788990"
};

    string[] addresses = {
    "*","Colombo", "Galle", "Kandy", "Kurunegala", "Jaffna", "Negombo", "Matara", "Batticaloa", "Anuradhapura", "Polonnaruwa",
    "Ratnapura", "Nuwara Eliya", "Trincomalee", "Badulla", "Puttalam", "Monaragala", "Hambantota", "Kalutara", "Gampaha", "Kegalle",
    "Vavuniya", "Mannar", "Kilinochchi", "Mullaitivu", "Matale", "Ampara"
};

    string[] nics = {
    "*","199012345678", "199112345678", "198512345678", "198912345678", "199312345678", "199412345678", "199512345678", "199612345678", "198212345678", "199812345678",
    "199212345678", "198912345678", "199112345678", "199512345678", "199712345678", "199212345678", "199312345678", "199012345678", "199512345678", "199412345678",
    "198812345678", "199012345678", "199612345678", "199712345678", "199812345678", "199212345678"
};

    for(int x=0;nics.Length>x;x++)
    {
        userlist.AddBack(names[x],usernames[x], passwords[x], emails[x], phones[x], addresses[x], nics[x]);
    }

}

bydefault();

while (t == true)
{
    
    Console.WriteLine("========================================");
    Console.WriteLine("          Welcome to Deport-Go          ");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Admin");
    Console.WriteLine("2. User");
    Console.WriteLine("3. Exit");
    Console.WriteLine("========================================");
    Console.Write("Select account: ");
    int account = Convert.ToInt32(Console.ReadLine());

    /////admin side//////////
    if (account == 1)
    {
        Console.WriteLine("========================================");
        Console.WriteLine("          Admin login          ");

        Console.Write("Enter the password: ");
        Console.WriteLine("========================================");
        
        string password = Console.ReadLine();
        if (password == "admin")

        {
            Console.Clear();
            Console.WriteLine("Welcome Admin");
            t_admin = true; // Reset t_admin to true
            while (t_admin == true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("          Admin Operations              ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Bus");
                Console.WriteLine("2. View Bus List");
                Console.WriteLine("3. View Next Time Bus");
                Console.WriteLine("4. Delete A Bus");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("5.Add Destination");
                Console.WriteLine("6. View Destination List");
                Console.WriteLine("7. delete Destination");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("8. Add User");
                Console.WriteLine("9. View User List");
                Console.WriteLine("10. Delete User");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("11. Go to Main Terminal");
                Console.WriteLine("========================================");
                Console.Write("Select operation: ");
                int operation = Convert.ToInt32(Console.ReadLine());
                if (operation == 1)
                {
                    operationcall.addbus(busdatalist);
                }
                else if (operation == 2)
                {
                    busdatalist.Print();
                }
                else if (operation == 3)
                {
                    operationcall.timesort(busdatalist);
                }
                else if (operation == 4)
                {
                    operationcall.removebus(busdatalist);
                }
                else if (operation == 5)
                {
                    Console.WriteLine("Enter the destination name");
                    string distname = Console.ReadLine();
                    Console.WriteLine("Enter the distance");
                    float distance = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the price");
                    float price = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the root number");
                    int rootno = int.Parse(Console.ReadLine());
                    distlist.AddBack(distname, distance, price, rootno);
                }
                else if (operation == 6)
                {
                    distlist.Print();
                }
                else if (operation == 7)
                {
                    Console.WriteLine("Enter the destination name");
                    string distname = Console.ReadLine();
                    distlist.deleteatdist(distname);
                }
                else if(operation == 8)
                {
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter your username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string password1 = Console.ReadLine();
                    Console.WriteLine("Enter your email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter your phone number: ");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Enter your address: ");
                    string address = Console.ReadLine();
                    Console.WriteLine("Enter your NIC: ");
                    string nic = Console.ReadLine();
                    userlist.AddBack(name, username, password1, email, phone, address, nic);
                }
                else if (operation == 9)
                {
                    userlist.Print();
                }
                else if (operation == 10)
                {
                    Console.WriteLine("Enter the username");
                    string username = Console.ReadLine();
                    userlist.deleteuser(username);
                }
                else if (operation == 11)
                {
                    t_admin = false;
                }
                else
                {
                    Console.WriteLine("Invalid operation");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Invalid password");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
   
    /////user side/////
    else if (account == 2)

    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("          User login          ");
        Console.WriteLine("\nDo you have an account? (y/n): ");
        string haveaccount = Console.ReadLine();

        Console.WriteLine("========================================");
        if (haveaccount.ToLower() == "n")
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your phone number: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter your address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your NIC: ");
            string nic = Console.ReadLine();
            userlist.AddBack(name, username, password, email, phone, address, nic);
        }
        else if (haveaccount.ToLower() == "y")
        {
            Console.WriteLine("========================================");
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();
            Console.WriteLine("========================================");

            if (userlist.verification(username, password))
            {


                Console.WriteLine("Welcome " + userlist.searchname(username));
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("          User Operations               ");
                    Console.WriteLine("========================================");
                    Console.WriteLine("1. View Destination List");
                    Console.WriteLine("2. View Bus List");
                    Console.WriteLine("3. Search Bus");
                    Console.WriteLine("4. Book Seat");
                    Console.WriteLine("5. Go to Main Terminal");
                    Console.WriteLine("========================================");
                    Console.Write("Select operation: ");
                    int operation = Convert.ToInt32(Console.ReadLine());
                    if (operation == 1)
                    {
                        Console.Write("Enter the root number: ");
                        int rootno = Convert.ToInt32(Console.ReadLine());
                        distlist.printdistbyroot(rootno);
                    }
                    else if (operation == 2)
                    {
                        Console.Write("Enter the root number: ");
                        int rootno = Convert.ToInt32(Console.ReadLine());
                        busdatalist.printbuslistbyroot(rootno);
                    }
                    else if (operation == 3)
                    {
                        Console.Write("Enter the destination: ");
                        string destination = Console.ReadLine();
                        Console.Write("Enter the time: ");
                        float time = float.Parse(Console.ReadLine());
                        operationcall.searchbus(distlist, busdatalist, destination, time);
                    }
                    else if (operation == 4)
                    {
                        Console.Write("Enter the bus registration number: ");
                        string regno = Console.ReadLine();
                        Console.Write("Enter the number of seats: ");
                        int seat = Convert.ToInt32(Console.ReadLine());
                        busdatalist.bookseat(regno, seat);
                    }
                    else if (operation == 5)
                    {
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Invalid operation");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

        }
        
        
        
    }
    ///// exit/////
    else if (account == 3)
    {
        Console.Write("Are you sure you want to exit? (y/n): ");
        string confirm = Console.ReadLine();
        if (confirm.ToLower() == "y")
        {
            t = false;
        }
    }
    ////////////error////////
    else
    {
        Console.WriteLine("Invalid account");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
