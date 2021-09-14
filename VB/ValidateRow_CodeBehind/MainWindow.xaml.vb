Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows

Namespace ValidateRow_CodeBehind
	Public Class Task
		Implements IDataErrorInfo

		Public Property TaskName() As String
		Public Property StartDate() As Date
		Public Property EndDate() As Date

		Private ReadOnly Property IDataErrorInfo_Error() As String Implements IDataErrorInfo.Error
			Get
				Return If(StartDate > EndDate, "Either Start Date or End Date should be corrected.", Nothing)
			End Get
		End Property

		Public ReadOnly Property IDataErrorInfo_Item(ByVal columnName As String) As String Implements IDataErrorInfo.Item
			Get
				Select Case columnName
					Case NameOf(StartDate)
						If StartDate > EndDate Then
						   Return "Start Date must be less than End Date"
						End If
					Case NameOf(EndDate)
						If StartDate > EndDate Then
							Return "End Date must be greater than Start Date"
						End If
					Case NameOf(TaskName)
						If String.IsNullOrEmpty(TaskName) OrElse String.IsNullOrWhiteSpace(TaskName) Then
							Return "Enter a task name"
						End If
				End Select
				Return Nothing
			End Get
		End Property
	End Class
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = GetData().ToList()
		End Sub
		Private Shared Iterator Function GetData() As IEnumerable(Of Task)
			Yield New Task() With {
				.TaskName = "Complete Project A",
				.StartDate = New Date(2009, 7, 17),
				.EndDate = New Date(2009, 7, 10)
			}
			Yield New Task() With {
				.TaskName = "Test Website",
				.StartDate = New Date(2009, 7, 10),
				.EndDate = New Date(2009, 7, 12)
			}
			Yield New Task() With {
				.TaskName = "",
				.StartDate = New Date(2009, 7, 4),
				.EndDate = New Date(2009, 7, 6)
			}
		End Function

		Private Sub OnValidateRow(ByVal sender As Object, ByVal e As GridRowValidationEventArgs)
			Dim task = DirectCast(e.Row, Task)
			If task.StartDate > task.EndDate Then
				e.SetError("Start Date must be less than End Date")
			End If
			If String.IsNullOrEmpty(task.TaskName) OrElse String.IsNullOrWhiteSpace(task.TaskName) Then
				e.SetError("Enter a task name")
			End If
		End Sub

		Private Sub OnInvalidRowException(ByVal sender As Object, ByVal e As InvalidRowExceptionEventArgs)
			e.ExceptionMode = ExceptionMode.NoAction
		End Sub
	End Class
End Namespace
