using MediatR;

namespace BlogsApp.Application.Blogs.Commands.DeleteBlog;

public class DeleteBlogCommand : IRequest<int>
{
    public int id;

    public int Id { get; set; }
}
