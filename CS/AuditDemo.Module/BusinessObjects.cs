using System;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.AuditTrail;

namespace AuditDemo.Module {
	[DefaultClassOptions]
	public class Album : BaseObject {
		public Album(Session session) : base(session) { }
		private string name;
		public string Name {
			get {
				return name;
			}
			set {
				SetPropertyValue("Name", ref name, value);
			}
		}
		private int year;
		public int Year {
			get {
				return year;
			}
			set {
				SetPropertyValue("Year", ref year, value);
			}
		}
		private Artist artist;
		[Association("Artist-Albums")]
		public Artist Artist {
			get {
				return artist;
			}
			set {
				SetPropertyValue("Artist", ref artist, value);
			}
		}
		private XPCollection<AuditDataItemPersistent> auditTrail;
		public XPCollection<AuditDataItemPersistent> AuditTrail {
			get {
				if(auditTrail == null) {
					auditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
				}
				return auditTrail;
			}
		}
	}
	[DefaultClassOptions]
	public class Artist : BaseObject {
		public Artist(Session session) : base(session) { }
		private string name;
		public string Name {
			get {
				return name;
			}
			set {
				SetPropertyValue("Name", ref name, value);
			}
		}
		[Association("Artist-Albums")]
		public XPCollection<Album> Albums {
			get {
				return GetCollection<Album>("Albums");
			}
		}
		private XPCollection<AuditDataItemPersistent> auditTrail;
		public XPCollection<AuditDataItemPersistent> AuditTrail {
			get {
				if(auditTrail == null) {
					auditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
				}
				return auditTrail;
			}
		}
	}
}
