using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;

using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SLCApiLibrary;

namespace SLC_Classview_CSharp
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            // Do we have a valid access token in session?  If yes, let's make an API call.
            if (Session["access_token"] != null) {
                JArray students = GetStudents();
                if (students != null) {
                    studentGridView.DataSource = students;
                    studentGridView.DataBind();
                }
            } else {
                Response.Redirect("default.aspx");
            }

        }

        private JArray GetStudents() {
            string apiEndPoint = string.Format("https://api.sandbox.slcedu.org/api/rest/v1/sections/{0}/studentSectionAssociations/students", Request.QueryString["id"]);
            APIResponse request = APIClient.Request(apiEndPoint, Session["access_token"].ToString(), SLCApiLibrary.RequestType.JSONObject);

            JArray students = null;

            if (request.ResponseObject == null)
                Response.Write(request.ErrorMessage);
            else
                students = request.ResponseObject;
            
            return students;
        }

        private XmlDocument GetStudentsXmlDocument() {
            string apiEndPoint = string.Format("https://api.sandbox.slcedu.org/api/rest/v1/sections/{0}/studentSectionAssociations/students", Request.QueryString["id"]);
            APIResponse request = APIClient.Request(apiEndPoint, Session["access_token"].ToString(), SLCApiLibrary.RequestType.XML);

            string studentsReturn = null;

            if (request.ResponseObject == null)
                Response.Write(request.ErrorMessage);
            else
                studentsReturn = request.ResponseString;

            XmlDocument students = new XmlDocument();

            try {
                students.LoadXml(studentsReturn);
            } catch (Exception ex) {
                Response.Write(ex.ToString());
            }

            return students;
        }




    }
}