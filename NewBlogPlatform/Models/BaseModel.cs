using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewBlogPlatform.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
    }
}