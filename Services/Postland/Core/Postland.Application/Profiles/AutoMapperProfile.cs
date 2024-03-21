using AutoMapper;
using Postland.Application.Features.Posts.Command.CreatPost;
using Postland.Application.Features.Posts.Command.DeletePost;
using Postland.Application.Features.Posts.Command.UpdatePost;
using Postland.Application.Features.Posts.Queries.GetPostDetail;
using Postland.Application.Features.Posts.Queries.GetPostList;
using Postland.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postland.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostListViewModel>().ReverseMap();
            CreateMap<Post, GetPostDetailViewModel>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Post, CreatPostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            CreateMap<Post, DeletePostCommand>().ReverseMap();


        }
    }
}
