using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.AuditTrail;
using System.Security.Principal;
using AuditDemo.Module;

namespace AuditDemo.Win
{
	static class Program {
		//private static void WinApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs args) {
		//    args.Updater.Update();
		//    args.Handled = true;
		//}
		///// <summary>
		///// The main entry point for the application.
		///// </summary>
		[STAThread]
		static void Main() {

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
			AuditDemoWindowsFormsApplication application = new AuditDemoWindowsFormsApplication();
			if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
				application.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
			try {
				//default time stamping strategy 
				IAuditTimestampStrategy timestampStrategy = new LocalAuditTimestampStrategy();

				//////////////////////////////////////////////////////////////////
				//You can use server-side time stamping for audit log
				//////////////////////////////////////////////////////////////////

				//Uncomment statement below to use WebService time stamps
				//	IAuditTimestampStrategy timestampStrategy = new WebServiceTimestampStrategy();

				//Uncomment statement below to use MSSqlServer time stamps
				//	IAuditTimestampStrategy timestampStrategy = new MSSqlServerTimestampStrategy();

				AuditTrailService.Instance.TimestampStrategy = timestampStrategy;
				AuditTrailService.Instance.QueryCurrentUserName += new QueryCurrentUserNameEventHandler(Instance_QueryCurrentUserName);
				application.Setup();
				application.Start();
			}
			catch (Exception e) {
				application.HandleException(e);
			}
		}
		private static void Instance_QueryCurrentUserName(object sender, QueryCurrentUserNameEventArgs e) {
			e.CurrentUserName = WindowsIdentity.GetCurrent().Name;
		}
	}
}
