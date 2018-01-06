Module Module1

    Sub Main()
        Dim testcases As IEnumerable(Of String) = System.IO.Directory.EnumerateFiles("..\\..\\..\\data", "*.txt")
        For Each filename In testcases
            Dim aCase As TestCase = New TestCase(filename)
            aCase.Run()
        Next
    End Sub

End Module
