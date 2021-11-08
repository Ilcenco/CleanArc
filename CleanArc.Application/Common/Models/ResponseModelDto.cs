using Application.Projects.ViewModels;
using System.Collections.Generic;

namespace CleanArc.Application.Common.Models
{
    public class ResponseModelDto
    {
        public string sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public List<ProjectDetailsViewModel> aaData { get; set; }
    }
}
