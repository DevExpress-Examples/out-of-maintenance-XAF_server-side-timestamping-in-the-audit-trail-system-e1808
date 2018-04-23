using System;
using DevExpress.Xpo;
using DevExpress.Persistent.AuditTrail;

namespace AuditDemo.Module {
	public class MSSqlServerTimestampStrategy : IAuditTimestampStrategy{
		DateTime cachedTimeStamp;
		#region IAuditTimeStampStrategy Members
		public DateTime GetTimestamp(AuditDataItem auditDataItem) {
			return cachedTimeStamp;
		}
		public void OnBeginSaveTransaction(Session session) {
            cachedTimeStamp = (DateTime)session.ExecuteScalar("select getdate()");
		}
		#endregion
	}
}
