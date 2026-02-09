using System.Numerics;
using Raylib_cs;

namespace Pong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector2 player1;
            Vector2 player2;
            Vector2 ball;
            Vector2 playerSize;
            Raylib.InitWindow(800, 600, "Pong!");
            Raylib.SetTargetFPS(60);
            while( Raylib.WindowShouldClose() == false)
            {
                Raylib.BeginDrawing();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
