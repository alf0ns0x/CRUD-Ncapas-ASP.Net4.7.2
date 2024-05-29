using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace CRUD.DataLayer
{
    public class EmpleadoDL
    {
        public List<Empleado> Lista()
        {
            List<Empleado> lista = new List<Empleado>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_empleados()", oconexion);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Empleado() {
                                IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Departamento = new Departamento() {
                                    IdDepartamento = Convert.ToInt32(dr["IdDepartamento"].ToString()),
                                    Nombre = dr["Nombre"].ToString()
                                },
                                Sueldo = Convert.ToDecimal(dr["Sueldo"]),
                                FechaContrato = dr["FechaContrato"].ToString()
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Empleado Obtener(int @IdEmpleado)
        {
            Empleado entidad = new Empleado();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_empleado(@IdEmpleado)", oconexion);
                cmd.Parameters.AddWithValue("@idEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.Text;

                try
                {
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entidad.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"].ToString());
                            entidad.NombreCompleto = dr["NombreCompleto"].ToString();
                            entidad.Departamento = new Departamento() {
                                IdDepartamento = Convert.ToInt32(dr["IdDepartamento"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            };
                            entidad.Sueldo = Convert.ToDecimal(dr["Sueldo"]);
                            entidad.FechaContrato = dr["FechaContrato"].ToString();
                        }
                    }
                    return entidad;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public bool Crear(Empleado entidad)
        {
            bool respuesta = false;

            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_CrearEmpleado", cn);
                cmd.Parameters.AddWithValue("@NombreCompleto", entidad.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", entidad.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entidad.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", entidad.FechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    var numFilas = cmd.ExecuteNonQuery();
                    if (numFilas > 0) respuesta = true;

                    return respuesta;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Editar(Empleado entidad)
        {
            bool respuesta = false;

            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarEmpleado", cn);
                cmd.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
                cmd.Parameters.AddWithValue("@NombreCompleto", entidad.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", entidad.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entidad.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", entidad.FechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    var numFilas = cmd.ExecuteNonQuery();
                    if (numFilas > 0) respuesta = true;

                    return respuesta;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public bool Eliminar(int IdEmpleado)
        {
            bool respuesta = false;

            using (SqlConnection cn = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarEmpleado", cn);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    var numFilas = cmd.ExecuteNonQuery();
                    if (numFilas > 0) respuesta = true;

                    return respuesta;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


    }
}
    