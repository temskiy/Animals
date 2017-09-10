//По мотивам игры "Животные" из журнала "Наука и жизнь" №12 за 1986г.
using System;

namespace Animals
{
    class Program
    {
        static string[] b;
        static string[] o;
        static string[] p;
        private static string oo, pp, aa = "";
        static int i;
        private static bool _exit;

        static void Main()
        {
            b = new string[2000];
            o = new string[2000];
            p = new string[2000];

            do
            {
                i = 0;
                o[i] = "Кот";

                while (!TryAndWaitAnswer(o[i]))
                {
                    do
                    {
                        oo = o[i];
                        pp = p[i];
                        if (i == 0)
                        {
                            i = 1;

                        }
                        else
                        {
                            i = i * 2;
                            if (aa == pp)
                            {
                                i++;
                            }
                        }

                        if (b[i] == null)
                        {
                            o[i] = WhoIsThis();
                            for (int j = 0; j < i - 1; j++)
                            {
                                if (o[j] == o[i])
                                {
                                    Console.WriteLine("Нечестно играете!");
                                    return;
                                }
                            }
                            Console.WriteLine("Задайте альтернативный вопрос, ответив на который сожно отличить " + o[i] + " от " + oo);
                            b[i] = Console.ReadLine();
                            Console.WriteLine("Правильный ответ?");
                            p[i] = Console.ReadLine();
                            _exit = true;
                            break;

                        }

                    } while (Ask());
                    if (_exit) { break;}
                }
                _exit = false;

            } while (TryAgain());
        }

        private static bool TryAndWaitAnswer(string animal)
        {
            Console.WriteLine("Это " + animal + ", да?");
            var readLine = Console.ReadLine();
            return readLine.ToLower() == "да";

        }

        private static bool TryAgain()
        {
            Console.WriteLine("Сыграем ещё?");
            var readLine = Console.ReadLine();
            return readLine.ToLower() == "да";
        }

        private static string WhoIsThis()
        {
            Console.WriteLine("Сдаюсь. Кто это?");
            return Console.ReadLine();

        }

  
        private static bool Ask()
        {
           Console.WriteLine(b[i]);
            aa = Console.ReadLine();
            if (aa != p[i])
            {
                return true;
            }
            return false;
        }


    }
}
