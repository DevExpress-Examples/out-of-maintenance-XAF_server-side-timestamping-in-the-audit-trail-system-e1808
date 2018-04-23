using System;
using DevExpress.Persistent.AuditTrail;
using DevExpress.Xpo;
using AuditDemo.Module.TimestampWebService;

namespace AuditDemo.Module {
	public class WebServiceTimestampStrategy : IAuditTimestampStrategy {
		DateTime cachedTimeStamp;
		#region IAuditTimeStampStrategy Members
		public DateTime GetTimestamp(AuditDataItem auditDataItem) {
			return cachedTimeStamp;
		}
		public void OnBeginSaveTransaction(Session session) {
			try {
				TimestampService service = new TimestampService();
				cachedTimeStamp = service.GetTime();
			}
			catch {
                throw new Exception("Cannot access the TimeStampWebService. Make sure it's running.");
			}
		}
		#endregion
	}
}
