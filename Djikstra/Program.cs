using Djikstra.Models;
using System;
using System.Collections.Generic;

namespace Dijkstras
{
    class Program
    {
        public static void Main(string[] args)
        {
            Graph g = new Graph();

            g.CreateNode("Wrocław", new List<Edge>() { new Edge("Namysłow", 61), new Edge("Bielany Wrocławskie", 10), new Edge("Brzeg", 42) });

            g.CreateNode("Namysłow", new List<Edge>() { new Edge("Brzeg", 33), new Edge("Częstochowa", 114) });
            g.CreateNode("Częstochowa", new List<Edge>() { new Edge("Gliwice", 91), new Edge("Jędrzejów", 98)});
            g.CreateNode("Jędrzejów", new List<Edge>() { new Edge("Kraków", 80)});


            g.CreateNode("Brzeg", new List<Edge>() { new Edge("Opole", 42)});
            g.CreateNode("Opole", new List<Edge>() { new Edge("Gliwice", 82)});
            g.CreateNode("Gliwice", new List<Edge>() { new Edge("Kraków", 110)});


            g.CreateNode("Bielany Wrocławskie", new List<Edge>() { new Edge("Katowice", 187)});
            g.CreateNode("Katowice", new List<Edge>() { new Edge("Kraków", 81)});


            g.CreateNode("Kraków", new List<Edge>() {});

            var path = g.ShortestPath("Wrocław", "Kraków");
            path.Reverse();
            path.ForEach(node => Console.WriteLine(node));
        }
    }
}