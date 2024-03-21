using Microsoft.EntityFrameworkCore;
using Postland.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postland.Persistence
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options)
           : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categoryGuid = "B0788D2F800343C192A4EDC76A7C5DDE";
            var postGuid = "6313179F7837473AA4D5A5571B43E6A6";
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = categoryGuid,
                Name = "Technology"
            });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = postGuid,
                Title = "Introduction to CQRS and Mediator Patterns",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat",
                ImageUrl = "https://api.khalidessaadani.com/uploads/articles_bg.jpg",
                CategoryId = "B0788D2F800343C192A4EDC76A7C5DDE"
            });

        }
    }
}
