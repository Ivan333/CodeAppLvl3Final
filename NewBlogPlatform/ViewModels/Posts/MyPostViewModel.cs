using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBlogPlatform.ViewModels.Posts
{
    public class MyPostViewModel : PostItemViewModel
    {
        [AllowHtml]
        public string Content { get; set; }
        public MyPostViewModel()
        {

        }
    }
}