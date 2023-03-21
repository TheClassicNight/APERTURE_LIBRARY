using APERTURE_LIBRARY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APERTURE_LIBRARY.Controllers
{
    public class HomeController : Controller
    {
        LibraryAPEntities db = new LibraryAPEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Books()
        {
            //var lst = db.Libros.ToList();
            var lst = db.Libros.Where(x => x.Activo == true).ToList();
            return View(lst);
        }

        public ActionResult BooksForm()
        {
            var ID = Request.Params["IdLibro"];
            if (ID != null)
            {
                int id = int.Parse(ID);
                var li = db.Libros.Where(x => x.IdLibro == id).FirstOrDefault();
                ViewBag.li = li;
            }
            return View();
        }

        public JsonResult guardarLi(int? IdLibro, string NombreLibro, string Autor, string Editorial, string FPublicacion, float CostoLibros, int CantidadLibros, int NoPaginas)
        {
            if (IdLibro != null)
            {
                var Art = db.Libros.Where(x => x.IdLibro == IdLibro).FirstOrDefault();
                Art.NombreLibro = NombreLibro;
                Art.Autor = Autor;
                Art.Editorial = Editorial;
                Art.FPublicacion = FPublicacion;
                Art.CostoLibros = CostoLibros;
                Art.CantidadLibros = CantidadLibros;
                Art.NoPaginas = NoPaginas;
                db.SaveChanges();
            }
            else
            {
                Libros Art = new Libros();
                Art.NombreLibro = NombreLibro;
                Art.Autor = Autor;
                Art.Editorial = Editorial;
                Art.FPublicacion = FPublicacion;
                Art.CostoLibros = CostoLibros;
                Art.CantidadLibros = CantidadLibros;
                Art.NoPaginas = NoPaginas;
                Art.Activo = true;
                db.Libros.Add(Art);
                db.SaveChanges();
            }
            return Json("");
        }

        public ActionResult Eliminar(int? IdLibro)
        {
            var book = db.Libros.Where(x => x.IdLibro == IdLibro).FirstOrDefault();
            //db.Libros.Remove(book);
            book.Activo = false;
            db.SaveChanges();
            return RedirectToAction("Books", "home");
        }
    }
}
