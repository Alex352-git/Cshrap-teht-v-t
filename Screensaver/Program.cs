using System.Numerics;
using Raylib_cs;

namespace Screensaver
{
    class WindowTest
    {
        public static void Main()
        {
            int screen_width =800;
            int screen_height =600;
            Vector2 A= new Vector2(10,10);
            Vector2 B = new Vector2(10, 10);
            Vector2 C = new Vector2(10, 10);
            Vector2 Amove = new Vector2(10, 10);
            Vector2 Bmove = new Vector2(10, 10);
            Vector2 Cmove = new Vector2(10, 10);
             

            Raylib.InitWindow(screen_width, screen_height, "Raylib");

            while (Raylib.WindowShouldClose() == false)
            {
                
                float dt = Raylib.GetFrameTime();
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);



            

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}