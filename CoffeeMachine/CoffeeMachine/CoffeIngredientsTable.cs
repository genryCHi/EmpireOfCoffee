using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    internal class CoffeIngredientsTable
    {
        public static Func<CoffeeMachino, bool> makeEvenet(string typeOfCofee)
        {



            switch (typeOfCofee)
            {
                case "Espresso":
                    return (CoffeeMachino cm) =>
                    {
                        if (cm.storage.Water < 10 | cm.storage.Sugar < 5 | cm.storage.Coffee < 5 | cm.storage.Cup < 1) throw new Exception();
                        cm.storage.Water -= 10;
                        cm.storage.Sugar -= 5;
                        cm.storage.Coffee -= 5;
                        cm.storage.Milk -= 5;
                        cm.storage.Cup -= 1;
                        cm.storage.Cash += 10;
                        return true;
                    };
                case "Americano":
                    return (CoffeeMachino cm) =>
                    {
                        if (cm.storage.Water < 15 | cm.storage.Sugar < 10 | cm.storage.Coffee < 5 | cm.storage.Cup < 1) throw new Exception();
                        cm.storage.Water -= 10;
                        cm.storage.Sugar -= 10;
                        cm.storage.Coffee -= 5;
                        cm.storage.Cup -= 1;
                        cm.storage.Cash += 10;
                        return true;
                    };
                case "Latte":
                    return (CoffeeMachino cm) =>
                    {
                        if (cm.storage.Water < 10 | cm.storage.Sugar < 5 | cm.storage.Coffee < 5 | cm.storage.Cup < 1) throw new Exception();
                        cm.storage.Water -= 10;
                        cm.storage.Sugar -= 5;
                        cm.storage.Coffee -= 5;
                        cm.storage.Milk -= 20;
                        cm.storage.Cup -= 1;
                        cm.storage.Cash += 10;
                        return true;
                    };
                default:
                    throw new Exception("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
        }
    }
}
