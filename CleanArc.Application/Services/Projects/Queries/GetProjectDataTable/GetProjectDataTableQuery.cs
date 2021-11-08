using CleanArc.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Projects.Queries.GetProjectDataTable
{
    public class GetProjectDataTableQuery : IRequest<ResponseModelDto>
    {
        public JqueryDatatableParam Model { get; set; }
    }
}
