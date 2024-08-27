Imports System
Imports System.ComponentModel.Design
Imports System.Threading

Module Program
    Dim _standUpCommand As String = "UP"
    Dim _rotateCommand As String = "R"
    Dim _makeOneStep As String = "STP"
    Dim _makeManySteps As String = "STP_"
    Dim _sitDownCommand As String = "DN"
    Dim _handsDownCommand As String = "HDN"
    Dim _handsUpCommand As String = "HUP"

    Dim men As MechanicalMan
    Sub Main(args As String())
        PrintCommands()
        men = New MechanicalMan(GetRandom(10, 100))


        ListenCommands()



        Console.ReadKey()

    End Sub

    Sub ListenCommands()

        While True
            Dim str As String = Console.ReadLine()
            If Not String.IsNullOrEmpty(str) Then
                If str = _standUpCommand Then
                    men.StandUp()
                ElseIf str = _sitDownCommand Then
                    men.Sitdown()
                ElseIf str = _makeOneStep Then
                    men.MoveOneStep()
                ElseIf str = _rotateCommand Then
                    men.Rotate()
                ElseIf str = _handsDownCommand Then
                    men.HandsDown()
                ElseIf str = _handsUpCommand Then
                    men.RiseHands()
                ElseIf str.StartsWith(_makeManySteps) Then
                    Dim stepsCount = Convert.ToInt16(str.Split("_").LastOrDefault())
                    If stepsCount > 0 Then
                        For index As Integer = stepsCount To 0 Step -1
                            men.MoveOneStep()
                            Thread.Sleep(1000)
                            Console.WriteLine("Steps to wall: " + men.StepsTowardWallFromMan.ToString())
                        Next
                    End If
                Else
                    Console.WriteLine("Wrong command")
                End If
                PrintState(men)
            End If

        End While


    End Sub

    Sub PrintState(men As MechanicalMan)
        Console.WriteLine("Is men stands up: " + men.IsStendUp.ToString())
        Console.WriteLine("Are men's hands rised: " + men.AreHandsRaised.ToString())
        Console.WriteLine("Is man are heading toward wall : " + men.IsGoingTowardWall.ToString())
        Console.WriteLine("Steps to wall: " + men.StepsTowardWallFromMan.ToString())
        Console.WriteLine("Steps to chair: " + (men.StepsTowardWallFromMan - men.StepsTowardWallFromChair).ToString())
    End Sub

    Sub PrintCommands()
        Console.WriteLine("Stand up: " + _standUpCommand)
        Console.WriteLine("Rotate: " + _rotateCommand)
        Console.WriteLine("Make one step: " + _makeOneStep)
        Console.WriteLine("Make many steps: " + _makeManySteps + "{number of steps}")
        Console.WriteLine("Sit down: " + _sitDownCommand)
        Console.WriteLine("Hands down: " + _handsDownCommand)
        Console.WriteLine("Hands up: " + _handsUpCommand)


    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
End Module
