using BlogsApp.Domain.Entity;
using BlogsApp.Domain.Repository;
using BlogsApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogsApp.Infrastructure.Repository;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _blogDbContext;

    public BlogRepository(BlogDbContext blogDbContext)
    {
        _blogDbContext = blogDbContext;
    }

    public async Task<List<Blog>> GetAllBlogsAsync()
    {
        return await _blogDbContext.Blogs
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Blog> GetByIdAsync(int id)
    {
        return await _blogDbContext.Blogs
            .AsNoTracking()
            .FirstAsync(x => x.Id == id);
    }

    public async Task<Blog> CreateAsync(Blog blog)
    {
        await _blogDbContext.Blogs.AddAsync(blog);
        await _blogDbContext.SaveChangesAsync();
        
        return blog;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _blogDbContext.Blogs
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<int> UpdateAsync(int id, Blog blog)
    {
        return await _blogDbContext.Blogs
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(x => x.Id, blog.Id)
                .SetProperty(x => x.Name, blog.Name)
                .SetProperty(x => x.Description, blog.Description)
                .SetProperty(x => x.Author, blog.Author)
            );
    }
}
