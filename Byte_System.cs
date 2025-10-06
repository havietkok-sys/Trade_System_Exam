namespace byte_system
{
    // Här kommer vi lägga alla klasser för själva byteslogiken

    public class Byte
    {
        public string avsändare;
        public string mottagare;
        public string varaSomBegärs;
        public string varaErbjuden;
        public string status; // t.ex."väntar accepterad nekad

        public Byte(string avsändare, string mottagare, string begärd, string erbjuden)
        {
            this.avsändare = avsändare;
            this.mottagare = mottagare;
            varaSomBegärs = begärd;
            varaErbjuden = erbjuden;
            status = "väntar";
        }
    }




    public class ByteSystem
    {
        public List<Byte> bytesLista = new();

        public void SkickaFörfrågan(string avsändare, string mottagare, string varaBegärd, string varaErbjuden)
        {
            Byte ny = new Byte(avsändare, mottagare, varaBegärd, varaErbjuden);
            bytesLista.Add(ny);
            Console.WriteLine($"Bytesförfrågan skickad till {mottagare}!");
        }

        public void VisaMottagna(string användare)
        {
            Console.Clear();
            Console.WriteLine($"=== Mottagna förfrågningar för {användare} ===");

            bool hittade = false;

            foreach (Byte b in bytesLista)
            {
                if (b.mottagare == användare && b.status == "väntar")
                {
                    Console.WriteLine($"{b.avsändare} vill byta sin '{b.varaErbjuden}' mot din '{b.varaSomBegärs}'");
                    hittade = true;
                }
            }

            if (hittade == false)
                Console.WriteLine("Inga aktiva förfrågningar.");

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

        public void VisaGenomförda(string användare)
        {
            Console.Clear();
            Console.WriteLine($" Genomförda byten för {användare} ");

            bool hittade = false;

            foreach (Byte b in bytesLista)
            {
                if ((b.avsändare == användare || b.mottagare == användare) && b.status == "accepterad")
                {
                    Console.WriteLine($"{b.avsändare} ↔ {b.mottagare} ({b.varaErbjuden} ⇆ {b.varaSomBegärs})");
                    hittade = true;
                }
            }

            if (hittade == false)
                Console.WriteLine("Inga genomförda byten ännu.");

            Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }
    }
}