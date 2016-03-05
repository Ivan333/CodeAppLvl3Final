using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBlogPlatform.ViewModels.Posts
{
    public class PostItemViewModel
    {
        public DateTime Date { get; set; }

        public string Username { get; set; }

        public int postId { get; set; }

        public string ImageUrl { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public string userSlug { get; set; }
        public string postSlug { get; set; }

        public string userPostId { get; set; }

        public string Title { get; set; }
        public PostItemViewModel()
        {

        }
    }
}