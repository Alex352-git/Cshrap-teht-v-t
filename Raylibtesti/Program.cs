using Raylib_cs;

namespace Raylibtesti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Raylib");
            while (Raylib.WindowShouldClose() == false)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Gold);
                Raylib.DrawCircle(
                    Raylib.GetScreenWidth() / 2,
                    Raylib.GetScreenHeight() / 2,
                    1 + (float)Raylib.GetTime() * 4,
                    Color.Black);
                Raylib.EndDrawing();

            }
            Raylib.CloseWindow();
        }
    }
}
