using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace BL
{
    public class Venta
    {
        public static ML.Result AddSP(ML.Venta venta, List<object> Objects)
        {
            ML.Result result = new ML.Result();

            

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO [Materia]([Nombre],[Creditos],[Costo] )VALUES (@Nombre, @Creditos, @Costo)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[3];

                        //collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        //collection[0].Value = materia.Nombre;

                        //collection[1] = new SqlParameter("Creditos", SqlDbType.TinyInt);
                        //collection[1].Value = materia.Creditos;

                        //collection[2] = new SqlParameter("Costo", SqlDbType.Decimal);
                        //collection[2].Value = materia.Costo;

                        //collection[3] = new SqlParameter("IdSemestre", SqlDbType.TinyInt);

                        ////materia.Semestre = new ML.Semestre();
                        //collection[3].Value = materia.Semestre.IdSemestre;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        //DateTime x = "";
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Materia";
                        }
                        //cmd.Connection.Close();                       
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
