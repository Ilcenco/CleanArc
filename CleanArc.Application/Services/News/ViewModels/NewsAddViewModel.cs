using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Services.News.ViewModels
{
    public class NewsAddViewModel : IRequest
    {
        public string Title { get; set; }
        public string Information { get; set; }
        public string Text { get; set; }
        public bool IsPrivate { get; set; }
    }
}
