using Microsoft.EntityFrameworkCore;
using MovieReviewWebAPI.Models;

namespace MovieReviewWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieProduction> MoviesProductions { get; set; }
        public DbSet<MovieGenre> MoviesGenres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Movie and Genre Joint Table (Many to Many)
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });
            modelBuilder.Entity<MovieGenre>()
                .HasOne(m => m.Movie)
                .WithMany(mg => mg.MovieGenres)
                .HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(g => g.Genre)
                .WithMany(mg => mg.MovieGenres)
                .HasForeignKey(g => g.GenreId);

            // Movie and Production Joint Table (Many to Many)
            modelBuilder.Entity<MovieProduction>()
                .HasKey(mp => new { mp.MovieId, mp.ProductionId });
            modelBuilder.Entity<MovieProduction>()
                .HasOne(m => m.Movie)
                .WithMany(mp => mp.MovieProductions)
                .HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<MovieProduction>()
                .HasOne(p => p.Production)
                .WithMany(mp => mp.MovieProductions)
                .HasForeignKey(p => p.ProductionId);
        }
    }
}
