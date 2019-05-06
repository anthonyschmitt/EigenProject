using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EigenprojectProject.Models;
using EigenprojectProject.ViewModels;
using EigenprojectProject.ViewModels.post;
using EigenprojectProject.Data;
using EigenprojectProject.Interfaces;
using EigenprojectProject.Data.ContextInterfaces;
using EigenprojectProject.Logic;
using EigenprojectProject.Logic.Models;

namespace EigenprojectProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPostContext _IPostContext;
        private PostLogic postLogic;

        public HomeController(IPostContext postContext)
        {
            _IPostContext = postContext;
            postLogic = new PostLogic(_IPostContext);
        }
        public IActionResult Index()
        {
            IList<PostViewModel> vmPost = new List<PostViewModel>();
            foreach (var item in postLogic.GetAllPosts())
            {
                vmPost.Add(new PostViewModel
                {
                    Id = item.Id,
                    Afbeelding = item.Afbeelding,
                    Titel = item.Titel,
                    Vraag = item.Vraag,
                    PostId = item.PostId
                });
            }
            return View(vmPost);
        }

        public IActionResult CreatePartialPost()
        {
            return View();
        }

        public IActionResult DeletePost(int id)
        {
            postLogic.DeletePost(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreatePost(PostViewModel model)
        {
            IPost post = new Post
            {
                Afbeelding = model.Afbeelding,
                Titel = model.Titel,
                Vraag = model.Vraag
            };
            postLogic.AddPost(post, HttpContext.Session.GetInt32("ID").GetValueOrDefault());
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        public IActionResult Register()
        {
            return RedirectToAction("Register","User");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
