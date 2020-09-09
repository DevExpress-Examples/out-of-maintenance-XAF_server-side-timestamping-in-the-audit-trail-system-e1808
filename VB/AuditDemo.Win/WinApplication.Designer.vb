Namespace AuditDemo.Win
	Partial Public Class AuditDemoWindowsFormsApplication
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
			Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
			Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
			Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
			Me.auditTrailModule1 = New DevExpress.ExpressApp.AuditTrail.AuditTrailModule()
			Me.module3 = New AuditDemo.Module.AuditDemoModule()
			DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			' 
			' sqlConnection1
			' 
			Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=AuditDemo;Integrated Security=SSPI;Pooling=fa" & "lse"
			Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
			' 
			' AuditDemoWindowsFormsApplication
			' 
			Me.ApplicationName = "AuditDemo"
			Me.Connection = Me.sqlConnection1
			Me.Modules.Add(Me.module1)
			Me.Modules.Add(Me.module2)
			Me.Modules.Add(Me.module3)
			Me.Modules.Add(Me.module6)
			Me.Modules.Add(Me.auditTrailModule1)
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.AuditDemoWindowsFormsApplication_DatabaseVersionMismatch);
			DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

		#End Region

		Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
		Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
		Private module3 As AuditDemo.Module.AuditDemoModule
		Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
		Private sqlConnection1 As System.Data.SqlClient.SqlConnection
		Private auditTrailModule1 As DevExpress.ExpressApp.AuditTrail.AuditTrailModule
	End Class
End Namespace
