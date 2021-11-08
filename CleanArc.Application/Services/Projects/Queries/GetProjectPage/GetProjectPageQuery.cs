using Application.Common;
using Application.Projects.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Application.Projects.Queries.GetProjectPage
{
    public class GetProjectPageQuery : IRequest<ResponseModel<IList<ProjectDetailsViewModel>>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Filter { get; set; }
    }
}
