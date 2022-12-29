﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanSachFahasa.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult _Layout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult _Layout(string Search)
        {
            Session["Tk"] = Search;
            return RedirectToAction("TIMKIEM", "Index");
        }
    }
}