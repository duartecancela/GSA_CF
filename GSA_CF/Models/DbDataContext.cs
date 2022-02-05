using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GSA_CF.Models
{
    public class DbDataContext : DbContext
    {
        public DbDataContext() : base("DataBaseConnection")
        {

        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Classificacao> Classificacoes { get; set; }
        public DbSet<Epoca> Epocas { get; set; }
        public DbSet<UC> UCs { get; set; }
    }
}