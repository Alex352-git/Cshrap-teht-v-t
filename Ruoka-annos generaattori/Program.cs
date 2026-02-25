namespace Ruoka_annos_generaattori
{
    enum PaaRaakaAine
    {
        nauta,
        kana,
        kasvis
    }

    enum Lisuke
    {
        peruna,
        riisi,
        pasta
    }

    enum Kastike
    {
        curry,
        pippuri,
        chili
    }

    class Ateria
    {
        public PaaRaakaAine PaaRaakaAine { get; set; }
        public Lisuke Lisuke { get; set; }
        public Kastike Kastike { get; set; }

        public override string ToString()
        {
            return $"{PaaRaakaAine} ja {Lisuke} {Kastike}-kastikkeella";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.List<Ateria> ateriat =
                new System.Collections.Generic.List<Ateria>();

            for (int i = 0; i < 3; i++)
            {
                System.Console.WriteLine($"\nLuo annos {i + 1}");

                PaaRaakaAine paa;
                while (true)
                {
                    System.Console.Write("Pääraaka-aine (nauta, kana, kasvis): ");
                    string input = System.Console.ReadLine();

                    if (System.Enum.TryParse(input, true, out paa))
                        break;

                    System.Console.WriteLine("Ei ole valinta, yritä uudelleen.");
                }

                Lisuke lisuke;
                while (true)
                {
                    System.Console.Write("Lisuke (peruna, riisi, pasta): ");
                    string input = System.Console.ReadLine();

                    if (System.Enum.TryParse(input, true, out lisuke))
                        break;

                    System.Console.WriteLine("Ei ole valinta, yritä uudelleen.");
                }

                Kastike kastike;
                while (true)
                {
                    System.Console.Write("Kastike (curry, pippuri, chili): ");
                    string input = System.Console.ReadLine();

                    if (System.Enum.TryParse(input, true, out kastike))
                        break;

                    System.Console.WriteLine("Ei ole valinta, yritä uudelleen.");
                }

                Ateria ateria = new Ateria
                {
                    PaaRaakaAine = paa,
                    Lisuke = lisuke,
                    Kastike = kastike
                };

                ateriat.Add(ateria);
            }

            System.Console.WriteLine("\nValitsemasi annokset:");
            foreach (var ateria in ateriat)
            {
                System.Console.WriteLine(ateria);
            }
        }
    }
}