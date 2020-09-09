Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.AuditTrail
Imports System.Security.Principal
Imports AuditDemo.Module

Namespace AuditDemo.Win
	Friend Module Program
		'private static void WinApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs args) {
		'    args.Updater.Update();
		'    args.Handled = true;
		'}
		'/// <summary>
		'/// The main entry point for the application.
		'/// </summary>
		<STAThread>
		Sub Main()

			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
			Dim application As New AuditDemoWindowsFormsApplication()
			If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
				application.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
			End If
			Try
				'default time stamping strategy 
				Dim timestampStrategy As IAuditTimestampStrategy = New LocalAuditTimestampStrategy()

				'////////////////////////////////////////////////////////////////
				'You can use server-side time stamping for audit log
				'////////////////////////////////////////////////////////////////

				'Uncomment statement below to use WebService time stamps
				'	IAuditTimestampStrategy timestampStrategy = new WebServiceTimestampStrategy();

				'Uncomment statement below to use MSSqlServer time stamps
				'	IAuditTimestampStrategy timestampStrategy = new MSSqlServerTimestampStrategy();

				AuditTrailService.Instance.TimestampStrategy = timestampStrategy
				AddHandler AuditTrailService.Instance.QueryCurrentUserName, AddressOf Instance_QueryCurrentUserName
	DevExpress.ExpressApp.Xpo.InMemoryDataStoreProvider.Register()
					application.ConnectionString = DevExpress.ExpressApp.Xpo.InMemoryDataStoreProvider.ConnectionString
				application.Setup()
				application.Start()
			Catch e As Exception
				application.HandleException(e)
			End Try
		End Sub
		Private Sub Instance_QueryCurrentUserName(ByVal sender As Object, ByVal e As QueryCurrentUserNameEventArgs)
			e.CurrentUserName = WindowsIdentity.GetCurrent().Name
		End Sub
	End Module
End Namespace
