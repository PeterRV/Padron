using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using PadronApi.Dto;
using ScjnUtilities;

namespace PadronApi.Model
{
    public class TitularModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        /// <summary>
        /// Obtiene la lista complete de funcionarios sin importar si al momento estan o no adscritos a algún organismo
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Titular> GetTitulares()
        {
            ObservableCollection<Titular> catalogoTitulares = new ObservableCollection<Titular>();

            string sqlCadena = "SELECT T.*,O.IdOrg, O.DescOrg FROM C_Titular T INNER JOIN C_Organismo O ON O.IdOrg = T.IdOrg WHERE T.IdOrg <> 7090 AND T.IdOrg <> 0 ORDER BY Apellidos";


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
                        titular.IdTitular = Convert.ToInt32(reader["IdTitular"]);
                        titular.Nombre = reader["Nombre"].ToString();
                        titular.Apellidos = reader["Apellidos"].ToString();
                        titular.NombreStr = reader["NombMay"].ToString();
                        titular.IdTitulo = reader["IdTitulo"] as int? ?? 0;
                        //titular.Cargo = Convert.ToInt32(reader["Cargo"]);
                        titular.Funcion = Convert.ToInt32(reader["IdFuncion"]);
                        titular.Observaciones = reader["Obs"].ToString();
                        titular.Activo = Convert.ToInt32(reader["Activo"]);
                        titular.Estado = reader["IdEstatus"]as int? ?? 0;
                        titular.QuiereDistribucion = Convert.ToBoolean(reader["QuiereDist"]);
                        titular.IdOrganismoAdscripcion = Convert.ToInt32(reader["T.IdOrg"]);
                        titular.OrganismoAdscripcion = reader["descOrg"].ToString();
                        titular.Correo = reader["Correo"].ToString();

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

        /// <summary>
        /// Obtiene los integrantes del organismo seleccionado
        /// </summary>
        /// <param name="idOrganismo">Organismo seleccionado</param>
        /// <returns></returns>
        public ObservableCollection<Titular> GetTitulares(int idOrganismo)
        {
            ObservableCollection<Titular> catalogoTitulares = new ObservableCollection<Titular>();

            string sqlCadena = "SELECT T.*,O.IdOrg, O.DescOrg FROM C_Titular T INNER JOIN C_Organismo O ON O.IdOrg = T.IdOrg WHERE T.IdOrg = @IdOrg ORDER BY Apellidos";


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;


            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdOrg", idOrganismo);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Titular titular = new Titular();
                        titular.IdTitular = Convert.ToInt32(reader["IdTitular"]);
                        titular.Nombre = reader["Nombre"].ToString();
                        titular.Apellidos = reader["Apellidos"].ToString();
                        titular.NombreStr = reader["NombMay"].ToString();
                        titular.IdTitulo = reader["IdTitulo"] as int? ?? 0;
                        titular.IdOrganismoAdscripcion = Convert.ToInt32(reader["T.IdOrg"]);
                        titular.Funcion = Convert.ToInt32(reader["IdFuncion"]);
                        titular.Observaciones = reader["Obs"].ToString();
                        titular.Activo = Convert.ToInt32(reader["Activo"]);
                        titular.Estado = reader["IdEstatus"] as int? ?? 0;
                        titular.QuiereDistribucion = Convert.ToBoolean(reader["QuiereDist"]);
                        titular.Correo = reader["Correo"].ToString();

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

        public Titular GetTitulares(Titular dtitular)
        {
            ObservableCollection<Titular> catalogoTitulares = new ObservableCollection<Titular>();

            string sqlCadena = "SELECT T.*,O.IdOrg, O.DescOrg FROM C_Titular T INNER JOIN C_Organismo O ON O.IdOrg = T.IdOrg WHERE T.IdTitular = @IdTitular ORDER BY Apellidos";


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            Titular dummyTitular = null;
            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdOrg", dtitular.IdTitular);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dummyTitular = new Titular();
                        dummyTitular.IdTitular = Convert.ToInt32(reader["IdTitular"]);
                        dummyTitular.Nombre = reader["Nombre"].ToString();
                        dummyTitular.Apellidos = reader["Apellidos"].ToString();
                        dummyTitular.NombreStr = reader["NombMay"].ToString();
                        dummyTitular.IdTitulo = reader["IdTitulo"] as int? ?? 0;
                        dummyTitular.IdOrganismoAdscripcion = Convert.ToInt32(reader["T.IdOrg"]);
                        dummyTitular.Funcion = Convert.ToInt32(reader["IdFuncion"]);
                        dummyTitular.Observaciones = reader["Obs"].ToString();
                        dummyTitular.Activo = Convert.ToInt32(reader["Activo"]);
                        dummyTitular.Estado = reader["IdEstatus"] as int? ?? 0;
                        dummyTitular.QuiereDistribucion = Convert.ToBoolean(reader["QuiereDist"]);
                        dummyTitular.Correo = reader["Correo"].ToString();

                        catalogoTitulares.Add(dummyTitular);

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

            return dummyTitular;
        }


        public ObservableCollection<Titular> GetTitularesSinAdscripcion()
        {
            ObservableCollection<Titular> catalogoTitulares = new ObservableCollection<Titular>();

            string sqlCadena = "SELECT * FROM C_Titular WHERE IdOrg = 7090 OR IdOrg = 0 ORDER BY Apellidos";


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
                        titular.IdTitular = Convert.ToInt32(reader["IdTitular"]);
                        titular.Nombre = reader["Nombre"].ToString();
                        titular.Apellidos = reader["Apellidos"].ToString();
                        titular.NombreStr = reader["NombMay"].ToString();
                        titular.IdTitulo = reader["IdTitulo"] as int? ?? 0;
                        //titular.Cargo = Convert.ToInt32(reader["Cargo"]);
                        titular.Funcion = Convert.ToInt32(reader["IdFuncion"]);
                        titular.Observaciones = reader["Obs"].ToString();
                        titular.Activo = Convert.ToInt32(reader["Activo"]);
                        titular.Estado = reader["IdEstatus"] as int? ?? 0;
                        titular.QuiereDistribucion = Convert.ToBoolean(reader["QuiereDist"]);
                        titular.Correo = reader["Correo"].ToString();

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

                string sqlQuery = "INSERT INTO C_Titular(IdTitular, Nombre,Apellidos,IdOrg,IdTitulo,IdFuncion,NombMay,Fecha,Obs,Activo,QuiereDist,IdTitulo,IdEstatus,Correo)" +
                                "VALUES (@IdTitular, @Nombre,@Apellidos,@IdOrg,@IdTitulo,@IdFuncion,@NombMay,@Fecha,@Obs,@Activo,@QuiereDist,@IdTitulo,@IdEstatus,@Correo)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdTitular", titular.IdTitular);
                cmd.Parameters.AddWithValue("@Nombre", titular.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", titular.Apellidos);
                cmd.Parameters.AddWithValue("@IdOrg", titular.IdOrganismoAdscripcion);
                cmd.Parameters.AddWithValue("@IdTitulo", titular.IdTitulo);
                cmd.Parameters.AddWithValue("@IdFuncion", titular.Funcion);
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
                cmd.Parameters.AddWithValue("@Correo", titular.Correo);


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
                          "IdOrg = @IdOrg,IdFuncion = @IdFuncion,NombMay = @NombMay," + 
                          "Obs = @Obs, IdTitulo = @IdTitulo, IdEstatus = @IdEstatus, Activo = @Activo, Correo = @Correo " +
                          " WHERE IdTitular = @IdTitular";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@Nombre", titular.Nombre);
                cmd.Parameters.AddWithValue("@Apellidos", titular.Apellidos);
                cmd.Parameters.AddWithValue("@IdOrg", titular.IdOrganismoAdscripcion);
                //cmd.Parameters.AddWithValue("@Cargo", titular.Cargo);
                cmd.Parameters.AddWithValue("@IdFuncion", titular.Funcion);
                cmd.Parameters.AddWithValue("@NombMay", StringUtilities.PrepareToAlphabeticalOrder(titular.Apellidos) + " " + StringUtilities.PrepareToAlphabeticalOrder(titular.Nombre));
                cmd.Parameters.AddWithValue("@Obs", titular.Observaciones);
                cmd.Parameters.AddWithValue("@IdTitulo", titular.IdTitulo);
                cmd.Parameters.AddWithValue("@IdEstatus", titular.Estado);
                cmd.Parameters.AddWithValue("@Activo", titular.Activo);
                cmd.Parameters.AddWithValue("@Correo", titular.Correo);
                cmd.Parameters.AddWithValue("@IdTitular", titular.IdTitular);
                


                cmd.ExecuteNonQuery();

                cmd.Dispose();
                updateCompleted = true;
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

            return updateCompleted;
        }



        public void EstableceAdscripcion(int idOrganismo, ObservableCollection<Titular> listaIntegrantes)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();

                foreach (Titular integrante in listaIntegrantes)
                {

                    string sqlQuery = "UPDATE C_Titular SET IdOrg = @IdOrg WHERE IdTitular = @IdLIdTitularic";

                    OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@IdOrg", idOrganismo);
                    cmd.Parameters.AddWithValue("@IdTitular", integrante.IdTitular);


                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
                }
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
        }

        public void EstableceAdscripcion(int idOrganismo, int idTitular)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();


                    string sqlQuery = "UPDATE C_Titular SET IdOrg = @IdOrg WHERE IdTitular = @IdLIdTitularic";

                    OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                    cmd.Parameters.AddWithValue("@IdOrg", idOrganismo);
                    cmd.Parameters.AddWithValue("@IdTitular", idTitular);


                    cmd.ExecuteNonQuery();

                    cmd.Dispose();
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
        }

