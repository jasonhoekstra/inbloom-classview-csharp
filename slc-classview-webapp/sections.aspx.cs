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
            Response.Write("here!");
            // Do we have a valid access token in session?  If yes, let's make an API call.
            if (Session["access_token"] != null)
            {
                string apiEndPoint = "https://api.sandbox.slcedu.org/api/rest/v1/sections";

                APIResponse apiResponse = APIClient.Request(apiEndPoint, Session["access_token"].ToString(), RequestType.JSONObject);
                APIResponse apiStringResponse = APIClient.Request(apiEndPoint, Session["access_token"].ToString(), RequestType.JSON);

                sectionsGridView.DataSource = apiResponse.ResponseObject;
                sectionsGridView.DataBind();
            }
        }
    }
}