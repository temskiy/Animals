//По мотивам игры "Животные" из журнала "Наука и жизнь" №12 за 1986г.
using System;
using AnimalGameClass;

namespace Animals
{
    class Program: IAnimal
    {
        static string[] b;
        static string[] o;
        static string[] p;
        static AniamlGameClass game;

        private static void Main()
        {
            b = new string[2000];
            o = new string[2000];
            p = new string[2000];
            game = new AnimalGameClass.AniamlGameClass();
            game.Start();

        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void Write(string type, int index, string message)
        {
            switch (type)
            {
                case "b":
                     b[index] = message;
                    break;
                case "o":
                    o[index]  = message;
                    break;
                case "p":
                    p[index] = message;
                    break;
            }
        }

        public string Read(string type, int index)
        {
            switch (type)
            {
                case "b":
                    return b[index];
                    
                case "o":
                    return o[index];
                case "p":
                    return p[index];
            }
            return "";
        }
    }
}
