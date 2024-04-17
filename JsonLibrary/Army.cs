using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonLibrary
{
    /// <summary>
    /// The class representing the hero's army.
    /// Contains an event for notifying about the movement of the army
    /// and an event for notifying about the update of information about the army.
    /// There are two methods - to update the army field and to change the location of the army.
    /// </summary>
    public class Army
    {
        public event EventHandler<ArmyMovementEventArgs> ArmyMovement;
        public event EventHandler<UpdatedEventArgs> Updated;

        [JsonPropertyName("unit_name")]
        public string UnitName {  get; private set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; private set;}

        [JsonPropertyName("experience")]
        public int Experience { get; private set;}

        [JsonPropertyName("current_location")]
        public string CurrentLocation { get; private set;}

        public Army()
        {
            UnitName = string.Empty;
            Quantity = 0;
            Experience = 0;
            CurrentLocation = string.Empty;
        }

        public Army(JsonElement json)
        {
            UnitName = json.GetProperty("unit_name").GetString() ?? "";
            Quantity = json.GetProperty("quantity").GetInt32();
            Experience = json.GetProperty("experience").GetInt32();
            CurrentLocation = json.GetProperty("current_location").GetString() ?? "";
        }

        public void UpdateField(ArmyField field,object value)
        {
            switch (field)
            {
                case ArmyField.QUANTITY:
                    Quantity = (int)value;
                    break;
                case ArmyField.EXPERIENCE:
                    Experience = (int)value;
                    break;
                case ArmyField.UNITNAME:
                    UnitName = (string)value;
                    break;
            }
            Updated?.Invoke(this, new UpdatedEventArgs(DateTime.Now));
        }
        public void ChangeLocation(string newLocation)
        {
            string oldLocation = CurrentLocation;
            CurrentLocation = newLocation;
            ArmyMovement?.Invoke(this, new ArmyMovementEventArgs(oldLocation, newLocation, UnitName, Quantity));
        }
    }
}
