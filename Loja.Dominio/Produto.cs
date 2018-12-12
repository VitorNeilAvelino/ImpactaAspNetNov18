using System.Collections.Generic;

namespace Loja.Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }

        public Categoria Categoria { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public ProdutoImagem Imagem { get; set; }
    }
}