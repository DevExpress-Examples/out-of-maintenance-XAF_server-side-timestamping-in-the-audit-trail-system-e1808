Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Win

Namespace AuditDemo.Win
	Partial Public Class AuditDemoWindowsFormsApplication
		Inherits WinApplication

		Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
			args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection)
		End Sub
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub AuditDemoWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles Me.DatabaseVersionMismatch
			'if(System.Diagnostics.Debugger.IsAttached) {
				e.Updater.Update()
				e.Handled = True
			'}
		End Sub
	End Class
End Namespace
