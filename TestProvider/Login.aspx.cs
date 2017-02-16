using PSUPKTProvider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestProvider
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login1.Authenticate += Login1_Authenticate;
            Login1.LoggedIn += Login1_LoggedIn;
        }

        void Login1_LoggedIn(object sender, EventArgs e)
        {
            //Get Profile
            var loginObj = (System.Web.UI.WebControls.Login)sender;
            PSUPKTADProfileProvider provider = new PSUPKTADProfileProvider();

            try
            {
                var profile = provider.GetProfile(loginObj.UserName, loginObj.Password);
                Session["Profile"] = profile;
            }
            catch (Exception)
            {

                //throw;
            }            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool IsAuthenticated = false;

            var loginObj = (System.Web.UI.WebControls.Login)sender;
            foreach (MembershipProvider authenProvider in Membership.Providers)
            {
                IsAuthenticated = authenProvider.ValidateUser(loginObj.UserName, loginObj.Password);
                if (IsAuthenticated) break;
            }

            e.Authenticated = IsAuthenticated;
        }


    }
}