using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BootstrapSliderSnippet.Models;
using System.IO;

namespace BootstrapSliderSnippet.Controllers
{
    public class ImageSlidesController : Controller
    {
        private SliderContext db;

        public ImageSlidesController()
        {
            this.db = new SliderContext();
        }

        // GET: ImageSlides
        public ActionResult Index()
        {
            var imageSlides = new List<ImageSlide>();
            if (db.ImageSlides.ToList().Count > 0)
            {
                imageSlides = db.ImageSlides.ToList();
            }

            return View(imageSlides);
        }

        // GET: ImageSlides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ImageSlide imageSlide = db.ImageSlides.Find(id);
            if (imageSlide == null)
            {
                return HttpNotFound();
            }

            return View(imageSlide);
        }

        // GET: ImageSlides/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageSlide model)
        {
            if (ModelState.IsValid)
            {
                // Verify that the user selected a file
                if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
                {
                    var fileType = Path.GetExtension(model.ImageFile.FileName);
                    var fileName = Guid.NewGuid().ToString() + fileType;

                    // store the file inside ~/Images/Uploads folder
                    var path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                    model.ImageFile.SaveAs(path);

                    // Save web url
                    model.ImageUrl = Url.Content(string.Format("~/Images/Uploads/{0}", fileName));
                }

                db.ImageSlides.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ImageSlides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ImageSlide imageSlide = db.ImageSlides.Find(id);
            if (imageSlide == null)
            {
                return HttpNotFound();
            }

            return View(imageSlide);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ImageSlide model)
        {
            if (ModelState.IsValid)
            {
                // Verify that the user selected a file
                if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
                {
                    var fileType = Path.GetExtension(model.ImageFile.FileName);
                    var fileName = Guid.NewGuid().ToString() + fileType;

                    // store the file inside ~/Images/Uploads folder
                    var path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                    model.ImageFile.SaveAs(path);

                    // Save web url
                    model.ImageUrl = Url.Content(string.Format("~/Images/Uploads/{0}", fileName));
                }

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ImageSlides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ImageSlide imageSlide = db.ImageSlides.Find(id);
            if (imageSlide == null)
            {
                return HttpNotFound();
            }

            return View(imageSlide);
        }

        // POST: ImageSlides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImageSlide imageSlide = db.ImageSlides.Find(id);
            db.ImageSlides.Remove(imageSlide);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
