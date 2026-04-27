using System;

namespace Ovi_auki
{
    enum OvenTila
    {
        Auki,
        Kiinni,
        Lukossa
    }

    class Ovi
    {
        public OvenTila Tila { get; set; }

        public Ovi()
        {
            Tila = OvenTila.Lukossa;
        }

        public void Avaa()
        {
            if (Tila == OvenTila.Kiinni)
            {
                Tila = OvenTila.Auki;
                Console.WriteLine($"Ovi on nyt {Tila}");
            }
            else
            {
                Console.WriteLine("Et voi avata ovea nyt.");
            }
        }

        public void Sulje()
        {
            if (Tila == OvenTila.Auki)
            {
                Tila = OvenTila.Kiinni;
                Console.WriteLine($"Ovi on nyt {Tila}");
            }
            else
            {
                Console.WriteLine("Et voi sulkea ovea nyt.");
            }
        }

        public void Lukitse()
        {
            if (Tila == OvenTila.Kiinni || Tila == OvenTila.Auki)
            {
                Tila = OvenTila.Lukossa;
                Console.WriteLine($"Ovi on nyt {Tila}");
            }
            else
            {
                Console.WriteLine("Et voi lukita ovea nyt.");
            }
        }

        public void PoistaLukitus()
        {
            if (Tila == OvenTila.Lukossa)
            {
                Tila = OvenTila.Kiinni;
                Console.WriteLine($"Ovi on nyt {Tila}");
            }
            else
            {
                Console.WriteLine("Ovi ei ole lukossa.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Ovi oviOlio = new Ovi();

            Console.WriteLine("Moi tässä on ovi ja se on lukossa sinulla on viisi komentoo");
            Console.WriteLine("avaa");
            Console.WriteLine("sulje");
            Console.WriteLine("lukitse");
            Console.WriteLine("poista lukitus tai avaa lukko");
            Console.WriteLine("lopeta (ohjelma sulkee)");

            while (true)
            {
                Console.WriteLine($"\nOvi on {oviOlio.Tila}. Mitä haluat tehdä?");
                string komento = Console.ReadLine().ToLower();

                if (komento == "avaa")
                {
                    oviOlio.Avaa();
                }
                else if (komento == "sulje")
                {
                    oviOlio.Sulje();
                }
                else if (komento == "lukitse")
                {
                    oviOlio.Lukitse();
                    Console.WriteLine("Lukko on asetettu.");
                }
                else if (komento == "avaa lukko" || komento == "poista lukitus")
                {
                    oviOlio.PoistaLukitus();
                    Console.WriteLine("Lukko on avattu.");
                }
                else if (komento == "lopeta")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Tuntematon komento.");
                }
            }
        }
    }
}