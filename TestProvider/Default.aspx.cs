using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestProvider
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

    
        protected void btnSearchDB_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(string.Format("~/UserProfile.aspx?type={0}&id={1}", "db", txtDBUserName.Text));
        }

    }
}