using BlogsApp.Domain.Entity;
using BlogsApp.Application.Common.Mappings;

namespace BlogsApp.Application.DTOs;

public class BlogViewModel : IMapFrom<Blog>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}
