using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.DataLayer;
using CRUD.EntityLayer;

namespace CRUD.BusinessLayer
{
    public class EmpleadoBL
    {
        EmpleadoDL empleadoDL = new EmpleadoDL();

        public List<Empleado> Lista()
        {
            try
            {
                return empleadoDL.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Empleado Obtener(int idEmpleado)
        {
            try
            {
                return empleadoDL.Obtener(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Crear(Empleado entidad)
        {
            try
            {
                if (entidad.NombreCompleto == "")
                    throw new OperationCanceledException("EL nombre no puede er vacio");

                return empleadoDL.Crear(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(Empleado entidad)
        {
            try
            {
                var encontrando = empleadoDL.Obtener(entidad.IdEmpleado);

                if (encontrando.IdEmpleado == 0)
                    throw new OperationCanceledException("No existe el emple");

                return empleadoDL.Editar(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idEmpleado)
        {
            try
            {
                var encontrando = empleadoDL.Obtener(idEmpleado);

                if (encontrando.IdEmpleado == 0)
                    throw new OperationCanceledException("No existe el emple");

                return empleadoDL.Eliminar(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
