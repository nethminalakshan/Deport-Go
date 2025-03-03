using Deport_Go;
bool t = true;
bool t_admin = true;

operation operationcall = new operation();
distdatalist distlist = new distdatalist();
busdatalist busdatalist = new busdatalist();
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

}

bydefault();

while (t == true)
{
    Console.Clear();
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
        Console.Write("Enter the password: ");
        string password = Console.ReadLine();
        if (password == "admin")
        {
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
                Console.WriteLine("5. Go to Main Terminal");
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
    /////user side/////
    else if (account == 2)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          User Operations               ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. View Destination List");
            Console.WriteLine("2. View Bus List");
            Console.WriteLine("3. Search Bus");
            Console.WriteLine("4. Go to Main Terminal");
            Console.WriteLine("========================================");
            Console.Write("Select operation: ");
            int operation = Convert.ToInt32(Console.ReadLine());
            if (operation == 1)
            {
                Console.Write("Enter the root number: ");
                int rootno = Convert.ToInt32(Console.ReadLine());
                operationcall.printdist(rootno);
            }
            else if (operation == 2)
            {
                Console.Write("Enter the root number: ");
                int rootno = Convert.ToInt32(Console.ReadLine());
                operationcall.printbus(rootno);
            }
            else if (operation == 3)
            {
                Console.Write("Enter the destination: ");
                string destination = Console.ReadLine();
                Console.Write("Enter the time: ");
                float time = float.Parse(Console.ReadLine());
                operationcall.searchbus(busdatalist, destination, time);
            }
            else if (operation == 4)
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
    ////////////error////////
    else
    {
        Console.WriteLine("Invalid account");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
