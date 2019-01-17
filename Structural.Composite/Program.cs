using System;

namespace Structural.Composite
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Geometric shapes
            var drawing = new GraphicObject { Name = "My Drawing" };
            drawing.Children.Add(new Square { Color = "Red" });
            drawing.Children.Add(new Square { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Circle { Color = "Blue" });
            group.Children.Add(new Square { Color = "Blue" });
            drawing.Children.Add(group);

            Console.WriteLine(drawing);
            #endregion

            #region NeuralNetwork
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            neuron1.ConnectTo(neuron2);

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);

            #endregion
            Console.ReadKey();
        }
    }
}
