using System;
using System.Data.SqlClient;
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
			SqlCommand command = new SqlCommand("select getdate()", (SqlConnection)session.Connection);
			cachedTimeStamp = (DateTime)command.ExecuteScalar();
		}
		#endregion
	}
}
