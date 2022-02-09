using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    internal class CoffeeMachino
    {

        public ResourcesStorage storage;
        public List<string> sortsOfCoffee;
        private Dictionary<string, Func<CoffeeMachino, bool>> _sortsEventsHandler = new Dictionary<string, Func<CoffeeMachino, bool>>();
        private STATE _state;
        public CoffeeMachino()
        {
            storage = new ResourcesStorage();
            sortsOfCoffee = new List<string> { "Espresso", "Americano", "Latte" };
            _state = STATE.CHOICE;
            _initiateSortsEventsHandler();
        }



        private enum STATE
        {
            CHOICE, BUY, INFO, FILL, GETCASH, EXIT
        }



        public void start()
        {
            while (_state != STATE.EXIT)
            {
                switch (_state)
                {
                    case STATE.CHOICE:
                        getChoice();
                        break;
                    case STATE.BUY:
                        buy();
                        break;
                    case STATE.INFO:
                        info();
                        break;
                    case STATE.FILL:
                        break;
                    case STATE.GETCASH:
                        getCash();
                        break;
                    default:
                        break;
                }
            }
        }


        public void getChoice()
        {
            string option;
            Console.WriteLine("Choose option : buy, info, fill, take, exit");
            option = Console.ReadLine();
            switch (option)
            {
                case "buy":
                    _state = STATE.BUY;
                    break;
                case "info":
                    _state = STATE.INFO;
                    break;
                case "fill":
                    _state = STATE.FILL;
                    break;
                case "take":
                    _state = STATE.GETCASH;
                    break;
                case "exit":
                    _state = STATE.EXIT;
                    break;
                default:
                    Console.WriteLine("Wrong option, try again!");
                    break;

            }
        }

        public void buy()
        {
            string choise;
            Console.WriteLine("1 - Espresso\n2 - Americano\n3 - Latte\n0 - back");
            choise = Console.ReadLine();
            if (!int.TryParse(choise, out int param))
            {
                Console.WriteLine("Wrong input!!! Try again");
                return;
            }
            Func<CoffeeMachino, bool> fc;
            switch (param)
            {

                case 1:
                    fc = _sortsEventsHandler["Espresso"];
                    break;
                case 2:
                    fc = _sortsEventsHandler["Americano"];
                    break;
                case 3:
                    fc = _sortsEventsHandler["Latte"];
                    break;
                case 0:
                    _state = STATE.CHOICE;
                    return;
                default:
                    Console.WriteLine("Wrong input!!! Try again");
                    return;
            }
            try
            {
                fc(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine("NOT ENOUGH RESOURSES!!!!");
            }
            _state = STATE.CHOICE;
        }

        public void info()
        {
            Console.WriteLine(storage.ToString());
            _state = STATE.CHOICE;

        }


        public void fill()
        {
            _state = STATE.CHOICE;
        }

        public void getCash()
        {
            storage.Cash = 0;
            Console.WriteLine("Getting cash...");
            Console.WriteLine("Amount of cash now is {0}", storage.Cash);
            _state = STATE.CHOICE;
        }

        private void _initiateSortsEventsHandler()
        {
            foreach (string value in sortsOfCoffee)
            {
                _sortsEventsHandler.Add(value, CoffeIngredientsTable.makeEvenet(value));
            }
        }


    }
}
