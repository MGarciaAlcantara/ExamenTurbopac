using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Agregar(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.MGarciaTurboPacEntities context= new DL.MGarciaTurboPacEntities())
                {

                    var query = context.EmpleadoAdd(empleado.Email, empleado.Password, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Status);

                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;

            }

            return result;


        }
        public static ML.Result Actualizar(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MGarciaTurboPacEntities context = new DL.MGarciaTurboPacEntities())
                {

                    var query = context.EmpleadoUpdate(empleado.IdEmpleado,empleado.Email, empleado.Password, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Status);

                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;

            }

            return result;


        }
        public static ML.Result Eliminar(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.MGarciaTurboPacEntities context = new DL.MGarciaTurboPacEntities())
                {

                    var query = context.EmpleadoDelete(IdEmpleado);

                    if (query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;

            }

            return result;


        }
        public static ML.Result Consultar()
        {


            ML.Result result = new ML.Result();
            try
            {
                using (DL.MGarciaTurboPacEntities context = new DL.MGarciaTurboPacEntities())
                {
                    var query = context.EmpleadoGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objeto in query)
                        {
                            ML.Empleado  empleado = new ML.Empleado();

                            empleado.IdEmpleado = objeto.IdEmpleado;
                            empleado.Email = objeto.Email;
                            empleado.Password = objeto.Password;
                            empleado.Nombre = objeto.Nombre;
                            empleado.ApellidoPaterno = objeto.ApellidoPaterno;
                            empleado.ApellidoMaterno=objeto.ApellidoMaterno;
                            empleado.Status = objeto.Status.Value;
                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;

        }
        public static ML.Result ConsultaById(int IdEmpleado )
        {


            ML.Result result = new ML.Result();
            try
            {
                using (DL.MGarciaTurboPacEntities context = new DL.MGarciaTurboPacEntities())
                {
                    var query = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();
                 

                    if (query != null)
                    {
                                            
                            ML.Empleado empleado = new ML.Empleado();

                      
                            empleado.Email = query.Email;
                            empleado.Password = query.Password;
                            empleado.Nombre = query.Nombre;
                            empleado.ApellidoPaterno = query.ApellidoPaterno;
                            empleado.ApellidoMaterno = query.ApellidoMaterno;
                            empleado.Status = query.Status.Value;
                            result.Object=empleado;
                        
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;

        }


    }
}
