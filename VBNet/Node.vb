Public Class Assignment
    Public StartNode As Node
    Public FinishNode As Node
    Public AllNodes As Dictionary(Of String, Node) = New Dictionary(Of String, Node)

    Friend Sub AddEdge(first As String, distance As Integer, second As String)
        If Not AllNodes.ContainsKey(first) Then
            AllNodes.Add(first, New Node(first))
        End If
        If Not AllNodes.ContainsKey(second) Then
            AllNodes.Add(second, New Node(second))
        End If
        Dim one As Node = AllNodes(first)
        Dim two = AllNodes(second)
        one.Edges.Add(New Edge(one, two, distance))
        two.Edges.Add(New Edge(two, one, distance))
    End Sub
End Class

Public Class Node
    Public Property Name As String
    Public Property Edges As List(Of Edge) = New List(Of Edge)
    Public Property BestDistance As Integer = Integer.MaxValue
    Public Property BestParent As Node = Nothing

    Public Sub New(name As String)
        Me.Name = name
    End Sub
End Class

Public Class Edge
    Public ReadOnly Property From As Node
    Public ReadOnly Property Into As Node
    Public ReadOnly Property Distance As Integer
    Public Sub New(from As Node, into As Node, distance As Integer)
        Me.From = from
        Me.Into = into
        Me.Distance = distance
    End Sub
End Class

Public Class DijkstraResult
    Public Property Successful As Boolean
    Public Property BestPath As List(Of Node)
    Public Property PathLength As Integer
End Class
