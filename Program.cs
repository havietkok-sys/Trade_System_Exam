using Kontohantering;

Kontohanterare konton = new Kontohanterare();
bool kör = true;

while (kör)
{
    Console.Clear();
    Console.WriteLine(" ANVÄNDARKONTON ");
    Console.WriteLine("1. Registrera användare");
    Console.WriteLine("2. Visa alla användare");
    Console.WriteLine("3. Avsluta");
    Console.Write("Välj ett alternativ: ");

    string val = Console.ReadLine();

    if (val == "1")
    {
        Console.Clear();
        Console.WriteLine("--- Ny registrering ---");
        Console.Write("Ange användarnamn: ");
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
        kör = false;
    }
    else
    {
        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent...");
        Console.ReadKey();
    }
}