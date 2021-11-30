using Application.Projects.ViewModels;
using CleanArc.Application.Common.Models;
using CleanArc.Common.DataTableModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Projects.Queries.GetProjectDataTable
{
    public class GetProjectDataTableQuery : IRequest<IEnumerable<ProjectDetailsViewModel>>
    { 
        public DataTablesParameters Model { get; set; }
    }
}
