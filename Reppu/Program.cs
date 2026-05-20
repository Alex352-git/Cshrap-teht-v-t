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

    public class Kirves : Tavara
    {
        public Kirves() : base(4, 2) { }
        public override string ToString() { return "Kirves"; }
    }

    public class VaritettyTavara<T>
    {
        public T Esine { get; }
        public ConsoleColor Vari { get; }

        public VaritettyTavara(T esine, ConsoleColor vari)
        {
            Esine = esine;
            Vari = vari;
        }

        public void NaytaTavara()
        {
            ConsoleColor vanhaVari = Console.ForegroundColor;
            Console.ForegroundColor = Vari;
            Console.WriteLine(Esine.ToString());
            Console.ForegroundColor = vanhaVari;
        }
    }

    public class Reppu
    {
        private int maxTavarat;
        private double maxPaino;
        private double maxTilavuus;
        private List<VaritettyTavara<Tavara>> tavarat;

        public Reppu(int maxTavarat, double maxPaino, double maxTilavuus)
        {
            this.maxTavarat = maxTavarat;
            this.maxPaino = maxPaino;
            this.maxTilavuus = maxTilavuus;
            this.tavarat = new List<VaritettyTavara<Tavara>>();
        }

        public int NykyinenTavaraMaara => tavarat.Count;
        public double NykyinenPaino => tavarat.Sum(t => t.Esine.Paino);
        public double NykyinenTilavuus => tavarat.Sum(t => t.Esine.Tilavuus);

        public bool Lisää(VaritettyTavara<Tavara> tavara)
        {
            if (NykyinenTavaraMaara + 1 > maxTavarat) return false;
            if (NykyinenPaino + tavara.Esine.Paino > maxPaino) return false;
            if (NykyinenTilavuus + tavara.Esine.Tilavuus > maxTilavuus) return false;

            tavarat.Add(tavara);
            return true;
        }

        public override string ToString()
        {
            if (tavarat.Count == 0)
            {
                return "Reppu on tyhjä.";
            }

            return "Repussa on seuraavat tavarat: " + string.Join(", ", tavarat.Select(t => t.Esine.ToString()));
        }

        public string KapasiteettiRaportti()
        {
            return $"Repussa on tällä hetkellä {NykyinenTavaraMaara}/{maxTavarat} tavaraa, {NykyinenPaino}/{maxPaino} painoa, and {NykyinenTilavuus}/{maxTilavuus} tilavuus.";
        }
    }

    class Program
    {
        public static void NaytaTavara<T>(VaritettyTavara<T> varitettyTavara)
        {
            varitettyTavara.NaytaTavara();
        }

        static void Main(string[] args)
        {
            VaritettyTavara<Miekka> esimerkkimiekka = new VaritettyTavara<Miekka>(new Miekka(), ConsoleColor.Blue);
            NaytaTavara(esimerkkimiekka);

            VaritettyTavara<Jousi> esimerkkijousi = new VaritettyTavara<Jousi>(new Jousi(), ConsoleColor.Red);
            esimerkkijousi.NaytaTavara();

            VaritettyTavara<Kirves> esimerkkikirves = new VaritettyTavara<Kirves>(new Kirves(), ConsoleColor.Green);
            esimerkkikirves.NaytaTavara();

            Console.WriteLine();

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
                VaritettyTavara<Tavara> uusiTavara = null;

                switch (valinta)
                {
                    case "1": uusiTavara = new VaritettyTavara<Tavara>(new Nuoli(), ConsoleColor.White); break;
                    case "2": uusiTavara = new VaritettyTavara<Tavara>(new Jousi(), ConsoleColor.Red); break;
                    case "3": uusiTavara = new VaritettyTavara<Tavara>(new Köysi(), ConsoleColor.Yellow); break;
                    case "4": uusiTavara = new VaritettyTavara<Tavara>(new Vesi(), ConsoleColor.Blue); break;
                    case "5": uusiTavara = new VaritettyTavara<Tavara>(new Ruoka(), ConsoleColor.Green); break;
                    case "6": uusiTavara = new VaritettyTavara<Tavara>(new Miekka(), ConsoleColor.Cyan); break;
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