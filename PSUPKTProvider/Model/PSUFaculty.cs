using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider.Model
{
    public class PSUFaculty: PSUOrganization
    {
        public PSUFaculty(string code, string nameTH, string nameEN, string parentCode)
            : base(code, nameTH, nameEN, parentCode, 2)
        {

        }
    }
}
