﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loja.Resources;

namespace Loja.Mvc.Areas.Admin.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = nameof(Literais.NomeProdutoLabel), ResourceType = typeof(Literais))]
        public string Nome { get; set; }

        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        public List<SelectListItem> Categorias { get; set; } = new List<SelectListItem>();

        [Required]
        [Display(Name = "Preço")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        public bool Ativo { get; set; } = true;
    }
}