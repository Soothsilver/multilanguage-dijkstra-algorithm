using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultilanguageDijkstraAlgorithm
{
    class Dijkstra
    {
        internal static DijkstraResult Compute(Assignment assignment)
        {
            assignment.StartNode.BestDistance = 0;
            List<Node> openList = new List<Node>();
            HashSet<Node> closedList = new HashSet<Node>();
            openList.Add(assignment.StartNode);

            // Main loop
            while (openList.Count > 0)
            {
                Node u = openList.MinBy(nd => nd.BestDistance);
                openList.Remove(u);
                closedList.Add(u);
                if (u == assignment.FinishNode)
                {
                    break;
                }
                foreach(Edge e in u.Edges)
                {
                    if (closedList.Contains(e.To))
                    {
                        continue;
                    }
                    int alt = u.BestDistance + e.Distance;
                    if (alt < e.To.BestDistance)
                    {
                        e.To.BestDistance = alt;
                        e.To.BestParent = u;
                        if (!openList.Contains(e.To))
                        {
                            openList.Add(e.To);
                        }
                    }
                }
            }

            // Unfold best
            if (assignment.FinishNode.BestParent == null)
            {
                return new DijkstraResult()
                {
                    Successful = false
                };
            }
            List<Node> unfoldedPath = new List<Node>();
            Node node = assignment.FinishNode;
            while (node != assignment.StartNode)
            {
                unfoldedPath.Insert(0, node);
                node = node.BestParent;
            }
            unfoldedPath.Insert(0, assignment.StartNode);
            return new DijkstraResult()
            {
                Successful = true,
                BestPath = unfoldedPath,
                PathLength = assignment.FinishNode.BestDistance
            };
        }
    }
}
