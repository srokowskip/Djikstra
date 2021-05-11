namespace Djikstra.Models
{
    public class Edge
    {
        public Edge(string targetNode, int cost)
        {
            TargetNode = targetNode;
            Cost = cost;
        }

        public string TargetNode { get;}

        public int Cost { get;}
    }
}
