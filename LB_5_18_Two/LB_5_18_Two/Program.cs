using LB_5_18_Two;
using System;
using System.Threading;

namespace Container
{
    class Program
    {
        static void Main(string[] args)
        {
            HoneyPot pot = new HoneyPot();

            Bee bee1 = new Bee(1, pot);
            Bee bee2 = new Bee(2, pot);
            Bear bear = new Bear(pot);

            Thread bee1Thread = new Thread(bee1.Start);
            Thread bee2Thread = new Thread(bee2.Start);
            Thread bearThread = new Thread(bear.Start);

            bee1Thread.Start();
            bee2Thread.Start();
            bearThread.Start();

            Console.ReadLine();
        }
    }
}
