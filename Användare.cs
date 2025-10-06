namespace Kontohantering
{
    // Klass för enskild användare
    public class Användare
    {
        public string användarnamn;
        public string lösenord;

        //  Varje användar får en lista med varot
        public List<Vara> varor = new();

        public Användare(string namn, string lösen)
        {
            användarnamn = namn;
            lösenord = lösen;
        }
    }

    // Klass lista av användare
    public class Kontohanterare
    {
        public List<Användare> användarLista = new();

//      Gör filen?
        private string filnamn = "data.txt";

        public void Registrera(string namn, string lösen)
        {
            Användare ny = new Användare(namn, lösen);
            användarLista.Add(ny);
            Console.WriteLine("Användare '" + namn + "' skapad!");
            //  Rad för å spara datan för användaren
            SparaData(); 

        }
//  Har fortfarande inte intuationen för void och kickback av values.
//  
        public void VisaAlla()
        {
            Console.Clear();
            Console.WriteLine("Registrerade användare:");

            if (användarLista.Count == 0)
            {
                Console.WriteLine("Inga användare registrerade ännu!");
            }
            else
            {
                foreach (Användare person in användarLista)
                    Console.WriteLine(": " + person.användarnamn);
            }

            Console.WriteLine("Tryck på valfri tangent för att fortsätta.");
            Console.ReadKey();
        }

        // Ny metod för å lägga till varor på 
     public void LäggTillVara(string användarnamn, string varunamn)
        {
            foreach (Användare person in användarLista)
            {
                if (person.användarnamn == användarnamn)
                {
                    Vara ny = new Vara(varunamn, användarnamn);
                    person.varor.Add(ny);
                    Console.WriteLine($"Vara '{varunamn}' tillagd till {användarnamn}!");
//                 Rad  Sparar Vara
                    SparaData();

                    return;
                }
            }
            Console.WriteLine("Användare hittades inte.");
        }

// Sparnings koden
    public void SparaData()
    {
        List<string> rader = new();

        foreach (Användare person in användarLista)
        {
            rader.Add($"ANV:{person.användarnamn};{person.lösenord}");
            foreach (Vara v in person.varor)
                rader.Add($"VARA:{v.namn}");
        }

        File.WriteAllLines(filnamn, rader);
    }

    public void LaddaData()
    {
        if (!File.Exists(filnamn))
            return;

        string[] rader = File.ReadAllLines(filnamn);
        Användare aktuell = null;

        foreach (string rad in rader)
        {
            if (rad.StartsWith("ANV:"))
            {
                string[] delar = rad.Substring(4).Split(';');
                if (delar.Length == 2)
                {
                    aktuell = new Användare(delar[0], delar[1]);
                    användarLista.Add(aktuell);
                }
            }
            else if (rad.StartsWith("VARA:") && aktuell != null)
            {
                string varunamn = rad.Substring(5);
                Vara ny = new Vara(varunamn, aktuell.användarnamn);
                aktuell.varor.Add(ny);
            }
        }
    }





    }

    public class Inloggning
    {
        private Kontohanterare konton;

        // Konstruktor som tar emot en referens till kontohanteraren
        public Inloggning(Kontohanterare kontohanterare)
        {
            konton = kontohanterare;
        }

        public bool FörsökLoggaIn(string namn, string lösen)
        {
            foreach (Användare person in konton.användarLista)
            {
                if (person.användarnamn == namn && person.lösenord == lösen)
                    return true;
            }

            return false;
        }
    }
  }
//  Börjar bli ett jävla helvete med alla klammrar nu. Var sjukt noga innan jag puttar in ny kod. 

// Vara Att trade egen class
    public class Vara
    {
        public string namn;
        public string ägare;

        public Vara(string varunamn, string ägarNamn)
        {
            namn = varunamn;
            ägare = ägarNamn;
        }
    }