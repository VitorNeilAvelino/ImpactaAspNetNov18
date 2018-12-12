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
            foreach (var usuario in db.Usuarios.ToList())
            {
                System.Console.WriteLine(usuario.Nome);
            }
        }
    }
}