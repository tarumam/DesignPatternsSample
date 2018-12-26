using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Creational.Singleton
{
    //Singleton here works because we have a static database
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDataBase : IDatabase
    {
        private static int instanceCount; //0
        public static int Count => instanceCount;

        private readonly Dictionary<string, int> Capitals;

        private SingletonDataBase()
        {
            instanceCount++;
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

        private static readonly Lazy<SingletonDataBase> instance = new Lazy<SingletonDataBase>(() => new SingletonDataBase());
        public static SingletonDataBase Instance => instance.Value;
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDataBase.Instance.GetPopulation(name);
            }
            return result;
        }
    }

    //Instead of taking that hard dependency on a singleton database instance
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
                result += SingletonDataBase.Instance.GetPopulation(name);

            return result;
        }
    }
}
