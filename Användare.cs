namespace Kontohantering
{
    // Klass för enskild användare
    public class Användare
    {
        public string användarnamn;
        public string lösenord;

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

        public void Registrera(string namn, string lösen)
        {
            Användare ny = new Användare(namn, lösen);
            användarLista.Add(ny);
            Console.WriteLine("Användare '" + namn + "' skapad!");
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