using System;

namespace NET.S._2019.Tkachenko._11_Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            Tester tester = new Tester();
            tester.Subscribe(timer);

            Console.Write("Time: ");
            int time = 0;
            try
            {
                time = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            Console.Write("Message: ");
            string message = Console.ReadLine();
            timer.StartCoundown(time, message);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}