Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports DevExpress.Persistent.AuditTrail

Namespace AuditDemo.Module
	<DefaultClassOptions> _
	Public Class Album
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private name_Renamed As String
		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", name_Renamed, value)
			End Set
		End Property
		Private year_Renamed As Integer
		Public Property Year() As Integer
			Get
				Return year_Renamed
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Year", year_Renamed, value)
			End Set
		End Property
		Private artist_Renamed As Artist
		<Association("Artist-Albums")> _
		Public Property Artist() As Artist
			Get
				Return artist_Renamed
			End Get
			Set(ByVal value As Artist)
				SetPropertyValue("Artist", artist_Renamed, value)
			End Set
		End Property
		Private auditTrail_Renamed As XPCollection(Of AuditDataItemPersistent)
		Public ReadOnly Property AuditTrail() As XPCollection(Of AuditDataItemPersistent)
			Get
				If auditTrail_Renamed Is Nothing Then
					auditTrail_Renamed = AuditedObjectWeakReference.GetAuditTrail(Session, Me)
				End If
				Return auditTrail_Renamed
			End Get
		End Property
	End Class
	<DefaultClassOptions> _
	Public Class Artist
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private name_Renamed As String
		Public Property Name() As String
			Get
				Return name_Renamed
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", name_Renamed, value)
			End Set
		End Property
		<Association("Artist-Albums")> _
		Public ReadOnly Property Albums() As XPCollection(Of Album)
			Get
				Return GetCollection(Of Album)("Albums")
			End Get
		End Property
		Private auditTrail_Renamed As XPCollection(Of AuditDataItemPersistent)
		Public ReadOnly Property AuditTrail() As XPCollection(Of AuditDataItemPersistent)
			Get
				If auditTrail_Renamed Is Nothing Then
					auditTrail_Renamed = AuditedObjectWeakReference.GetAuditTrail(Session, Me)
				End If
				Return auditTrail_Renamed
			End Get
		End Property
	End Class
End Namespace
