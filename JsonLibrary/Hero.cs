using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonLibrary
{
    /// <summary>
    /// The class describes the hero.
    /// Contains a method for serializing the hero object to JSON format and 
    /// a method for updating the field in the hero object.
    /// Contains an event to notify about the hero update.
    /// </summary>
    public class Hero
    {
        public event EventHandler<UpdatedEventArgs> Updated;

        [JsonPropertyName("hero_id")]
        public int HeroId {  get; private  set; }

        [JsonPropertyName("hero_name")]
        public string HeroName { get; private set; }

        [JsonPropertyName("faction")]
        public string Faction { get; private set; }

        [JsonPropertyName("level")]
        public int HeroLevel { get; private set; }

        [JsonPropertyName("castle_location")]
        public string CastleLocation {  get; private set; }

        [JsonPropertyName("army")]
        public List<Army> Army { get; private set; }

        public Hero()
        {
            HeroId = 0;
            HeroName = string.Empty;
            Faction = string.Empty;
            HeroLevel = 0;
            CastleLocation = string.Empty;
            Army = new List<Army>();

        }

        public Hero(JsonElement json)
        {
            HeroId = json.GetProperty("hero_id").GetInt32();
            HeroName = json.GetProperty("hero_name").GetString();
            Faction = json.GetProperty("faction").GetString();
            HeroLevel = json.GetProperty("level").GetInt32();
            CastleLocation = json.GetProperty("castle_location").GetString();
            Army = new List<Army>();


            JsonElement armyList = json.GetProperty("army");

            foreach (JsonElement martial in armyList.EnumerateArray())
            {
                Army military = new Army(martial);
                Army.Add(military);
            }
        }
        public string ToJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(System.Text.Unicode.UnicodeRanges.All)
            };
            return JsonSerializer.Serialize(this, options);
        }

        public void UpdateField(ChangeField field, object value)
        {
            // Update the specified field
            switch (field)
            {
                case ChangeField.HERO_NAME:
                    HeroName =(string)value;
                    break;
                case ChangeField.FACTION:
                    Faction = (string)value;
                    break;
                case ChangeField.LEVEL:

                    HeroLevel = (int)value;
                    break;
                case ChangeField.CASTLE_LOCATION:
                    string newLocation = (string)value;
                    // Updating the location of the castle
                    string oldLocation = CastleLocation;
                    CastleLocation = newLocation;

                    // Updating the location of troops in the army
                    foreach (var army in Army)
                    {
                       army.ChangeLocation(newLocation);
                    }
                    break;
                case ChangeField.ARMY:

                    break;
            } 
            Updated?.Invoke(this, new UpdatedEventArgs(DateTime.Now));
        }
    }
}