using NewBlogPlatform.Models;
using NewBlogPlatform.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBlogPlatform.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var posts = db.Posts.ToList();
            var postsViewModel = posts.Select(x => new PostItemViewModel
            {
                Date = x.DateCreated,
                Title = x.Title
            }).ToList();
            return View(postsViewModel);
        }


        public ActionResult Details(string slug)
        {
            var post = db.Posts.SingleOrDefault(x => x.Slug == slug);
            var model = new PostItemViewModel
            {
                Date = post.DateCreated,
                Title = post.Title
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new Post(model.Title, model.Content);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(model);
        }

    }
}