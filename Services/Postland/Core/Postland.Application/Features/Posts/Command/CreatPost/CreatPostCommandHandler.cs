using AutoMapper;
using MediatR;
using Postland.Application.Contracts;
using Postland.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postland.Application.Features.Posts.Command.CreatPost
{
    public class CreatPostCommandHandler : IRequestHandler<CreatPostCommand, string>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public CreatPostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(CreatPostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);
            post.Id = Guid.NewGuid().ToString(); // Générer un nouvel ID unique
            CreatCommandValidators validators = new CreatCommandValidators();
            var result = await validators.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new Exception("Post is not valid ");
            }
            post = await _postRepository.AddAsync(post);
            return post.Id;
        }
    }
}
