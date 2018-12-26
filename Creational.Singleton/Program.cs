using static System.Console;

namespace Creational.Singleton
{
    internal class Program
    {
        //For other singleton listed in cs files, check the test project.
        private static void Main(string[] args)
        {
            WriteLine("Singleton");
            var db = SingletonDataBase.Instance;
            var city = "Tokyo";
            WriteLine($"{city} has population {db.GetPopulation(city)}");
            WriteLine("****************************");

            //Bizzar implementation of singleton... here we can instantiate new classes but the instances "Share" the same static fields / values
            WriteLine("Singleton monostate");
            var ceo1 = new ChiefExecutiveOfficer();
            ceo1.Name = "Adam Smith";
            ceo1.Age = 55;
            WriteLine(ceo1);

            var ceo2 = new ChiefExecutiveOfficer();
            WriteLine(ceo2);
            WriteLine("****************************");

            ReadKey();

        }
    }
}
