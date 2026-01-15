namespace KErtaus_tehtävä
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ritari_hp = 15;
            int orkki_hp = 15;
            Random random = new Random();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hello, Brave Adventurer. Time to kill orc!");
            Console.ResetColor();
            while (true)
            {
                int orkkidamage = random.Next(1, 6);
                int ritaridamage = random.Next(1, 6);
                int oneshot = random.Next(1, 100);
                Console.WriteLine($"Ritarin HP: {ritari_hp}/15");
                Console.WriteLine($"Örkin HP: {orkki_hp}/15");
                Console.WriteLine("Anna komento: 1 hyökkää, 2 puolusta");
                string vastaus = Console.ReadLine();
                if (vastaus == "1")
                {
                    orkki_hp -= ritaridamage;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Ritari tekee {ritaridamage} vahinkoo");
                    Console.ResetColor();
                    if (oneshot == 1)
                    {
                        orkki_hp -= 1000;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("CRITICAL HIT!!!");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.WriteLine("SURMASIT ÖRKIN");
                        break;
                    }



                }
                else if (vastaus == "2")
                {
                    orkkidamage -= 2;
                    if (orkkidamage <= 0)
                    {
                        orkkidamage = 1;
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Ritari puolustaa {orkkidamage} vahinkoo");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("En ymmärrä!");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Örkki hyökkää pelaaja ottaa {orkkidamage} vahinkoo!");
                Console.ResetColor();
                ritari_hp -= orkkidamage;


                if (ritari_hp <= 0 && orkki_hp <= 0)
                {
                    Console.WriteLine("Eeppinen tappelu molemmat kuolitte");
                    break;
                }

                if (orkki_hp <= 0)
                {
                    Console.WriteLine("tapoit Örkin hanen lapset itkee");
                    break;
                }
                if (ritari_hp <= 0)
                {
                    Console.WriteLine("Kuolit oot paska");
                }

            }


        }
    }
}
