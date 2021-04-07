using GraphLib;
using GraphLib.Graphs;
using System;
using System.Linq;

namespace GraphProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new DirectedWeightedGraph<int, double>();

            foreach (var num in Enumerable.Range(0, 10))
            {
                graph.AddNode(num);
            }
            foreach(var num in Enumerable.Range(0,9))
            {
                graph.AddEdge(new Random().Next(0, 9), new Random().Next(0,9), num);
            }

            Console.WriteLine(graph.ToString());

            graph.RemoveEdge(4, 5, 5);
            graph.RemoveEdge(3, 4, 3);
            graph.RemoveEdge(5, 6, 5);

            Console.WriteLine(graph.ToString());

            graph.Clear();
            Console.WriteLine(graph.ToString());
        }
    }
}
