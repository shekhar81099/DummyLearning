using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testapi.Models
{
    public class SuperHero
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;

        public virtual List<SuperPower>? SuperPowers { get; set; } = null;

    }
    public class SuperPower
    {
        public int Id { get; set; }
        public string? SuperPowerName { get; set; } = string.Empty;

        public virtual SuperHero SuperHero { get; set; } = null;


    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
    public class Blog
    {
        public int Id { get; set; }
        public ICollection<Post> Posts { get; } = new List<Post>(); // Collection navigation containing dependents
    }

    // Dependent (child)
    public class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; } // Required foreign key property
        public Blog Blog { get; set; } = null!; // Required reference navigation to principal
    }
}