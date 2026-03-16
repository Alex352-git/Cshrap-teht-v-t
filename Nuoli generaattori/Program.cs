using System;

namespace NuoliKauppa
{
    enum Kärki { puu, teräs, timantti }
    enum Perä { lehti, kanansulka, kotkansulka }

    class Nuoli
    {
        public Kärki NuolenKärki { get; private set; }
        public Perä NuolenPerä { get; private set; }
        public int VarrenPituus { get; private set; }

        public Nuoli(Kärki karki, Perä pera, int pituus)
        {
            NuolenKärki = karki;
            NuolenPerä = pera;
            VarrenPituus = pituus;
        }

        public static Nuoli LuoEliittiNuoli()
        {
            return new Nuoli(Kärki.timantti, Perä.kotkansulka, 100);
        }

        public static Nuoli LuoAloittelijaNuoli()
        {
            return new Nuoli(Kärki.puu, Perä.kanansulka, 70);
        }

        public static Nuoli LuoPerusNuoli()
        {
            return new Nuoli(Kärki.teräs, Perä.kanansulka, 85);
        }

        public double PalautaHinta()
        {
            double hinta = 0;

            switch (NuolenKärki)
            {
                case Kärki.puu: hinta += 3; break;
                case Kärki.teräs: hinta += 5; break;
                case Kärki.timantti: hinta += 50; break;
            }

            switch (NuolenPerä)
            {
                case Perä.lehti: hinta += 0; break;
                case Perä.kanansulka: hinta += 1; break;
                case Perä.kotkansulka: hinta += 5; break;
            }

            hinta += 0.05 * VarrenPituus;

            return hinta;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa nuolikauppaan.");

            int valinta = KysyNumero("Haluatko:\n1. Teettää nuolen tilaustyönä?\n2. Ostaa valmiin nuolen?\nValinta: ", 1, 2);

            Nuoli nuoli;

            if (valinta == 2)
            {
                int nuoliValinta = KysyNumero("Valitse valmis nuoli:\n1. Eliittinuoli\n2. Aloittelijanuoli\n3. Perusnuoli\nValinta: ", 1, 3);

                if (nuoliValinta == 1)
                    nuoli = Nuoli.LuoEliittiNuoli();
                else if (nuoliValinta == 2)
                    nuoli = Nuoli.LuoAloittelijaNuoli();
                else
                    nuoli = Nuoli.LuoPerusNuoli();
            }
            else
            {
                Kärki karki = KysyKarki();
                Perä pera = KysyPera();
                int pituus = KysyPituus();

                nuoli = new Nuoli(karki, pera, pituus);
            }

            Console.WriteLine($"Valitsemasi nuolen hinta on {nuoli.PalautaHinta()} kultarahaa.");
        }

        static int KysyNumero(string teksti, int min, int max)
        {
            int numero;
            while (true)
            {
                Console.Write(teksti);
                if (int.TryParse(Console.ReadLine(), out numero) && numero >= min && numero <= max)
                    return numero;

                Console.WriteLine("Virheellinen valinta, yritä uudelleen.");
            }
        }

        static Kärki KysyKarki()
        {
            while (true)
            {
                Console.Write("Minkälainen kärki (puu, teras, timantti)?: ");
                if (Enum.TryParse(Console.ReadLine(), true, out Kärki k))
                    return k;

                Console.WriteLine("Ei ole valinta, yritä uudelleen.");
            }
        }

        static Perä KysyPera()
        {
            while (true)
            {
                Console.Write("Minkälaiset sulat (lehti, kanansulka, kotkansulka)?: ");
                if (Enum.TryParse(Console.ReadLine(), true, out Perä p))
                    return p;

                Console.WriteLine("Ei ole valinta, yritä uudelleen.");
            }
        }

        static int KysyPituus()
        {
            int pituus;

            while (true)
            {
                Console.Write("Nuolen pituus sentteinä (60-100): ");

                if (int.TryParse(Console.ReadLine(), out pituus) && pituus >= 60 && pituus <= 100)
                    return pituus;

                Console.WriteLine("Virheellinen pituus, yritä uudelleen.");
            }
        }
    }
}