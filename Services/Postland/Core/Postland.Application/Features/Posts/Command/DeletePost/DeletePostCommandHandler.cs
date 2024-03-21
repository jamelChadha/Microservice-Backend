using MediatR;
using Postland.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postland.Application.Features.Posts.Command.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, string>
    {
        private readonly IPostRepository _postRepository;
        public DeletePostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<string> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetPostByIdAsync(request.Id, true);

            await _postRepository.DeleteAsync(post);

            return post.Id;
        }
    }
}