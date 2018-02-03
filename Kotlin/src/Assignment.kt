
class Assignment (public var startNode : Node? = null, public var finishNode : Node? = null, public val allNodes : MutableMap<String, Node> = HashMap()) {
    fun addEdge(node1s: String, distance: Int, node2s: String) {
        if (!allNodes.containsKey(node1s)) {
            allNodes.put(node1s, Node(node1s))
        }
        if (!allNodes.containsKey(node2s)) {
            allNodes.put(node2s, Node(node2s))
        }
        val one = allNodes[node1s]!!
        val two = allNodes[node2s]!!
        one.edges.add(Edge(one,  two, distance))
        two.edges.add(Edge(two, one, distance))
    }

}
class Node (val name : String, val edges : MutableList<Edge> = ArrayList<Edge>(), val bestDistance : Int = Int.MAX_VALUE, val bestParent : Node? = null) {

}
class Edge (val from : Node, val to : Node, val distance : Int) {

}
class DijkstraResult(val successful: Boolean, val bestPath : List<Node>, val pathLength : Int) {

}
/* class Assignment
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
    }*/