Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Persistent.AuditTrail
Imports DevExpress.Xpo

Namespace AuditDemo.Module
	Public Class WebServiceTimestampStrategy
		Implements IAuditTimestampStrategy
		Private cachedTimeStamp As DateTime
		#Region "IAuditTimeStampStrategy Members"
		Public Function GetTimestamp(ByVal auditDataItem As AuditDataItem) As DateTime Implements IAuditTimestampStrategy.GetTimestamp
			Return cachedTimeStamp
		End Function
		Public Sub OnBeginSaveTransaction(ByVal session As Session) Implements IAuditTimestampStrategy.OnBeginSaveTransaction
			Try
                Dim service As New TimestampWebService.TimestampService()
				cachedTimeStamp = service.GetTime()
			Catch
                Throw New Exception("Cannot access the TimeStampWebService. Make sure it's running.")
			End Try
		End Sub
		#End Region
	End Class
End Namespace
