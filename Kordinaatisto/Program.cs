using System;

namespace Koordinaatisto
{
    public struct Koordinaatti
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Koordinaatti(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool OnkoVieressa(Koordinaatti toinen)
        {
            int etaisyysX = Math.Abs(this.X - toinen.X);
            int etaisyysY = Math.Abs(this.Y - toinen.Y);

            return etaisyysX <= 1 && etaisyysY <= 1 && !(etaisyysX == 0 && etaisyysY == 0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Koordinaatti nollaKoordinaatti = new Koordinaatti(0, 0);

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Koordinaatti testattava = new Koordinaatti(x, y);

                    if (testattava.X == nollaKoordinaatti.X && testattava.Y == nollaKoordinaatti.Y)
                    {
                        Console.WriteLine($"Annettu koordinaatti {testattava.X},{testattava.Y} on koordinaatissa {nollaKoordinaatti.X},{nollaKoordinaatti.Y}.");
                    }
                    else if (testattava.OnkoVieressa(nollaKoordinaatti))
                    {
                        Console.WriteLine($"Annettu koordinaatti {testattava.X},{testattava.Y} on koordinaatin {nollaKoordinaatti.X},{nollaKoordinaatti.Y} vieressä.");
                    }
                }
            }
        }
    }
}