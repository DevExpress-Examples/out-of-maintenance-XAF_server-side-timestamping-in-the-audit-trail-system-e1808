Imports Microsoft.VisualBasic
Imports System
Imports System.Data.SqlClient
Imports DevExpress.Xpo
Imports DevExpress.Persistent.AuditTrail

Namespace AuditDemo.Module
	Public Class MSSqlServerTimestampStrategy
		Implements IAuditTimestampStrategy
		Private cachedTimeStamp As DateTime
		#Region "IAuditTimeStampStrategy Members"
		Public Function GetTimestamp(ByVal auditDataItem As AuditDataItem) As DateTime Implements IAuditTimestampStrategy.GetTimestamp
			Return cachedTimeStamp
		End Function
		Public Sub OnBeginSaveTransaction(ByVal session As Session) Implements IAuditTimestampStrategy.OnBeginSaveTransaction
			Dim command As New SqlCommand("select getdate()", CType(session.Connection, SqlConnection))
			cachedTimeStamp = CDate(command.ExecuteScalar())
		End Sub
		#End Region
	End Class
End Namespace
