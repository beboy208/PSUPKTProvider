using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestProvider
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString.Count > 0)
            {
                doSearch(Page.Request.QueryString);
            }
            else
            {

            }
        }

        private void doSearch(System.Collections.Specialized.NameValueCollection nameValueCollection)
        {
            switch (nameValueCollection["type"])
            {

                case "db":
                    if (nameValueCollection["id"] != string.Empty)
                    {
                        //PSUPKTProvider.PSUPKTDBProfileProvider provider = new PSUPKTProvider.PSUPKTDBProfileProvider();
                        //var profile = provider.GetProfile(nameValueCollection["id"]);
                        odsSearchProfileFromDB.Select();
                    }
                    break;
                default:
                    break;
            }
        }


    }
}