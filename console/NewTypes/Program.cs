using System;
using System.Collections.Generic;
using Pets;

namespace NewTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<IPet> pets = new List<IPet>
            {
                new Dog(),
                new Cat()
            };
            foreach (var pet in pets)
            {
                Console.WriteLine(pet.TalkToOwner());
            }
        }
    }
}
