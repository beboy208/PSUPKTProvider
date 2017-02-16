using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider.Model
{
    class PSUPKTRole
    {
        public string role_id { get; set; }
        public string role_name_thai { get; set; }
        public string role_name_eng { get; set; }
        public string app_id { get; set; }
    }

    class JsonPSUPKTRoleResult
    {
        public PSUPKTRole[] result {get; set;}
    }

    class PSUPassport {
        public string username {get; set;}
    }

    class JsonPSUPKTPassportResult 
    {
        public PSUPassport[] result { get; set; }
    }
}
