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
    public class PaisEstadoModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        #region Pais

        public bool InsertaPais(PaisEstado pais)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

           pais.IdPais = DataBaseUtilities.GetNextIdForUse("C_Pais", "Id", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Pais(Id,Desc,DescMay)" +
                                "VALUES (@Id,@Desc,@DescMay)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@Id", pais.IdPais);
                cmd.Parameters.AddWithValue("@Desc", pais.Descripcion);
                cmd.Parameters.AddWithValue("@DescMay", StringUtilities.PrepareToAlphabeticalOrder(pais.Descripcion));

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



        #endregion 



        #region Ciudad

        public ObservableCollection<PaisEstado> GetCiudades()
        {
            ObservableCollection<PaisEstado> catalogoCiudades = new ObservableCollection<PaisEstado>();

            string sqlCadena = "SELECT * FROM C_Ciudad ORDER BY IdCiudad";


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
                        PaisEstado obra = new PaisEstado();
                        obra.IdCiudad = Convert.ToInt32(reader["IdCiudad"]);
                        obra.Descripcion = reader["Ciudad"].ToString();
                        obra.IdEstdo = Convert.ToInt32(reader["IdEstado"]);

                        catalogoCiudades.Add(obra);

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

        #endregion

    }
}
