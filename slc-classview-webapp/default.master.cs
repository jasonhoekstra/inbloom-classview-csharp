using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SLC_Classview_CSharp
{
    public partial class default_master : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e) {
            if (Session["access_token"] == null) {
                Response.Redirect("default.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}