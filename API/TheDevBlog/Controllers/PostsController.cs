using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using theDevBlog.Models.Entities.DTO;
using TheDevBlog.Data;
using TheDevBlog.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace theDevBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly TheDevBlogDbContext dbContext;

        private readonly IWebHostEnvironment _env;

        public PostsController(TheDevBlogDbContext dbContext, IWebHostEnvironment env)
        {
            this.dbContext = dbContext;

            this._env = env;

        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await dbContext.Posts.ToListAsync());
        }

        // GET api/values/5
        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetPostById([FromRoute] Guid id)
        {
            var post = await dbContext.Posts.FindAsync(id);

            if (post != null)
            {

                return Ok(post);
            }

            return NotFound();

        }


        // POST api/values
        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostRequest addPostRequest)
        {
            //convert DTO to Entity
            var post = new Post()
            {

                 Title = addPostRequest.Title,

                 Content = addPostRequest.Content,

                 Summary = addPostRequest.Summary,

                 UrlHandle = addPostRequest.UrlHandle,

                 FeaturedImageUrl = addPostRequest.FeaturedImageUrl,

                 Visible = addPostRequest.Visible,

                 Author = addPostRequest.Author,

                 PublishDate = addPostRequest.PublishDate,

                 UpdatedDate = addPostRequest.UpdatedDate
            };

            post.Id = Guid.NewGuid();
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            return Ok(post);
        }


        // PUT api/values/5

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdatePost([FromRoute] Guid id, UpdatePostRequest updatePostRequest)
        {
            var post = await dbContext.Posts.FindAsync(id);

            if (post != null)
            {
                post.Title = updatePostRequest.Title;

                post.Content = updatePostRequest.Content;

                post.Summary = updatePostRequest.Summary;

                post.UrlHandle = updatePostRequest.UrlHandle;

                post.FeaturedImageUrl = updatePostRequest.FeaturedImageUrl;

                post.Visible = updatePostRequest.Visible;

                post.Author = updatePostRequest.Author;

                post.PublishDate = updatePostRequest.PublishDate;

                post.UpdatedDate = updatePostRequest.UpdatedDate;

                await dbContext.SaveChangesAsync();

                return Ok(post);
            }

            return NotFound();
        }


        // DELETE api/values/5
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {
            var post = await dbContext.Posts.FindAsync(id);

            if (post != null)
            {
                dbContext.Remove(post);
                await dbContext.SaveChangesAsync();

                return Ok(post);
            }

            return NotFound();
        }
    }
}

