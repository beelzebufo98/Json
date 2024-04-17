
namespace ConsoleApp
{
    public class Logger
    {
        public static void LogError(string error)
        {
            Color.SetColor(ColorEnum.ERROR);
            Console.WriteLine(error);
            Color.Reset();
        }

        public static void LogSuccess(string message)
        {
            Color.SetColor(ColorEnum.SUCCESS);
            Console.WriteLine(message);
            Color.Reset();
        }
    }
}
