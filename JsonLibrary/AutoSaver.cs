
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace JsonLibrary
{
    /// <summary>
    /// The class responsible for automatically saving hero data.
    /// There is a handler for the hero or his army update event.
    /// If less than 15 seconds have passed since the last event, the data will be saved to a file.
    /// </summary>
    public class AutoSaver
    {
        private readonly List<Hero> Characters;
        private readonly string OriginalFileName;
        private DateTime LastUpdateTime;

        public AutoSaver(string fileName, List<Hero> characters)
        {
            OriginalFileName = fileName;
            Characters = characters;
            LastUpdateTime = DateTime.Now;

            foreach (var hero in Characters)
            {
                hero.Updated += HeroUpdated;
                foreach(var army in hero.Army)
                {
                    army.Updated += HeroUpdated;
                }
            }
        }

        private void HeroUpdated(object sender, UpdatedEventArgs e)
        {
            if ((e.UpdateDateTime - LastUpdateTime).TotalSeconds <= 15)
            {
                SaveToFile();
            }
            LastUpdateTime = e.UpdateDateTime;
        }
        
        private void SaveToFile()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Запись в файл");
            Console.ResetColor();
            string directoryPath = Path.GetDirectoryName(OriginalFileName); // Получаем только путь к каталогу
            string tmpFileName = $"{Path.GetFileNameWithoutExtension(OriginalFileName)}_tmp.json";
            string newPath = Path.Combine(directoryPath, tmpFileName);
            
            // Save the current state of the character list to a new JSON file
            var json = JsonSerializer.Serialize(Characters, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) });
            
            File.WriteAllText(newPath, json);
        }
    }
}