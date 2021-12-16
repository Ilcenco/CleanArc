using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Web.Common.Enums;

namespace Web.Common.Classes
{
    public class ViewResultJsonResponse
    {
        public ExecutionResult Result { get; set; }
        public string ViewHtml { get; set; }
    }
}
