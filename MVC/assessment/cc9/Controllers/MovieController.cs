using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cc9.Models;
using cc9.Repository;


namespace cc9.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IRepository<Movie> _movieRepository;

        public MoviesController()
        {
            var context = new MoviesContext();
            _movieRepository = new Repository<Movie>(context);
        }

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _movieRepository.GetAll();
            return View(movies);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Insert(movie);
                _movieRepository.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Update(movie);
                _movieRepository.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie != null)
            {
                _movieRepository.Delete(id);
                _movieRepository.Save();
            }
            return RedirectToAction("Index");
        }

        // GET: Movies/ByYear/2010
        public ActionResult ByYear(int year)
        {
            var movies = _movieRepository.GetAll().Where(m => m.DateofRelease.Year == year);
            return View(movies);
        }
    }
}