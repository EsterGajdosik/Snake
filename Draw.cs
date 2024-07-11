namespace Snake
{
    class Draw
    {
        private readonly int screenWidth;
        private readonly int screenHeight;

        public Draw(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public void DrawGame(Pixel head, Pixel berry, List<Pixel> snake)
        {
            Console.Clear();
            DrawBorders();
            DrawPixel(head);
            DrawPixel(berry);
            foreach (var pixel in snake)
            {
                DrawPixel(pixel);
            }
        }

        private void DrawBorders()
        {
            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, screenHeight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(screenWidth - 1, i);
                Console.Write("■");
            }
        }

        private void DrawPixel(Pixel pixel)
        {
            Console.SetCursorPosition(pixel.XPos, pixel.YPos);
            Console.ForegroundColor = pixel.Color;
            Console.Write("■");
        }

        public void DisplayGameOver(int score)
        {
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
        }
    }   
}