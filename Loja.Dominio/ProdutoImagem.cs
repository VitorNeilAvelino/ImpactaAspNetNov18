﻿namespace Loja.Dominio
{
    public class ProdutoImagem
    {
        //[Key]
        public int ProdutoId { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }

        public virtual Produto Produto { get; set; }
    }
}