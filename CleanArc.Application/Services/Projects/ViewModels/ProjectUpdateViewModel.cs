using Application.Common;
using CleanArc.Application.Services.Projects.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace CleanArc.Application.Services.Projects.Commands.ViewModels
{
    public class ProjectUpdateViewModel : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid CedacriInternationalRUser { get; set; }
        public Guid CedacriItalyRUser { get; set; }
        public List<ProjectRepositoryURLViewModel> URLs { get; set; }


        public List<DropDownList> UrlTypesDropDown { get; set; }
        public List<DropDownList> DepartmentsDropDown { get; set; }
        public List<DropDownList> UsersDropDown { get; set; }
    }
}
