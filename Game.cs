using System;
using System.Collections.Generic;
using System.Threading;


namespace Snake
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    class Game
    {
        private const int ScreenWidth = 32;
        private const int ScreenHeight = 16;
        private const int InitialScore = 5;

        private int score;
        private bool gameOver;
        private Direction direction;
        private Pixel head;
        private List<Pixel> snake;
        private Pixel berry;
        private Random random;
        private Draw draw;


        public Game()
        {
            if (!Console.IsOutputRedirected)
        {
            Console.WindowHeight = ScreenHeight;
            Console.WindowWidth = ScreenWidth;
            Console.CursorVisible = false;
        }
            random = new Random();
            draw  = new Draw(ScreenWidth, ScreenHeight);

        }

        public void Initialize(){
            score = InitialScore;
            gameOver = false;
            direction = Direction.Right;
            head = new Pixel(ScreenWidth / 2, ScreenHeight / 2, ConsoleColor.Red);
            snake = new List<Pixel>();
            berry = GenerateBerry();
        }

        public void Run()
        {
            Initialize();
            while (!gameOver)
            {
                draw.DrawGame(head, berry, snake);
                HandleInput();
                Update();
                CheckCollision();
                Thread.Sleep(100);
            }
            draw.DisplayGameOver(score);

        }    

        private void Update()
        {
            MoveHead();
            MoveSnake();
        }

        private void MoveHead()
        {
            switch (direction)
            {
                case Direction.Up:
                    head.YPos--;
                    break;
                case Direction.Down:
                    head.YPos++;
                    break;
                case Direction.Left:
                    head.XPos--;
                    break;
                case Direction.Right:
                    head.XPos++;
                    break;
            }
        }

        private void MoveSnake()
        {
            snake.Insert(0, new Pixel(head.XPos, head.YPos, ConsoleColor.Green));
            if (head.XPos == berry.XPos && head.YPos == berry.YPos)
            {
                score++;
                berry = GenerateBerry();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        private Pixel GenerateBerry()
        {
            return new Pixel(random.Next(1, ScreenWidth - 1), random.Next(1, ScreenHeight - 1), ConsoleColor.Cyan);
        }


        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow && direction != Direction.Down)
                    direction = Direction.Up;
                else if (key == ConsoleKey.DownArrow && direction != Direction.Up)
                    direction = Direction.Down;
                else if (key == ConsoleKey.LeftArrow && direction != Direction.Right)
                    direction = Direction.Left;
                else if (key == ConsoleKey.RightArrow && direction != Direction.Left)
                    direction = Direction.Right;
            }
        }


        private void CheckCollision()
        {
            if (head.XPos == 0 || head.XPos == ScreenWidth - 1 || head.YPos == 0 || head.YPos == ScreenHeight - 1)
            {
                gameOver = true;
            }
            foreach (var pixel in snake)
            {
                if (pixel.XPos == head.XPos && pixel.YPos == head.YPos)
                {
                    gameOver = true;
                }
            }
        }
    }
}