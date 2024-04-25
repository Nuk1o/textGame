namespace game
{
    internal class Location : ILocation
    {
        public string Name { get; }
        public string Description { get; }
        public List<IItem> Items { get; }
        public Dictionary<string, ILocation> Exits { get; }

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<IItem>();
            Exits = new Dictionary<string, ILocation>();
        }

        public void AddItem(IItem item)
        {
            Items.Add(item);
        }
    }
}
