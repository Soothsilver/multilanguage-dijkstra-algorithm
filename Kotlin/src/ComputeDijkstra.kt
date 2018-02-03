
fun computeDijkstra(assignment: Assignment): DijkstraResult {
    assignment.startNode?.bestDistance = 0
    val openList = ArrayList<Node>()
    val closedList = HashSet<Node>()
    openList.add(assignment.startNode!!)
    while (openList.size > 0) {
        val u = openList.minBy { it.bestDistance }!!
        openList.remove(u)
        closedList.add(u)
        if (u == assignment.finishNode) {
            break
        }
        for (e in u.edges) {
            if (closedList.contains(e.to)) {
                continue
            }
            val alt = u.bestDistance + e.distance
            if (alt < e.to.bestDistance) {
                e.to.bestDistance = alt
                e.to.bestParent = u
                if (!openList.contains(e.to)) {
                    openList.add(e.to)
                }
            }
        }
    }

    if (assignment.finishNode!!.bestParent == null) {
        return DijkstraResult(false, ArrayList(), 0)
    }
    val unfoldedPath = ArrayList<Node>()
    var node = assignment.finishNode!!
    while (node != assignment.startNode) {
        unfoldedPath.add(0, node)
        node = node.bestParent!!
    }
    unfoldedPath.add(0, assignment.startNode!!)
    return DijkstraResult(true, unfoldedPath, assignment.finishNode!!.bestDistance)

    /*
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
*/
}