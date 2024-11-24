using System;
using System.Collections.Generic;

namespace backpack
{
    public class BackpackItem
    {
        public string Name { get; set; } 
        public double Volume { get; set; } 

        public BackpackItem(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
    }
    public class Backpack
    {
        public string Color { get; set; }
        public string Firm { get; set; }
        public string Fabric { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        private List<BackpackItem> fillingItem = new List<BackpackItem>();
        public delegate void BackpackItemHandler(Backpack sender, BackpackItem item);
        public event BackpackItemHandler ItemAdd;
        public void AddItem(BackpackItem item)
        {
            double usedVolume = GetUsedVolume();
            if (usedVolume + item.Volume > Volume)
            {
                Console.WriteLine($"Error: невозможно добавить \"{item.Name}\". Превышен объем рюкзака!");
                return; 
            }
            fillingItem.Add(item); 
            ItemAdd?.Invoke(this, item); 
        }
        public IEnumerable<BackpackItem> GetContents()
        {
            return fillingItem;
        }
        public double GetUsedVolume()
        {
            double usedVolume = 0;
            foreach (var item in fillingItem)
            {
                usedVolume += item.Volume;
            }
            return usedVolume;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Backpack myBackpack = new Backpack
            {
                Color = "Серый",
                Firm = "Nike",
                Fabric = "Полиэстер",
                Weight = 1.5,
                Volume = 20.0 
            };
            myBackpack.ItemAdd += (sender, item) =>
            {
                double usedVolume = sender.GetUsedVolume();
                if (usedVolume + item.Volume > sender.Volume)
                {
                    Console.WriteLine($"Error: невозможно добавить \"{item.Name}\". Превышен объем рюкзака!");
                    return; 
                }

                Console.WriteLine($"Добавлен объект: {item.Name}, объем: {item.Volume} m^3");
            };
            myBackpack.AddItem(new BackpackItem("Книга", 5));
            myBackpack.AddItem(new BackpackItem("Ноутбук", 8));
            myBackpack.AddItem(new BackpackItem("Бутылка воды", 3));
            myBackpack.AddItem(new BackpackItem("Гантеля", 10)); 
            Console.WriteLine("\nСодержимое рюкзака:");
            foreach (var item in myBackpack.GetContents())
            {
                Console.WriteLine($"{item.Name}, объем: {item.Volume} m^3");
            }
        }
    }
}
