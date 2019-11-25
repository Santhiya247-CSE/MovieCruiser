namespace MovieCruiser
{
    using MovieCruiser;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MovieEntity : DbContext
    {

        public MovieEntity()
            : base("name=MovieEntity")
        {
        }
        public DbSet<Movie> movie { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Favorite> favorite { get; set; }

    }
}