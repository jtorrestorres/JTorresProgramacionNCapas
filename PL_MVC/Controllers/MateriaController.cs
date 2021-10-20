using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        //
        // GET: /Materia/
        [HttpPost]
        public ActionResult GetAll(ML.Materia materia)
        {
            ML.Result result = BL.Materia.GetAll();//ProductoGetByIdDepartamento
            ML.Result resultSemestre = BL.Semestre.GetAll();
            materia.Materias = result.Objects;
            materia.Semestre = new ML.Semestre();
            materia.Semestre.Semestres = resultSemestre.Objects;
            return View(materia);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();

            ML.Result resultSemestre = BL.Semestre.GetAll();
            ML.Materia materia = new ML.Materia();

            if (result.Correct)
            {
                materia.Materias = result.Objects;

                materia.Semestre = new ML.Semestre();
                materia.Semestre.Semestres = resultSemestre.Objects;
                return View(materia);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }



        }

        [HttpGet]
        public ActionResult Form(int? IdMateria) //Add { Id null } //Update {Id > 0 }
        {
            ML.Materia materia = new ML.Materia();

            ML.Result resultSemestre = BL.Semestre.GetAll();

            if (resultSemestre.Correct)
            {
                materia.Semestre = new ML.Semestre();
                materia.Semestre.Semestres = resultSemestre.Objects;

                if (IdMateria == null)
                {
                    return View(materia);
                }
                else
                {
                    //GetById
                    ML.Result result = BL.Materia.GetById(IdMateria.Value);

                    if (result.Correct)
                    {
                        materia.IdMateria = ((ML.Materia)result.Object).IdMateria;
                        materia.Nombre = ((ML.Materia)result.Object).Nombre;
                        materia.Costo = ((ML.Materia)result.Object).Costo;
                        materia.Creditos = ((ML.Materia)result.Object).Creditos;

                        return View(materia);

                    }
                    else
                    {
                        ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                        return PartialView("ValidationModal");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información de semestres" + resultSemestre.ErrorMessage;
                return PartialView("ValidationModal");
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia) //Add { Id null } //Update {Id > 0 }
        {
            ML.Result result = new ML.Result();
            if (ModelState.IsValid)
            {
                if (materia.IdMateria == 0)
                {
                    result = BL.Materia.AddSP(materia);
                    if (result.Correct)
                    {
                        ViewBag.Message = "Materia agregada correctamente";
                    }
                }
                else
                {
                    result = BL.Materia.Update(materia);
                    if (result.Correct)
                    {
                        ViewBag.Message = "Materia actualizada correctamente";
                    }
                }

                if (!result.Correct)
                {
                    ViewBag.Message = "No se pudo agregar correctamente la materia " + result.ErrorMessage;
                }

            }
            else
            {
                ML.Result resultSemestre = BL.Semestre.GetAll();

                materia.Semestre = new ML.Semestre();
                materia.Semestre.Semestres = resultSemestre.Objects;
                return View(materia);
            }
            return PartialView("ValidationModal");

        }

        [HttpGet]
        public ActionResult Delete(int IdMateria)
        {
            ML.Result result = BL.Materia.Delete(IdMateria);

            if (result.Correct)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al eliminar la materia " + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
        }
    }
}