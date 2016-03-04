using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewBlogPlatform.Models
{
    public class Post:BaseModel
    {
        
        [Required(ErrorMessage ="Post must have a title")]
        public  string Title { get; set; }

        public  string Content { get; set; }
        public string Slug { get; set; }
        
        
        public string UserRefId { get; set; }

        [ForeignKey("UserRefId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Post()
        {

        }

        public Post(string title,string content, string userId)
        {
            DateCreated = DateTime.UtcNow;
            Title = title;
            Content = content;
            UserRefId = userId;
            Slug = generateSlug();
        }

        private string generateSlug()
        {
            return Title.Replace(" ", "-").ToLower() + UserRefId.ToString();
        }
    }
}