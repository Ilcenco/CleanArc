using CleanArc.Application.Services.News.ViewModels;
using CleanArc.Common.DataTableModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.News.Queries.GetDataTable
{
    public class GetGridQuery : IRequest<IEnumerable<UpdateNewsViewModel>>
    {
        public DataTablesParameters Model { get; set; }

    }
}
