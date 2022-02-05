using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_CF.Models
{
    public class Classificacao
    {
        [Key]
        public int id { get; set; }

        public string nome { get; set; }

        public int id_aluno { get; set; }

        public int id_uc { get; set; }

        public int id_epoca { get; set; }

        public int nota { get; set; }

        public string obs { get; set; }


        public virtual Aluno Aluno { get; set; }
        public virtual Epoca Epoca { get; set; }
        public virtual UC UC { get; set; }
    }
}