
namespace ConsoleApp
{
    public enum ColorEnum
    {
        MENU = 0,
        ERROR = 1,
        SUCCESS = 2,
    }

    public static class Color
    {
        public static void SetColor(ColorEnum color)
        {
            switch (color)
            {
                case ColorEnum.MENU:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    }
                case ColorEnum.ERROR:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    }
                case ColorEnum.SUCCESS:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    }
            }
        }
        public static void Reset()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
