using JsonLibrary;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace ConsoleApp
{
    /// <summary>
    /// The Class for processing character data.
    /// Includes methods for sorting, filtering, and other operations on a list of characters.
    /// </summary>
    public class DataProcessing
    {
        public static void Sort(ref List<Hero> list, FieldType fieldtype)
        {
            try
            {
                string type = Menu.GetTypeSortField();
                switch (type)
                {
                    case "1":
                        {
                            list.Sort((character1, character2) => character1.CompareTo(character2, fieldtype));
                            return;
                        }
                    case "2":
                        {
                            list.Sort((character1, character2) => character2.CompareTo(character1, fieldtype));
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }

        public static void Filter(List<Hero> data, FieldType field, string value)
        {
            try
            {
                List<Hero> filteredList = DataFilter.FilterByField(data, field, value);
                if (filteredList.Count >= 1)
                {
                    Logger.LogSuccess($"По фильтру найдено совпадений: {filteredList.Count}");
                    for (int i = 0; i < filteredList.Count(); i++)
                    {
                        Console.Write(filteredList[i].ToJson());
                        if (i + 1 != filteredList.Count())
                            Console.WriteLine(",");
                        else Console.WriteLine();
                    }
                    
                    Color.SetColor(ColorEnum.SUCCESS);
                    Console.WriteLine("Работа с данными завершена");
                    Color.Reset();
                }
                else
                {
                    Logger.LogError($"По фильтру найдено совпадений: {filteredList.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

        }
        
        public static void SolutionMethod(ref List<Hero> characters)
        {
            bool exitFlag = false;
            
            while (!exitFlag)
            {
                string menuAction = Menu.GetFileMenuAction();
                switch (menuAction)
                {
                    case "1": //Filter
                        {
                            //Filter data by one of the fields.
                            FieldType data = Menu.GetFieldDataMenu();
                            if (data == FieldType.NONE)
                            {
                                Console.WriteLine("Поле для фильтрации не было выбрано");
                                continue;
                            }
                            Console.Write("Введите значение поля: ");
                            string value = "";
                            int intValue;
                            if (data == FieldType.HERO_ID || data == FieldType.LEVEL)
                            {
                                intValue = CheckData.CheckNumber<int>(Int32.MaxValue);
                                DataProcessing.Filter(characters, data, intValue.ToString());
                            }
                            else
                            {
                                value = Console.ReadLine();
                                if (string.IsNullOrEmpty(value))
                                {
                                    Console.WriteLine("Введено некорректное значение");
                                    continue;
                                }
                                DataProcessing.Filter(characters, data, value);
                            }


                            break;
                        }
                    case "2": //Sort
                        {
                            FieldType data = Menu.GetFieldDataMenu();
                            if (data == FieldType.NONE)
                            {
                                Console.WriteLine("Поле для сортировки не было выбрано");
                                continue;
                            }
                            DataProcessing.Sort(ref characters, data);
                            for (int i = 0; i < characters.Count(); i++)
                            {
                                Console.Write(characters[i].ToJson());
                                if (i + 1 != characters.Count())
                                    Console.WriteLine(",");
                                else Console.WriteLine();
                            }
                            Color.SetColor(ColorEnum.SUCCESS);
                            Console.WriteLine("Работа с данными завершена");
                            Color.Reset();
                            break;
                        }
                    case "3": //Change field
                        {
                            //completing work with file data
                            ChangeField data = Menu.GetChangeField();
                            if (data == ChangeField.NONE)
                            {
                                continue;
                            }
                            Console.WriteLine("Выберите номер объекта, который хотите изменить");
                            int number = CheckData.CheckNumber<int>(characters.Count());
                            string value = "";
                            int intValue = 0;
                            if (data == ChangeField.LEVEL)
                            {
                                Console.WriteLine("Введите значение поля.");
                                intValue = CheckData.CheckNumber<int>(Int32.MaxValue);
                                
                                characters[number - 1].UpdateField(data, intValue);
                                Color.SetColor(ColorEnum.SUCCESS);
                                Console.WriteLine("Работа с данными завершена");
                                Color.Reset();
                            }
                            else if (data == ChangeField.ARMY)
                            {
                                Console.WriteLine("Выберите номер объекта, который хотите изменить");
                                int armyCount = CheckData.CheckNumber<int>(characters[number - 1].Army.Count());
                                
                                ArmyField armyField = Menu.GetArmyField();
                                
                                switch (armyField)
                                {
                                    case ArmyField.UNITNAME:
                                        Console.WriteLine("Введите значение поля: ");
                                        value = Console.ReadLine() ?? "";
                                        if (string.IsNullOrEmpty(value))
                                        {
                                            Console.WriteLine("Введено некорректное значение");
                                            continue;
                                        }
                                        characters[number - 1].Army[armyCount - 1].UpdateField(armyField, value);
                                        Color.SetColor(ColorEnum.SUCCESS);
                                        Console.WriteLine("Работа с данными завершена");
                                        Color.Reset();
                                        break;
                                    case ArmyField.QUANTITY:
                                        Console.WriteLine("Введите значение поля.");
                                        intValue = CheckData.CheckNumber<int>(Int32.MaxValue);
                                        characters[number - 1].Army[armyCount - 1].UpdateField(armyField, intValue);
                                        Color.SetColor(ColorEnum.SUCCESS);
                                        Console.WriteLine("Работа с данными завершена");
                                        Color.Reset();
                                        break;
                                    case ArmyField.EXPERIENCE:
                                        Console.WriteLine("Введите значение поля.");
                                        intValue = CheckData.CheckNumber<int>(Int32.MaxValue);
                                        characters[number - 1].Army[armyCount - 1].UpdateField(armyField, intValue);
                                        Color.SetColor(ColorEnum.SUCCESS);
                                        Console.WriteLine("Работа с данными завершена");
                                        Color.Reset();
                                        break;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Введите значение поля: ");
                                value = Console.ReadLine() ?? "";
                                if (string.IsNullOrEmpty(value))
                                {
                                    Console.WriteLine("Введено некорректное значение");
                                    continue;
                                }
                                characters[number - 1].UpdateField(data, value);
                                Color.SetColor(ColorEnum.SUCCESS);
                                Console.WriteLine("Работа с данными завершена");
                                Color.Reset();
                            }
                            break;
                        }
                    case "4":
                        {
                            for (int i = 0; i < characters.Count(); i++)
                            {
                                Console.Write(characters[i].ToJson());
                                if (i + 1 != characters.Count())
                                    Console.WriteLine(",");
                                else Console.WriteLine();
                            }
                            break;
                        }
                    case "5":
                        {
                            exitFlag = true;
                            break;
                        }
                    default:
                        {
                            Logger.LogError("Выбран некорректный пункт меню");
                            break;
                        }
                }

                if (exitFlag)
                    break;
            }

        }
        public static void ReadData(ref List<Hero> characters, string filePath)
        {
            JsonElement jsonElement = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(filePath,Encoding.Default),new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) });
            foreach (JsonElement hero in jsonElement.EnumerateArray())
            {
                Hero protagonists = new Hero(hero);
                foreach (var army in protagonists.Army)
                {
                    army.ArmyMovement += DataProcessing.HandleArmyMovement;
                }
                characters.Add(protagonists);
            }
            AutoSaver autoSaver = new AutoSaver(filePath, characters);
            Logger.LogSuccess("Данные успешно прочитаны!");
        
        }

        public static void HandleArmyMovement(object hero, ArmyMovementEventArgs e)
        {
            Console.WriteLine($"Войска маршируют из {e.OldLocation} в {e.NewLocation}:");
            Console.WriteLine($"{e.Quantity} юнитов {e.UnitName}");
        }
    }
}
