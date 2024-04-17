
namespace ConsoleApp
{
    public class Manual
    {
        public static void Guide()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************************************");
            Console.WriteLine("*                                             *");
            Console.WriteLine("*           Добро пожаловать в программу!     *");
            Console.WriteLine("*                                             *");
            Console.WriteLine("***********************************************");
            

            Console.WriteLine("\nПрограмма работает с JSON файлом.\n");
            Console.WriteLine("Вначале программы вам потребуется ввести путь к файлу для дальнейшей работы.\n");
            Console.ResetColor();
            Console.WriteLine("Дальше потребуется выбрать один из следующих пунктов:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1) Отфильтровать данные.");
            Console.WriteLine("2) Отсортировать данные.");
            Console.WriteLine("3) Изменить какое-то поле в выбанном вами объекте из данных.");
            Console.WriteLine("4) Вывести данные в консоль.");
            Console.WriteLine("5) Вернуться в основное меню.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("***********************************************");
            Console.WriteLine("*                                             *");
            Console.WriteLine("*                  Примечание                 *");
            Console.WriteLine("*                                             *");
            Console.WriteLine("***********************************************");
            Console.WriteLine("Если вы выберете пункт 1), то Вам будет доступно фильтрация по данным считанного Json-файла.\nДля фильтрации Вам доступны такие поля:\n\thero_id,\n\thero_name\n\tever,\n\tfaction,\n\tlevel,\n\tcastle_location.");
            Console.WriteLine("Если вы выберете пункт 2), то Вам будет доступно сортировка по данным считанного Json - файла.\nДля сортировки Вам доступны такие поля:\n\thero_id,\n\thero_name\n\tever,\n\tfaction,\n\tlevel,\n\tcastle_location.\nДалее вам нужно будет выбрать тип сортировки - возрастанию или убыванию.");
            Console.WriteLine("Если вы выберете пункт 3), то Вам будет доступно изменить какое-то поле выбранного вами объекта, из данных считанного\nJson - файла.\nДля изменения Вам доступны такие поля:\n\thero_name\n\tever,\n\tfaction,\n\tlevel,\n\tcastle_location,\n\tarmy\nЕсли вы захотите изменить поле army, то вам нужно будет выбрать поле вложенного в army объекта.");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
