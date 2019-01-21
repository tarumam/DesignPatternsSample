using static System.Console;

namespace Structural.Decorator
{
    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }
    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }
        public void Fly()
        {
            WriteLine($"Soaring in the sky with weight {Weight}.");
        }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }
        public void Crawl()
        {
            WriteLine($"Crawling in the dirt  with weight {Weight}.");
        }
    }

    public class Dragon : ILizard, IBird
    {
        private int weight;
        public int Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            }
        }

        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }
}
