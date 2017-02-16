using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider.Model
{
    public partial class PSUUserInfo
    {
        #region Properties
        private static IPSUOrganizationProvider _orgProvider = new PSUOrganizationProvider();
        public PSUCampus Campus { get; set; }
        public PSUFaculty Faculty { get; set; }
        public PSUDepartment Department { get; set; }
        public PSUMajor Major { get; set; }
        public bool IsValidOrganizationInfo
        {
            get
            {
                if (Campus == null || Faculty == null || Department == null || Major == null) return false;
                return ((Faculty.ParentCode == Campus.Code) &&
                        (Department.ParentCode == Faculty.Code) &&
                        (Major.ParentCode == Department.Code)
                    );
            }
        }
        #endregion

        //#region constructor
        //public PSUUserInfo(string userName, string campusCode, string facultyCode, string departmentCode, string majorCode, bool isAuthenticated)
        //    : this(userName, isAuthenticated)
        //{
        //    Campus = getCampus(campusCode);
        //    Faculty = getFaculty(facultyCode);
        //    Department = getDepartment(departmentCode);
        //    Major = getMajor(majorCode);
        //}
        //#endregion
        public static PSUUserInfo Create(string userName, string campusCode, string facultyCode, string departmentCode, string majorCode, bool isAuthenticated)
        {
            var profile = new PSUUserInfo(userName);
            profile.Campus = getCampus(campusCode);
            profile.Faculty = getFaculty(facultyCode);
            profile.Department = getDepartment(departmentCode);
            profile.Major = getMajor(majorCode);
            return profile;
        }
        

        #region privateFunctions
        private static PSUCampus getCampus(string code)
        {
            PSUCampus org = null;
            if (!string.IsNullOrWhiteSpace(code))
            {
                try
                {
                    org = _orgProvider.GetCampus(code);
                }
                catch (Exception)
                {
                    org = new PSUCampus(code, string.Empty, string.Empty);
                }
            }

            return org;
        }

        private static PSUFaculty getFaculty(string code)
        {
            PSUFaculty org = null;
            if (!string.IsNullOrWhiteSpace(code))
            {
                try
                {
                    org = _orgProvider.GetFaculty(code);
                }
                catch (Exception)
                {
                    org = new PSUFaculty(code, string.Empty, string.Empty, string.Empty);
                }
            }

            return org;
        }

        private static PSUDepartment getDepartment(string code)
        {
            PSUDepartment org = null;
            if (!string.IsNullOrWhiteSpace(code))
            {
                try
                {
                    org = _orgProvider.GetDepartment(code);
                }
                catch (Exception)
                {
                    org = new PSUDepartment(code, string.Empty, string.Empty, string.Empty);
                }
            }

            return org;
        }

        private static PSUMajor getMajor(string code)
        {
            PSUMajor org = null;
            if (!string.IsNullOrWhiteSpace(code))
            {
                try
                {
                    org = _orgProvider.GetMajor(code);
                }
                catch (Exception)
                {
                    org = new PSUMajor(code, string.Empty, string.Empty, string.Empty);
                }
            }

            return org;
        }
        #endregion
    }
}
