using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace SocietyAPI.Global
{
    public class DataResult<T>
    {
        public string Message { get; set; }
        public string MsgType { get; set; }
        public string StringResult { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}