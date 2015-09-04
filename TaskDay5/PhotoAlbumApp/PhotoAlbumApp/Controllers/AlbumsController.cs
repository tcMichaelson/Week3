using AutoMapper;
using PhotoAlbumApp.Models;
using PhotoAlbumApp.Presentation.Web;
using PhotoAlbumApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoAlbumApp.Controllers {

    public class AlbumsController : Controller
    {

        private AlbumsServices _service;

        public AlbumsController(AlbumsServices service) {
            _service = service;
        }

        // GET: Albums
        public ActionResult Index()
        {

            return View(_service.ListAlbums());
        }


        // GET: Albums/Details/5
        public ActionResult ViewPics(string name)
        {
            AlbumViewModel vm = new AlbumViewModel();
            var album = _service.GetAlbumByName(name);
            var pics = album.Photos;
            List<PhotoDTO> picsToShow = new List<PhotoDTO>();
            foreach (var photo in pics) {
                picsToShow.Add(Mapper.Map<PhotoDTO>(photo));
            }
            vm.Photos = picsToShow;
            vm.Album = Mapper.Map<AlbumDTO>(album);
            return View(vm);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(AlbumDTO album)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    //Album newAlbum = new Album {
                    //    Name = album.Name
                    //};
                    _service.CreateAlbum(album);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Albums/Edit/5
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

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Albums/Delete/5
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
