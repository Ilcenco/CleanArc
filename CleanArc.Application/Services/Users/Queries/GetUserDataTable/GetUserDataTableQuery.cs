using CleanArc.Application.Services.Users.ViewModels;
using CleanArc.Common.DataTableModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.Users.Queries.GetUserDataTable
{
    public class GetUserDataTableQuery : IRequest<IEnumerable<UserDetailViewModel>>
    {
        public DataTablesParameters Model { get; set; }
    }
}
