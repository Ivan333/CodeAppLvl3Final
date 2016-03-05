using NewBlogPlatform.Models;
using NewBlogPlatform.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Data.Entity;

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
                Title = x.Title,
                postSlug = x.Slug,
                postId = x.Id,
                Content = x.Content,
                ImageUrl = x.ImageUrl
            }).ToList();
            return View(postsViewModel);
        }


        public ActionResult Details(string slug)
        {
            var username = User.Identity.GetUserName();
            var post = db.Posts.SingleOrDefault(x => x.Slug == slug);
            if (post != null) {
                return View(post);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult MyPosts()
        {
            
            var id = User.Identity.GetUserId();
            var username = User.Identity.GetUserName();
            var userPosts = db.Posts.Where(x => x.UserRefId == id);
               
            var postsViewModel = userPosts.Select(x => new MyPostViewModel
            {
                Content = x.Content,
                Username = username,
                postSlug = x.Slug,
                userSlug = x.UserRefId,
                Date = x.DateCreated,
                Title = x.Title,
                postId = x.Id,
                ImageUrl = x.ImageUrl
            }).ToList();
            return View(postsViewModel);
                
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

                
                var post = new Post(model.Title, model.Content, User.Identity.GetUserId(),model.ImageUrl);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }
        /*
        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }
        */
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var post = db.Posts.Find(id);

            if(post == null)
            {
                return RedirectToAction("Index");
            }

            
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("MyPosts");
        }

    }
}