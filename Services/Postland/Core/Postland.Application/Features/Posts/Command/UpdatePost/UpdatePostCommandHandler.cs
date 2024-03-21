using AutoMapper;
using MediatR;
using Postland.Application.Contracts;
using Postland.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postland.Application.Features.Posts.Command.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, string>
    {
        private readonly IAsyncRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IAsyncRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);

            await _postRepository.UpdateAsync(post);

            return post.Id;
        }


    }
}
