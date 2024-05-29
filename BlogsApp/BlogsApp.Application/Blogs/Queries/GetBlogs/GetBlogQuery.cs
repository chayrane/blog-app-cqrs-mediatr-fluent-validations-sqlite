using BlogsApp.Application.DTOs;
using MediatR;

namespace BlogsApp.Application.Blogs.Queries.GetBlogs;

public class GetBlogQuery : IRequest<List<BlogViewModel>>
{
}

// public record GetBlogQuery : IRequest<List<BlogViewModel>>
