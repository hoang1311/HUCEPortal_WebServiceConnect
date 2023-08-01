using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HUCEAdmin_API.Common
{
    public enum EnumErrCode
    {
        Error = 0,
        Fail,
        Success,
        InvalidInput,
        NotYetLogin,
        EmptyData,
        ExistentUnique,
    }
}