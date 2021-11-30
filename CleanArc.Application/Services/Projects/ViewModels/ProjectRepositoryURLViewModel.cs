using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Projects.ViewModels
{
    public class ProjectRepositoryURLViewModel : IRequest
    {
        public Guid? Id { get; set; }
        public string Url { get; set; }
        public Guid UrlTypeId { get; set; }

    }
}
