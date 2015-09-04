using MovieAppWithRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieAppWithRepository.Controllers
{
    public class MoviesController : Controller
    {
        private IRepository _repo;

        public MoviesController(IRepository repo) {
            _repo = repo;
        }
        // GET: Movies
        public ActionResult Index()
        {
            return View(_repo.ListMovies());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetMovieById(id));
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(Movie collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    _repo.CreateMovie(collection);
                    return RedirectToAction("Index");
                } else {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetMovieById(id));
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                movie.Id = id;
                // TODO: Add update logic here
                _repo.UpdateMovie(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View(_repo.GetMovieById(id));
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.DeleteMovie(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
