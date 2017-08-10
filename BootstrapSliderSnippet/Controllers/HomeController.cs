using BootstrapSliderSnippet.Models;
using BootstrapSliderSnippet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapSliderSnippet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new SliderContext();
            var vm = new HomeIndexVM();
            vm.ImageSlides = db.ImageSlides.ToList();

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}