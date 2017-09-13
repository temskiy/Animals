using System;
using System.IO;
using AnimalGameClass;

namespace AnimalsFileStore
{
    internal class Implementer : IAnimal
    {
        
        public Implementer()
        {
            AniamlGame game = new AniamlGame(this);
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
            try
            {
                File.WriteAllText(type + index.ToString(), message);
            }
            catch (Exception)
            {

                throw;
            }
        
        }
        public string Read(string type, int index)
        {
            var fn = type + index.ToString();
            if (!File.Exists(fn))
            {
                return null;
            }
            try
            {
                return File.ReadAllText(fn);
            }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Implementer imp = new Implementer();
        }
    }
}
