Imports MoreLinq
Imports VBNet

Public Class Dijkstra
    Friend Shared Function Compute(assignment As Assignment) As DijkstraResult
        assignment.StartNode.BestDistance = 0
        Dim openList = New List(Of Node)
        Dim closedList = New HashSet(Of Node)
        openList.Add(assignment.StartNode)

        While openList.Count > 0
            Dim u = openList.MinBy(Function(nnn) nnn.BestDistance)
            openList.Remove(u)
            closedList.Add(u)
            If u Is assignment.FinishNode Then
                Exit While
            End If
            For Each e As Edge In u.Edges
                If closedList.Contains(e.Into) Then
                    Continue For
                End If
                Dim alt = u.BestDistance + e.Distance
                If alt < e.Into.BestDistance Then
                    e.Into.BestDistance = alt
                    e.Into.BestParent = u
                    If Not openList.Contains(e.Into) Then
                        openList.Add(e.Into)
                    End If
                End If
            Next
        End While

        If assignment.FinishNode.BestParent Is Nothing Then
            Return New DijkstraResult With {.Successful = False}
        End If
        Dim unfoldedPath = New List(Of Node)
        Dim node = assignment.FinishNode
        While node IsNot assignment.StartNode
            unfoldedPath.Insert(0, node)
            node = node.BestParent
        End While
        unfoldedPath.Insert(0, assignment.StartNode)
        Return New DijkstraResult With {
            .Successful = True,
            .BestPath = unfoldedPath,
            .PathLength = assignment.FinishNode.BestDistance
        }
    End Function
End Class
