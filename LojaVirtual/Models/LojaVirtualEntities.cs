using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace LojaVirtual.Models
{
    public class LojaVirtualEntities : DbContext
    {
        public LojaVirtualEntities()
            : base("name=LojaVirtualEntities")
        {
        }

        public virtual DbSet<Manga> Mangas { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}