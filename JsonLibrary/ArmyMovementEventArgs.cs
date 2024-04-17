
namespace JsonLibrary
{
    public class ArmyMovementEventArgs : EventArgs
    {
        public string OldLocation { get; }
        public string NewLocation { get; }
        public string UnitName { get; }
        public int Quantity { get; }

        public ArmyMovementEventArgs(string oldLocation, string newLocation, string unitName,int quantity)
        {
            OldLocation = oldLocation;
            NewLocation = newLocation;
            UnitName = unitName;
            Quantity = quantity;
        }
    }
}
