Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows

Namespace ValidateRow_CodeBehind

    Public Class Task
        Implements IDataErrorInfo

        Public Property TaskName As String

        Public Property StartDate As Date

        Public Property EndDate As Date

        Private ReadOnly Property [Error] As String Implements IDataErrorInfo.[Error]
            Get
                Return If(StartDate > EndDate, "Either Start Date or End Date should be corrected.", Nothing)
            End Get
        End Property

        Private ReadOnly Property Item(ByVal columnName As String) As String Implements IDataErrorInfo.Item
            Get
                Select Case columnName
                    Case NameOf(Task.StartDate)
                        If StartDate > EndDate Then Return "Start Date must be less than End Date"
                    Case NameOf(Task.EndDate)
                        If StartDate > EndDate Then Return "End Date must be greater than Start Date"
                    Case NameOf(Task.TaskName)
                        If String.IsNullOrEmpty(TaskName) Then Return "Enter a task name"
                End Select

                Return Nothing
            End Get
        End Property
    End Class

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            grid.ItemsSource = New List(Of Task) From {New Task() With {.TaskName = "Complete Project A", .StartDate = New DateTime(2009, 7, 17), .EndDate = New DateTime(2009, 7, 10)}, New Task() With {.TaskName = "Test Website", .StartDate = New DateTime(2009, 7, 10), .EndDate = New DateTime(2009, 7, 12)}, New Task() With {.TaskName = String.Empty, .StartDate = New DateTime(2009, 7, 4), .EndDate = New DateTime(2009, 7, 6)}}
        End Sub

        Private Sub OnValidateRow(ByVal sender As Object, ByVal e As GridRowValidationEventArgs)
            Dim task = CType(e.Row, Task)
            If task.StartDate > task.EndDate Then e.SetError("Start Date must be less than End Date")
            If String.IsNullOrEmpty(task.TaskName) Then e.SetError("Enter a task name")
        End Sub

        Private Sub OnInvalidRowException(ByVal sender As Object, ByVal e As InvalidRowExceptionEventArgs)
            e.ExceptionMode = ExceptionMode.NoAction
        End Sub
    End Class
End Namespace
