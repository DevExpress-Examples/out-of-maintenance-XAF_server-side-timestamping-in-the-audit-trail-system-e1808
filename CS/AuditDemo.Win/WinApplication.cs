using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.ExpressApp.Win;

namespace AuditDemo.Win
{
	public partial class AuditDemoWindowsFormsApplication : WinApplication {
		public AuditDemoWindowsFormsApplication() {
			InitializeComponent();
		}

		private void AuditDemoWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {
			//if(System.Diagnostics.Debugger.IsAttached) {
				e.Updater.Update();
				e.Handled = true;
			//}
		}
	}
}
