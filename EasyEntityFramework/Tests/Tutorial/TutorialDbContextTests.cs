using System;
using System.Collections.Generic;
using System.Linq;
using EasyEntityFramework.EFDbContext.EFTutorial;
using EasyEntityFramework.Entities.Tutorial;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EasyEntityFramework.Tests.Tutorial
{
    public class TutorialDbContextTests
    {
        [Fact]
        public void BasicTest()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void CRUD()
        {
            var builder = new DbContextOptionsBuilder<EFTutorialDbContext>().UseSqlite("Data Source=blogging_IT_test" + Guid.NewGuid().ToString() + ".db");
            using (var db = new EFTutorialDbContext(builder.Options))
            {
                db.Database.Migrate();
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.Id)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts = new List<Post>();
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}
