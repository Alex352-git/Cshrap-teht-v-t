namespace Ovi_auki
{
    internal class Program
    {
        enum OvenTila
        {
            Auki,
            Kiinni,
            Lukossa
        }

        static void Main(string[] args)
        {
            OvenTila ovi = OvenTila.Lukossa;

            Console.WriteLine("Moi tässä on ovi ja se on lukossa sinulla on viisi komentoo");
            Console.WriteLine("avaa");
            Console.WriteLine("sulje");
            Console.WriteLine("lukitse");
            Console.WriteLine("poista lukitus tai avaa lukko");
            Console.WriteLine("lopeta (ohjelma sulkee)");

            while (true)
            {
                Console.WriteLine($"Ovi on {ovi}. Mitä haluat tehdä?");
                string komento = Console.ReadLine().ToLower();

                if (komento == "avaa")
                {
                    if (ovi == OvenTila.Kiinni)
                    {
                        ovi = OvenTila.Auki;
                        Console.WriteLine($"Ovi on nyt {ovi}");
                    }
                    else
                        Console.WriteLine("Et voi avata ovea nyt.");
                }
                else if (komento == "sulje")
                {
                    if (ovi == OvenTila.Auki)
                    {
                        ovi = OvenTila.Kiinni;
                        Console.WriteLine($"Ovi on nyt {ovi}");

                    }




                    else
                        Console.WriteLine("Et voi sulkea ovea nyt.");
                }
                else if (komento == "lukitse")
                {
                    if (ovi == OvenTila.Kiinni || ovi == OvenTila.Auki) 
                    {
                        ovi = OvenTila.Lukossa;
                        Console.WriteLine($"Ovi on nyt {ovi}");
                    }
                        
                    else
                        Console.WriteLine("Et voi lukita ovea nyt.");
                }
                else if (komento == "avaa lukko" || komento == "poista lukitus")
                {
                    if (ovi == OvenTila.Lukossa)

                    {
                        ovi = OvenTila.Kiinni;
                        Console.WriteLine($"Ovi on nyt {ovi}");
                    }
                    else
                        Console.WriteLine("Ovi ei ole lukossa.");
                }
                else if (komento == "lopeta")
                    break;
                else
                {
                    Console.WriteLine("Tuntematon komento.");
                }
            }
        }
    }
}
