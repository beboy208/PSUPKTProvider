using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Profile;

namespace PSUPKTProvider.Model
{
    public class PSUProfileBase: ProfileBase
    {
        public PSUUserInfo UserDetails { get; set; }
    }
}
