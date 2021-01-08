using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using EasyEntityFramework.Entities.Tutorial;
using Microsoft.EntityFrameworkCore;

namespace EasyEntityFramework.EFDbContext.EFTutorial
{
    public class EFTutorialDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public EFTutorialDbContext() : base()
        {
        }

        public EFTutorialDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //AA
            //options.usesq
            options.UseSqlServer("Server=192.168.79.157,2022;Database=easyapple;User Id=sa;Password=Pass@word;");
            //options.UseSqlite("Data Source=blogging.db");
        }
    }
}
