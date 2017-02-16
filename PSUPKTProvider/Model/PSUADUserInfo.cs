using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSUPKTProvider.Model
{
    [Serializable()]
    public partial class PSUUserInfo //: ProfileBase
    {

        public PSUUserInfo(string userName)//, bool isAuthenticated)
        {
            //ProfileBase.Create(userName, isAuthenticated);
            UserName = userName;
        }

        public static PSUUserInfo CreateByADUserDetails(string[] ADUserDetails, bool isAuthenticated)
        {
            var profile = PSUUserInfo.Create(ADUserDetails[0], ADUserDetails[9], ADUserDetails[7], ADUserDetails[6], string.Empty, isAuthenticated);
            if (ADUserDetails != null || ADUserDetails.Length > 0)
            {
                profile.Title = ADUserDetails[12];
                profile.Gender = MapGender(ADUserDetails[4]);
                profile.FirstName = ADUserDetails[1];
                profile.LastName = ADUserDetails[2];
                profile.Email = ADUserDetails[13];
                profile.CitizenID = ADUserDetails[5];
                profile.StaffCode = ADUserDetails[3];
                profile.Position = string.Empty;
                profile.DistinguishedName = ADUserDetails[14];
                profile.OUs = new Dictionary<string, string>();
                profile.OUs.Add(ADUserDetails[6], string.Empty);
                profile.OUs.Add(ADUserDetails[7], ADUserDetails[8]);
                profile.OUs.Add(ADUserDetails[9], ADUserDetails[10]);
                string ouPrositioin = profile.DistinguishedName.Split(',')[4].Split('=')[1];
                profile.OUs.Add(ouPrositioin, ouPrositioin);
            }

            return profile;
        }

        //public PSUUserInfo(string[] ADUserDetails, bool isAuthenticated)
        //    : this(ADUserDetails[0], ADUserDetails[9], ADUserDetails[7], ADUserDetails[6], string.Empty, isAuthenticated)
        //{
        //    if (ADUserDetails != null || ADUserDetails.Length > 0)
        //    {
        //        Title = ADUserDetails[12];
        //        Gender = MapGender(ADUserDetails[4]);
        //        FirstName = ADUserDetails[1];
        //        LastName = ADUserDetails[2];
        //        Email = ADUserDetails[13];
        //        CitizenID = ADUserDetails[5];
        //        StaffCode = ADUserDetails[3];
        //        Position = "";
        //        DistinguishedName = ADUserDetails[14];
        //    }
        //}


        private string _userName;
        public string UserName
        {
            get { return _userName;  }
            private set { _userName = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private string _staffCode;

        public string StaffCode
        {
            get { return _staffCode; }
            set { _staffCode = value; }
        }

        private Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _citizenID;

        public string CitizenID
        {
            get { return _citizenID; }
            set { _citizenID = value; }
        }

        private string _position;

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        private Dictionary<string, string> _OUs;

        public Dictionary<string, string> OUs
        {
            get { return _OUs; }
            internal set { _OUs = value; }
        }

        private string _fullADString;

        public string DistinguishedName
        {
            get { return _fullADString; }
            set { _fullADString = value; }
        }

        private static Gender MapGender(string value)
        {
            try
            {
                return (Gender)value[0];
            }
            catch (Exception)
            {
                return Gender.Unmatch;
            }
        }
    }
}
