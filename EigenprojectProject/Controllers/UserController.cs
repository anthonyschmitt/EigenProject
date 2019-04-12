using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.ContextInterfaces;
using LogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using EigenprojectProject.Models;
using EigenprojectProject.ViewModels;

namespace EigenprojectProject.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserContext _userContext;
        private UserLogic userLogic;

        public UserController(IUserContext userContext)
        {
            _userContext = userContext;
            userLogic = new UserLogic(_userContext);
        }

        // GET: User
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        // GET: User/Details/5
        public ActionResult Details()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View("~/Views/Account/Login.cshtml");
            }
            var context = userLogic.GetUserByUsername(HttpContext.Session.GetString("Username"));
            var model = new UserViewModel
            {
                UserId = context.UserId,
                Username = context.Username,
                Password = context.Password,
                Email = context.Email,
                Firstname = context.Firstname,
                Lastname = context.Lastname
            };
            return View("~/Views/Account/AccountDetails.cshtml", model);
        }

        // GET: User/Create
        public ActionResult Register()
        {
           // if (HttpContext.Session.GetString("Username") == null ||  HttpContext.Session.GetInt32("AccessLevel") <= 0)
           // {
           //     return View("~/Views/Account/Login.cshtml");
           // }

            return View("~/Views/Account/Register.cshtml");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: User/Login
        public ActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }

        // POST: User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            try
            {
                if (userLogic.Login(username, password) && ModelState.IsValid)
                {
                    HttpContext.Session.SetString("Username", userLogic.GetUserByUsername(username).Username);
                    HttpContext.Session.SetInt32("AccessLevel",Convert.ToInt32(userLogic.GetUserByUsername(username).AccessLevel));
                    ViewBag.Username = HttpContext.Session.GetString("Username");
                    ViewBag.AccLevel = ViewBag.AccLayer = _userContext.GetAccLevel(HttpContext.Session.GetString("Username"));
                    return View("~/Views/Home/Index.cshtml");
                }
                ViewBag.errorMessage = "Wachtwoord en gebruikersnaam komt niet overeen.";
                return View("~/Views/Account/Login.cshtml");

            }
            catch
            {
                ViewBag.errorMessage = "Er is een fout opgetreden.";
                return View("~/Views/Account/Login.cshtml");
            }

        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel newUser)
        {
            if (ModelState.IsValid && userLogic.IsUsernameTaken(newUser.Username) == false)
            {
               try
               {
                    userLogic.AddUser(newUser);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return View("~/Views/Account/Register.cshtml");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "User");
            }
            var context = userLogic.GetUserByUsername(HttpContext.Session.GetString("Username"));
            var model = new UserViewModel
            {
                UserId = context.UserId,
                Username = context.Username,
                Password = context.Password,
                Email = context.Email,
                Firstname = context.Firstname,
                Lastname = context.Lastname
            };
            return View("~/Views/Account/EditAccount.cshtml", model);

        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel updatedUserViewModel)
        {
            try
            {
                //Todo: add username is taken check
                userLogic.UpdateUser(updatedUserViewModel, userLogic.GetUserByUsername(HttpContext.Session.GetString("Username")).UserId);
                return RedirectToAction(nameof(Details));

            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        public ActionResult UsersOverview()
        {
            if (HttpContext.Session.GetString("Username") == null || HttpContext.Session.GetInt32("AccessLevel") <= 0)
            {
                return RedirectToAction("Login", "User");
            }
            var context = userLogic.GetUsers();
            var model = context.Select(user => new UserOverviewViewModel(user.UserId, user.Username, user.Firstname, user.Lastname, user.Email, user.Password, user.AccessLevel)).ToList();
            return View("~/Views/Account/UsersOverview.cshtml",model);
        }
    }
}