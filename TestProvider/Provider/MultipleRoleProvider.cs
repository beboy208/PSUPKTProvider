using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Windows;

namespace TestProvider.Provider
{
    public class MultipleRoleProviderManager : RoleProvider
    {
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            if (config["applicationName"] == null || config["applicationName"].Trim() == "")
                ApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
            else
                ApplicationName = config["applicationName"];
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get;
            set;
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            List<string> roles = new List<string>();

            #region Method1
            //if (Roles.Providers.Count > 1)
            //{
            //    var providers = Roles.Providers.GetEnumerator();

            //    while (providers.MoveNext()) //การ MoveNext จะเริ่มจากรายการสุดท้าย ไปรายการแรก
            //    {
            //        var current_provider = (RoleProvider)providers.Current;

            //        if (current_provider != this) //ที่ไม่ใช่ตัวเอง
            //        {
            //            roles.AddRange(current_provider.GetRolesForUser(username));
            //        }
            //    }
            //}
            #endregion Method1

            #region Method2
            var providers = Roles.Providers;

            if (providers.Count > 1)
            {
                foreach (var p in providers)
                {
                    if (p != this)
                    {
                        roles.AddRange(((RoleProvider)p).GetRolesForUser(username));
                    }
                }
            }
            #endregion Method2

            return roles.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}