using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider.Model
{
    public class PSUDepartment: PSUOrganization
    {
        public PSUDepartment(string code, string nameTH, string nameEN, string parentID)
            : base(code, nameTH, nameEN, parentID, 3)
        {

        }
    }
}
