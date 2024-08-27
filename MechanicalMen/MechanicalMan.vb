Imports System.IO

Public Class MechanicalMan
    Dim _areHandsRaised As Boolean
    Dim _isStendUp As Boolean
    Dim _isGoingTowardWall As Boolean
    Dim _stepsTowardWallFromMan As Integer
    Dim _stepsTowardWallFromChair As Integer

    Public ReadOnly Property AreHandsRaised As Boolean
        Get
            Return _areHandsRaised
        End Get
    End Property

    Public ReadOnly Property IsStendUp As Boolean
        Get
            Return _isStendUp
        End Get

    End Property

    Public ReadOnly Property IsGoingTowardWall As Boolean
        Get
            Return _isGoingTowardWall
        End Get

    End Property

    Public ReadOnly Property StepsTowardWallFromMan As Integer
        Get
            Return _stepsTowardWallFromMan
        End Get
    End Property

    Public ReadOnly Property StepsTowardWallFromChair As Integer
        Get
            Return _stepsTowardWallFromChair
        End Get

    End Property

    Public Sub New(steptsTowardsWall As Integer)
        _stepsTowardWallFromChair = steptsTowardsWall
        _stepsTowardWallFromMan = steptsTowardsWall
        _isGoingTowardWall = True
    End Sub

    Public Sub MoveOneStep()
        If Not _isStendUp Then
            Return
        End If
        If _isGoingTowardWall And
            AnySpaceBetweenMenAndWall() Then

            _stepsTowardWallFromMan -= 1

        ElseIf Not _isGoingTowardWall Then

            _stepsTowardWallFromMan += 1

        End If
        CheckEnvironment()
    End Sub

    Public Sub Rotate()
        If _isGoingTowardWall Then
            _isGoingTowardWall = False
        Else
            _isGoingTowardWall = True
        End If
    End Sub

    Public Sub StandUp()
        _isStendUp = True
    End Sub

    Public Sub Sitdown()
        If _stepsTowardWallFromMan = _stepsTowardWallFromChair Then
            _isStendUp = False
        End If

    End Sub

    Public Sub RiseHands()
        _areHandsRaised = True
    End Sub

    Public Sub HandsDown()
        _areHandsRaised = False
    End Sub


    'Private methods'

    Private Function AnySpaceBetweenMenAndWall() As Boolean
        Return _stepsTowardWallFromMan > 0
    End Function

    Private Sub CheckEnvironment()
        If _areHandsRaised And Not AnySpaceBetweenMenAndWall() Then
            Rotate()
        End If

        If Not _areHandsRaised And
           _stepsTowardWallFromMan = _stepsTowardWallFromChair Then
            Sitdown()
        End If
    End Sub








End Class
