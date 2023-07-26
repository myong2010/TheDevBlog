using System;
namespace theDevBlog.Models.Entities.DTO
{
	public class UpdatePostRequest
	{

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string UrlHandle { get; set; } = string.Empty;

        public string FeaturedImageUrl { get; set; } = string.Empty;

        public bool Visible { get; set; }

        public string Author { get; set; } = string.Empty;

        public DateTime PublishDate { get; set; }

        public DateTime UpdatedDate { get; set; }

    }
}

