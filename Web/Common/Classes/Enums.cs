using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Common
{
    public static class Enums
    {
        public enum ExecutionResult
        {
            OK = 1,
            KO = 2,
            ERROR = 3,
            NOTVALID = 4,
            EXCEPTION = 5,
        }
    }
}
