Imports System
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Xpo
Imports DevExpress.Persistent.AuditTrail

Namespace AuditDemo.Module
	<DefaultClassOptions>
	Public Class Album
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
'INSTANT VB NOTE: The field name was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private name_Conflict As String
		Public Property Name() As String
			Get
				Return name_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", name_Conflict, value)
			End Set
		End Property
'INSTANT VB NOTE: The field year was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private year_Conflict As Integer
		Public Property Year() As Integer
			Get
				Return year_Conflict
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Year", year_Conflict, value)
			End Set
		End Property
'INSTANT VB NOTE: The field artist was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private artist_Conflict As Artist
		<Association("Artist-Albums")>
		Public Property Artist() As Artist
			Get
				Return artist_Conflict
			End Get
			Set(ByVal value As Artist)
				SetPropertyValue("Artist", artist_Conflict, value)
			End Set
		End Property
'INSTANT VB NOTE: The field auditTrail was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private auditTrail_Conflict As XPCollection(Of AuditDataItemPersistent)
		Public ReadOnly Property AuditTrail() As XPCollection(Of AuditDataItemPersistent)
			Get
				If auditTrail_Conflict Is Nothing Then
					auditTrail_Conflict = AuditedObjectWeakReference.GetAuditTrail(Session, Me)
				End If
				Return auditTrail_Conflict
			End Get
		End Property
	End Class
	<DefaultClassOptions>
	Public Class Artist
		Inherits BaseObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
'INSTANT VB NOTE: The field name was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private name_Conflict As String
		Public Property Name() As String
			Get
				Return name_Conflict
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", name_Conflict, value)
			End Set
		End Property
		<Association("Artist-Albums")>
		Public ReadOnly Property Albums() As XPCollection(Of Album)
			Get
				Return GetCollection(Of Album)("Albums")
			End Get
		End Property
'INSTANT VB NOTE: The field auditTrail was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private auditTrail_Conflict As XPCollection(Of AuditDataItemPersistent)
		Public ReadOnly Property AuditTrail() As XPCollection(Of AuditDataItemPersistent)
			Get
				If auditTrail_Conflict Is Nothing Then
					auditTrail_Conflict = AuditedObjectWeakReference.GetAuditTrail(Session, Me)
				End If
				Return auditTrail_Conflict
			End Get
		End Property
	End Class
End Namespace
