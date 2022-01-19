using System;
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
                // Needs a delay, otherwise it won't draw correctly
                await Task.Delay(10);
            }
        }

        public static void Draw(int x, int y, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = color;
            Console.Write(" ");
        }

        public static void SetTextColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void SetBgColor(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        public static void ResetTextColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
