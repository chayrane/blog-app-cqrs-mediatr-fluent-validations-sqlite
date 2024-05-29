using AutoMapper;
using BlogsApp.Application.DTOs;
using BlogsApp.Domain.Repository;
using MediatR;

namespace BlogsApp.Application.Blogs.Queries.GetBlogs;

public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogViewModel>>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;

    public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }

    public async Task<List<BlogViewModel>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _blogRepository.GetAllBlogsAsync();

        var blogList = _mapper.Map<List<BlogViewModel>>(blogs);

        //var blogList = blogs.Select(x => new BlogViewModel
        //{
        //    Author = x.Author,
        //    Name = x.Name,
        //    Description = x.Description,
        //    Id = x.Id,
        //}).ToList();

        return blogList;
    }
}
