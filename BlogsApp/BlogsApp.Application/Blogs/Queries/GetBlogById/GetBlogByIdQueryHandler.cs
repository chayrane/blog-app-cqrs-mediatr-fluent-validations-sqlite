using AutoMapper;
using BlogsApp.Application.DTOs;
using BlogsApp.Domain.Repository;
using MediatR;

namespace BlogsApp.Application.Blogs.Queries.GetBlogById;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogViewModel>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<BlogViewModel> Handle(
        GetBlogByIdQuery request,
        CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetByIdAsync(request.BlogId);

        return _mapper.Map<BlogViewModel>(blog);
    }
}
