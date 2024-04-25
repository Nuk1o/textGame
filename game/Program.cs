using game;

class Program
{
    static void Main(string[] args)
    {
        // Создаем локации
        ILocation kitchen = new Location("кухня", "Ты находишься на кухне, надо собрать рюкзак и идти в универ.");
        ILocation corridor = new Location("коридор", "Коридор, ничего интересного.");
        ILocation room = new Location("комната", "Пустая комната.");
        ILocation street = new Location("улица", "На улице весна.");

        // Добавляем предметы в локации
        kitchen.AddItem(new Item("ключи"));
        kitchen.AddItem(new Item("конспекты"));
        kitchen.AddItem(new Item("рюкзак"));

        // Устанавливаем выходы из локаций
        kitchen.Exits.Add("коридор", corridor);
        corridor.Exits.Add("кухня", kitchen);
        corridor.Exits.Add("комната", room);
        corridor.Exits.Add("улица", street);
        room.Exits.Add("коридор", corridor);
        street.Exits.Add("домой", corridor); // Предполагается, что улица ведет к дому

        IPlayer player = new Player();
        player.CurrentLocation = kitchen;

        Console.WriteLine("Добро пожаловать в игру!");
        player.LookAround();

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');
            string command = parts[0].ToLower();

            switch (command)
            {
                case "осмотреться":
                    player.LookAround();
                    break;
                case "идти":
                    if (parts.Length > 1)
                    {
                        string locationName = string.Join(" ", parts, 1, parts.Length - 1);
                        player.GoTo(locationName);
                    }
                    else
                    {
                        Console.WriteLine("Не указана локация.");
                    }
                    break;
                case "взять":
                    if (parts.Length > 1)
                    {
                        string itemName = string.Join(" ", parts, 1, parts.Length - 1);
                        player.TakeItem(itemName);
                    }
                    else
                    {
                        Console.WriteLine("Не указан предмет.");
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }
}