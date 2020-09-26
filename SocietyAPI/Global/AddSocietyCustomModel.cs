using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocietyAPI.Global
{
    public class AddSocietyCustomModel
    {
        public string societyCode { get; set; }
        public string societyName { get; set; }
        public string memberName { get; set; }
        public string address { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public decimal mobileNo { get; set; }
        public string memberType { get; set; }
        public string flatNo { get; set; }
        public string email { get; set; }
        public string createdBy { get; set; }
    }
}