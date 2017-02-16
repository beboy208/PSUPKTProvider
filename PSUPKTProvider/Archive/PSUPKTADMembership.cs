using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;


namespace PSUPKTProvider.Archive
{
    public class PSUPKTADMembership: MembershipProvider
    {
        public PSUPKTADMembership()
        {

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
            return ValidateWithPSUAD(username, password);
        }

        private bool ValidateWithPSUAD(string username, string password)
        {
            bool IsAuthendicated = false;
            string connectionStringName = "LDAP://dc.phuket.psu.ac.th/dc=psu,dc=ac,dc=th";
            string domain = "psu\\";
            string attributeMapUsername = "sAMAccountName";
            AuthenticationTypes connectionProtection = AuthenticationTypes.None;

            //try
            //{
            //    if (System.Configuration.ConfigurationManager.ConnectionStrings["ADConnectionString"] != null)
            //        connectionStringName = System.Configuration.ConfigurationManager.ConnectionStrings["ADConnectionString"].ConnectionString;

            //}
            //catch (Exception)
            //{
            //    //do noting
            //}

            DirectoryEntry root = new DirectoryEntry(connectionStringName, domain + username, password, connectionProtection);
            //return root.NativeObject != null;  //แบบนี้ก็ใช้ได้นะ

            /*
             * DirectorySearcher Class (.net 4.5)
             * https://msdn.microsoft.com/en-us/library/system.directoryservices.directorysearcher%28v=vs.110%29.aspx
             * Performs queries against Active Directory Domain Services
             * 
             * 6 Constructors
             * 
             * DirectorySearcher() - Initializes a new instance of the DirectorySearcher class with default values.
             * DirectorySearcher(DirectoryEntry) - Initializes a new instance of the DirectorySearcher class using the specified search root.
             * DirectorySearcher(DirectoryEntry, String Filter) - Initializes a new instance of the DirectorySearcher class with the specified search root and search filter.
             * 
             * The String Filter is The search filter string in Lightweight Directory Access Protocol (LDAP) format. The Filter property is initialized to this value.
             */

            DirectorySearcher searcher = new DirectorySearcher(root, string.Format("({0} = {1})", attributeMapUsername, username)); // "(sAMAccountName=" + username + ")");
            searcher.CacheResults = true; //Cache the search results on the local computer
            //searcher.SizeLimit = 1; //Specify the maximum number of entries to return

            try
            {
                //searcher.PropertiesToLoad.Add("cn");
                //searcher.PropertiesToLoad.Add("ou");
                //searcher.PropertiesToLoad.Add("dc");
                SearchResult result = searcher.FindOne();  //If authentication failed, Exception occured. Executes the search and returns only the first entry that is found.
                IsAuthendicated = true;

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                IsAuthendicated = false;
            }

            return IsAuthendicated;
        }
    }
}