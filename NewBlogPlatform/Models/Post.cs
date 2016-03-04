using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBlogPlatform.Models
{
    public class Post:BaseModel
    {
     
        public  string Title { get; set; }
        public  string Content { get; set; }
        public string Slug { get; set; }


        public Post()
        {

        }

        public Post(string title,string content)
        {
            DateCreated = DateTime.UtcNow;
            Title = title;
            Content = content;
            Slug = generateSlug();
        }

        private string generateSlug()
        {
            return Title.Replace(" ", "-").ToLower();
        }
    }
}