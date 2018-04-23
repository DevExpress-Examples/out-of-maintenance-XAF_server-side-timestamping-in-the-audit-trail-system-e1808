using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace TimestampWebService {
	[WebService(Namespace = "http://localhost/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[ToolboxItem(false)]
	public class TimestampService : System.Web.Services.WebService {
		[WebMethod]
		public DateTime GetTime() {
			return DateTime.Now;
		}
	}
}
