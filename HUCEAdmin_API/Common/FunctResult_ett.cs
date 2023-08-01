using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HUCEAdmin_API.Common
{
    public class FunctResult_ett<T>
    {
        public EnumErrCode ErrCode { get; set; }
        public string ErrDesc { get; set; }
        public T Data { get; set; }
    }
}