        /// <summary>
        /// Elimina relación organismo-titular
        /// </summary>
        /// <param name="idTitular">Identificador del titular que queda fuera del organismo</param>
        /// <returns></returns>
        public bool EliminaAdscripcion(int idTitular)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool updateCompleted = false;


            try
            {
                connection.Open();

                string sqlQuery = "UPDATE C_Titular SET IdOrg = @IdOrg" +
                          " WHERE IdTitular = @IdTitular";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdOrg", 0);
                cmd.Parameters.AddWithValue("@IdTitular", idTitular);


                cmd.ExecuteNonQuery();

                cmd.Dispose();
                updateCompleted = true;
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
            return updateCompleted;
        }



        #region Historico


        public bool InsertaHistorico(Titular titular)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;


            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_TitularHistorico(IdTitular, IdOrg,IdFuncion,IdUsr,Fecha,Activo)" +
                                "VALUES (@IdTitular,@IdOrg,@IdFuncion,@IdUsr,@Fecha,@Activo)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdTitular", titular.IdTitular);
                cmd.Parameters.AddWithValue("@IdOrg", titular.IdOrganismoAdscripcion);
                cmd.Parameters.AddWithValue("@IdFuncion", titular.Funcion);
                cmd.Parameters.AddWithValue("@IdUsr", 5);
                cmd.Parameters.AddWithValue("@Fecha", DateTimeUtilities.DateToInt(DateTime.Now));
                cmd.Parameters.AddWithValue("@Activo", titular.Activo);
                cmd.Parameters.AddWithValue("@Correo", titular.Correo);

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

        #endregion


    }
}
