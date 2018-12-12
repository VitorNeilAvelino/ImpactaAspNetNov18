namespace Loja.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarProdutoDescontinuadoParaAtivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Ativo", c => c.Boolean(nullable: false));
            DropColumn("dbo.Produto", "Descontinuado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Descontinuado", c => c.Boolean(nullable: false));
            DropColumn("dbo.Produto", "Ativo");
        }
    }
}
