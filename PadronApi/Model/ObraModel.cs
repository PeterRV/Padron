using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using PadronApi.Dto;
using ScjnUtilities;

namespace PadronApi.Model
{
    public class ObraModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        /// <summary>
        /// Obtiene el catálogo de obras que se mostrará en padrón
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Obra> GetObras()
        {
            ObservableCollection<Obra> catalogoObras = new ObservableCollection<Obra>();

            string sqlCadena = "SELECT IdObra,Orden, Titulo, TituloTxt,Sintesis,IdPresentacion,NumeroMaterial,AnioPublicacion,ISBN,Paginas,IdTipoObra,IdMedio FROM C_Obra WHERE Activo = 1 ORDER BY Orden";


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
                        Obra obra = new Obra();
                        obra.IdObra = Convert.ToInt32(reader["IdObra"]);
                        obra.Orden = reader["Orden"] as int? ?? 0;
                        obra.Titulo = reader["Titulo"].ToString();
                        obra.TituloStr = reader["TituloTxt"].ToString();
                        obra.Sintesis = reader["Sintesis"].ToString();
                        obra.NumMaterial = reader["NumeroMaterial"].ToString();
                        obra.AnioPublicacion = reader["AnioPublicacion"] as int? ?? 0;
                        obra.Isbn = reader["ISBN"].ToString();
                        obra.Paginas = reader["Paginas"] as int? ?? 0;
                        obra.Presentacion = reader["IdPresentacion"] as int? ?? 0;
                        obra.TipoObra = reader["IdTipoObra"] as Int16? ?? 0;
                        obra.MedioPublicacion = reader["IdMedio"] as int? ?? 0;

                        catalogoObras.Add(obra);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GetObras", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,GetObras", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoObras;
        }






        /// <summary>
        /// Inserta una obra dentro del catálogo. Solamente ingresa los campos que interesan para la generación del
        /// padrón de distribución
        /// </summary>
        /// <param name="obra">Obra que se integrará al catálogo</param>
        /// <returns></returns>
        public bool InsertaObra(Obra obra)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            obra.IdObra = DataBaseUtilities.GetNextIdForUse("C_Obra", "IdObra", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Obra(IdObra,Titulo,TituloTxt,NumeroMaterial,NoVolumenes,IdPresentacion,IdTipoObra,AnioPublicacion,Isbn,Activo)" +
                                "VALUES (@IdObra,@Titulo,@TituloTxt,@NumeroMaterial,@NoVolumenes,@IdPresentacion,@IdTipoObra,@AnioPublicacion,@Isbn,@Activo)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdObra", obra.IdObra);
                cmd.Parameters.AddWithValue("@Titulo", obra.Titulo);
                cmd.Parameters.AddWithValue("@TituloTxt", StringUtilities.PrepareToAlphabeticalOrder( obra.Titulo));
                cmd.Parameters.AddWithValue("@NumeroMaterial", obra.NumMaterial);
                cmd.Parameters.AddWithValue("@NoVolumenes", obra.NumLibros);
                cmd.Parameters.AddWithValue("@IdPresentacion", obra.Presentacion);
                cmd.Parameters.AddWithValue("@IdTipoObra", obra.TipoObra);
                cmd.Parameters.AddWithValue("@AnioPublicacion", obra.AnioPublicacion);
                if (obra.Isbn != null)
                    cmd.Parameters.AddWithValue("@Isbn", obra.Isbn);
                else
                    cmd.Parameters.AddWithValue("@Isbn", String.Empty);
                cmd.Parameters.AddWithValue("@Activo", 1);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                insertCompleted = true;
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

            return insertCompleted;
        }

        /// <summary>
        /// Permite Actualizar la información de una obra a nivel padron.
        /// </summary>
        /// <param name="obra">Obra que se va a actualizar</param>
        /// <returns></returns>
        public bool UpdateObra(Obra obra)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool updateCompleted = false;

            try
            {
                connection.Open();

                string sqlQuery = "UPDATE C_Obra SET Titulo = @Titulo, TituloTxt = @TituloTxt, NumeroMaterial = @NumeroMaterial," +
                    "NoVolumenes = @NoVolumenes, IdPresentacion = @IdPresentacion,IdTipoObra = @IdTipoObra, AnioPublicacion = @AnioPublicacion, Isbn = @Isbn " +
                    "WHERE IdObra = @IdObra";


                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@Titulo", obra.Titulo);
                cmd.Parameters.AddWithValue("@TituloTxt", StringUtilities.PrepareToAlphabeticalOrder(obra.Titulo));
                cmd.Parameters.AddWithValue("@NumeroMaterial", obra.NumMaterial);
                cmd.Parameters.AddWithValue("@NoVolumenes", obra.NumLibros);
                cmd.Parameters.AddWithValue("@IdPresentacion", obra.Presentacion);
                cmd.Parameters.AddWithValue("@IdTipoObra", obra.TipoObra);
                cmd.Parameters.AddWithValue("@AnioPublicacion", obra.AnioPublicacion);
                cmd.Parameters.AddWithValue("@Isbn", obra.Isbn);
                cmd.Parameters.AddWithValue("@IdObra", obra.IdObra);

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



        /// <summary>
        /// Desactiva un registro del catálogo de la base de datos. Es decir dicho registro no se 
        /// mostrará en mantenimiento ni en producción en ninguno de los programas que accedan a 
        /// este catálogo
        /// </summary>
        /// <param name="obra"></param>
        public void DesactivaObra(Obra obra)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);


            try
            {
                connection.Open();

                string sqlQuery = "UPDATE C_Obra SET Activo = @Activo WHERE IdObra = @IdObra";


                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@Activo", 0);
                cmd.Parameters.AddWithValue("@IdObra", obra.IdObra);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
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

        }
    }
}
