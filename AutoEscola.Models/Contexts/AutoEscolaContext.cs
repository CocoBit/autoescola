using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using AutoEscola.Models;
using System.Data.Entity.Database;

namespace AutoEscola.Contexts.Models
{
    public class AutoEscolaContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>();
            modelBuilder.Entity<Aluno>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Endereco>();
            modelBuilder.Entity<Bairro>();
            modelBuilder.Entity<Contato>();
            modelBuilder.Entity<Pessoa>();

            DbDatabase.SetInitializer<AutoEscolaContext>(new CreateDatabaseIfNotExists<AutoEscolaContext>());
        }
    }
}
