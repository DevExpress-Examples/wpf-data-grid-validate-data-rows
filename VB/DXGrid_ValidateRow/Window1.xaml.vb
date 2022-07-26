Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Grid
Imports DevExpress.XtraEditors.DXErrorProvider

Namespace DXGrid_ValidateRow

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = TaskList.GetData()
        End Sub

        Private Sub TableView_ValidateRow(ByVal sender As Object, ByVal e As GridRowValidationEventArgs)
            Dim startDate As Date = CType(e.Row, Task).StartDate
            Dim endDate As Date = CType(e.Row, Task).EndDate
            e.IsValid = startDate < endDate
        End Sub

        Private Sub TableView_InvalidRowException(ByVal sender As Object, ByVal e As InvalidRowExceptionEventArgs)
            e.ExceptionMode = ExceptionMode.NoAction
        End Sub
    End Class

    Public Class TaskList

        Public Shared Function GetData() As List(Of Task)
            Dim data As List(Of Task) = New List(Of Task)()
            data.Add(New Task() With {.TaskName = "Complete Project A", .StartDate = New DateTime(2009, 7, 17), .EndDate = New DateTime(2009, 7, 10)})
            data.Add(New Task() With {.TaskName = "Test Website", .StartDate = New DateTime(2009, 7, 10), .EndDate = New DateTime(2009, 7, 12)})
            data.Add(New Task() With {.TaskName = "Publish Docs", .StartDate = New DateTime(2009, 7, 4), .EndDate = New DateTime(2009, 7, 6)})
            Return data
        End Function
    End Class

    Public Class Task
        Implements IDXDataErrorInfo

        Public Property TaskName As String

        Public Property StartDate As Date

        Public Property EndDate As Date

        Private Sub GetError(ByVal info As ErrorInfo) Implements IDXDataErrorInfo.GetError
            If StartDate > EndDate Then
                SetErrorInfo(info, "Either StartDate or EndDate should be corrected.", ErrorType.Critical)
            End If
        End Sub

        Private Sub GetPropertyError(ByVal propertyName As String, ByVal info As ErrorInfo) Implements IDXDataErrorInfo.GetPropertyError
            Select Case propertyName
                Case "StartDate"
                    If StartDate > EndDate Then SetErrorInfo(info, "StartDate must be less than EndDate", ErrorType.Critical)
                Case "EndDate"
                    If StartDate > EndDate Then SetErrorInfo(info, "EndDate must be greater than StartDate", ErrorType.Critical)
                Case "TaskName"
                    If IsStringEmpty(TaskName) Then SetErrorInfo(info, "Task name hasn't been entered", ErrorType.Information)
            End Select
        End Sub

        Private Sub SetErrorInfo(ByVal info As ErrorInfo, ByVal errorText As String, ByVal errorType As ErrorType)
            info.ErrorText = errorText
            info.ErrorType = errorType
        End Sub

        Private Function IsStringEmpty(ByVal str As String) As Boolean
            Return(Not Equals(str, Nothing) AndAlso str.Trim().Length = 0)
        End Function
    End Class
End Namespace
