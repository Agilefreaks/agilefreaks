﻿using System.Web.Mvc;

namespace AgileFreaks.Controllers
{
    public class TasksController : Controller
    {
        //
        // GET: /Tasks/

        public ActionResult Index()
        {
            return View();
        }
    }
}
