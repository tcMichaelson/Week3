using AutoMapper;
using PhotoAlbumApp.Models;
using PhotoAlbumApp.Presentation.Web;
using PhotoAlbumApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoAlbumApp.Controllers
{

    public class PhotosController : Controller {

        private PhotosServices _service;

        public PhotosController(PhotosServices service) {
            _service = service;
        }
        
        // GET: Photos/Add
        public ActionResult Add(string albumName)
        {
            AddPhotoViewModel vm = new AddPhotoViewModel();
            vm.AlbumName = albumName;
            return View(vm);
        }

        // POST: Photos/Add
        [HttpPost]
        public ActionResult Add(PhotoDTO photo, HttpPostedFileBase file, string albumName)
        {
            try
            {
                if (ModelState.IsValid) {
                    // TODO: Add insert logic here
                    var fileName = Path.Combine(Server.MapPath("../Uploads"), DateTime.Now.Ticks.ToString() + file.FileName);
                    file.SaveAs(fileName);

                    _service.AddPhoto(albumName, photo, fileName);
                    return RedirectToAction("Index", "Albums");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Photos/Edit/5
        public ActionResult Edit(string pathName) {
            _service.UpdatePhoto(pathName);

            return RedirectToAction("View","Albums");
        }

        // POST: Photos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Photos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Photos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
