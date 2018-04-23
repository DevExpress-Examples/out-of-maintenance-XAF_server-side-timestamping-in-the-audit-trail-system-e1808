Imports System
Imports DevExpress.Xpo
Imports DevExpress.Persistent.AuditTrail

Namespace AuditDemo.Module
    Public Class MSSqlServerTimestampStrategy
        Implements IAuditTimestampStrategy
        Private cachedTimeStamp As Date
        #Region "IAuditTimeStampStrategy Members"
        Public Function GetTimestamp(ByVal auditDataItem As AuditDataItem) As DateTime _
        Implements IAuditTimestampStrategy.GetTimestamp
             Return cachedTimestamp
        End Function
        Public Sub OnBeginSaveTransaction(ByVal session As Session) _
        Implements IAuditTimestampStrategy.OnBeginSaveTransaction
            cachedTimeStamp = CDate(session.ExecuteScalar("select getdate()"))
        End Sub
        #End Region
    End Class
End Namespace