using PSUPKTProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider
{
    public class PSUOrganizationProvider : IPSUOrganizationProvider
    {
        #region Campus
        private IEnumerable<PSUCampus> campusesConverter(IEnumerable<Regist2005New.CAMPUSRow> campuses)
        {
            List<PSUCampus> camps = new List<PSUCampus>();
            if (campuses == null || campuses.Count() <= 0) return camps;
            campuses.ToList().ForEach(c =>
            {
                var camNT = (c.IsCAMPUS_NAME_THAINull()) ? "" : c.CAMPUS_NAME_THAI;
                var camEN = (c.IsCAMPUS_NAME_ENGNull()) ? "" : c.CAMPUS_NAME_ENG;

                PSUCampus campus = new PSUCampus(c.CAMPUS_ID, camNT, camEN);
                camps.Add(campus);
            });
            return camps;
        }
        public IEnumerable<PSUCampus> GetCampuses()
        {
            Regist2005NewTableAdapters.CAMPUSTableAdapter tadapter = new Regist2005NewTableAdapters.CAMPUSTableAdapter();
            var campusTable = tadapter.GetData();
            return campusesConverter(campusTable);
        }

        public PSUCampus GetCampus(string CampusCode)
        {
            if (string.IsNullOrWhiteSpace(CampusCode)) return null;
            var tadapter = new Regist2005NewTableAdapters.CAMPUSTableAdapter();
            var campusTable = tadapter.GetDataByCampusID(CampusCode);
            var campuses = campusesConverter(campusTable);
            return campuses.SingleOrDefault();
        }
        #endregion Campus

        #region Faculty
        private IEnumerable<PSUFaculty> facultiesConverter(IEnumerable<Regist2005New.FACULTYRow> factories)
        {
            List<PSUFaculty> facts = new List<PSUFaculty>();
            if (factories == null || factories.Count() < 0) return facts;
            factories.ToList().ForEach(f =>
            {
                PSUFaculty fact = new PSUFaculty(f.FAC_ID, 
                    (f.IsFAC_NAME_THAINull()) ? "" : f.FAC_NAME_THAI,
                    (f.IsFAC_NAME_ENGNull()) ? "" : f.FAC_NAME_ENG,
                    (f.IsCAMPUS_IDNull()) ? "" : f.CAMPUS_ID);
                facts.Add(fact);
            });
            return facts;
        }

        public IEnumerable<PSUFaculty> GetFaculties()
        {
            Regist2005NewTableAdapters.FACULTYTableAdapter tadapter = new Regist2005NewTableAdapters.FACULTYTableAdapter();
            var facTable = tadapter.GetData();
            return facultiesConverter(facTable);
        }

        public IEnumerable<PSUFaculty> GetFaculties(string CampusCode)
        {
            if (string.IsNullOrWhiteSpace(CampusCode)) return null;
            var tadapter = new Regist2005NewTableAdapters.FACULTYTableAdapter();
            var campusTable = tadapter.GetDataByCampusID(CampusCode);
            return facultiesConverter(campusTable);
        }

        public PSUFaculty GetFaculty(string FacultyCode)
        {
            if (string.IsNullOrWhiteSpace(FacultyCode)) return null;
            var tadapter = new Regist2005NewTableAdapters.FACULTYTableAdapter();
            var facTable = tadapter.GetDataByFacultyID(FacultyCode);
            return facultiesConverter(facTable).SingleOrDefault();
        }

        #endregion Faculty

        #region Department
        private IEnumerable<PSUDepartment> departmentsConverter(IEnumerable<Regist2005New.DEPTRow> departments)
        {
            List<PSUDepartment> depts = new List<PSUDepartment>();
            if (departments == null || departments.Count() <= 0) return depts;
            departments.ToList().ForEach(d =>
            {
                string deptID = d.DEPT_ID;
                string deptNT = (d.IsDEPT_NAME_THAINull()) ? "" : d.DEPT_NAME_THAI;
                string deptEN = (d.IsDEPT_NAME_ENGNull()) ? "" : d.DEPT_NAME_ENG;
                string parentID = (d.IsCAMPUS_IDNull()) ? "" : d.CAMPUS_ID;
                PSUDepartment dept = new PSUDepartment(deptID, deptNT, deptEN, parentID);
                depts.Add(dept);
            });
            return depts;
        }

        public IEnumerable<PSUDepartment> GetDepartments()
        {
            Regist2005NewTableAdapters.DEPTTableAdapter tadapter = new Regist2005NewTableAdapters.DEPTTableAdapter();
            var depTable = tadapter.GetData();
            return departmentsConverter(depTable);
        }

        public IEnumerable<PSUDepartment> GetDepartments(string FacultyCode)
        {
            if (string.IsNullOrWhiteSpace(FacultyCode)) return null;
            var tadapter = new Regist2005NewTableAdapters.DEPTTableAdapter();
            var facTable = tadapter.GetDataByFacID(FacultyCode);
            return departmentsConverter(facTable);
        }

        public PSUDepartment GetDepartment(string DepartmentCode)
        {
            var tadapter = new Regist2005NewTableAdapters.DEPTTableAdapter();
            var depTable = tadapter.GetDataByDeptID(DepartmentCode);
            return departmentsConverter(depTable).SingleOrDefault();
        }

        #endregion Department

        #region Major
        private IEnumerable<PSUMajor> majorsConverter(IEnumerable<Regist2005New.MAJORRow> majors)
        {
            List<PSUMajor> majs = new List<PSUMajor>();
            if (majors == null || majors.Count() <= 0) return majs;
            majors.ToList().ForEach(m =>
            {
                PSUMajor maj = new PSUMajor(m.MAJOR_ID, 
                    (m.IsMAJOR_NAME_THAINull())? "" : m.MAJOR_NAME_THAI,
                    (m.IsMAJOR_NAME_ENGNull())? "" : m.MAJOR_NAME_ENG,
                    (m.IsDEPT_IDNull() ? "" : m.DEPT_ID));
                majs.Add(maj);
            });
            return majs;
        }

        public IEnumerable<PSUMajor> GetMajors()
        {
            Regist2005NewTableAdapters.MAJORTableAdapter tadapter = new Regist2005NewTableAdapters.MAJORTableAdapter();
            return majorsConverter(tadapter.GetData());
        }
        public IEnumerable<PSUMajor> GetMajors(string DepartmentCode)
        {
            var tadapter = new Regist2005NewTableAdapters.MAJORTableAdapter();
            return majorsConverter(tadapter.GetDataByDeptID(DepartmentCode));
        }

        public PSUMajor GetMajor(string MajorCode)
        {
            var tadapter = new Regist2005NewTableAdapters.MAJORTableAdapter();
            return majorsConverter(tadapter.GetDataByMajorID(MajorCode)).SingleOrDefault();
        }

        #endregion Major
    }
}
