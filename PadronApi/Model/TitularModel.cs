using PadronApi.Dto;
using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadronApi.Model
{
    public class TitularModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public ObservableCollection<Titular> GetTitulares()
        {
            ObservableCollection<Titular> catalogoTitulares = new ObservableCollection<Titular>();

            string sqlCadena = "SELECT T.*,O.IdOrg, O.DescOrg FROM C_Titular T INNER JOIN C_Organismo O ON O.IdOrg = T.CveAdscripcion ORDER BY Apellidos";


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;


            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Titular titular = new Titular();
                        titular.IdTitular = Convert.ToInt32(reader["IdLic"]);
                        titular.Nombre = reader["Nombre"].ToString();
                        titular.Apellidos = reader["Apellidos"].ToString();
                        titular.NombreStr = reader["NombMay"].ToString();
                        titular.IdTitulo = reader["IdTitulo"] as int? ?? 0;
                        //titular.Cargo = Convert.ToInt32(reader["Cargo"]);
                        titular.Funcion = Convert.ToInt32(reader["Funcion"]);
                        titular.Observaciones = reader["Obs"].ToString();
                        titular.Activo = Convert.ToInt32(reader["Activo"]);
                        titular.Estado = reader["IdEstatus"]as int? ?? 0;
                        titular.QuiereDistribucion = Convert.ToBoolean(reader["QuiereDist"]);
                        titular.IdOrganismoAdscripcion = Convert.ToInt32(reader["IdOrg"]);
                        titular.OrganismoAdscripcion = reader["descOrg"].ToString();

                        catalogoTitulares.Add(titular);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TitularModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TitularModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoTitulares;
        }


        public bool InsertaTitular(Titular titular)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            titular.IdTitular = DataBaseUtilities.GetNextIdForUse("C_Titular", "IdLic", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Titular(IdLic, Nombre,Apellidos,CveAdscripcion,Funcion,NombMay,Fecha,Obs,Activo,QuiereDist,IdTitulo,IdEstatus)" +
                                "VALUES (@IdLic, @Nombre,@Apellidos,@CveAdscripcion,@Funcion,@NombMay,@Fecha,@Obs,@Activo,@QuiereDist,@IdTitulo,@IdEstatus)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdLic", titular.IdTitular);
               // cmd.Parameters.AddWithValue("@[Id de Licenciado]", titular.IdTitular);
                cmd.Parameters.AddWithValue("@Nombre", titular.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", titular.Apellidos);
                cmd.Parameters.AddWithValue("@CveAdscripcion", titular.IdOrganismoAdscripcion);
                //cmd.Parameters.AddWithValue("@Cargo", titular.Cargo);
                cmd.Parameters.AddWithValue("@Funcion", titular.Funcion);
                cmd.Parameters.AddWithValue("@NombMay", StringUtilities.PrepareToAlphabeticalOrder(titular.Apellidos) + " " + StringUtilities.PrepareToAlphabeticalOrder(titular.Nombre));
                cmd.Parameters.AddWithValue("@Fecha", DateTimeUtilities.DateToInt(DateTime.Now));

                if (titular.Observaciones == null)
                    cmd.Parameters.AddWithValue("@Obs", String.Empty);
                else
                    cmd.Parameters.AddWithValue("@Obs", titular.Observaciones);
                cmd.Parameters.AddWithValue("@Activo", 1);
                cmd.Parameters.AddWithValue("@QuiereDist", 0);
                cmd.Parameters.AddWithValue("@IdTitulo", titular.IdTitulo);
                cmd.Parameters.AddWithValue("@IdEstatus", titular.Estado);


                cmd.ExecuteNonQuery();

                cmd.Dispose();
                insertCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TitularModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,TitularModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }


        public bool UpdateTitular(Titular titular)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool updateCompleted = false;


            try
            {
                connection.Open();

                string sqlQuery = "UPDATE C_Titular SET Nombre = @Nombre,Apellidos = @Apellidos," +
                          "CveAdscripcion = @CveAdscripcion,Funcion = @Funcion,NombMay = @NombMay," + 
                          "Obs = @Obs, IdTitulo = @IdTitulo, IdEstatus = @IdEstatus, Activo = @Activo " +
                          " WHERE IdLic = @IdLic";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@Nombre", titular.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", titular.Apellidos);
                cmd.Parameters.AddWithValue("@CveAdscripcion", titular.IdOrganismoAdscripcion);
                //cmd.Parameters.AddWithValue("@Cargo", titular.Cargo);
                cmd.Parameters.AddWithValue("@Funcion", titular.Funcion);
                cmd.Parameters.AddWithValue("@NombMay", StringUtilities.PrepareToAlphabeticalOrder(titular.Apellidos) + " " + StringUtilities.PrepareToAlphabeticalOrder(titular.Nombre));
                cmd.Parameters.AddWithValue("@Obs", titular.Observaciones);
                cmd.Parameters.AddWithValue("@IdTitulo", titular.IdTitulo);
                cmd.Parameters.AddWithValue("@IdEstatus", titular.Estado);
                cmd.Parameters.AddWithValue("@IdLic", titular.IdTitular);
                cmd.Parameters.AddWithValue("@Activo", titular.Activo);


                cmd.ExecuteNonQuery();

                cmd.Dispose();
                updateCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObraModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ObraModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return updateCompleted;
        }


    }
}
