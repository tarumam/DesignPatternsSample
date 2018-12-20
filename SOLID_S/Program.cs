using System;
using System.Collections.Generic;
using System.IO;

//Single Responsability Principle - A class is responsible for one thing and has one reason to change
namespace SOLID_S
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        //Wrong if we put persistence methods inside of Journal Method that already has responsability to manage entries.
        //public void SaveToFile() { //Save file code}

    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());

        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("It is the first item ");
            j.AddEntry("I ate a bug");

            var p = new Persistence();
            var fileName = @"D:\temp\Journal.txt";
            p.SaveToFile(j, fileName, true);

            Console.WriteLine(@"Open the file D:\temp\Journal.txt");
            Console.ReadKey();
        }
    }
}
