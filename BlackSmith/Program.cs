using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackSmith
{
    class Program
    {
        static void Main(string[] args)
        {
            //steel - firstinfirstout -- queue
            //carbon - firstinLastOut -- stack
            int[] steel = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] carbon = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> steelRessources = new Queue<int>(steel);

            Stack<int> carbonRessources = new Stack<int>(carbon);

            SortedDictionary<string, int> swords = new SortedDictionary<string, int>
            {
                {"Gladius" , 0 },
                {"Shamshir", 0},
                {"Katana" , 0},
                {"Sabre", 0},
                {"Broadsword" , 0}
            };
            int totalSwords = 0;
            while (steelRessources.Count>0 && carbonRessources.Count>0)
            {
                int currentSteel = steelRessources.Peek();
                int currentCarbon = carbonRessources.Peek();
                int sum = currentCarbon + currentSteel;
                if (sum == 70)
                {
                    swords["Gladius"]++;
                    totalSwords++;
                    steelRessources.Dequeue();
                    carbonRessources.Pop();
                }
                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                    totalSwords++;
                    steelRessources.Dequeue();
                    carbonRessources.Pop();
                }
                else if (sum == 90)
                {
                    swords["Katana"]++;
                    totalSwords++;
                    steelRessources.Dequeue();
                    carbonRessources.Pop();
                }
                else if (sum == 110)
                {
                    swords["Sabre"]++;
                    totalSwords++;
                    steelRessources.Dequeue();
                    carbonRessources.Pop();
                }
                else if (sum ==150)
                {

                    swords["Broadsword"]++;
                    totalSwords++;
                    steelRessources.Dequeue();
                    carbonRessources.Pop();
                }
                else
                {
                    steelRessources.Dequeue();
                    currentCarbon += 5;
                    carbonRessources.Pop();
                    carbonRessources.Push(currentCarbon);

                }

            }
            if (totalSwords>=1)
            {
                Console.WriteLine($"You have forged {totalSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steelRessources.Count==0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left:{string.Join(", " , steelRessources)}");
            }
            if (carbonRessources.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", " , carbonRessources)}");
            }
            foreach (var sword in swords)
            {
                if (sword.Value>0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
