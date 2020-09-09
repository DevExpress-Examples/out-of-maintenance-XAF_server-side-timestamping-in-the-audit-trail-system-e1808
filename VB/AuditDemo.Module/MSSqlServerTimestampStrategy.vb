Imports System
Imports DevExpress.Xpo
Imports DevExpress.Persistent.AuditTrail

Namespace AuditDemo.Module
	Public Class MSSqlServerTimestampStrategy
		Implements IAuditTimestampStrategy

		Private cachedTimeStamp As DateTime
		#Region "IAuditTimeStampStrategy Members"
		Public Function GetTimestamp(ByVal auditDataItem As AuditDataItem) As DateTime
			Return cachedTimeStamp
		End Function
		Public Sub OnBeginSaveTransaction(ByVal session As Session)
			cachedTimeStamp = DirectCast(session.ExecuteScalar("select getdate()"), DateTime)
		End Sub
		#End Region
	End Class
End Namespace
