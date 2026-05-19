using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace Tanks
{
    public class Tank
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; private set; }
        public Color TankColor { get; private set; }
        public Vector2 Direction { get; set; }
        public int Score { get; set; } = 0;
        private float speed = 200f;
        Vector2 turretSize = new Vector2(10, 30);
        private KeyboardKey upKey, downKey, leftKey, rightKey, shootKey;

        public Tank(Vector2 position, Vector2 size, Color color, KeyboardKey up, KeyboardKey down, KeyboardKey left, KeyboardKey right, KeyboardKey shoot)
        {
            Position = position;
            Size = size;
            TankColor = color;
            Direction = Vector2.UnitX;

            upKey = up;
            downKey = down;
            leftKey = left;
            rightKey = right;
            shootKey = shoot;
        }

        public void Update(float deltaTime, List<Wall> walls, Tank enemyTank, List<Bullet> bullets, int ownerId)
        {
            Vector2 oldPos = Position;
            int screenWidth = Raylib.GetScreenWidth();
            int screenHeight = Raylib.GetScreenHeight();

            if (Raylib.IsKeyDown(upKey) && Position.Y > 0)
            {
                Position = new Vector2(Position.X, Position.Y - speed * deltaTime);
                Direction = -Vector2.UnitY;
            }
            else if (Raylib.IsKeyDown(downKey) && Position.Y < screenHeight - Size.Y)
            {
                Position = new Vector2(Position.X, Position.Y + speed * deltaTime);
                Direction = Vector2.UnitY;
            }
            else if (Raylib.IsKeyDown(leftKey) && Position.X > 0)
            {
                Position = new Vector2(Position.X - speed * deltaTime, Position.Y);
                Direction = -Vector2.UnitX;
            }
            else if (Raylib.IsKeyDown(rightKey) && Position.X < screenWidth - Size.X)
            {
                Position = new Vector2(Position.X + speed * deltaTime, Position.Y);
                Direction = Vector2.UnitX;
            }

            Rectangle playerRect = new Rectangle(Position.X, Position.Y, Size.X, Size.Y);
            Rectangle enemyRect = new Rectangle(enemyTank.Position.X, enemyTank.Position.Y, enemyTank.Size.X, enemyTank.Size.Y);

            foreach (var wall in walls)
            {
                if (Raylib.CheckCollisionRecs(playerRect, wall.Rect))
                {
                    Position = oldPos;
                    break;
                }
            }

            if (Raylib.IsKeyPressed(shootKey))
            {
                Vector2 bulletPos = Position + Size / 2;
                bullets.Add(new Bullet(bulletPos, Direction, ownerId));
            }

            if (Raylib.CheckCollisionRecs(playerRect, enemyRect))
            {
                Position = oldPos;
            }
        }

        public void DrawTank()
        {
            Raylib.DrawRectangleV(Position, Size, TankColor);

            Vector2 tankCenter = Position + new Vector2(Size.X / 2, Size.Y / 2);
            Vector2 turretOffset = Direction * (turretSize.Y + 10);
            Vector2 turretEndPos = tankCenter + turretOffset;
            Raylib.DrawLineEx(tankCenter, turretEndPos, 10, TankColor);
        }
    }

    public class Bullet
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public int Owner { get; set; }

        public Bullet(Vector2 position, Vector2 direction, int owner)
        {
            Position = position;
            Direction = direction;
            Owner = owner;
        }
    }

    public class Wall
    {
        public Rectangle Rect { get; set; }

        public Wall(Rectangle rect)
        {
            Rect = rect;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            const int screenWidth = 800;
            const int screenHeight = 600;
            Vector2 playerSize = new Vector2(50, 50);
            Color fieldColor;
            Color player1Color;
            Color player2Color;
            Color wallColor;
            Color bulletColor;
            int score1 = 0;
            int score2 = 0;

            Random rng = new Random();
            List<Wall> walls = new List<Wall>();

            player1Color = Color.Green;
            player2Color = Color.Purple;

            Tank player1 = new Tank(Vector2.Zero, playerSize, player1Color, KeyboardKey.W, KeyboardKey.S, KeyboardKey.A, KeyboardKey.D, KeyboardKey.LeftControl);
            Tank player2 = new Tank(Vector2.Zero, playerSize, player2Color, KeyboardKey.Up, KeyboardKey.Down, KeyboardKey.Left, KeyboardKey.Right, KeyboardKey.RightControl);

            List<Bullet> bullets = new List<Bullet>();
            float bulletSpeed = 500f;
            float bulletRadius = 5f;

            RunGame();

            void RunGame()
            {
                Raylib.InitWindow(screenWidth, screenHeight, "TANKS");
                Raylib.SetTargetFPS(60);

                fieldColor = Raylib.GetColor(0x414141ff);
                wallColor = Raylib.GetColor(0x2e2e2eff);
                bulletColor = Color.Yellow;

                ResetPositions();

                while (!Raylib.WindowShouldClose())
                {
                    float deltaTime = Raylib.GetFrameTime();

                    player1.Update(deltaTime, walls, player2, bullets, 1);
                    player2.Update(deltaTime, walls, player1, bullets, 2);

                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(fieldColor);

                    foreach (var wall in walls)
                    {
                        Raylib.DrawRectangleRec(wall.Rect, wallColor);
                    }

                    player1.DrawTank();
                    player2.DrawTank();

                    Raylib.DrawText($"{score1}", 250, 10, 50, player1Color);
                    Raylib.DrawText($"{score2}", 500, 10, 50, player2Color);

                    for (int i = bullets.Count - 1; i >= 0; i--)
                    {
                        var b = bullets[i];

                        b.Position += b.Direction * bulletSpeed * deltaTime;

                        Raylib.DrawCircleV(b.Position, bulletRadius, bulletColor);

                        bool remove = false;

                        foreach (var wall in walls)
                        {
                            if (Raylib.CheckCollisionCircleRec(b.Position, bulletRadius, wall.Rect))
                            {
                                remove = true;
                                break;
                            }
                        }

                        if (!remove)
                        {
                            Rectangle player1Rect = new Rectangle(player1.Position.X, player1.Position.Y, player1.Size.X, player1.Size.Y);
                            Rectangle player2Rect = new Rectangle(player2.Position.X, player2.Position.Y, player2.Size.X, player2.Size.Y);

                            if (b.Owner == 1 && Raylib.CheckCollisionCircleRec(b.Position, bulletRadius, player2Rect))
                            {
                                score1++;
                                ResetPositions();
                                break;
                            }
                            else if (b.Owner == 2 && Raylib.CheckCollisionCircleRec(b.Position, bulletRadius, player1Rect))
                            {
                                score2++;
                                ResetPositions();
                                break;
                            }
                        }

                        if (b.Position.X < 0 || b.Position.X > screenWidth || b.Position.Y < 0 || b.Position.Y > screenHeight)
                        {
                            remove = true;
                        }

                        if (remove)
                        {
                            bullets.RemoveAt(i);
                        }
                    }

                    Raylib.EndDrawing();
                }
                Raylib.CloseWindow();
            }

            void ResetPositions()
            {
                int fromWall = 20;

                player1.Position = new Vector2(fromWall, 600 / 2 - playerSize.Y / 2);
                player1.Direction = Vector2.UnitX;

                player2.Position = new Vector2(800 - fromWall - playerSize.X, 600 / 2 - playerSize.Y / 2);
                player2.Direction = -Vector2.UnitX;

                bullets.Clear();
                walls.Clear();

                int layout = rng.Next(3);
                if (layout == 0)
                {
                    walls.Add(new Wall(new Rectangle(200, 150, 400, 20)));
                    walls.Add(new Wall(new Rectangle(200, 450, 400, 20)));
                    walls.Add(new Wall(new Rectangle(100, 225, 20, 150)));
                    walls.Add(new Wall(new Rectangle(675, 225, 20, 150)));
                }
                else if (layout == 1)
                {
                    walls.Add(new Wall(new Rectangle(350, 200, 100, 200)));
                    walls.Add(new Wall(new Rectangle(150, 100, 150, 20)));
                    walls.Add(new Wall(new Rectangle(500, 100, 150, 20)));
                    walls.Add(new Wall(new Rectangle(150, 480, 150, 20)));
                    walls.Add(new Wall(new Rectangle(500, 480, 150, 20)));
                }
                else
                {
                    walls.Add(new Wall(new Rectangle(300, 100, 20, 150)));
                    walls.Add(new Wall(new Rectangle(480, 100, 20, 150)));
                    walls.Add(new Wall(new Rectangle(300, 350, 20, 150)));
                    walls.Add(new Wall(new Rectangle(480, 350, 20, 150)));
                    walls.Add(new Wall(new Rectangle(150, 290, 100, 20)));
                    walls.Add(new Wall(new Rectangle(550, 290, 100, 20)));
                }
            }
        }
    }
}