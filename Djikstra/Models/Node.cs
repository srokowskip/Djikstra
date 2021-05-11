using System;
using System.Collections.Generic;
using System.Text;

namespace Djikstra.Models
{
    public class Node
    {
        public string Symbol { get; set; }
        public List<Edge> Edges { get; set; }
    }
}
