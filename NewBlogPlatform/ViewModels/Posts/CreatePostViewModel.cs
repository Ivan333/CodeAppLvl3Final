using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewBlogPlatform.ViewModels.Posts
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }

        
        
        public string Content { get; set; }

         
    }
}