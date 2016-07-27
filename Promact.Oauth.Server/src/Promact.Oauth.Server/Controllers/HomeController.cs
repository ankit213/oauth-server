﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Promact.Oauth.Server.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return View("Index");
            }
            else
            {
                if(User.IsInRole("Admin"))
                {
                    return View("Admin");
                }
                return View("Index");
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
