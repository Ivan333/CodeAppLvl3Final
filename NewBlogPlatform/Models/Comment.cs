using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBlogPlatform.Models
{
    public class Comment : BaseModel
    {
        public string Message { get; set; }
    }
}