using Behavioral.ChainOfResponsability.MethodChain;
using System;

namespace Behavioral.ChainOfResponsability
{
    public class Demo
    {
        public static void Main()
        {
            Console.WriteLine("Method Chain");
            //Creating a goblin
            var goblin = new Creature("Goblin", 2, 2);
            Console.WriteLine(goblin);

            var root = new CreatureModifier(goblin);

            //Console.WriteLine("Do not allow any modifier after this");
            //root.Add(new NoBonusesModifier(goblin));

            Console.WriteLine("Doubling goblin attack");
            root.Add(new DoubleAttackModifier(goblin));

            Console.WriteLine("Increasing globin defense");
            root.Add(new IncreaseDefenseModifier(goblin));

            root.Handle();

            Console.WriteLine(goblin);

            Console.WriteLine("**************************");


            Console.WriteLine("Broker Chain");

            var game = new BrokerChain.Game();
            var orc = new BrokerChain.Creature(game, "strong Orc", 3, 3);
            Console.WriteLine(orc);

            using (new BrokerChain.DoubleAttackModifier(game, orc))
            {
                Console.WriteLine(orc);
                using (new BrokerChain.IncreaseDefenseModifier(game, orc))
                {
                    Console.WriteLine(orc);
                }
            }
            Console.WriteLine(orc);
            Console.WriteLine("**************************");

            Console.ReadKey();
        }
    }
}
