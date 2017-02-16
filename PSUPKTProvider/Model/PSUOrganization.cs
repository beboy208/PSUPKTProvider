using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider.Model
{
    public abstract class PSUOrganization
    {
        public string Code { get; private set; }
        public string NameTH { get; private set; }
        public string NameEN { get; private set; }
        public string ParentCode { get; private set; }
        public int? CurrentLevel { get; private set; }

        public PSUOrganization(string code, string nameTH, string nameEN, string parentCode, int? currentLevel)
        {
            Code = code;
            NameTH = nameTH;
            NameEN = nameEN;
            ParentCode = parentCode;
            CurrentLevel = currentLevel;
        }
    }
}
