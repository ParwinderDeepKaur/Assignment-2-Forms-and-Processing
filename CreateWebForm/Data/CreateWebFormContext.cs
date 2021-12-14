using CreateWebForm.Model;
using Microsoft.EntityFrameworkCore;
using System;


namespace CreateWebForm.Data
{
    public class CreateWebFormContext : DbContext
    {

        public DbSet<CreateWebFormTable> FormTable { get; set; }

        public string DbPath { get; private set; }

        public CreateWebFormContext()
        {
            var path = Environment.CurrentDirectory;
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}CreateWebForm.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

}
