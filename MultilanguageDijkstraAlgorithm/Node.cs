using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilanguageDijkstraAlgorithm
{
    class Assignment
    {
        public Node StartNode { get; set; }
        public Node FinishNode { get; set; }
        public Dictionary<string, Node> AllNodes = new Dictionary<string, Node>();

        internal void AddEdge(string node1s, int distance, string node2s)
        {
            if (!AllNodes.ContainsKey(node1s))
            {
                AllNodes.Add(node1s, new Node(node1s));
            }
            if (!AllNodes.ContainsKey(node2s))
            {
                AllNodes.Add(node2s, new Node(node2s));
            }
            Node one = AllNodes[node1s];
            Node two = AllNodes[node2s];
            one.Edges.Add(new Edge(one, two, distance));
            two.Edges.Add(new Edge(two, one, distance));
        }
    }
    class Node
    {
        public string Name { get; set; }
        public List<Edge> Edges = new List<Edge>();
        public int BestDistance = Int32.MaxValue;
        public Node BestParent = null;

        public Node(string name)
        {
            this.Name = name;
        }
    }
    class Edge
    {
        public Node From { get; set; }
        public Node To { get; set; }
        public int Distance { get; set; }
        public Edge(Node from, Node to, int distance)
        {
            From = from;
            To = to;
            Distance = distance;
        }
    }
    class DijkstraResult
    {
        public bool Successful { get; set; }
        public List<Node> BestPath = new List<Node>();
        public int PathLength;
    }
}
