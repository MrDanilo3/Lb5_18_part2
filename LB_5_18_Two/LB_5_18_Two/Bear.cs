using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_5_18_Two
{
    internal class Bear
    {
        private readonly HoneyPot _pot;

        public Bear(HoneyPot pot)
        {
            _pot = pot;
        }

        public void Start()
        {
            while (true)
            {
                _pot.GetPortion();
                Thread.Sleep(1000);
                _pot.Refill();
            }
        }

        public void EatHoney()
        {
            while (true)
            {
                lock (_pot)
                {
                    while (!_pot.IsFull())
                    {
                        Console.WriteLine("Bear is sleeping...");
                        Monitor.Wait(_pot);
                    }

                    _pot.Empty();

                    Console.WriteLine("Bear ate all the honey and is going to sleep...");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
