using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Common.Models
{
    public class JqueryDatatableParam
    {
        public string sEcho { get; set; }
        public string search { get; set; }
        public int length { get; set; }
        public int start { get; set; }
        public int iColumns { get; set; }
        public int iSortCol_0 { get; set; }
        public string sSortDir_0 { get; set; }
        public int iSortingCols { get; set; }
        public string sColumns { get; set; }
    }
}
