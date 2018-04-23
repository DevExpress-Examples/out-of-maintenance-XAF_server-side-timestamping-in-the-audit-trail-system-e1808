Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Web
Imports System.Collections
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Namespace TimestampWebService
	<WebService(Namespace := "http://localhost/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1), ToolboxItem(False)> _
	Public Class TimestampService
		Inherits System.Web.Services.WebService
		<WebMethod> _
		Public Function GetTime() As DateTime
			Return DateTime.Now
		End Function
	End Class
End Namespace
