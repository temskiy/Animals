using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalGameClass
{
    public interface IAnimal
    {
        void Print(string message);
        string Input();
        void Write(string type, int index, string message);
        string Read(string type, int index);
    }

    public class AniamlGameClass
    {
        private int i;
        private bool _exit;
        private string oo, pp, aa = "";
        public IAnimal inter;
        public void Start()
        {
            do
            {
                InitGame();
                while (!TryAndWaitAnswer(inter.Read("o", i)))
                {
                    do
                    {
                        oo = inter.Read("o",i);
                        pp = inter.Read("p", i);
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

                        if (inter.Read("b", i) == null)
                        {
                            inter.Write("o",i, WhoIsThis());
                            for (int j = 0; j < i - 1; j++)
                            {
                                if (inter.Read("o", j) == inter.Read("o", i))
                                {
                                    inter.Print(Properties.Resources.lie);
                                    return;
                                }
                            }
                            inter.Print(Properties.Resources.alt_q + inter.Read("o", i) + Properties.Resources.ot + oo);
                            inter.Write("b",i,inter.Input());
                            inter.Print(Properties.Resources.right_answer);
                            inter.Write("p",i, inter.Input());
                            _exit = true;
                            break;

                        }

                    } while (ask());
                    if (_exit) { break; }
                }
                _exit = false;

            } while (TryAgain());
        }

        private void InitGame()
        {
            i = 0;
            if (inter.Read("o", i) == "")
            {
                inter.Write("o", i, Properties.Resources.initial_animal);
            }
            
        }

        private bool TryAndWaitAnswer(string animal)
        {
            inter.Print(Properties.Resources.thisis + animal + Properties.Resources.yea);
            var readLine = inter.Input();
            return readLine.ToLower() == Properties.Resources.yes;

        }

        private bool TryAgain()
        {
            inter.Print(Properties.Resources.play_again);
            var readLine = inter.Input();
            return readLine.ToLower() == Properties.Resources.yes;
        }

        private string WhoIsThis()
        {
            inter.Print(Properties.Resources.kapituliren);
            return inter.Input();

        }

        private bool ask()
        {
            inter.Print(inter.Read("b", i));
            aa = inter.Input();
            if (aa != inter.Read("p", i))
            {
                return true;
            }
            return false;
        }

    }

    }

