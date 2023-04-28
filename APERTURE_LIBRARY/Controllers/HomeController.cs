﻿using APERTURE_LIBRARY.Models;
using APERTURE_LIBRARY.Models.ViewModel;
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

        /// Modulos

        public ActionResult Books()
        {
            //var lst = db.Libros.ToList();
            var lst = db.Libros.Where(x => x.Activo == true).ToList();
            return View(lst);
        }

        public ActionResult BooksType()
        {
            //var lst = db.Libros.ToList();
            var lst = db.TipoLibros.Where(x => x.Activo == true).ToList();
            return View(lst);
        }

        public ActionResult Clients()
        {
            //var lst = db.Clients.ToList();
            var lst = db.Clientes.Where(x => x.Activo == true).ToList();
            return View(lst);
        }

        public ActionResult Employees()
        {
            //var lst = db.Clients.ToList();
            var lst = db.Personal.Where(x => x.Activo == true).ToList();
            return View(lst);
        }


        public ActionResult LoanType()
        {
            var lst = db.TiposPrestamos.Where(x => x.Activo == true).ToList();
            return View(lst);
        }

        public ActionResult EntracesAndExits()
        {
            var lst = db.Checadas.Where(x => x.Activo == true).ToList();
            return View(lst);
        }

        public ActionResult Sales()
        {
            var lst = db.Checadas.Where(x => x.Activo == true).ToList();

            var ID = Request.Params["IdTL"];
            if (ID != null)
            {
                int id = int.Parse(ID);
                var li = db.TipoLibros.Where(x => x.IdTL == id).FirstOrDefault();
                ViewBag.li = li;
            }

            return View(lst);
        }

        /// Forms

        public ActionResult BooksTypeForm()
        {
            var ID = Request.Params["IdTL"];
            if (ID != null)
            {
                int id = int.Parse(ID);
                var li = db.TipoLibros.Where(x => x.IdTL == id).FirstOrDefault();
                ViewBag.li = li;
            }

            return View();
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

            //Elementos para llave foranea
            ViewBag.TipoLibro = db.TipoLibros.Where(x => x.Activo == true).ToList();
            return View();

        }

        public ActionResult ClientsForm()
        {
            var ID = Request.Params["IdCLI"];
            if (ID != null)
            {
                int id = int.Parse(ID);
                var li = db.Clientes.Where(x => x.IdCLI == id).FirstOrDefault();
                ViewBag.li = li;
            }

            return View();

        }

        public ActionResult EmployeeForm()
        {
            var ID = Request.Params["IdPE"];
            if (ID != null)
            {
                int id = int.Parse(ID);
                var li = db.Personal.Where(x => x.IdPE == id).FirstOrDefault();
                ViewBag.li = li;
            }

            return View();

        }

        public ActionResult LoanTypeForm()
        {

            var ID = Request.Params["IdTP"];
            if (ID != null)
            {
                int id = int.Parse(ID);
                var li = db.TiposPrestamos.Where(x => x.IdTP == id).FirstOrDefault();
                ViewBag.li = li;
            }
            return View();

        }

        public ActionResult EntracesAndExitsForm()
        {
            var ID = Request.Params["IdCH"];
            if (ID != null)
            {
                int id = int.Parse(ID);
                var li = db.Checadas.Where(x => x.IdCH == id).FirstOrDefault();
                ViewBag.li = li;
            }

            //Elementos para llave foranea
            ViewBag.Personal = db.Personal.Where(x => x.Activo == true).ToList();
            return View();
        }

        /// Añadir en BD

        public JsonResult guardarLi(int? IdLibro, string NombreLibro, string Autor, string Editorial, string FPublicacion, float CostoLibros, int CantidadLibros, int NoPaginas, int? TipoLibro)
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
                Art.idtipolibro = TipoLibro;
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
                Art.idtipolibro = TipoLibro;
                db.Libros.Add(Art);
                db.SaveChanges();
            }
            return Json("");
        }

        public JsonResult guardarTLi(int? IdTL, string Genero, string Categoria)
        {
            if (IdTL != null)
            {
                var Art = db.TipoLibros.Where(x => x.IdTL == IdTL).FirstOrDefault();
                Art.Genero = Genero;
                Art.Categoria = Categoria;
                db.SaveChanges();
            }
            else
            {
                TipoLibros Art = new TipoLibros();
                Art.Genero = Genero;
                Art.Categoria = Categoria;
                Art.Activo = true;
                db.TipoLibros.Add(Art);
                db.SaveChanges();
            }
            return Json("");
        }
        public JsonResult guardarCLI(int? IdCLI, string NombreCli, string ApePat, string ApeMat, string FechaNacimiento, string correo, string NumTelefono, string Domicilio)
        {
            if (IdCLI != null)
            {
                var Art = db.Clientes.Where(x => x.IdCLI == IdCLI).FirstOrDefault();
                Art.NombreCli = NombreCli;
                Art.ApePat = ApePat;
                Art.ApeMat = ApeMat;
                Art.FechaNacimiento = FechaNacimiento;
                Art.correo = correo;
                Art.NumTelefono = NumTelefono;
                Art.Domicilio = Domicilio;
                db.SaveChanges();
            }
            else
            {
                Clientes Art = new Clientes();
                Art.NombreCli = NombreCli;
                Art.ApePat = ApePat;
                Art.ApeMat = ApeMat;
                Art.FechaNacimiento = FechaNacimiento;
                Art.correo = correo;
                Art.NumTelefono = NumTelefono;
                Art.Domicilio = Domicilio;
                Art.Activo = true;
                db.Clientes.Add(Art);
                db.SaveChanges();
            }
            return Json("");
        }

        public JsonResult guardarPer(int? IdPE, string NombrePer, string ApePat, string ApeMat, string FechaNacimiento, string correo, string NumTelefono, string Domicilio, string Puesto, string Turno)
        {
            if (IdPE != null)
            {
                var Art = db.Personal.Where(x => x.IdPE == IdPE).FirstOrDefault();
                Art.NombrePer = NombrePer;
                Art.ApePat = ApePat;
                Art.ApeMat = ApeMat;
                Art.FechaNacimiento = FechaNacimiento;
                Art.correo = correo;
                Art.NumTelefono = NumTelefono;
                Art.Domicilio = Domicilio;
                Art.Puesto = Puesto;
                Art.Turno = Turno;
                db.SaveChanges();
            }
            else
            {
                Personal Art = new Personal();
                Art.NombrePer = NombrePer;
                Art.ApePat = ApePat;
                Art.ApeMat = ApeMat;
                Art.FechaNacimiento = FechaNacimiento;
                Art.correo = correo;
                Art.NumTelefono = NumTelefono;
                Art.Domicilio = Domicilio;
                Art.Puesto = Puesto;
                Art.Turno = Turno;
                Art.Activo = true;
                db.Personal.Add(Art);
                db.SaveChanges();
            }
            return Json("");
        }
        public JsonResult guardarTPr(int? IdTP, string TipoPrestamo, string Descripcion)
        {
            if (IdTP != null)
            {
                var Art = db.TiposPrestamos.Where(x => x.IdTP == IdTP).FirstOrDefault();
                Art.TipoPrestamo = TipoPrestamo;
                Art.Descripcion = Descripcion;
                db.SaveChanges();
            }
            else
            {
                TiposPrestamos Art = new TiposPrestamos();
                Art.TipoPrestamo = TipoPrestamo;
                Art.Descripcion = Descripcion;
                Art.Activo = true;
                db.TiposPrestamos.Add(Art);
                db.SaveChanges();
            }
            return Json("");
        }

        public JsonResult guardarCh(int? IdCH, string FechaDia, string HoraEntrada, string HoraSalida,  int? Empleado)
        {
            if (IdCH != null)
            {
                var Art = db.Checadas.Where(x => x.IdCH == IdCH).FirstOrDefault();
                Art.FechaDia = FechaDia;
                Art.HoraEntrada = HoraEntrada;
                Art.HoraSalida = HoraSalida;
                Art.idPersonal = Empleado;
                db.SaveChanges();
            }
            else
            {
                Checadas Art = new Checadas();
                Art.FechaDia = FechaDia;
                Art.HoraEntrada = HoraEntrada;
                Art.HoraSalida = HoraSalida;
                Art.Activo = true;
                Art.idPersonal = Empleado;
                db.Checadas.Add(Art);
                db.SaveChanges();
            }
            return Json("");
        }

        // "Eliminar" en BD

        public ActionResult Eliminar(int? IdLibro)
        {
            var book = db.Libros.Where(x => x.IdLibro == IdLibro).FirstOrDefault();
            //db.Libros.Remove(book);
            book.Activo = false;
            db.SaveChanges();
            return RedirectToAction("Books", "home");
        }

        public ActionResult EliminarTL(int? IdTL)
        {
            var book = db.TipoLibros.Where(x => x.IdTL == IdTL).FirstOrDefault();
            //db.Libros.Remove(book);
            book.Activo = false;
            db.SaveChanges();
            return RedirectToAction("BooksType", "home");
        }

        public ActionResult EliminarCLI(int? IdCLI)
        {
            var clients = db.Clientes.Where(x => x.IdCLI == IdCLI).FirstOrDefault();
            clients.Activo = false;
            db.SaveChanges();
            return RedirectToAction("Clients", "home");
        }

        public ActionResult EliminarPer(int? IdPE)
        {
            var clients = db.Personal.Where(x => x.IdPE == IdPE).FirstOrDefault();
            clients.Activo = false;
            db.SaveChanges();
            return RedirectToAction("Employees", "home");
        }

        public ActionResult EliminarTPr(int? IdTP)
        {
            var LoanType = db.TiposPrestamos.Where(x => x.IdTP == IdTP).FirstOrDefault();
            LoanType.Activo = false;
            db.SaveChanges();
            return RedirectToAction("LoanType", "home");
        }

        public ActionResult EliminarEAE(int? IdCH)
        {
            var Chec = db.Checadas.Where(x => x.IdCH == IdCH).FirstOrDefault();
            Chec.Activo = false;
            db.SaveChanges();
            return RedirectToAction("EntracesAndExits", "home");
        }

    }
}
