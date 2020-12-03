using MVCMoviesDetails.Models.Movies;using System.Collections.Generic;namespace MVCMoviesDetails.Data{    public class MovieData    {        static List<MovieModel> movielist = new List<MovieModel>();        public static List<MovieModel> GetMovieList()        {            movielist = new List<MovieModel>()            {               new MovieModel
                {
                    MovieId = 1,
                    MovieName  = "Sanam Teri Kasam",
                    ReleaseYear = "2016",
                    Genre = "Romance"
                },
                 new MovieModel
                {
                    MovieId = 2,
                    MovieName  = "War",
                    ReleaseYear = "2019",
                    Genre = "Action"
                },
                  new MovieModel
                {
                    MovieId = 3,
                    MovieName  = "The Prodigy",
                    ReleaseYear = "2019",
                    Genre = "Horror"
                },
                   new MovieModel
                {
                    MovieId = 4,
                    MovieName  = "Good Newz",
                    ReleaseYear = "2019",
                    Genre = "Comedy"
                },
                    new MovieModel
                {
                    MovieId = 5,
                    MovieName  = "Qismat",
                    ReleaseYear = "2018",
                    Genre = "Romance"
                }            };

            return movielist;        }        public static List<MovieModel> FilterData(int id)        {            List<MovieModel> filterList = movielist.FindAll(            delegate (MovieModel movie)            {                return movie.MovieId == id;            }            );            return filterList;        }        public static List<MovieModel> InsertData(int movieId, string movieName, string releaseYear, string genre)
        {
            movielist.Add(new MovieModel()
            {
                MovieId = movieId,
                MovieName = movieName,
                ReleaseYear = releaseYear,
                Genre = genre
            }) ;
            return movielist;

           
        }        public static List<MovieModel> UpdateData(int UpdateId, MovieModel movie)
        {
            for(int loop=0; loop<movielist.Count; loop++)
            {
                if (movielist[loop].MovieId == UpdateId)
                {
                    movielist.RemoveAt(loop);
                    movielist.Insert(loop, movie);
                    break;
                }
                
            }
            return movielist;
        }


        public static List<MovieModel> DeleteData(int Id)
        {
            for (int loop = 0; loop < movielist.Count; loop++)
            {
                if (movielist[loop].MovieId == Id)
                {
                    movielist.RemoveAt(loop);
                    break;
                }

            }
            return movielist;
        }    }}