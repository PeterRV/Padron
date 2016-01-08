using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using PadronApi.Dto;
using ScjnUtilities;

namespace PadronApi.Model
{
    public class PaisEstadoModel
    {
        Pais dummyPais = new Pais() { IdPais = 999999999, PaisDesc = "Agregar país..." };
        Estado dummyEstado = new Estado() { IdEstado = 999999999, EstadoDesc = "Agregar estado..." };
        Ciudad dummyCiudad = new Ciudad() { IdCiudad = 999999999, CiudadDesc = "Agregar ciudad..." };

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        #region Pais

        /// <summary>
        /// Obtiene el listado de paises capturados en el sistema
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Pais> GetPaises()
        {
            ObservableCollection<Pais> catalogoPaises = new ObservableCollection<Pais>();

            string sqlCadena = "SELECT * FROM C_Pais ORDER BY PaisMay";


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
                        Pais pais = new Pais();
                        pais.IdPais = Convert.ToInt32(reader["IdPais"]);
                        pais.PaisDesc = reader["Pais"].ToString();
                        pais.PaisStr = reader["PaisMay"].ToString();

                        catalogoPaises.Add(pais);

                    }
                }
                cmd.Dispose();
                reader.Close();
                catalogoPaises.Add(dummyPais);
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoPaises;
        }


        /// <summary>
        /// Obtiene el país al que pertenece un estado
        /// </summary>
        /// <param name="idEstado">Estado del cual se quiere conocer el país</param>
        /// <returns></returns>
        public Pais GetPaises(int idEstado)
        {
            Pais pais = new Pais();
            string sqlCadena = "SELECT P.* FROM C_Pais P INNER JOIN C_Estado E ON P.IdPais = E.IdPais WHERE IdEstado = @IdEstado ORDER BY PaisMay";


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;


            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdEstado", idEstado);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pais.IdPais = Convert.ToInt32(reader["IdPais"]);
                        pais.PaisDesc = reader["Pais"].ToString();
                        pais.PaisStr = reader["PaisMay"].ToString();

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return pais;
        }


        public bool InsertaPais(Pais pais)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

           pais.IdPais = DataBaseUtilities.GetNextIdForUse("C_Pais", "IdPais", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Pais(IdPais,Pais,PaisMay)" +
                                "VALUES (@IdPais,@Pais,@PaisMay)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdPais", pais.IdPais);
                cmd.Parameters.AddWithValue("@Pais", pais.PaisDesc);
                cmd.Parameters.AddWithValue("@PaisMay", StringUtilities.PrepareToAlphabeticalOrder(pais.PaisDesc));

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                insertCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }

        #endregion



        #region Estado

        /// <summary>
        /// Obtiene el listado de todos los estados capturados en el sistema sin importar el país al que pertenecen
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Estado> GetEstados()
        {
            ObservableCollection<Estado> catalogoEstados = new ObservableCollection<Estado>();

            string sqlCadena = "SELECT * FROM C_Estado ORDER BY EstadoMay";


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
                        Estado estado = new Estado();
                        estado.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        estado.EstadoDesc = reader["Estado"].ToString();
                        estado.EstadoStr = reader["EstadoMay"].ToString();
                        estado.Abreviatura = reader["EstadoAbr"].ToString();
                        estado.IdPais = Convert.ToInt32(reader["IdPais"]);

                        catalogoEstados.Add(estado);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoEstados;
        }

        /// <summary>
        /// Obtiene el listado de estados del pais solicitado
        /// </summary>
        /// <param name="idPais"></param>
        /// <returns></returns>
        public ObservableCollection<Estado> GetEstados(int idPais)
        {
            ObservableCollection<Estado> catalogoEstados = new ObservableCollection<Estado>();

            string sqlCadena = "SELECT * FROM C_Estado WHERE IdPais = @IdPais ORDER BY EstadoMay";


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;


            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdPais", idPais);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Estado estado = new Estado();
                        estado.IdEstado = Convert.ToInt32(reader["IdEstado"]);
                        estado.EstadoDesc = reader["Estado"].ToString();
                        estado.EstadoStr = reader["EstadoMay"].ToString();
                        estado.Abreviatura = reader["EstadoAbr"].ToString();
                        estado.IdPais = Convert.ToInt32(reader["IdPais"]);

                        catalogoEstados.Add(estado);

                    }
                }
                cmd.Dispose();
                reader.Close();
                catalogoEstados.Add(dummyEstado);
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoEstados;
        }


        public bool InsertaEstado(Estado estado)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            estado.IdEstado = DataBaseUtilities.GetNextIdForUse("C_Estado", "IdEstado", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Estado(IdEstado,Estado,EstadoAbr,EstadoMay,IdPais)" +
                                "VALUES (@IdEstado,@Estado,@EstadoAbr,@EstadoMay,@IdPais)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdEstado", estado.IdEstado);
                cmd.Parameters.AddWithValue("@Estado", estado.EstadoDesc);
                cmd.Parameters.AddWithValue("@EstadoAbr", estado.EstadoDesc);
                cmd.Parameters.AddWithValue("@EstadoMay", StringUtilities.PrepareToAlphabeticalOrder(estado.EstadoDesc));
                cmd.Parameters.AddWithValue("@IdPais", estado.IdPais);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                insertCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }



        #endregion 



        #region Ciudad

        /// <summary>
        /// Obtiene el listado completo de ciudades capturadas en el sistema
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Ciudad> GetCiudades()
        {
            ObservableCollection<Ciudad> catalogoCiudades = new ObservableCollection<Ciudad>();

            string sqlCadena = "SELECT * FROM C_Ciudad ORDER BY CiudadMay";


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
                        Ciudad ciudad = new Ciudad();
                        ciudad.IdCiudad = Convert.ToInt32(reader["IdCiudad"]);
                        ciudad.CiudadDesc = reader["Ciudad"].ToString();
                        ciudad.CiudadStr = reader["CiudadMay"].ToString();
                        ciudad.IdEstado = Convert.ToInt32(reader["IdEstado"]);

                        catalogoCiudades.Add(ciudad);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoCiudades;
        }

        /// <summary>
        /// Obtiene el listado de ciudades del estado solicitado
        /// </summary>
        /// <param name="idEstado">Identificador del Estado del cual se quieren obtener las ciudades</param>
        /// <returns></returns>
        public ObservableCollection<Ciudad> GetCiudades(int idEstado)
        {
            ObservableCollection<Ciudad> catalogoCiudades = new ObservableCollection<Ciudad>();

            string sqlCadena = "SELECT * FROM C_Ciudad WHERE IdEstado = @IdEstado ORDER BY CiudadMay";


            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;


            try
            {
                connection.Open();

                cmd = new OleDbCommand(sqlCadena, connection);
                cmd.Parameters.AddWithValue("@IdEstado", idEstado);
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Ciudad ciudad = new Ciudad();
                        ciudad.IdCiudad = Convert.ToInt32(reader["IdCiudad"]);
                        ciudad.CiudadDesc = reader["Ciudad"].ToString();
                        ciudad.CiudadStr = reader["CiudadMay"].ToString();
                        ciudad.IdEstado = Convert.ToInt32(reader["IdEstado"]);

                        catalogoCiudades.Add(ciudad);

                    }
                }
                cmd.Dispose();
                reader.Close();

                catalogoCiudades.Add(dummyCiudad);
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoCiudades;
        }


        public bool InsertaCiudad(Ciudad ciudad)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            ciudad.IdCiudad = DataBaseUtilities.GetNextIdForUse("C_Ciudad", "IdCiudad", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Ciudad(IdCiudad,Ciudad,CiudadMay,IdEstado)" +
                                "VALUES (@IdCiudad,@Ciudad,@CiudadMay,@IdEstado)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdCiudad", ciudad.IdCiudad);
                cmd.Parameters.AddWithValue("@Ciudad", ciudad.CiudadDesc);
                cmd.Parameters.AddWithValue("@CiudadMay", StringUtilities.PrepareToAlphabeticalOrder(ciudad.CiudadDesc));
                cmd.Parameters.AddWithValue("@IdEstado", ciudad.IdEstado);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                insertCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,PaisEstadoModel", "PadronApi");
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
