using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Modelo;


namespace Capa_Datos
{
    public class CD_Estudiante
    {
        public List<Estudiante> CD_ListarEstudiante()
        {
            List<Estudiante> Lista = new List<Estudiante>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_listarEstudiantes", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Lista.Add(new Estudiante()
                        {
                            ESTUDIANTE_ID = (dr["ESTUDIANTE_ID"].ToString()),
                            EST_DNI = dr["EST_DNI"].ToString(),
                            EST_NOMBRES = dr["EST_NOMBRES"].ToString(),
                            EST_APELLIDOS = dr["EST_APELLIDOS"].ToString(),
                            EST_FECHA = dr["EST_FECHA"].ToString(),
                            EST_DISTRITO = dr["EST_DISTRITO"].ToString(),
                            EST_DIRECCION = dr["EST_DIRECCION"].ToString(),
                            APODERADO_ID = dr["APODERADO_ID"].ToString(),
                            EST_USUARIO = dr["EST_USUARIO"].ToString()

                        });
                    }
                    dr.Close();

                    return Lista;

                }
                catch (Exception ex)
                {
                    Lista = null;
                    return Lista;
                }
            }
        }

        public bool CD_eliminar(Estudiante obj,out string Mensaje )
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_ELIMINAR:ESTUDIANTE", oConexion);
                    cmd.Parameters.AddWithValue("ESTUDIANTE_ID",obj.ESTUDIANTE_ID);
                    cmd.Parameters.Add("Resultado",SqlDbType.Bit).Direction= ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;

            }

            return resultado;
        }
    }
}
