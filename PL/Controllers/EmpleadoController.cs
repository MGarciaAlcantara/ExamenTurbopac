using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/
        [HttpGet]
        public ActionResult Consultar()
        {
            ML.Empleado empleado = new ML.Empleado();
            ML.Result result = new ML.Result();

            result = BL.Empleado.Consultar();
            empleado.Empleados = result.Objects;

            return View(empleado);

        }

        [HttpGet]
        public ActionResult Formulario(int? IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();


            if (IdEmpleado == null)
            {
                return View(empleado);
            }
            else
            {
                ML.Result result = BL.Empleado.ConsultaById(IdEmpleado.Value);

                if (result.Correct)
                {
                    empleado = ((ML.Empleado)result.Object);
                    return View(empleado);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("ModalValidcacion");
                }
            }



        }
        [HttpPost]
        public ActionResult Formulario(ML.Empleado empleado)
        {

            ML.Result result = new ML.Result();


            if (empleado.IdEmpleado == 0)
            {
                result = BL.Empleado.Agregar(empleado);
                ViewBag.Message = "Empleado agregado correctamente ";
            }
            else
            {

                result = BL.Empleado.Actualizar(empleado);



                ViewBag.Message = "El empleado se actualizó correctamente ";
            }

            if (!result.Correct)
            {
                ViewBag.Message = "No se pudo agregar correctamente el empleado " + result.ErrorMessage;
            }

            return PartialView("ModalValidacion");
        }

        [HttpGet]
        public ActionResult Eliminar(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Eliminar(IdEmpleado);

            return RedirectToAction("Consultar");
        }

        public ActionResult ActualizarEstatus(int IdEmpleado)
        {

            ML.Result result = new ML.Result();
            result = BL.Empleado.ConsultaById(IdEmpleado);

            ML.Empleado empleado = new ML.Empleado();
            if (result.Correct == true)
            {
                empleado = ((ML.Empleado)result.Object);
                empleado.IdEmpleado = IdEmpleado;

                if (empleado.Status == 0)
                {
                    empleado.Status = 1;
                }
                else
                {
                    empleado.Status = 0;
                }

                ML.Result res = BL.Empleado.Actualizar(empleado);


            }


            return RedirectToAction("Consultar");
        }





    }
}