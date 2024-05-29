using BlogsApp.Application.DTOs;
using MediatR;

namespace BlogsApp.Application.Blogs.Queries.GetBlogById;

public class GetBlogByIdQuery : IRequest<BlogViewModel>
{
    public int BlogId { get; set; }
}
