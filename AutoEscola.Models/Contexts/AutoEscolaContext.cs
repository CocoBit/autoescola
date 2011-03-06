using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using AutoEscola.Models;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>().ToTable("empresas");
            modelBuilder.Entity<Aluno>().ToTable("alunos");
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Endereco>().ToTable("enderecos");
            modelBuilder.Entity<Bairro>().ToTable("bairros");
            modelBuilder.Entity<Contato>().ToTable("contatos");
        }
    }
}
