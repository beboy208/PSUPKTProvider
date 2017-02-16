using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace PSUPKTProvider
{
    public class PSUPKTRoleProvider : RoleProvider
    {
        public PSUPKTRoleProvider()
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

        
        //http://www.newtonsoft.com/json/help/html/SerializingJSON.htm
        /// <summary>
        ///  PSU PKT Role Provider มีข้อมูลทั้งที่เป็นภาษาอังกฤษ และ ภาษาไทย 
        ///  แต่ Base.RoleProvider กำหนดให้ส่งข้อมูลเป็นแบบ String
        ///  เพื่อให้ง่ายต่อการใช้งาน จึงกำหนดให้ ส่งผลลัพธ์ เฉพาะชื่อ Role ที่เป็นภาษาอังกฤษ
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public override string[] GetRolesForUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ProviderException("User name cannot be empty or null.");

            string applicationID = ApplicationName;
            string serviceURL = "http://api.phuket.psu.ac.th/roleprovider/service/getroles/{0}/{1}";
            string uri = string.Format(serviceURL, applicationID, username);
            string jsonRaw;
            Model.JsonPSUPKTRoleResult resultValue = null;

            WebClient client = new WebClient();
            try
            {
                jsonRaw = client.DownloadString(uri);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot connect to PSU Phuket Role Provider.", ex);
            }

            try
            {
                resultValue = JsonConvert.DeserializeObject<Model.JsonPSUPKTRoleResult>(jsonRaw);
            }
            catch (Exception ex)
            {
                throw new Exception("Host not allowed to connect to the Provider", ex);
            }
            
            
            if (resultValue != null)
            {
                var roles = resultValue.result.ToList().Select(r => r.role_name_eng).ToArray();
                return roles;
            }
            
            return new string[] {};
        }

        /// <summary>
        /// PSU PKT Role Provider มีข้อมูลทั้งที่เป็นภาษาอังกฤษ และ ภาษาไทย การตรวจหาว่าใครเป็นสมาชิกใน Role ใด
        /// จึงให้ทำผ่าน ID ที่ได้ตกลงกับทาง PSU PKT Role Manager
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public override string[] GetUsersInRole(string roleID)
        {
            if (string.IsNullOrWhiteSpace(roleID))
                throw new ProviderException("Role ID cannot be empty or null.");

            string applicationID = ApplicationName;
            string serviceURL = "http://api.phuket.psu.ac.th/roleprovider/service/getuserrole/{0}/{1}";
            string uri = string.Format(serviceURL, applicationID, roleID);
            string jsonRaw;
            Model.JsonPSUPKTPassportResult resultValue = null;

            WebClient client = new WebClient();
            try
            {
                jsonRaw = client.DownloadString(uri);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot connect to PSU Phuket Role Provider.", ex);
            }

            try
            {
                resultValue = JsonConvert.DeserializeObject<Model.JsonPSUPKTPassportResult>(jsonRaw);
            }
            catch (Exception ex)
            {
                throw new Exception("Host not allowed to connect to the Provider", ex);
            }


            if (resultValue != null)
            {
                var roles = resultValue.result.ToList().Select(x => x.username).ToArray();
                return roles;
            }

            return new string[] { };
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
            //if (username == null || username == "")
            //    throw new ProviderException("User name cannot be empty or null.");
            //if (rolename == null || rolename == "")
            //    throw new ProviderException("Role name cannot be empty or null.");

            //return true;
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
