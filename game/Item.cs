namespace game
{
    internal class Item : IItem
    {
        public string Name { get; }

        public Item(string name)
        {
            Name = name;
        }
    }
}
