using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Creational.Singleton.SingletonDependencyInjection
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class OrdinaryDatabase : IDatabase
    {
        private readonly Dictionary<string, int> Capitals;
        public OrdinaryDatabase()
        {
            Console.WriteLine("Initializing databse");

            Capitals = File.ReadAllLines(Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt"))
                .Batch(2)
                .ToDictionary(list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return Capitals[name];
        }
    }

    public class ConfigurableRecordFinder
    {
        private readonly IDatabase database;
        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException(paramName: nameof(IDatabase));
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
                result += database.GetPopulation(name);

            return result;
        }

        public int GetPopulation(string name)
        {
            return database.GetPopulation(name);
        }
    }

    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["betta"] = 2,
                ["gamma"] = 3
            }[name];
        }
    }
}
