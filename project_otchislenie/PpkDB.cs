using Microsoft.EntityFrameworkCore;
using project_otchislenie.Models;
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
        public DbSet<Resignationletter> Resignationletters { get; set; }
        public DbSet<User> Users { get; set; }

        public PpkDB(string filename)
        { 
            this.filename = filename;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var splitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Database");
            Directory.CreateDirectory(splitePath);
            var fileName = $"{splitePath}\f{filename}";
            if (!File.Exists(fileName))
                File.Create(fileName);
            optionsBuilder.UseSqlite($"Data Source={fileName}");
            base.OnConfiguring(optionsBuilder);
            
        }


    }
}
