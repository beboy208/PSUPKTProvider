using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Profile;

namespace PSUPKTProvider.Archive
{
    public class PSUPKTADProfileProvider : ProfileProvider
    {
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            if (config["applicationName"] == null || config["applicationName"].Trim() == "")
                ApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
            else
                ApplicationName = config["applicationName"];
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(string[] usernames)
        {
            throw new NotImplementedException();
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get;
            set;
        }


        public override System.Configuration.SettingsPropertyValueCollection GetPropertyValues(System.Configuration.SettingsContext context, System.Configuration.SettingsPropertyCollection collection)
        {

            throw new Exception("Cannot get user profile from PSU Passport because of no password");

            /* 
             * https://msdn.microsoft.com/en-us/library/aa479025.aspx
             * The context parameter passed to GetPropertyValues is a dictionary of key/value pairs containing information about the context 
             * in which GetPropertyValues was called. It contains the following keys:
             * 1. UserName—User name or user ID of the profile to read
             * 2. IsAuthenticated—Indicates whether the requestor is authenticated
             */
            string userName = (string)context["UserName"];
            bool isAuthenticated = (bool)context["IsAuthenticated"];

            string connectionStringName = "LDAP://dc.phuket.psu.ac.th/dc=psu,dc=ac,dc=th";
            //string domain = "psu\\";
            //string attributeMapUsername = "sAMAccountName";
            //AuthenticationTypes connectionProtection = AuthenticationTypes.None;


            DirectoryEntry root = new DirectoryEntry(connectionStringName);
            DirectorySearcher searcher = new DirectorySearcher(root);
            searcher.Filter = "&(objectClass=user)";
            // SearchResult result = searcher.FindOne(); 




            SettingsPropertyValueCollection svc = new SettingsPropertyValueCollection();
            foreach (SettingsProperty prop in collection)
            {
                SettingsPropertyValue pv = new SettingsPropertyValue(prop);

                if (prop.PropertyType == typeof(Model.PSUUserInfo))
                {
                    //Get UserDetails from PSU Passport Service


                    pv.PropertyValue = new Model.PSUUserInfo("Uname")
                    {
                        FirstName = "F1",
                        LastName = "L1",
                        StaffCode = "Code1"
                    };

                    svc.Add(pv);
                }
                else
                {
                    throw new ProviderException("Unsupported Property.");
                }
            }

            UpdateActivityDates(Name, true, true);

            return svc;
        }


        public override void SetPropertyValues(System.Configuration.SettingsContext context, System.Configuration.SettingsPropertyValueCollection collection)
        {
            //do notting, we cannot write properties to PSU Passport Service
        }

        // เลียนแบบจากบทความ Profile Provider Implementation Example
        // https://msdn.microsoft.com/en-us/library/ta63b872(v=vs.140).aspx

        private void UpdateActivityDates(string name, bool isAuthenticated, bool activityOnly)
        {
            //do notting
        }

    }
}
