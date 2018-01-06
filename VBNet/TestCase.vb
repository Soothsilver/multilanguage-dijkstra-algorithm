Public Class TestCase
    Private filename As String

    Public Sub New(filename As String)
        Me.filename = filename
    End Sub

    Friend Sub Run()
        Console.Write("[VB.NET] Running test case " + filename + "... ")
        Dim lines() As String = System.IO.File.ReadAllLines(filename)
        Dim firstLine = lines(0)
        ' #start#end#27#start:a:c:d:end# 
        Dim assignment As Assignment = New Assignment()
        For Each line In lines.Skip(1).Where(Function(text) text <> "")
            Dim split = line.Split(":")
            Dim s1 = split(0)
            Dim dist = Integer.Parse(split(1))
            Dim s2 = split(2)
            assignment.AddEdge(s1, dist, s2)
        Next

        Dim metadata As String() = firstLine.Split(New Char() {"#"}, StringSplitOptions.RemoveEmptyEntries)
        assignment.StartNode = assignment.AllNodes(metadata(0))
        assignment.FinishNode = assignment.AllNodes(metadata(1))
        Dim expectSuccess = metadata(2) <> "FAIL"
        Dim result = Dijkstra.Compute(assignment)

        If result.Successful Then
            If Not expectSuccess Then
                Console.WriteLine("fail! (unexpectedly succeeded)")
                Return
            End If
            If result.PathLength <> Integer.Parse(metadata(2)) Then
                Console.WriteLine("fail! (bad path length)")
                Return
            End If
            Dim nodeNames = metadata(3).Split(":")
            If nodeNames.Length <> result.BestPath.Count Then
                Console.WriteLine("fail! (bad node count)")
                Return
            End If
            For i = 0 To nodeNames.Length - 1
                If nodeNames(i) <> result.BestPath(i).Name Then
                    Console.WriteLine("fail! (bad path)")
                    Return
                End If
            Next
            Console.WriteLine("OK!")
        Else
            If expectSuccess Then
                Console.WriteLine("fail! (unexpectedly failed)")
            Else
                Console.WriteLine("OK!")
            End If
        End If
    End Sub
End Class
