Module Module1

    Dim n, m As Integer
    Dim Debuger() As Algor
    Class Algor
        Private Before, After As Char()
        Private Time As Integer

        Sub setTime(Source As Integer)
            Time = Source
        End Sub
        Sub setBefore(Source As String)
            Before = Source
        End Sub
        Sub setAfter(Source As String)
            After = Source
        End Sub

        Function getTime()
            Return Time
        End Function
        Function getBefore()
            Return Before
        End Function
        Function getAfter()
            Return After
        End Function

    End Class

    Sub Main()
        Dim InitString As String = ""

        '================================= Test1 ====================================
        m = 15
        n = 15
        ReDim Debuger(m - 1)
        For i = 0 To (m - 1)
            Debuger(i) = New Algor()
        Next

        testInput(0, "10 000000000000000 00000000000000-")
        testInput(1, "10 00000000000000- 0000000000000-+")
        testInput(2, "10 0000000000000-- 000000000000-++")
        testInput(3, "10 000000000000--- 00000000000-+++")
        testInput(4, "10 00000000000---- 0000000000-++++")
        testInput(5, "10 0000000000----- 000000000-+++++")
        testInput(6, "10 000000000------ 00000000-++++++")
        testInput(7, "10 00000000------- 0000000-+++++++")
        testInput(8, "10 0000000-------- 000000-++++++++")
        testInput(9, "10 000000--------- 00000-+++++++++")
        testInput(10, "10 00000---------- 0000-++++++++++")
        testInput(11, "10 0000----------- 000-+++++++++++")
        testInput(12, "10 000------------ 00-++++++++++++")
        testInput(13, "10 00------------- 0-+++++++++++++")
        testInput(14, "10 0-------------- -++++++++++++++")

        InitString = ""
        For i = 0 To n - 1
            InitString = InitString + "+"
        Next
        '===========================================================================
        findAlgor(InitString)

        '================================= Test2 ====================================
        m = 3
        n = 3
        ReDim Debuger(m - 1)
        For i = 0 To (m - 1)
            Debuger(i) = New Algor()
        Next

        testInput(0, "1 000 0--")
        testInput(1, "3 000 --+")
        testInput(2, "2 0-- -++")

        InitString = ""
        For i = 0 To n - 1
            InitString = InitString + "+"
        Next
        '===========================================================================
        findAlgor(InitString)

        '================================= Test3 ====================================
        m = 3
        n = 3
        ReDim Debuger(m - 1)
        For i = 0 To (m - 1)
            Debuger(i) = New Algor()
        Next

        testInput(0, "2 +00 00-")
        testInput(1, "1 00- +-+")
        testInput(2, "2 0-- -++")

        InitString = ""
        For i = 0 To n - 1
            InitString = InitString + "+"
        Next
        '===========================================================================
        findAlgor(InitString)

        '================================= Test4 ====================================
        m = 4
        n = 3
        ReDim Debuger(m - 1)
        For i = 0 To (m - 1)
            Debuger(i) = New Algor()
        Next

        testInput(0, "2 +00 00-")
        testInput(1, "1 00- +-0")
        testInput(2, "2 0-- -++")
        testInput(3, "4 +00 -0-")

        InitString = ""
        For i = 0 To n - 1
            InitString = InitString + "+"
        Next
        '===========================================================================
        findAlgor(InitString)

        Console.ReadLine()
    End Sub

    Sub testInput(index As Integer, InputString As String)
        Dim InputString2 As String()
        InputString2 = InputString.Split(" ")
        Debuger(index).setTime(InputString2(0))
        Debuger(index).setBefore(InputString2(1))
        Debuger(index).setAfter(InputString2(2))
    End Sub

    Sub input()
        Dim InputString1 As String() = Console.ReadLine().Split(" ")
        n = InputString1(0)
        m = InputString1(1)

        ReDim Debuger(m - 1)
        For i = 0 To m - 1
            Debuger(i) = New Algor()
            Dim InputString2 As String() = Console.ReadLine().Split(" ")
            Debuger(i).setTime(InputString2(0))
            Debuger(i).setBefore(InputString2(1))
            Debuger(i).setAfter(InputString2(2))
        Next
    End Sub

    Sub findAlgor(Source As String)
        Dim FinishCase As String = ""

        For j = 0 To n - 1
            FinishCase = FinishCase + "-"
        Next

        Dim InputRound() As String
        Dim OutputRound() As String
        Dim AlgorIndexRound() As Integer
        Dim TimeOutputRound() As Integer
        Dim Round As Integer = 0
        Dim Result As String
        Dim TimeOutput As Integer = 0
        Dim ResultDup As Boolean = False
        Dim MinTimeOutput As Integer = 0
        Dim CanChoose As Boolean = True
        Dim i As Integer = 0

        Do
            CanChoose = False
            While i < m
                CanChoose = isCanChoose(Source, Debuger(i))
                If CanChoose Then
                    Result = processOutput(Source, Debuger(i).getAfter())
                    If Round = 0 Then
                        ReDim InputRound(Round)
                        ReDim OutputRound(Round)
                        ReDim AlgorIndexRound(Round)
                        ReDim TimeOutputRound(Round)
                        InputRound(Round) = Source
                        OutputRound(Round) = Result
                        AlgorIndexRound(Round) = i
                        Source = Result
                        TimeOutputRound(Round) = TimeOutput
                        TimeOutput = TimeOutput + Debuger(i).getTime()
                        If Source <> FinishCase Then
                            Round += 1
                        End If
                        i = 0
                    Else
                        ResultDup = False
                        For Each OutputRounds In OutputRound
                            If OutputRounds = Result Then
                                ResultDup = True
                                Exit For
                            End If
                        Next
                        If Not ResultDup Then
                            ReDim Preserve InputRound(Round)
                            ReDim Preserve OutputRound(Round)
                            ReDim Preserve AlgorIndexRound(Round)
                            ReDim Preserve TimeOutputRound(Round)
                            InputRound(Round) = Source
                            OutputRound(Round) = Result
                            AlgorIndexRound(Round) = i
                            Source = Result
                            TimeOutputRound(Round) = TimeOutput
                            TimeOutput = TimeOutput + Debuger(i).getTime()
                            If Source <> FinishCase Then
                                Round += 1
                            End If
                            i = 0
                        Else
                            i += 1
                        End If
                    End If
                    If Source = FinishCase Then
                        If MinTimeOutput = 0 Then
                            MinTimeOutput = TimeOutput
                        Else
                            If TimeOutput < MinTimeOutput Then
                                MinTimeOutput = TimeOutput
                            End If
                        End If
                        Round -= 1
                        Source = InputRound(Round)
                        i = AlgorIndexRound(Round) + 1
                        TimeOutput = TimeOutputRound(Round)
                        ReDim Preserve InputRound(UBound(InputRound) - 1)
                        ReDim Preserve OutputRound(UBound(OutputRound) - 1)
                        ReDim Preserve AlgorIndexRound(UBound(AlgorIndexRound) - 1)
                        ReDim Preserve TimeOutputRound(UBound(TimeOutputRound) - 1)
                    End If
                Else
                    i += 1
                End If
            End While
            If Not CanChoose Then
                Round -= 1
                Source = InputRound(Round)
                i = AlgorIndexRound(Round) + 1
                TimeOutput = TimeOutputRound(Round)
                ReDim Preserve InputRound(UBound(InputRound) - 1)
                ReDim Preserve OutputRound(UBound(OutputRound) - 1)
                ReDim Preserve AlgorIndexRound(UBound(AlgorIndexRound) - 1)
                ReDim Preserve TimeOutputRound(UBound(TimeOutputRound) - 1)
            End If
        Loop While Round > 0
        If MinTimeOutput = 0 Then
            Console.WriteLine("Bugs cannot be fixed.")
        Else
            Console.WriteLine("Fastest sequence takes " + MinTimeOutput.ToString() + " seconds.")
        End If

    End Sub

    Function isCanChoose(Source As String, Debuger As Algor) As Boolean
        Dim i As Integer = 0
        Dim ChooseAlgor As Integer = 1
        While i <= (Source.Length - 1) AndAlso ChooseAlgor <> 0
            If Debuger.getBefore(i) = "0" Then
                If Not ("+-".Contains(Source(i))) Then
                    ChooseAlgor = 0
                End If
            ElseIf Debuger.getBefore(i) = "+" Then
                If Not ("+".Contains(Source(i))) Then
                    ChooseAlgor = 0
                End If
            ElseIf Debuger.getBefore(i) = "-" Then
                If Not ("-".Contains(Source(i))) Then
                    ChooseAlgor = 0
                End If
            End If
            i = i + 1
        End While
        If ChooseAlgor = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
    Function processOutput(Source As String, Condition As String) As String
        Dim result(Source.Length - 1) As Char
        For i = 0 To (Source.Length - 1)
            If Condition(i) = "0" Then
                result(i) = Source(i)
            ElseIf Condition(i) = "+" Then
                result(i) = "+"
            ElseIf Condition(i) = "-" Then
                result(i) = "-"
            End If
        Next
        Return result
    End Function
End Module
