

namespace Nuoli_generaattori
{
    // Enumeraattorit
    enum Karki
    {
        puu,
        teras,
        timantti
    }

    enum Pera
    {
        lehti,
        kanansulka,
        kotkansulka
    }

    class Nuoli
    {
        public Karki NuolenKarki { get; set; }
        public Pera NuolenPera { get; set; }
        public int VarrenPituus { get; set; } // sentteinä

        // Metodi nuolen hinnan laskemiseen
        public double PalautaHinta()
        {
            double hinta = 0;

            // Kärki
            switch (NuolenKarki)
            {
                case Karki.puu:
                    hinta += 3;
                    break;
                case Karki.teras:
                    hinta += 5;
                    break;
                case Karki.timantti:
                    hinta += 50;
                    break;
            }

            // Perä
            switch (NuolenPera)
            {
                case Pera.lehti:
                    hinta += 0;
                    break;
                case Pera.kanansulka:
                    hinta += 1;
                    break;
                case Pera.kotkansulka:
                    hinta += 5;
                    break;
            }

            // Varsi
            hinta += 0.05 * VarrenPituus;

            return hinta;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Karki karki;
            while (true)
            {
                Console.Write("Minkälainen kärki (puu, teräs, timantti)?: ");
                string input = Console.ReadLine().ToLower();
                if (Enum.TryParse(input, true, out karki))
                    break;
                Console.WriteLine("Ei ole valinta, yritä uudelleen.");
            }

            Pera pera;
            while (true)
            {
                Console.Write("Minkälaiset sulat (lehti, kanansulka, kotkansulka)?: ");
                string input = Console.ReadLine().ToLower();
                if (Enum.TryParse(input, true, out pera))
                    break;
                Console.WriteLine("Ei ole valinta, yritä uudelleen.");
            }

            int pituus;
            while (true)
            {
                Console.Write("Nuolen pituus sentteinä (60-100): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out pituus) && pituus >= 60 && pituus <= 100)
                    break;
                Console.WriteLine("Virheellinen pituus, yritä uudelleen.");
            }

            Nuoli nuoli = new Nuoli
            {
                NuolenKarki = karki,
                NuolenPera = pera,
                VarrenPituus = pituus
            };

            Console.WriteLine($"Tämän nuolen hinta on {nuoli.PalautaHinta()} kultaraha.");
        }
    }
}