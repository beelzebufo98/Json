using JsonLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "";
            
            List<Hero> characters = new List<Hero>();
            while (true)
            {
                try
                {
                    string action = Menu.GetMainMenuAction();

                    if (action != "1" && action != "2" && action !="3" )
                    {
                        Logger.LogError("Выбран некорректный пункт меню");
                        continue;
                    }
                    if (action == "2")
                    {
                        Manual.Guide();
                        continue;
                    }
                    if (action == "3")
                    {
                        Logger.LogSuccess("До скорых встреч!");
                        break;
                    }

                    // Clear data before processing file again.
                    characters.Clear();
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Произошла ошибка: {ex.Message}");
                }

                while (true)
                {
                    try
                    {
                        try
                        {
                            filePath = FilePath.ReadFilePathValue("Введите путь к файлу с json данными: ");
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError($"Произошла ошибка: {ex.Message}");
                            continue;
                        }
                        DataProcessing.ReadData(ref characters, filePath);
                        
                        break;
                    }
                    catch (ArgumentNullException ex)
                    {
                        Logger.LogError($"Произошла ошибка: {ex.Message}");
                    }
                    catch (ArgumentException ex)
                    {
                        Logger.LogError($"Произошла ошибка: {ex.Message}");
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        Logger.LogError($"Произошла ошибка: {ex.Message}");
                    }
                    catch (IOException ex)
                    {
                        Logger.LogError($"Произошла ошибка: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Произошла ошибка: {ex.Message}");
                    }
                }
                try
                {
                    DataProcessing.SolutionMethod(ref characters);
                }
                catch (Exception ex)
                {
                    Logger.LogError($"Произошла ошибка: {ex.Message}");
                }
            }
            
        }
    }
}