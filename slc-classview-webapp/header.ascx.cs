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
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) {
            userFullName.Text = Session["user_FullName"].ToString();
            userRoles.Text = Session["user_SLIRoles"].ToString();
        }
    }
}