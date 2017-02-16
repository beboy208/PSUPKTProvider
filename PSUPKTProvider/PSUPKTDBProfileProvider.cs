using PSUPKTProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider
{
    public class PSUPKTDBProfileProvider : IUserProfileProvider<PSUUserInfo>
    {
        public PSUUserInfo GetProfile(string username, string password)
        {
            throw new NotSupportedException("Please user function GetProfile(username).");
        }

        /// <summary>
        /// ค้นหาข้อมูลของ นักศึกษา หรือ บุคลากร จากฐานข้อมูลทะเบียนของมหาวิทยาลัย
        /// AD_DETAIL
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public PSUUserInfo GetProfile(string username)
        {
            //throw new NotImplementedException();
            //algorithm

            //do get PSU User from Oracle Database (Staff and Student)
            //throw new NotImplementedException();
            var adapter = new Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter();
            var user = adapter.GetDataByUsername(username).FirstOrDefault();

            if (user == null) return null;

            //after get PSU User then assign to class PSUUser
            string campusCode = user.CAMPUS_ID;
            string facultyCode = user.FAC_ID;
            string departmentCode = user.DEPT_ID;
            string majorCode = user.MAJOR_ID;

            PSUUserInfo profile = PSUUserInfo.Create(username, campusCode, facultyCode, departmentCode, majorCode, false);
            
            //assign other value
            profile.StaffCode = user.STAFF_ID;
            profile.CitizenID = user.CITIZEN_ID;
            profile.Email = user.EMAIL;
            profile.DistinguishedName = string.Empty;
            profile.Gender = Gender.Unmatch;
            profile.FirstName = user.NAME_THAI;
            profile.LastName = user.SNAME_THAI;                  
            return profile;
        }

        private IEnumerable<PSUUserInfo> userinfoConverter(IEnumerable<Regist2005New.V_LC_AD_DETAIL_COMPLETERow> userinfos)
        {
            List<PSUUserInfo> users = new List<PSUUserInfo>();
            userinfos.ToList().ForEach(f =>
            {
                PSUUserInfo user = PSUUserInfo.Create(f.ACCOUNT_NAME, f.CAMPUS_ID, f.FAC_ID, f.DEPT_ID, f.MAJOR_ID, false);
                users.Add(user);
            });
            return users;
        }
        public IEnumerable<PSUUserInfo> GetProfiles()
        {
            Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter tadapter = new Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter();
            return userinfoConverter(tadapter.GetData().ToList());
        }

        public IEnumerable<PSUUserInfo> GetProfileByFac(string facultyCode)
        {
            Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter tadapter = new Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter();
            return userinfoConverter(tadapter.GetDataByFacId(facultyCode).ToList());
        }

        public IEnumerable<PSUUserInfo> GetProfileByMajor(string majorCode)
        {
            Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter tadapter = new Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter();
            return userinfoConverter(tadapter.GetDataByMajorID(majorCode).ToList());
        }

        public IEnumerable<PSUUserInfo> GetProfileByDept(string departmentCode)
        {
            Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter tadapter = new Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter();
            return userinfoConverter(tadapter.GetDataByDeptID(departmentCode).ToList());
        }

        public IEnumerable<PSUUserInfo> GetProfileByCamp(string campusCode)
        {
            Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter tadapter = new Regist2005NewTableAdapters.V_LC_AD_DETAIL_COMPLETETableAdapter();
            return userinfoConverter(tadapter.GetDataByCampusID(campusCode).ToList());
        }
    }
}
