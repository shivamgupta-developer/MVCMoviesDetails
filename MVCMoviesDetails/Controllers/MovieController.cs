using Microsoft.AspNetCore.Mvc;
using MVCMoviesDetails.Data;
using MVCMoviesDetails.Models.Movies;

namespace MVCMoviesDetails.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            var model = MovieData.GetMovieList();
            return View(model);
        }        
        public IActionResult SearchById(int id)
        {       
            var movies = MovieData.FilterData(id);
            if (movies.Count != 0)
            {
                return PartialView("~/Views/Movie/_FilterMovieDetailsPartial.cshtml", movies);
            }

            else
            {
                return PartialView("~/Views/Movie/_EmptyPartial.cshtml");
            }

        }
        public IActionResult InsertView()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult InsertView(int Id, string Name, string releaseYear, string movieGenre)
        {

            if(Id==0 || Name==null || releaseYear==null || movieGenre == null)
            {
                return PartialView("~/Views/Movie/_WrongInsertion.cshtml");
            }


            //var MovieName = model.MovieName;
            //var ReleaseYear = model.ReleaseYear;
            //var Genre = model.Genre;
            // }
            var detail = MovieData.InsertData(Id, Name, releaseYear, movieGenre);
            return PartialView("~/Views/Movie/_FilterMovieDetailsPartial.cshtml",detail);
        }
        public IActionResult UpdateView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateView( MovieModel model)
        {
            
            var MovieId = model.MovieId;
            var MovieName = model.MovieName;
            var ReleaseYear = model.ReleaseYear;
            var Genre = model.Genre;
            if (model.MovieId == 0 || model.MovieName == null || model.ReleaseYear == null || model.Genre== null)
            {
                return PartialView("~/Views/Movie/_WrongInsertion.cshtml");
            }
            var select = MovieData.FilterData(MovieId);
            if (select.Count == 0)
            {
                return PartialView("~/Views/Movie/_EmptyPartial.cshtml");
            }
            var Data = MovieData.UpdateData(MovieId, model);
            return PartialView("~/Views/Movie/_FilterMovieDetailsPartial.cshtml", Data);
        }
        public IActionResult DeleteView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteView(int Id)
        {

            if (Id == 0)
            {
                return PartialView("~/Views/Movie/_WrongInsertion.cshtml");
            }
            var select = MovieData.FilterData(Id);
            if (select.Count == 0)
            {
                return PartialView("~/Views/Movie/_EmptyPartial.cshtml");
            }
            var Data = MovieData.DeleteData(Id);
            return PartialView("~/Views/Movie/_FilterMovieDetailsPartial.cshtml", Data);
        }
    }
}
