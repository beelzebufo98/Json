
namespace ConsoleApp
{
    public static class CheckData
    {
        public static T CheckNumber<T>(int n)
        {
            int number;
            bool isValidInput = false;

            do
            {
                Console.WriteLine($"Введите число от 1 до {n}:");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    if (number >= 1 && number <= n)
                    {
                        isValidInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Число не находится в диапазоне от 1 до {n}");
                    }
                }
                else
                {
                    Console.WriteLine("Введенная строка не является числом");
                }
            }
            while (!isValidInput);
            if (typeof(T) == typeof(string))
            {
                return (T)(object)number.ToString() ;
            }
            else if (typeof(T) == typeof(int))
            {
                return (T)(object)number;
            }
            else
            {
                throw new ArgumentException("Неподдерживаемый тип");
            }
        }
    }
}
