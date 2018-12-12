using System.Data.Entity;

namespace Loja.Repositorios.SqlServer
{
    internal class LojaDbInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            //base.Seed(context);
        }
    }
}