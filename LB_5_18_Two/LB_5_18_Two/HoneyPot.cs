using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_5_18_Two
{
    class HoneyPot
    {


        private const int MaxCapacity = 10;
        private int _currentCapacity = 0;
        private readonly object _lockObject = new object();

        public void AddPortion(int beeId)
        {
            lock (_lockObject)
            {
                while (_currentCapacity == MaxCapacity)
                {
                    Console.WriteLine("Bee {0} is waiting...", beeId);
                    Monitor.Wait(_lockObject);
                }

                _currentCapacity++;
                Console.WriteLine("Bee {0} added a portion. Current capacity: {1}", beeId, _currentCapacity);

                Monitor.PulseAll(_lockObject);
            }
        }

        public bool IsFull()
        {
            lock (_lockObject)
            {
                return _currentCapacity == MaxCapacity;
            }
        }

        public void WakeUpBear()
        {
            lock (_lockObject)
            {
                Console.WriteLine("Bear is woken up!");
                Monitor.Pulse(_lockObject);
            }
        }

        public void GetPortion()
        {
            lock (_lockObject)
            {
                while (_currentCapacity == 0)
                {
                    Console.WriteLine("Bear is waiting...");
                    Monitor.Wait(_lockObject);
                }

                _currentCapacity--;
                Console.WriteLine("Bear took a portion. Current capacity: {0}", _currentCapacity);

                Monitor.PulseAll(_lockObject);
            }
        }

        public void Refill()
        {
            lock (_lockObject)
            {
                while (_currentCapacity < MaxCapacity)
                {
                    Console.WriteLine("Bear is sleeping...");
                    Monitor.Wait(_lockObject);
                }

                Console.WriteLine("Bear refilled the pot. Current capacity: {0}", _currentCapacity);

                Monitor.PulseAll(_lockObject);
            }
        }

        public void Empty()
        {
            lock (_lockObject)
            {
                _currentCapacity = 0;
                Console.WriteLine("HoneyPot has been emptied.");
                Monitor.PulseAll(_lockObject);
            }
        }


    }

}
