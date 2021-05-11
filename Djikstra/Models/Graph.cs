using System;
using System.Collections.Generic;
using System.Linq;

namespace Djikstra.Models
{
    public class Graph
    {
        readonly List<Node> Nodes = new List<Node>();

        public void CreateNode(string symbol, List<Edge> edges)
        {
            if (Nodes.Any(n => n.Symbol.Equals(symbol)))
                throw new System.Exception("Duplicated node symbol");

            var node = new Node()
            {
                Symbol = symbol,
                Edges = edges
            };

            Nodes.Add(node);
        }
        
        //SHORTEST PATH ALGORITHM IMPLEMENTATION FROM: https://github.com/mburst/dijkstras-algorithm
        public List<string> ShortestPath(string start, string finish)
        {
            Console.WriteLine($"Started with {start}, trying to get shortest path to {finish}.");

            var previous = new Dictionary<string, string>();
            var distances = new Dictionary<string, int>();
            var nodes = new List<string>();

            List<string> path = null;

            foreach (var node in Nodes)
            {
                if (node.Symbol == start)
                {
                    distances[node.Symbol] = 0;
                }
                else
                {
                    distances[node.Symbol] = int.MaxValue;
                }

                nodes.Add(node.Symbol);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<string>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in Nodes.Find(n => n.Symbol.Equals(smallest)).Edges)
                {
                    var alt = distances[smallest] + neighbor.Cost;
                    if (alt < distances[neighbor.TargetNode])
                    {
                        distances[neighbor.TargetNode] = alt;
                        previous[neighbor.TargetNode] = smallest;
                    }
                }
            }

            return path;
        }
    }
}
