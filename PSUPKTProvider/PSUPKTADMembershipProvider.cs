using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace PSUPKTProvider
{
    class PSUPKTADMembershipProvider : MembershipProvider
    {

        private Model.PSUUserInfo _userInfo;

        public Model.PSUUserInfo UserInfo
        {
            get { return _userInfo; }
            private set { _userInfo = value; }
        }

        private string[] _dn;

        public string[] Dn
        {
            get { return _dn; }
            set { _dn = value; }
        }


        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            if (config["applicationName"] == null || config["applicationName"].Trim() == "")
                ApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
            else
                ApplicationName = config["applicationName"];
        }

        public override string ApplicationName
        {
            get;
            set;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            //Error Endpint when use as Library or Cross Project
            //ValidateWithService(username, password);

            try
            {
                Dn = ValidateWithWebService(username, password);
                if (Dn == null || Dn.Length <= 0)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        internal string[] ValidateWithWebService(string username, string password)
        {

            th.ac.psu.passport.Authentication a = new th.ac.psu.passport.Authentication();
            var result = a.GetUserDetails(username, password);
            return result;
        }

        private bool ValidateWithService(string username, string password)
        {
            /*
           <endpoint address="http://passport.phuket.psu.ac.th/authentication/authentication.asmx"
               binding="basicHttpBinding" bindingConfiguration="AuthenticationSoap"
               contract="PSUPKTPassportService.AuthenticationSoap" name="AuthenticationSoap" />
           */

            PSUPKTPassportService.AuthenticationSoapClient soapClient = new PSUPKTPassportService.AuthenticationSoapClient();

            try
            {
                var userInfo = soapClient.GetUserDetails(username, password);
            }
            catch (Exception ex)
            {
                throw new Exception("exception", ex);
            }
            finally
            {
                Debug.Print("Finally");
            }

            return (UserInfo != null);
        }


    }
}
