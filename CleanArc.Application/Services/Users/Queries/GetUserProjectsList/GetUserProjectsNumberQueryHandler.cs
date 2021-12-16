using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArc.Application.Services.Users.Queries.GetUserProjectsList
{
    class GetUserProjectsNumberQueryHandler : IRequestHandler<GetUserProjectsNumberQuery, int>
    {
        private readonly IDataContext _dataContext;
        public GetUserProjectsNumberQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<int> Handle(GetUserProjectsNumberQuery request, CancellationToken cancellationToken)
        {
            var projects = await _dataContext.Projects.ToListAsync();
            int num = 0;
            foreach (var project in projects)
            {
                if (project.CedacriItalyRUser == request.Id || project.CedacriInternationalRUser == request.Id)
                {
                    num++;
                }
            }
            return num;
        }
    }
}
