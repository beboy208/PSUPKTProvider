using PSUPKTProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Profile;

namespace PSUPKTProvider
{
       public interface IUserProfileProvider<T> //where T : ProfileBase
    {
        //IEnumerable<T> GetProfiles();
        //IEnumerable<T> GetProfileByFac(string facultyCode);
        //IEnumerable<T> GetProfileByMajor(string majorCode);
        //IEnumerable<T> GetProfileByDept(string departmentCode);
        //IEnumerable<T> GetProfileByCamp(string campusCode);
        T GetProfile(string username, string password);
        T GetProfile(string username);
    }
}
