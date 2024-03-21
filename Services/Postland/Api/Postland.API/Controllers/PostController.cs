using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postland.Application.Features.Posts.Command.CreatPost;
using Postland.Application.Features.Posts.Command.DeletePost;
using Postland.Application.Features.Posts.Command.UpdatePost;
using Postland.Application.Features.Posts.Queries.GetPostDetail;
using Postland.Application.Features.Posts.Queries.GetPostList;

namespace Postland.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllPosts")]
        public async Task<ActionResult<List<GetPostListViewModel>>> GetAllPosts()
        {
            var dtos = await _mediator.Send(new GetPostListQuery());


            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetPostById")]
        public async Task<ActionResult<GetPostDetailViewModel>> GetPostById(string id)
        {
            var getEventDetailQuery = new GetPostDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddPost")]
        public async Task<ActionResult<string>> Create([FromBody] CreatPostCommand createPostCommand)
        {
            string id = await _mediator.Send(createPostCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdatePost")]
        public async Task<ActionResult> Update([FromBody] UpdatePostCommand updatePostCommand)
        {
            await _mediator.Send(updatePostCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public async Task<ActionResult> Delete(string id)
        {
            var deletePostCommand = new DeletePostCommand() { Id = id };
            await _mediator.Send(deletePostCommand);
            return NoContent();
        }

    }
}