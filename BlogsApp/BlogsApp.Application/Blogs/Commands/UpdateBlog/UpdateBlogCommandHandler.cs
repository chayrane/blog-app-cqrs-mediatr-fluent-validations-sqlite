using AutoMapper;
using BlogsApp.Domain.Entity;
using BlogsApp.Domain.Repository;
using MediatR;

namespace BlogsApp.Application.Blogs.Commands.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;

    public UpdateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var updateBlogEntity = new Blog()
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Author = request.Author
        };

        return await _blogRepository.UpdateAsync(request.Id, updateBlogEntity);
    }
}
