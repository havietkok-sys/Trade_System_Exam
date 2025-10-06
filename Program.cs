using Kontohantering;

// Får se hur om jag kör en klass till för Själva trade systemet.

Kontohanterare konton = new Kontohanterare();
//  Hämtar datan
konton.LaddaData();

bool kör = true;

// Ny klass för loggin 

Inloggning login = new Inloggning(konton);







while (kör)
{
    Console.Clear();
    Console.WriteLine(" ANVÄNDARKONTON ");
    Console.WriteLine("1. Registrera användare");
    Console.WriteLine("2. Visa alla användare");
    Console.WriteLine("3. Logga in");
    Console.WriteLine("4. Avsluta");
    Console.Write("Välj ett alternativ: ");

    string val = Console.ReadLine();

//  Ska nog komma in ett alternativ här tänker jag logga in. Fan dumt å sätta val börja tänka på value hela tiden.


    if (val == "1")
    {
        Console.Clear();
        Console.WriteLine(" Ny registrering ");
        Console.Write(" Ange användarnamn: ");
        string namn = Console.ReadLine();

        Console.Write("Ange lösenord: ");
        string lösen = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(namn) || string.IsNullOrWhiteSpace(lösen))
            Console.WriteLine("Du måste fylla i både användarnamn och lösenord!");
        else
            konton.Registrera(namn, lösen);



        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        Console.ReadKey();




    }


    else if (val == "2")


    {
        konton.VisaAlla();
    }
    else if (val == "3")
    {
        Console.Clear();
        Console.WriteLine("--- Logga in ---");
        Console.Write("Ange användarnamn: ");
        string namn = Console.ReadLine();

        Console.Write("Ange lösenord: ");
        string lösen = Console.ReadLine();

        bool lyckad = login.FörsökLoggaIn(namn, lösen);

        if (lyckad)
        {
            Console.WriteLine($"Välkommen tillbaka, {namn}!"); 
            // $ = “tolka innehållet inom {} som kod, inte bara text.” Kan vara nice om du vill + eller göra något med det. Säg ålder + lr något sånt
            //  Inloggat läge 
            bool inloggad = true;
            while (inloggad)
            {
                Console.Clear();
                Console.WriteLine($" INLOGGAD SOM {namn} ");
                Console.WriteLine("1. Ladda upp vara");
                Console.WriteLine("2. Visa andra användares varor");
                Console.WriteLine("3. Skicka bytesförfrågan");
                Console.WriteLine("4. Visa mottagna förfrågningar");
                Console.WriteLine("5. Visa genomförda byten");
                Console.WriteLine("6. Logga ut");
                Console.Write("Välj ett alternativ: ");

                string inVal = Console.ReadLine();

                switch (inVal)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("=== Lägg till en vara ===");
                        Console.Write("Ange namn på varan: ");
                        string varunamn = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(varunamn))
                        {
                        Console.WriteLine("Du måste ange ett namn!");
                        }
                        else
                        {
                        konton.LäggTillVara(namn, varunamn);
                        }

                        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                        Console.ReadKey();
                        break;
                    
                    


                    case "2":
                        Console.Clear();
                        Console.WriteLine("TODO: Visa andra användares varor");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("TODO: Skicka bytesförfrågan");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("TODO: Visa mottagna förfrågningar");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("TODO: Visa genomförda byten");
                        Console.ReadKey();
                        break;

                    case "6":
                        inloggad = false;
                        Console.WriteLine("Du har loggat ut.");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val! Tryck på valfri tangent...");
                        Console.ReadKey();
                        break;
                }
            }
        }

// Slut på inloggat läget

        else
        {
            Console.WriteLine("Fel användarnamn eller lösenord.");
        }
        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }
    else if (val == "4")


    {
        kör = false;
    }
    else
    {
        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent...");
        Console.ReadKey();
    }
}
//  Börjar bli ett jävla helvete med alla klammrar nu. Var sjukt noga innan jag puttar in ny kod. 
// Nästa är att fixa hur man loggar in
// Glömde nog å git committa redan innan.