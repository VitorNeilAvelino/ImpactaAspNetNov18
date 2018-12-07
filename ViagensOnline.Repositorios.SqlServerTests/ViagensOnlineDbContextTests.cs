using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnline.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        private readonly ViagensOnlineDbContext db = new ViagensOnlineDbContext();

        [TestMethod()]
        public void InserirTeste()
        {
            var destino = new Destino();

            destino.Cidade = "São Paulo";
            destino.Nome = "Conheça São Paulo";
            destino.NomeImagem = "Paulista.png";
            destino.Pais = "Brasil";

            db.Destinos.Add(destino);

            db.SaveChanges();
        }

        [TestMethod]
        public void AtualizarTeste()
        {
            var destino = db.Destinos.Find(1);

            destino.Pais = "Brazil";
            destino.Cidade = "SP";

            db.SaveChanges();

            destino = db.Destinos.Find(1);

            Assert.AreEqual(destino.Pais, "Brazil");
            Assert.AreEqual(db.Destinos.Find(1).Cidade, destino.Cidade);
        }

        [TestMethod]
        public void ExcluirTeste()
        {
            var destino = db.Destinos.Find(1);

            db.Destinos.Remove(destino);

            db.SaveChanges();
        }
    }
}