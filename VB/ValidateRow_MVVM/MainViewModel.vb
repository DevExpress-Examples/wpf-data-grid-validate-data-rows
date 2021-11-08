Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace ValidateRow_MVVM

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

    Public Class MainViewModel
        Inherits ViewModelBase

        Public ReadOnly Property TaskList As List(Of Task)

        Public Sub New()
            TaskList = New List(Of Task) From {New Task() With {.TaskName = "Complete Project A", .StartDate = New DateTime(2009, 7, 17), .EndDate = New DateTime(2009, 7, 10)}, New Task() With {.TaskName = "Test Website", .StartDate = New DateTime(2009, 7, 10), .EndDate = New DateTime(2009, 7, 12)}, New Task() With {.TaskName = String.Empty, .StartDate = New DateTime(2009, 7, 4), .EndDate = New DateTime(2009, 7, 6)}}
        End Sub

        <Command>
        Public Sub ValidateRow(ByVal args As RowValidationArgs)
            args.Result = MainViewModel.GetValidationErrorInfo(CType(args.Item, Task))
        End Sub

        Private Shared Function GetValidationErrorInfo(ByVal task As Task) As ValidationErrorInfo
            If task.StartDate > task.EndDate Then Return New ValidationErrorInfo("Start Date must be less than End Date")
            If String.IsNullOrEmpty(task.TaskName) Then Return New ValidationErrorInfo("Enter a task name")
            Return Nothing
        End Function

        <Command>
        Public Sub InvalidRow(ByVal args As InvalidRowExceptionArgs)
            args.ExceptionMode = ExceptionMode.NoAction
        End Sub
    End Class
End Namespace
