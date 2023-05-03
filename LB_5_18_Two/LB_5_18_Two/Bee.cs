using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_5_18_Two
{
    internal class Bee
    {
        
        private readonly int _id;
        private readonly HoneyPot _pot;

        public Bee(int id, HoneyPot pot)
        {
            _id = id;
            _pot = pot;
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(1000);
                _pot.AddPortion(_id);

                if (_pot.IsFull())
                {
                    Console.WriteLine("Bee {0} filled the pot", _id);
                    _pot.WakeUpBear();
                }
            }
        }
    }

}

