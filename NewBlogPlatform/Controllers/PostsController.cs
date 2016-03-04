using NewBlogPlatform.Models;
using NewBlogPlatform.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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
                Username = x.ApplicationUser.UserName,
                Date = x.DateCreated,
                Title = x.Title
            }).ToList();
            return View(postsViewModel);
        }


        public ActionResult Details(string slug)
        {
            var username = User.Identity.GetUserName();
            var post = db.Posts.SingleOrDefault(x => x.Slug == slug);
            if (post != null) {
                var model = new PostItemViewModel
                {
                    Username = username,
                    Date = post.DateCreated,
                    Title = post.Title
                };
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult MyPosts()
        {
            if (User.Identity.IsAuthenticated)
            {
                var id = User.Identity.GetUserId();
                var username = User.Identity.GetUserName();
                var userPosts = db.Posts.Where(x => x.UserRefId == id);
                if (userPosts != null && userPosts.ToList().Count != 0)
                {
                    var postsViewModel = userPosts.Select(x => new MyPostViewModel
                    {
                        Content = x.Content,
                        Username = username,
                        postSlug = x.Slug,
                        userSlug = x.UserRefId,
                        Date = x.DateCreated,
                        Title = x.Title
                    }).ToList();
                    return View(postsViewModel);
                }
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreatePostViewModel model)
        {
            bool val1 = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (ModelState.IsValid && val1)
            {

                
                var post = new Post(model.Title, model.Content, User.Identity.GetUserId());
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}