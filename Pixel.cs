namespace Snake
{
    class Pixel
        {
            public int XPos { get; set; }
            public int YPos { get; set; }
            public ConsoleColor Color { get; set; }


            public Pixel(int x, int y, ConsoleColor color)
            {
                XPos = x;
                YPos = y;
                Color = color;
            }

        }
}