using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    internal class ResourcesStorage
    {
        public int Water { get; set; }
        public int Milk { get; set; }
        public int Sugar { get; set; }
        public int Coffee { get; set; }
        public int Cash { get; set; }
        public int Cup { get; set; }

        public ResourcesStorage()
        {
            Water = 50;
            Milk = 50;
            Sugar = 50;
            Coffee = 50;
            Cash = 0;
            Cup = 10;
        }

        public override string ToString()
        {
            return $"Water : {Water}\n" +
                $"Milk : {Milk}\n" +
                $"Sugar : {Sugar}\n" +
                $"Coffee : {Coffee}\n" +
                $"Cash : {Cash}$\n" +
                $"Cup(s) : {Cup}\n";

        }

    }
}

