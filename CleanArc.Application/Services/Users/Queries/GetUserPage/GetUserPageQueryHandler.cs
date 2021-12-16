using Application.Common;
using Application.Common.Interfaces;
using CleanArc.Application.Services.Users.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserPage
{
    class GetUserPageQueryHandler : IRequestHandler<GetUserPageQuery, ResponseModel<IList<UserDetailViewModel>>>
    {
        private readonly IDataContext _dataContext;
        public GetUserPageQueryHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ResponseModel<IList<UserDetailViewModel>>> Handle(GetUserPageQuery request, CancellationToken cancellationToken)
        {
            var responseModel = new ResponseModel<IList<UserDetailViewModel>>();
            responseModel.ErrorMessage = "";
            responseModel.IsError = false;
            var pageIndex = request.PageIndex;
            var pageSize = request.PageSize;
            var filter = request.Filter;

            if (filter == null)
            {
                responseModel.ResponseValue = await _dataContext.IdentityUsers
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(s => new UserDetailViewModel
                {
                    Id = s.Id,
                    UserName = s.UserName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                }).ToListAsync(cancellationToken);
                responseModel.totalItems = _dataContext.IdentityUsers.Count();
                responseModel.totalPages = (int)Math.Ceiling(responseModel.totalItems / (double)pageSize);
            }
            else
            {
                responseModel.ResponseValue = await _dataContext.IdentityUsers
                    .Where(c => c.UserName.Contains(filter))
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Select(s => new UserDetailViewModel()
                {
                    UserName = s.UserName,
                    Email = s.Email,
                    Id = s.Id,
                    PhoneNumber = s.PhoneNumber,
                }).ToListAsync(cancellationToken);
                responseModel.totalItems = _dataContext.IdentityUsers.Where(c => c.UserName.Contains(filter)).Count();
                responseModel.totalPages = (int)Math.Ceiling(responseModel.totalItems / (double)pageSize);
            }
            return responseModel;
        }
    }
}
