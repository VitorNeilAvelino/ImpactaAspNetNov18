using Loja.Dominio;
using Loja.Repositorios.SqlServer.Migrations;
using Loja.Repositorios.SqlServer.ModelConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Loja.Repositorios.SqlServer
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext() : base("lojaSqlServer")
        {
            //Database.SetInitializer(new LojaDbInitializer());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}