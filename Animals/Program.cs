using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Animals
{
    class Program
    {
        static string[] b;
        static string[] o;
        static string[] p;
        static int i = 0;
        static void Main(string[] args)
        {
            InitGame();

        }

        static void InitGame()
        {
            o[i] = "Кот";
        }

        static bool TryAndWaitAnswer(string animal)
        {
            Console.WriteLine("Это " + animal + ", да?");
            var readLine = Console.ReadLine();
            return readLine != null && (readLine.ToLower() == "да" ? true : false);

        }

        private static bool TryAgain()
        {
            Console.WriteLine("Сыграем ещё?");
            var readLine = Console.ReadLine();
            return readLine != null && (readLine.ToLower() == "да" ? true : false);
        }
    }
}
