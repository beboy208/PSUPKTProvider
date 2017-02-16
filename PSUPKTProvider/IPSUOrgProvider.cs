using PSUPKTProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider
{
    public interface IPSUOrganizationProvider
    {
        IEnumerable<PSUCampus> GetCampuses();
        PSUCampus GetCampus(string CampusCode);

        IEnumerable<PSUFaculty> GetFaculties();
        PSUFaculty GetFaculty(string FacultyCode);

        IEnumerable<PSUDepartment> GetDepartments(string FacultyCode);
        PSUDepartment GetDepartment(string DepartmentCode);
        IEnumerable<PSUDepartment> GetDepartments();

        IEnumerable<PSUMajor> GetMajors(string DepartmentCode);
        PSUMajor GetMajor(string MajorCode);
        IEnumerable<PSUMajor> GetMajors();
        

    }
}
