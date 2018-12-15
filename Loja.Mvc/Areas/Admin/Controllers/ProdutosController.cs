using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Mvc.Areas.Admin.Models;
using Loja.Mvc.Helpers;
using Loja.Mvc.Mapeamento;
using Loja.Repositorios.SqlServer;

namespace Loja.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly LojaDbContext db = new LojaDbContext();
        private readonly ProdutoMapeamento map = new ProdutoMapeamento();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(map.Mapear(db.Produtos.ToList()));
        }

        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        public ActionResult Create()
        {
            return View(map.Mapear(new Produto(), db.Categorias.ToList()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = map.Mapear(viewModel, db);

                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.ProdutoImagems, "ProdutoId", "ContentType", viewModel.Id);
            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            ViewBag.Id = new SelectList(db.ProdutoImagems, "ProdutoId", "ContentType", produto.Id);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Preco,Estoque,Ativo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.ProdutoImagems, "ProdutoId", "ContentType", produto.Id);
            return View(produto);
        }

        //[Authorize(Users = "avelino.vitor@gmail.com")]
        //[Authorize(Roles = "Master, Gerente")]
        [AuthorizeRole(PerfilUsuario.Gerente, PerfilUsuario.Master)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(map.Mapear(produto));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ActionName("Categoria")]
        public JsonResult ObterProdutoPorCategoria(int categoriaId)
        {
            var produtos = db.Produtos
                .Where(p => p.Categoria.Id == categoriaId)
                .Select(p => new { p.Nome, p.Preco, p.Estoque })
                .ToList();

            return Json(produtos, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}