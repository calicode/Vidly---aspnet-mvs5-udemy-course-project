using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
namespace Vidly.Controllers
{


    public class MoviesController : Controller
    {



        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}

            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers

            };
            return View(viewModel);
        }

        public ActionResult MovieList()
        {

            List<Movie> movieList = new List<Movie>
            {
                new Movie { Name = "Bill and Teds bogus journey" },
                new Movie { Name = "Dr Strange. " },
                new Movie { Name = "Stalker" },
                new Movie { Name = "Yakkity sax" }
            };


            var viewModel = new MovieListViewModel { MovieList = movieList };



            return View(viewModel);
        }

        public ActionResult CustomerList()
        {
            List<Customer> customerList = new List<Customer>
            {
                new Customer { Name = "Bobert smirth" },
                new Customer { Name = "Satan" },
                new Customer { Name = "Grumpy cat" }
            };
            var viewModel = new CustomerListViewModel { CustomerList = customerList };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("blah " + id);
        }

        //attribute routing
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)})")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        // int? makes the parameteter nullable. string is nullable by default
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) { pageIndex = 1; }
            if (String.IsNullOrWhiteSpace(sortBy)) { sortBy = "Name"; }


            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}