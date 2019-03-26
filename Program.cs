using System;

namespace CustomEvents
{
    class Program
    {
        static void Main(string[] args)
        {

            Counter c = new Counter();
            c.CounterStart += C_CounterStart;
            c.CounterChange += C_CounterChange;

            //c.CounterChange += (object sender, CounterEventArgs e) =>
            //{
            //    Console.WriteLine("onCounterChange, Count = {0}", e.Count);
            //};

            //c.CounterChange += delegate (object sender, CounterEventArgs e)
            //{
            //    Console.WriteLine("onCounterChange, Count = {0}", e.Count);
            //};


            c.CounterFinish += C_CounterFinish;
            c.Run();

            Console.ReadLine();
        }

        private static void C_CounterStart(object sender, CounterEventArgs e)
        {
            Counter c = sender as Counter;

            Console.WriteLine("onStart, Count = {0}, Step = {1}", e.Count, c.Step);



        }

        private static void C_CounterChange(object sender, CounterEventArgs e)
        {
            Console.WriteLine("onChange, Count = {0}", e.Count);
        }

        private static void C_CounterFinish(object sender, CounterEventArgs e)
        {
            Console.WriteLine("onFinsih, Count = {0}", e.Count);
            Console.WriteLine("----------------------- RESET -----------------------");

            Counter c = sender as Counter;
            c.Reset(0, 20, 2);
            c.CounterFinish -= C_CounterFinish;
            c.Run();
        }




    }
}
