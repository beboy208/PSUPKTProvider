using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider.Model
{
    public class PSUCampus: PSUOrganization
    {
        public PSUCampus(string code, string nameTH, string nameEN)
            : base(code, nameTH, nameEN,string.Empty, 1)
        {

        }
    }
}
