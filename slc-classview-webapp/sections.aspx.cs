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
    public partial class sections : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            string apiEndPoint = String.Format("https://api.sandbox.slcedu.org/api/rest/v1/teachers/{0}/teacherSectionAssociations/sections", Session["user_ID"].ToString());

            APIResponse apiResponse = APIClient.Request(apiEndPoint, Session["access_token"].ToString(), RequestType.JSONObject);
            sectionsGridView.DataSource = apiResponse.ResponseObject;
            sectionsGridView.DataBind();
        }
    }
}