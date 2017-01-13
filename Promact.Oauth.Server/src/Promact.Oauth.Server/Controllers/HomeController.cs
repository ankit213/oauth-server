﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Promact.Oauth.Server.Models;
using Promact.Oauth.Server.Models.ApplicationClasses;
using Promact.Oauth.Server.Constants;
using System.Threading.Tasks;

namespace Promact.Oauth.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringConstant _stringConstant;
        public HomeController(UserManager<ApplicationUser> userManager, IStringConstant stringConstant)
        {
            _userManager = userManager;
            _stringConstant = stringConstant;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                UserRoleAc userRole;
                if (User.IsInRole(_stringConstant.RoleAdmin))
                {
                    userRole = new UserRoleAc(user.Id, user.Email, user.FirstName, _stringConstant.RoleAdmin);
                }
                else
                {
                    userRole = new UserRoleAc(user.Id, user.Email, user.FirstName, _stringConstant.RoleEmployee);
                }
                ViewData["UserRole"] = userRole;
                return View("Index");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
