using System;

namespace UP_Exercise_6
{
    delegate void Del(string message);
    class classEvent
    {
        public event Del Event;
        public void DisplayMessage(string msg)
        {
            Console.WriteLine(msg);
        }
        public void funEvent(string msg, ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
            Event = DisplayMessage;
            Event.Invoke(msg);
            Console.ResetColor();
        }
    }
    class forEvent
    {
        private classEvent eve;
        private string data;
        public forEvent(classEvent n_eve, string n_data) { eve = n_eve; data = n_data; }
        public void DisplayEvent(int inp, int comp)
        {
            if (inp > comp)
            {
                eve.funEvent($"{data} {inp} больше {comp}", ConsoleColor.Red);
            }
            else if (inp < comp)
            {
                eve.funEvent($"{data} {inp} меньше {comp}", ConsoleColor.Green);
            }
            else
            {
                eve.funEvent($"{data} {inp} равно {comp}", ConsoleColor.Blue);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            classEvent ob = new classEvent();
            forEvent fe = new forEvent(ob, "Число");
            Console.WriteLine("Введите число, с которым будет происходить сравнение: ");
            int max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество сравнений: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите числа: ");
            int a;
            for (int i = 0; i < n; i++)
            {
                a = Convert.ToInt32(Console.ReadLine());
                fe.DisplayEvent(a, max);
            }
        }
    }
}
