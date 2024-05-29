using BlogsApp.Application.Blogs.Commands.CreateBlog;
using BlogsApp.Application.Blogs.Commands.DeleteBlog;
using BlogsApp.Application.Blogs.Commands.UpdateBlog;
using BlogsApp.Application.Blogs.Queries.GetBlogById;
using BlogsApp.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Mvc;

namespace BlogsApp.API.Controllers
{
    [Route("api/blogs")]
    [ApiController]
    public class BlogsController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetBlogQuery();

            var blogs = await Mediator.Send(query);

            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBlogByIdQuery() { BlogId = id };

            var blog = await Mediator.Send(query);

            if (blog is null)
                return NotFound();

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {

            var createdBlog = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBlogCommand command)
        {
            if (!id.Equals(command.Id)) return BadRequest();

            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCommand { Id = id };

            var result = await Mediator.Send(command);

            if (result is 0) return BadRequest();

            return Ok();
        }
    }
}
