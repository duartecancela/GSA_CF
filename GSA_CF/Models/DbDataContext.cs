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

        public DbSet<Aluno> Aluno { get; set; }

        public DbSet<Classificacao> Classificacao { get; set; }
        public DbSet<Epoca> Epoca { get; set; }
        public DbSet<UC> UC { get; set; }
    }
}