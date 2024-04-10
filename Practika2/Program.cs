using System.Drawing;


namespace Practika2
{
    
    internal class Program
    {
        /// <summary>
        /// Основная функция, запускающая окно
        /// 
        /// </summary>
        /// <param name="nameWindow">
        /// Имя окна
        /// </param>
        /// <param name="symbol">
        /// Символ, которым будет отображаться окно
        /// </param>
        /// <param name="colorWindow">
        /// Цвет окна
        /// </param>
        /// <param name="topLeft">
        /// Стартовое положение окна
        /// </param>
        /// <param name="horizontalSizeWindow">
        /// Длина окна
        /// </param>
        /// <param name="verticalSizeWindow">
        /// Ширина окна
        /// </param>
        static void WindowStart(string nameWindow, char symbol, ConsoleColor colorWindow, 
            Point topLeft, int horizontalSizeWindow, int verticalSizeWindow)
        {
            Screen screen = new Screen(new ModelWindow(nameWindow, symbol, colorWindow, topLeft, horizontalSizeWindow, verticalSizeWindow));

            while (true)
            {
                screen.PrintScreen();
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape) break;
                screen.Offset(key);
                Console.Clear();
            }
        }
        
        static void Main(string[] args)
        {
            WindowStart("Testing", '*', ConsoleColor.Red, new Point(0, 0), 5, 5);
        }
    }
} 
