using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SLCApiLibrary;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SLC_Classview_CSharp
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            // Do we have a valid access token in session?  If yes, let's make an API call.
            if (Session["access_token"] != null) {
                JArray student = GetStudent();
                if (student != null) {
                    studentDetailView.DataSource = student;
                    studentDetailView.DataBind();
                }
            } else {
                Response.Redirect("default.aspx");
            }

        }

        private JArray GetStudent() {
            string apiEndPoint = string.Format("https://api.sandbox.slcedu.org/api/rest/v1/students/{0}", Request.QueryString["id"]);
            APIResponse request = APIClient.Request(apiEndPoint, Session["access_token"].ToString(), SLCApiLibrary.RequestType.JSONObject);

            JArray student = null;

            if (request.ResponseObject == null)
                Response.Write(request.ErrorMessage);
            else
                student = request.ResponseObject;

            return student;
        }

        //private JArray GetStudentCustomData() {
        //    string apiEndPoint = string.Format("https://api.sandbox.slcedu.org/api/rest/v1/students/{0}/custom", Request.QueryString["id"]);
        //    APIResponse request = APIClient.Request(apiEndPoint, Session["access_token"].ToString(), SLCApiLibrary.RequestType.JSONObject);

        //    JArray student = null;

        //    if (request.ResponseObject == null)
        //        Response.Write(request.ErrorMessage);
        //    else
        //        student = request.ResponseObject;

        //    return student;
        //}

        protected void saveButton_Click(object sender, EventArgs e) {

        }
    }
}