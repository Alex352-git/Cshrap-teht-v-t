using System;
using System.Collections.Generic;
using System.Linq;

namespace Reppu
{
    public class Tavara
    {
        public double Paino { get; }
        public double Tilavuus { get; }

        public Tavara(double paino, double tilavuus)
        {
            Paino = paino;
            Tilavuus = tilavuus;
        }
    }

    public class Nuoli : Tavara
    {
        public Nuoli() : base(0.1, 0.05) { }
        public override string ToString() { return "Nuoli"; }
    }

    public class Jousi : Tavara
    {
        public Jousi() : base(1, 4) { }
        public override string ToString() { return "Jousi"; }
    }

    public class Köysi : Tavara
    {
        public Köysi() : base(1, 1.5) { }
        public override string ToString() { return "Köysi"; }
    }

    public class Vesi : Tavara
    {
        public Vesi() : base(2, 2) { }
        public override string ToString() { return "Vesi"; }
    }

    public class Ruoka : Tavara
    {
        public Ruoka() : base(1, 0.5) { }
        public override string ToString() { return "Ruoka"; }
    }

    public class Miekka : Tavara
    {
        public Miekka() : base(5, 3) { }
        public override string ToString() { return "Miekka"; }
    }

    public class Reppu
    {
        private int maxTavarat;
        private double maxPaino;
        private double maxTilavuus;
        private List<Tavara> tavarat;

        public Reppu(int maxTavarat, double maxPaino, double maxTilavuus)
        {
            this.maxTavarat = maxTavarat;
            this.maxPaino = maxPaino;
            this.maxTilavuus = maxTilavuus;
            this.tavarat = new List<Tavara>();
        }

        public int NykyinenTavaraMaara => tavarat.Count;
        public double NykyinenPaino => tavarat.Sum(t => t.Paino);
        public double NykyinenTilavuus => tavarat.Sum(t => t.Tilavuus);

        public bool Lisää(Tavara tavara)
        {
            if (NykyinenTavaraMaara + 1 > maxTavarat) return false;
            if (NykyinenPaino + tavara.Paino > maxPaino) return false;
            if (NykyinenTilavuus + tavara.Tilavuus > maxTilavuus) return false;

            tavarat.Add(tavara);
            return true;
        }

      
        public override string ToString()
        {
            if (tavarat.Count == 0)
            {
                return "Reppu on tyhjä.";
            }

          
            return "Repussa on seuraavat tavarat: " + string.Join(", ", tavarat);
        }

        
        public string KapasiteettiRaportti()
        {
            return $"Repussa on tällä hetkellä {NykyinenTavaraMaara}/{maxTavarat} tavaraa, {NykyinenPaino}/{maxPaino} painoa, and {NykyinenTilavuus}/{maxTilavuus} tilavuus.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Reppu reppu = new Reppu(10, 30, 20);

            while (true)
            {
                
                Console.WriteLine(reppu.KapasiteettiRaportti());
                
                Console.WriteLine(reppu.ToString());

                Console.WriteLine("Mitä haluat lisätä?");
                Console.WriteLine("1 - Nuoli");
                Console.WriteLine("2 - Jousi");
                Console.WriteLine("3 - Köysi");
                Console.WriteLine("4 - Vettä");
                Console.WriteLine("5 - Ruokaa");
                Console.WriteLine("6 - Miekka");

                string valinta = Console.ReadLine();
                Tavara uusiTavara = null;

                switch (valinta)
                {
                    case "1": uusiTavara = new Nuoli(); break;
                    case "2": uusiTavara = new Jousi(); break;
                    case "3": uusiTavara = new Köysi(); break;
                    case "4": uusiTavara = new Vesi(); break;
                    case "5": uusiTavara = new Ruoka(); break;
                    case "6": uusiTavara = new Miekka(); break;
                    default: continue;
                }

                if (!reppu.Lisää(uusiTavara))
                {
                    Console.WriteLine("Tavara ei mahdu reppuun!");
                    Console.WriteLine();
                }
            }
        }
    }
}