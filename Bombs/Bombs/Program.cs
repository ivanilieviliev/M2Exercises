using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
                List<int> bombAndPower = Console.ReadLine().Split().Select(int.Parse).ToList();
                int bomb = bombAndPower[0];
                int power = bombAndPower[1];

                int elementsToRemove;
                for (int i = 0; i < numbers.Count && i >= 0;) // i >= 0 for case like 2 3 2 2 and 3 2
                {
                    if (numbers[i] == bomb)
                    {
                        elementsToRemove = power * 2 + 1;

                        for (int j = i - power; j <= i + power;)
                        {
                            if (j < 0)
                            {
                                j++;
                                elementsToRemove--;
                                continue;
                            }

                            if (j == numbers.Count)
                            {
                                break;
                            }

                            if (elementsToRemove == 0)
                            {
                                break;
                            }

                            numbers.RemoveAt(j);
                            elementsToRemove--;
                        }

                        i = i - power;
                    }
                    else
                    {
                        i++;
                    }
                }

                Console.WriteLine(numbers.Sum());
            }
            catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
    }
}
