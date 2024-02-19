using MovieReviewWebAPI.Data;
using MovieReviewWebAPI.Models;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.MoviesProductions.Any())
            {
                var movieProductions = new List<MovieProduction>()
                {
                    new MovieProduction()
                    {
                        Movie = new Movie()
                        {
                            Name = "The Notebook",
                            ReleaseDate = new DateTime(2004,4,5),
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre { Genre = new Genre() { Name = "Romance"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="The Notebook",Text = "The notebook is the best movie, because it is heart warming", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="The Notebook", Text = "The Notebook is the best a romance movie", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="The Notebook",Text = "The notebook, notebook, notebook", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Production = new Production()
                        {
                            Name = "Woner Bros",
                            Country = new Country()
                            {
                                Name = "United State"
                            }
                        }
                    },
                    new MovieProduction()
                    {
                        Movie = new Movie()
                        {
                            Name = "The Endgame",
                            ReleaseDate = new DateTime(2022,2,21),
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre { Genre = new Genre() { Name = "Action"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "The Endgame", Text = "The Endgame is the best action movie, because it is very exciting", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title= "The Endgame",Text = "The Endgame is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title= "The Endgame", Text = "The Endgame, The Endgame, The Endgame", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Production = new Production()
                        {
                            Name = "Disney",
                            Country = new Country()
                            {
                                Name = "United State"
                            }
                        }
                    },
                                    new MovieProduction()
                    {
                        Movie = new Movie()
                        {
                            Name = "The Avater",
                            ReleaseDate = new DateTime(2009,12,17),
                            MovieGenres = new List<MovieGenre>()
                            {
                                new MovieGenre { Genre = new Genre() { Name = "Sci-Fi"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="The Avater",Text = "The Avater is the best Sci-Fi movie, because it is very interesting", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                                new Review { Title="The Avater",Text = "The Avater is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                                new Review { Title="The Avater",Text = "The Avater, The Avater, The Avater", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Production = new Production()
                        {
                            Name = "DreamWorks",
                            Country = new Country()
                            {
                                Name = "United State"
                            }
                        }
                    }
                };
                dataContext.MoviesProductions.AddRange(movieProductions);
                dataContext.SaveChanges();
            }
        }
    }
}
