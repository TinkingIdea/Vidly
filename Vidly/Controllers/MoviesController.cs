using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		private readonly ApplicationDbContext _db;
		public MoviesController()
		{
			_db = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_db.Dispose();
		}

		// GET: Movies
		public ActionResult Random()
		{
			Movie movies = new Movie() { Name = "TinkingIdea!" };
			//			//return View(movies);    //返回视图并传递数据
			//			//return PartialView();   //返回分布视图
			//			//return Content("Hello");    //返回文本
			//			//return Redirect();      //重定向到视图
			//			//return Json();          //返回Json
			//			//return HttpNotFound();      //返回404 Not Fount页面
			//			//return new EmptyResult();   //返回空白页面
			//			//return RedirectToAction("Index", "Movies", new { pageIndex = 1, sortBy = "hello" }); //跳转到指定的action
			//
			//			var customers = new List<Customer>
			//	        {
			//				new Customer{Name="Customer1"},
			//				new Customer{Name="Customer2"}
			//	        };
			//	        var viewModel = new RandomMovieViewModel
			//	        {
			//		        Movie = movies,
			//		        Customer = customers
			//	        };
			//	        //var movie = "movie";
			//	        //ViewData["RandomMovie"] = movie;	//ViewData传值
			//	        //ViewBag.RandomMovie = movie;		//ViewBag传值
			//	        //return View(movies);				//传递Movie对象
			return View();              //传递viewModel对象
		}

		public ActionResult Exit(int id)
		{
			return Content("id=" + id);
		}

		public ViewResult Index()
		{
			var movies = _db.Movies.Include(c => c.Genre).ToList();
			return View(movies);
		}

		[Route("Movies/released/{year}/{month}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if (movie.Id == 0)
				_db.Movies.Add(movie);
			else
			{
				var movieInDb = _db.Movies.SingleOrDefault(c => c.Id == movie.Id);
				movieInDb.Name = movie.Name;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
				movieInDb.ReleaseDate = movie.ReleaseDate;
			}

			_db.SaveChanges();

			return RedirectToAction("Index", "Movies");
		}

		public ActionResult MovieForm()
		{
			var viewModel = new MovieFormViewModel
			{
				Genres = _db.Genres.ToList()
			};
			return View(viewModel);
		}

		public ActionResult Edit(int id)
		{
			var movies = _db.Movies.SingleOrDefault(c => c.Id == id);

			if (movies == null)
				return HttpNotFound();

			var viewModel = new MovieFormViewModel(movies)
			{
				Genres = _db.Genres.ToList()
			};
			return View("MovieForm", viewModel);
		}
	}
}