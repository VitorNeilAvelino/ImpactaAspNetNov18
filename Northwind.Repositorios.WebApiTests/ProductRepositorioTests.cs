using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Repositorios.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi.Tests
{
    [TestClass()]
    public class ProductRepositorioTests
    {
        private readonly ProductRepositorio repositorio = new ProductRepositorio();

        [TestMethod()]
        public void PostTest()
        {
            var product = new ProductViewModel();
            product.ProductName = "Geléia";
            product.UnitPrice = 21.57m;

            var response = repositorio.Post(product).Result;

            Console.WriteLine(response.ProductID);
        }

        [TestMethod]
        public void PutTeste()
        {
            var product = new ProductViewModel();
            product.ProductName = "Geléia editado";
            product.UnitPrice = 21.08m;
            product.ProductID = 80;

            repositorio.Put(product).Wait();

            var response = repositorio.Get(80).Result;

            Assert.IsTrue(response.UnitPrice == 21.08m);
        }

        [TestMethod]
        public void GetTeste()
        {
            Assert.IsTrue(repositorio.Get().Result.Count > 0);
        }

        [TestMethod]
        public void DeleteTeste()
        {
            repositorio.Delete(80).Wait();

            var response = repositorio.Get(80).Result;

            Assert.IsNull(response);            
        }
    }
}