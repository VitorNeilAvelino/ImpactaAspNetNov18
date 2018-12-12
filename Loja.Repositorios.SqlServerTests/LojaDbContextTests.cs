using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Loja.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private readonly LojaDbContext db = new LojaDbContext();

        [TestMethod()]
        public void LojaDbContextTest()
        {
            var produtos = db.Produtos.ToList();
        }
    }
}