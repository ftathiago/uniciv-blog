using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogPessoal.Web.Models
{
    public class CategoriaDeArtigo
    {
        public int Id { get; set; }
        [Required(ErrorMessage= "Informe o nome.")]
        [Display(Name = "Nome da categoria")]
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText, ErrorMessage ="Descrição errada")]
        [StringLength(300, MinimumLength=10)]
        public string Descricao { get; set; }

    }
}