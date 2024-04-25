namespace game
{
    internal interface IPlayer
    {
        ILocation CurrentLocation { get; set; }
        List<IItem> Inventory { get; }
        void LookAround();
        void TakeItem(string itemName);
        void GoTo(string locationName);
    }
}
