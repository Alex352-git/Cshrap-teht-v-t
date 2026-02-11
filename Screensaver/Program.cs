using System.Numerics;
using Raylib_cs;

namespace Screensaver
{
    class WindowTest
    {
        static Vector2 Törmäystarkistus(Vector2 paikka, Vector2 suunta, int screendWidth, int screendHeight)
        {
            if (paikka.X < 0 || paikka.X > screendWidth)
            {
                suunta.X *= -1.0f;
            }
            if (paikka.Y < 0 || paikka.Y > screendHeight)
            {
                suunta.Y *= -1.0f;
            }
            return suunta;
        }
        public static void Main()
        {
            int screen_width =800;
            int screen_height =600;
            Vector2 A= new Vector2(100,20);
            Vector2 B = new Vector2(60, 40);
            Vector2 C = new Vector2(300, 60);
            Vector2 Amove = new Vector2(1, 1);
            Vector2 Bmove = new Vector2(1,-1);
            Vector2 Cmove = new Vector2(-1, 1);
            float speed = 500;
            var R = new Random();

            Raylib.InitWindow(screen_width, screen_height, "Screensaver");

            while (Raylib.WindowShouldClose() == false)
            {
                
                float dt = Raylib.GetFrameTime();
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawLineV(A, B, Color.DarkBlue);
                Raylib.DrawLineV(B, C, Color.Magenta);
                Raylib.DrawLineV(C,A, Color.Lime);
                A.X = Amove.X * speed * dt + A.X;
                A.Y = Amove.Y* speed* dt + A.Y;
                B.X = Bmove.X* speed* dt + B.X;
                B.Y = Bmove.Y* speed* dt + B.Y;
                C.X = Cmove.X* speed* dt + C.X;
                C.Y = Cmove.Y* speed* dt + C.Y;
                Amove=Törmäystarkistus(A,Amove, screen_width,screen_height);
                Bmove = Törmäystarkistus(B, Bmove, screen_width, screen_height);
                Cmove = Törmäystarkistus(C, Cmove, screen_width, screen_height);



                System.Threading.Thread.Sleep(1);


                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}