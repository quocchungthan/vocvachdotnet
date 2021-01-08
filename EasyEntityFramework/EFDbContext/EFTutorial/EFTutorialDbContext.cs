using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using EasyEntityFramework.Entities.Tutorial;
using Microsoft.EntityFrameworkCore;

namespace EasyEntityFramework.EFDbContext.EFTutorial
{
    class EFTutorialDbContext: DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public EFTutorialDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //AA
            //options.usesq
            //options.UseSqlite("Data Source=blogging.db");
        }
    }
}
