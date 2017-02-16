using PSUPKTProvider.Model;
using System;
using System.Web;
using System.Web.Profile;

namespace PSUPKTProvider
{

    /*
     * Learning from
     * http://willmtz.blogspot.com/search?updated-max=2011-09-24T07:48:00-07:00&max-results=5
     * https://msdn.microsoft.com/en-us/library/d8b58y5d(v=vs.140).aspx
     * 
     * This class is inherited from the ProfileBase class and will be used to expose the profile functionality on other pages in the site.
     */

    public class PSUPKTADProfileProvider : IUserProfileProvider<PSUUserInfo> //ProfileBase
    {
        public PSUUserInfo GetProfile(string username)
        {
            throw new NotSupportedException("Please user function GetProfile(username, password).");
        }

        public PSUUserInfo GetProfile(string username, string password)
        {
            try
            {
                var dn = this.GetResultFromPSUPassport(username, password);
                if (dn == null || dn.Length <= 0)
                    throw new Exception("No user details from PSU Passport.");
                return Model.PSUUserInfo.CreateByADUserDetails(dn, false);
            }
            catch (Exception ex)
            {
                throw new Exception("GetProfile", ex);
            }
        }

        private string[] GetResultFromPSUPassport(string username, string password)
        {
            try
            {
                th.ac.psu.passport.Authentication a = new th.ac.psu.passport.Authentication();
                return a.GetUserDetails(username, password);
            }
            catch (System.Exception ex)
            {
                throw new Exception("GetPSUPassport", ex);
            }
        }

        //public System.Collections.Generic.IEnumerable<PSUUserInfo> GetProfiles()
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Collections.Generic.IEnumerable<PSUUserInfo> GetProfileByFac(string facultyCode)
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Collections.Generic.IEnumerable<PSUUserInfo> GetProfileByMajor(string majorCode)
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Collections.Generic.IEnumerable<PSUUserInfo> GetProfileByDept(string departmentCode)
        //{
        //    throw new NotImplementedException();
        //}

        //public System.Collections.Generic.IEnumerable<PSUUserInfo> GetProfileByCamp(string campusCode)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
