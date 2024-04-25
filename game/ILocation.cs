namespace game
{
    internal interface ILocation
    {
        string Name { get; }
        string Description { get; }
        List<IItem> Items { get; }
        Dictionary<string, ILocation> Exits { get; }
        void AddItem(IItem item);
    }
}
