using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia
{
    internal class Graphics
    {

        public static async Task DrawRectangle(int width, int height, ConsoleColor color)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Draw(i, j, color);
                }
                // Må ha litt delay så programmet får tid til å tegne opp
                await Task.Delay(10);
            }
        }

        public static void Draw(int x, int y, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = color;
            Console.Write(" ");
        }
    }
}
