using Gerenciador_Cursos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_Cursos.Data
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options) : base(options) 
        {

        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Curso>(e =>
            {
                e.ToTable("Curso");
                e.HasKey(p => p.Id);
                e.Property(p => p.Titulo).HasColumnType("varchar(60)").IsRequired();
                e.Property(p => p.DuracaoMes).HasColumnType("varchar(60)").IsRequired();
                e.Property(p => p.Status).HasConversion<string>();
            });

        }

    }
}