using JsonLibrary;


namespace ConsoleApp
{
    public static class Menu
    {
        public static string GetMainMenuAction()
        {
            Color.SetColor(ColorEnum.MENU);
            Console.WriteLine("---------Главное меню--------");
            Console.WriteLine("1. Работа с файлом");
            Console.WriteLine("2. Инструкция");
            Console.WriteLine("3. Завершить работу программы");
            Color.Reset();
            string? action = Console.ReadLine();
            return action ?? "";
        }
        public static string GetFileMenuAction()
        {
            Color.SetColor(ColorEnum.MENU);
            Console.WriteLine("Выберите действие с исходными данными:");
            Console.WriteLine("1. Отфильтровать данные по одному из полей");
            Console.WriteLine("2. Отсортировать данные по одному из полей");
            Console.WriteLine("3. Отредактировать одно из полей");
            Console.WriteLine("4. Вывести данные в консоль");
            Console.WriteLine("5. Вернуться в основное меню");
            Color.Reset();
            string? menu = Console.ReadLine();
            return menu ?? "";
        }
        public static FieldType GetFieldDataMenu()
        {
            Color.SetColor(ColorEnum.MENU);
            Console.WriteLine("Введите поле(нужно ввести цифру от 1 до 6):");
            Console.WriteLine("1 - поле 'hero_id'");
            Console.WriteLine("2 - поле 'hero_name'");
            Console.WriteLine("3 - поле 'faction'");
            Console.WriteLine("4 - поле 'level'");
            Console.WriteLine("5 - поле 'castle_location'");
            Console.WriteLine("6 - если хотите вернуться назад");
            Color.Reset();
            int EnumValue = CheckData.CheckNumber<int>(6);
            FieldType fieldType = (FieldType)EnumValue;

            return fieldType;
        }
       public static ArmyField GetArmyField()
        {
            Color.SetColor(ColorEnum.MENU);
            Console.WriteLine("Введите поле(нужно ввести цифру от 1 до 3)");
            Console.WriteLine("1 - поле unit_name");
            Console.WriteLine("2 - поле quantity");
            Console.WriteLine("3 - поле experience");
            Color.Reset();
            int EnumValue = CheckData.CheckNumber<int>(3);
            ArmyField fieldType = (ArmyField)EnumValue;

            return fieldType;
        }
       public static ChangeField GetChangeField()
        {
            Color.SetColor(ColorEnum.MENU);
            Console.WriteLine("Введите поле(нужно ввести цифру от 1 до 6)");
            Console.WriteLine("1 - поле 'hero_name'");
            Console.WriteLine("2 - поле 'faction'");
            Console.WriteLine("3 - поле 'level'");
            Console.WriteLine("4 - поле 'castle_location'");
            Console.WriteLine("5 - поле 'army'");
            Console.WriteLine("6 - если хотите вернуться назад"); 
            Color.Reset();
            int EnumValue = CheckData.CheckNumber<int>(6);
            ChangeField fieldType = (ChangeField)EnumValue;

            return fieldType;
        }

        public static string GetTypeSortField()
        {
            Color.SetColor(ColorEnum.MENU);
            Console.WriteLine("Тип сортировки:");
            Console.WriteLine("1. Сортировка по возрастанию");
            Console.WriteLine("2. Сортировка по убыванию");
            Color.Reset();
            string type = CheckData.CheckNumber<string>(2);
            return type;
        }
    }
}
