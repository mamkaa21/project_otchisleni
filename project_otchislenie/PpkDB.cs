using Microsoft.EntityFrameworkCore;
using project_otchislenie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_otchislenie
{
    public class PpkDB: DbContext
    {
        private readonly string filename;
        
        public DbSet<Student> Students { get; set; }
        public DbSet<ResignationLetter> ResignationLetters { get; set; }
        public DbSet<User> Users { get; set; }

        public PpkDB(string filename)
        { 
            this.filename = filename;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={filename}");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
