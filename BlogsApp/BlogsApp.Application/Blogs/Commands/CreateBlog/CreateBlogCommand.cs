using BlogsApp.Application.DTOs;
using MediatR;

namespace BlogsApp.Application.Blogs.Commands.CreateBlog;

public class CreateBlogCommand : IRequest<BlogViewModel>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}