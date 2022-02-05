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
        public int Id { get; set; }

        public string Nome { get; set; }

        public int AlunoId { get; set; }

        public int UcId { get; set; }

        public int EpocaId { get; set; }

        public int Nota { get; set; }

        public string Obs { get; set; }


        public virtual Aluno Aluno { get; set; }
        public virtual Epoca Epoca { get; set; }
        public virtual UC Uc { get; set; }
    }
}