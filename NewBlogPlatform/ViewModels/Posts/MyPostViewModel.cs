using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBlogPlatform.ViewModels.Posts
{
    public class MyPostViewModel : PostItemViewModel
    {
        public string Content { get; set; }
        public MyPostViewModel()
        {

        }
    }
}