using System;
using System.Globalization;
using AnimalGameClass;
using MySql.Data.MySqlClient;

namespace AnimalsMySQLStore
{
    internal class Implementer : IAnimal
    {
        private string connStr = "server=;user=;database=;port=3306;password=;charset=";
        private MySqlConnection conn;

        public Implementer()
        {
            conn = new MySqlConnection(connStr);
            conn.Open();
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
            var qs = "SELECT * FROM animals.animals WHERE i = " + index.ToString() + ";";
            var qi = "INSERT INTO animals.animals (i," + type + ") VALUES(" + index.ToString() + ",'" + message.ToString() + "');";
            var qu = "UPDATE animals.animals SET "+ type + " = '" + message  + "'WHERE i = " + index.ToString() + "; ";
            var command = new MySqlCommand(qs, conn);
            var reader = command.ExecuteReader();
            reader.Read();
            if (!reader.HasRows)
            {
                command = new MySqlCommand(qi, conn);
            }
            else
            {
                command = new MySqlCommand(qu, conn);
            }
            reader.Close();

            reader = command.ExecuteReader();
            reader.Read();
            reader.Close();
        }
        public string Read(string type, int index)
        {
            var q = "SELECT " + type + " FROM animals.animals WHERE i = " + index.ToString() + ";";
            var command = new MySqlCommand(q, conn);
            var reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                var r = reader[0].ToString();
                reader.Close();
                return r;
            }
            reader.Close();
            return null;
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
