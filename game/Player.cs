using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Player : IPlayer
    {
        public ILocation CurrentLocation { get; set; }
        public List<IItem> Inventory { get; }
        public Player()
        {
            Inventory = new List<IItem>();
        }
        
        // Осмотреться в текущей локации
        public void LookAround()
        {
            Console.WriteLine(CurrentLocation.Description);
            if (CurrentLocation.Items.Count > 0)
            {
                Console.Write("На столе:");
                foreach (var item in CurrentLocation.Items)
                {
                    Console.Write($" {item.Name}");
                }
                Console.WriteLine();
            }
            Console.Write("Можно пройти - ");
            foreach (var exit in CurrentLocation.Exits)
            {
                Console.Write($"{exit.Key} ");
            }
            Console.WriteLine();
        }

        // Взять предмет из текущей локации
        public void TakeItem(string itemName)
        {
            IItem item = CurrentLocation.Items.Find(x => x.Name == itemName);
            if (item != null)
            {
                Inventory.Add(item);
                CurrentLocation.Items.Remove(item);
                Console.WriteLine($"Предмет добавлен в инвентарь: {itemName}");
            }
            else
            {
                Console.WriteLine("Такого предмета здесь нет.");
            }
        }

        // Перемещение в другую локацию
        public void GoTo(string locationName)
        {
            if (CurrentLocation.Exits.ContainsKey(locationName))
            {
                CurrentLocation = CurrentLocation.Exits[locationName];
                Console.WriteLine($"Ты пришел в {CurrentLocation.Name}.");
                LookAround();
            }
            else
            {
                Console.WriteLine("Нет пути в указанную локацию.");
            }
        }
    }
}
