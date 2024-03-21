using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postland.Application.Features.Posts.Command.DeletePost
{
    public class DeletePostCommand : IRequest<string>
    {
        public string Id { get; set; }
    }
}
