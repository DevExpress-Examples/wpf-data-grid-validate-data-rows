Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Data
Imports DevExpress.XtraEditors.DXErrorProvider

Namespace DXGrid_ValidateRow
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			grid.DataSource = TaskList.GetData()
		End Sub

		Private Sub TableView_ValidateRow(ByVal sender As Object, _
			ByVal e As DevExpress.Xpf.Grid.GridRowValidationEventArgs)
				Dim startDate As DateTime = (CType(e.Row, Task)).StartDate
				Dim endDate As DateTime = (CType(e.Row, Task)).EndDate
				e.IsValid = startDate < endDate
		End Sub

		Private Sub TableView_InvalidRowException(ByVal sender As Object, _
			ByVal e As DevExpress.Xpf.Grid.InvalidRowExceptionEventArgs)
				e.ExceptionMode = DevExpress.Xpf.Grid.ExceptionMode.NoAction
		End Sub
	End Class

	Public Class TaskList
		Public Shared Function GetData() As List(Of Task)
			Dim data As New List(Of Task)()
			data.Add(New Task() With {.TaskName = "Complete Project A", _
				.StartDate = New DateTime(2009, 7, 17), .EndDate = New DateTime(2009, 7, 10)})
			data.Add(New Task() With {.TaskName = "Test Website", _
				.StartDate = New DateTime(2009, 7, 10), .EndDate = New DateTime(2009, 7, 12)})
			data.Add(New Task() With {.TaskName = "Publish Docs", _
				.StartDate = New DateTime(2009, 7, 4), .EndDate = New DateTime(2009, 7, 6)})
			Return data
		End Function
	End Class

	Public Class Task
		Implements IDXDataErrorInfo
		Private privateTaskName As String
		Public Property TaskName() As String
			Get
				Return privateTaskName
			End Get
			Set(ByVal value As String)
				privateTaskName = value
			End Set
		End Property
		Private privateStartDate As DateTime
		Public Property StartDate() As DateTime
			Get
				Return privateStartDate
			End Get
			Set(ByVal value As DateTime)
				privateStartDate = value
			End Set
		End Property
		Private privateEndDate As DateTime
		Public Property EndDate() As DateTime
			Get
				Return privateEndDate
			End Get
			Set(ByVal value As DateTime)
				privateEndDate = value
			End Set
		End Property
		Private Sub GetError(ByVal info As ErrorInfo) Implements IDXDataErrorInfo.GetError
			If StartDate > EndDate Then
				SetErrorInfo(info, _
					"Either StartDate or EndDate should be corrected.", _
					ErrorType.Critical)
			End If
		End Sub
		Private Sub GetPropertyError(ByVal propertyName As String, _
			ByVal info As ErrorInfo) Implements IDXDataErrorInfo.GetPropertyError
				Select Case propertyName
					Case "StartDate"
						If StartDate > EndDate Then
							SetErrorInfo(info, _
								"StartDate must be less than EndDate", _
								ErrorType.Critical)
						End If
					Case "EndDate"
						If StartDate > EndDate Then
							SetErrorInfo(info, _
								"EndDate must be greater than StartDate", _
								ErrorType.Critical)
						End If
					Case "TaskName"
						If IsStringEmpty(TaskName) Then
							SetErrorInfo(info, _
								"Task name hasn't been entered", _
								ErrorType.Information)
						End If
				End Select
		End Sub
		Private Sub SetErrorInfo(ByVal info As ErrorInfo, _
			ByVal errorText As String, _
			ByVal errorType As ErrorType)
				info.ErrorText = errorText
				info.ErrorType = errorType
		End Sub
		Private Function IsStringEmpty(ByVal str As String) As Boolean
			Return (str IsNot Nothing AndAlso str.Trim().Length = 0)
		End Function
	End Class
End Namespace
