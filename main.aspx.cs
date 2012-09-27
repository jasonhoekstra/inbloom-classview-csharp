using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SLC_Classview_CSharp
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Do we have a valid access token in session?  If yes, let's make an API call.
            if (Session["access_token"] != null)
            {
                string apiEndPoint = "https://api.sandbox.slcedu.org/api/rest/v1/students";

                WebClient restClient = new WebClient();

                string bearerToken = string.Format("bearer {0}", Session["access_token"]);

                restClient.Headers.Add("Authorization", bearerToken);
                restClient.Headers.Add("Content-Type", "application/vnd.slc+json");
                restClient.Headers.Add("Accept", "application/vnd.slc+json");

                string result = restClient.DownloadString(apiEndPoint);

                JArray response = JArray.Parse(result);

                for (int index = 0; index < response.Count(); index++)
                {
                    JToken token = response[index];
                    Response.Write(token["name"]["firstName"].ToString() + " " + token["name"]["lastSurname"].ToString());
                    Response.Write("<br/>");
                }

                Response.Write("<br/><br/><h1>Full JSON Response</h1><br/><br/>");
                Response.Write(result);

            }
        }
    }
}