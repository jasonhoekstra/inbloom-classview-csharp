using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SLC_Classview_CSharp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string clientId = ConfigurationManager.AppSettings["clientId"];
            string clientSecret = ConfigurationManager.AppSettings["clientSecret"];
            string redirectUri = ConfigurationManager.AppSettings["redirectUri"];
            
            // We need an access token to call the API.  If we don't have one, let's get it, otherwise, redirect to main.aspx.
            if (Session["access_token"] == null)
            {
                // We get a code back from the first leg of OAuth process.  If we don't have one, let's get it.
                if (Request.QueryString["code"] == null)
                {
                    // Here the user will log into the SLC.  This page (start.aspx) will be called back with the code to do second leg of OAuth.
                    string authorizeUrl = string.Format("https://api.sandbox.slcedu.org/api/oauth/authorize?client_id={0}&redirect_uri={1}", clientId, redirectUri);
                    Response.Redirect(authorizeUrl);
                }
                else
                {
                    // Now we have a code, we can run the second leg of OAuth process.
                    string code = Request.QueryString["code"];

                    // Set the authorization URL
                    string sessionUrl = string.Format("https://api.sandbox.slcedu.org/api/oauth/token?client_id={0}&client_secret={1}&grant_type=authorization_code&redirect_uri={2}&code={3}", clientId, clientSecret, redirectUri, code);

                    WebClient restClient = new WebClient();

                    restClient.Headers.Add("Content-Type", "application/vnd.slc+json");
                    restClient.Headers.Add("Accept", "application/vnd.slc+json");

                    // Call authorization endpoint
                    string result = restClient.DownloadString(sessionUrl);

                    // Convert response into a JSON object
                    JObject response = JObject.Parse(result);
                    string access_token = (string) response["access_token"];

                    // If we have a valid token, it'll be 38 chars long.  Let's add it to session if so.
                    if (access_token.Length == 38) {
                        Session.Add("access_token", access_token);

                        // Redirect to app main page.
                        Response.Redirect("sections.aspx");
                    }
                }
            } else {
                // We have an access token in session, let's redirect to app main page.
                Response.Redirect("sections.aspx");
            }
        }
    }
}