using System.Drawing;

namespace Practika2
{
    internal class Screen
    {
        static public int HorizontalSize { get; private set; } = 30;
        static public int VerticalSize { get; private set; } = 30;
        private char[,] _screenArray = new char[VerticalSize, HorizontalSize];
        private ModelWindow _window;

        public Screen(ModelWindow window)
        {
            _window = window;
            Fill();
        }
        public Screen() : this(new ModelWindow()) { }

        public void PrintScreen()
        {
            if (_window == null || (_window.HorizontalSize == 0 || _window.VerticalSize == 0)) return;
            Console.WriteLine($"{_window.NameWindow}");
            PrintWindow();
            for (int i = 0; i < VerticalSize; ++i)
            {
                for (int j = 0; j < HorizontalSize; ++j)
                {
                    Console.Write(_screenArray[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("→ - передвинуть вправо; ");
            Console.Write("← - передвинуть влево; ");
            Console.Write("↑ - передвинуть вверх; ");
            Console.Write("↓ - передвинуть вниз; ");
            Console.Write("esc - Выйти;");
            Console.WriteLine();
        }
        public void Offset(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    _window.TopLeft = new Point(_window.TopLeft.X - 1, _window.TopLeft.Y);
                    break;
                case ConsoleKey.RightArrow:
                    _window.TopLeft = new Point(_window.TopLeft.X + 1, _window.TopLeft.Y);
                    break;
                case ConsoleKey.UpArrow:
                    _window.TopLeft = new Point(_window.TopLeft.X, _window.TopLeft.Y - 1);
                    break;
                case ConsoleKey.DownArrow:
                    _window.TopLeft = new Point(_window.TopLeft.X, _window.TopLeft.Y + 1);
                    break;
            }
            Fill();
        }
        private void Fill()
        {
            for (int i = 0; i < VerticalSize; ++i)
                for (int j = 0; j < HorizontalSize; ++j)
                    _screenArray[i, j] = ' ';
        }
        private void PrintWindow()
        {
            for (int i = 0; i < _window.HorizontalSize; ++i)
            {
                _screenArray[_window.TopLeft.Y, _window.TopLeft.X + i] = _window.SymbolWindow;
                _screenArray[_window.TopLeft.Y + _window.VerticalSize - 1, _window.TopLeft.X + i] = _window.SymbolWindow;
            }
            for (int i = 0; i < _window.VerticalSize; ++i)
            {
                _screenArray[_window.TopLeft.Y + i, _window.TopLeft.X] = _window.SymbolWindow;
                _screenArray[_window.TopLeft.Y + i, _window.TopLeft.X + _window.HorizontalSize - 1] = _window.SymbolWindow;
            }
            Console.ForegroundColor = _window.ColorWindow;
        }
    }
    internal class ModelWindow
    {
        public string NameWindow { get; set; }
        public ConsoleColor ColorWindow { get; set; }
        public char SymbolWindow { get; set; }
        private Point _topLeft;
        public Point TopLeft
        {
            get { return _topLeft;}
            set
            {
                if (value.X < 0 || value.Y < 0 || (value.X + HorizontalSize) > Screen.HorizontalSize || (value.Y + VerticalSize) > Screen.VerticalSize)
                    Console.WriteLine("Невозможное присваивание. Координаты не могут быть отрицательнвми.");
                else
                    _topLeft = value;
            }
        }

        private int _horizontalSize;
        public int HorizontalSize
        {
            get { return _horizontalSize; }
            set
            {
                if (value < 0 || (TopLeft.X + value > Screen.HorizontalSize))
                    Console.WriteLine("Не допустимая длина окна. Превышает размеры экрана.");
                else
                    _horizontalSize = value;
            }
        }
        private int _verticalSize;
        public int VerticalSize
        {
            get { return _verticalSize; }
            set
            {
                if (value < 0 || (TopLeft.Y + value) > Screen.VerticalSize)
                    Console.WriteLine("Не допустимая длина окна. Превышает размеры экрана.");
                else
                    _verticalSize = value;
            }
        }

        public ModelWindow(string nameWindow, char symbolWindow, ConsoleColor colorWindow, Point topLeft, int horizontalSize, int verticalSize) 
        {
            NameWindow = nameWindow;
            SymbolWindow = symbolWindow;
            ColorWindow = colorWindow;
            TopLeft= topLeft;
            HorizontalSize = horizontalSize;
            VerticalSize = verticalSize;
        }
        public ModelWindow() : this("", '*', ConsoleColor.White, Point.Empty, 0, 0) { }

    }
}
