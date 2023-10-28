using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using api.Models;

namespace api.Data
{
    public class ClienteData
    {


        public static bool Registrar(Cliente oCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrarCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", oCliente.Cedula);
                cmd.Parameters.AddWithValue("@nombres", oCliente.Nombres);
                cmd.Parameters.AddWithValue("@telefono", oCliente.Telefono);
                cmd.Parameters.AddWithValue("@correo", oCliente.Correo);
                cmd.Parameters.AddWithValue("@ciudad", oCliente.Ciudad);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Cliente oCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificarCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", oCliente.IdCliente);
                cmd.Parameters.AddWithValue("@Cedula", oCliente.Cedula);
                cmd.Parameters.AddWithValue("@nombres", oCliente.Nombres);
                cmd.Parameters.AddWithValue("@telefono", oCliente.Telefono);
                cmd.Parameters.AddWithValue("@correo", oCliente.Correo);
                cmd.Parameters.AddWithValue("@ciudad", oCliente.Ciudad);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Cliente> Listar()
        {
            List<Cliente> oListaCliente = new List<Cliente>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listarCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaCliente.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Cedula = dr["Cedula"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = Convert.ToInt32(dr["Telefono"]),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString()
                            });
                        }

                    }



                    return oListaCliente;
                }
                catch (Exception ex)
                {
                    return oListaCliente;
                }
            }
        }

        public static Cliente Obtener(int IdCliente)
        {
            Cliente oCliente = new Cliente();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtenerCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdCliente", IdCliente);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCliente = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Cedula = dr["Cedula"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = Convert.ToInt32(dr["Telefono"]),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString()
                            };
                        }

                    }
                    return oCliente;

                }

                catch (Exception ex)
                {
                    return oCliente;
                }
            }
        }



        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminarCliente", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


    }
}