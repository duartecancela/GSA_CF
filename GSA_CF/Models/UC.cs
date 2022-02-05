using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GSA_CF.Models
{
    public class UC
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }

        public virtual ICollection<Classificacao> Classificacao { get; set; }

    }
}