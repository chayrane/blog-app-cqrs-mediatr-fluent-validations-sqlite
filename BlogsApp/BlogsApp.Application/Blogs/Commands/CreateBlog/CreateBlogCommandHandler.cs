using AutoMapper;
using BlogsApp.Application.DTOs;
using BlogsApp.Domain.Entity;
using BlogsApp.Domain.Repository;
using MediatR;

namespace BlogsApp.Application.Blogs.Commands.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogViewModel>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<BlogViewModel> Handle(
        CreateBlogCommand request,
        CancellationToken cancellationToken)
    {
        var blogEntity = new Blog()
        {
            Name = request.Name,
            Description = request.Description,
            Author = request.Author
        };

        var Result = await _blogRepository.CreateAsync(blogEntity);

        return _mapper.Map<BlogViewModel>(Result);
    }
}
