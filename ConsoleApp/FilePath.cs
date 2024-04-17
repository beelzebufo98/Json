

namespace ConsoleApp
{
    public class FilePath
    {
        public static string ReadFilePathValue(string placeholder)
        {
            string? filePath;
            do
            {
                Console.Write(placeholder);
                filePath = Console.ReadLine();
                if (!string.IsNullOrEmpty(filePath))
                {
                    if (!filePath.EndsWith(".json"))
                    {
                        Logger.LogError("Значение пути к файлу задано некорректно");
                        throw new Exception();
                    }
                }

                return filePath;
            } while (true);
        }
    }
}
