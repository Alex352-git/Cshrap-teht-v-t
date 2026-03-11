using System.Numerics;
using Raylib_cs;

namespace Pong
{
    internal class Program
    {
        private const int Width = 800;

        float playerSpeed = 600;
        int playerWidth = 50;
        int playerHeight = 50;
        Rectangle player1;
        Rectangle player2;
        Vector2 ball;
        Vector2 ballVelocity;
        int score1 = 0;
        int score2 = 0;

        float speed = 400;
        private const int Height = 600;

        static Vector2 OffScreenCheck(Vector2 paikka, Vector2 suunta)

        {
            if (paikka.X < 3 || paikka.X > Width - 3)
            {
                suunta.X *= -1.0f;
            }
            if (paikka.Y < 3 || paikka.Y > Height - 3)
            {
                suunta.Y *= -1.0f;
            }
            return suunta;

        }
        static Vector2 PlayerBallCheck(Vector2 paikka, Vector2 suunta, Rectangle player)
        {
            if (Raylib.CheckCollisionPointRec(paikka, player))
            {
                suunta.X *= -1.0f;
            }
            return suunta;
        }
        static void Main(string[] args)
        {
            Program PongGame = new Program();
            PongGame.rungame();
        }
        void ResetBall()
        {
            ball = new Vector2(400, 300);
            ballVelocity = new Vector2(1, 1);
        }
        void rungame()
        {
            Raylib.InitWindow(Width, Height, "Pong!");
            Raylib.SetTargetFPS(60);
            playerSpeed = 600;
            playerWidth = 20;
            playerHeight = 150;
            int minY = 0;
            int maxY = 600 - playerHeight;
            player1 = new Rectangle(720, 200, playerWidth, playerHeight);
            player2 = new Rectangle(40, 200, playerWidth, playerHeight);
            ball = new Vector2(400, 300);
            ballVelocity = new Vector2(1, 1);
            int ballRadius = 20;

            while (Raylib.WindowShouldClose() == false)
            {
                ball = ball + ballVelocity * speed * Raylib.GetFrameTime();
                ballVelocity = OffScreenCheck(ball, ballVelocity);
                Raylib.BeginDrawing();
                Raylib.ClearBackground(color: Color.Gray);
                Raylib.DrawCircleV(ball, ballRadius, Color.DarkPurple);
                Raylib.DrawRectangleRec(player1, Color.Red);
                Raylib.DrawRectangleRec(player2, Color.Blue);
                // ballVelocity = PlayerBallCheck(ball, ballVelocity, player1);
                // ballVelocity = PlayerBallCheck(ball, ballVelocity, player2);
                Raylib.DrawText($"{score1}", 250, 10, 50, Color.Blue);
                Raylib.DrawText($"{score2}", 500, 10, 50, Color.Red);

                if (Raylib.IsKeyDown(KeyboardKey.Up) && player1.Y > minY)
                {
                    player1.Y = player1.Y - playerSpeed * Raylib.GetFrameTime();
                }
                if (Raylib.IsKeyDown(KeyboardKey.Down) && player1.Y < maxY)
                {
                    player1.Y = player1.Y + playerSpeed * Raylib.GetFrameTime();
                }
                if (Raylib.IsKeyDown(KeyboardKey.W) && player2.Y > minY)
                {
                    player2.Y = player2.Y - playerSpeed * Raylib.GetFrameTime();
                }
                if (Raylib.IsKeyDown(KeyboardKey.S) && player2.Y < maxY)

                {
                    player2.Y = player2.Y + playerSpeed * Raylib.GetFrameTime();
                }
                // Pelaajan 1 törmäytys
                if (ball.X <= player1.X + playerWidth && ball.X >= player1.X &&
                    ball.Y >= player1.Y && ball.Y <= player1.Y + playerHeight)
                {
                    ballVelocity.X *= -1;
                    ball.X = player1.X; // Korjaa pallon paikka    
                }

                // Pelaajan 2 törmäytys
                if (ball.X <= player2.X + playerWidth && ball.X >= player2.X &&
                    ball.Y >= player2.Y && ball.Y <= player2.Y + playerHeight)
                {
                    ballVelocity.X *= -1;
                    ball.X = player2.X + playerWidth; // Korjaa pallon paikka
                }

                // Pallo meni vasemmalle (pelaaja 2 saa pisteen)
                if (ball.X - ballRadius < 0)
                {
                    score2++;

                    ResetBall();
                }

                // Pallo meni oikealle (pelaaja 1 saa pisteen)
                if (ball.X + ballRadius > Width)
                {
                    score1++;
                    ResetBall();
                }

                if (score1 >= 4 || score2 >= 4)
                {
                    string winner = score1 > score2 ? "Pelaaja 2 voitti!" : "Pelaaja 1 voitti!";
                    Raylib.DrawText(winner, Width / 2 - 100, Height / 2 - 20, 30, Color.Green);
                    Raylib.EndDrawing();
                    Raylib.WaitTime(3.0f); // Odota hetki ennen sulkemista
                    break; // Lopeta peli
                }



                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}

