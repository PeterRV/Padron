using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using PadronApi.Dto;
using ScjnUtilities;

namespace PadronApi.Model
{
    public class OrganismoModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<Organismo> GetOrganismos()
        {
            ObservableCollection<Organismo> catalogoOrganismo = new ObservableCollection<Organismo>();

            string sqlCadena = "SELECT C_Organismo.*, C_TipoOrganismo.DescTpo, C_Distribucion.Distribucion " +
                               "FROM C_Distribucion INNER JOIN (C_TipoOrganismo INNER JOIN C_Organismo ON C_TipoOrganismo.IdTpo = C_Organismo.TpoOrg) " + 
                               " ON C_Distribucion.IdDistribucion = C_Organismo.tpodist ORDER BY OrdenVer";


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
                        Organismo obra = new Organismo();
                        obra.IdOrganismo = Convert.ToInt32(reader["IdOrg"]);
                        obra.OrganismoDesc = reader["DescOrg"].ToString();
                        obra.OrganismoStr = reader["DescOrgMay"].ToString();
                        obra.TipoOrganismo = Convert.ToInt32(reader["TpoOrg"]);
                        obra.Circuito = Convert.ToInt32(reader["Cto"]);
                        obra.Ordinal = Convert.ToInt32(reader["Ordinal"]);
                        obra.Materia = Convert.ToInt32(reader["Materia"]);
                        obra.Ciudad = Convert.ToInt32(reader["Ciudad"]);
                        obra.Estado = Convert.ToInt32(reader["Estado"]);
                        obra.Orden = reader["OrdenVer"] as int? ?? 0;
                        obra.Calle = reader["Calle"].ToString();
                        obra.Colonia = reader["Colonia"].ToString();
                        obra.Delegacion = reader["Delegacion"].ToString();
                        obra.Cp = reader["Cp"].ToString();
                        obra.Telefono = reader["Tel"].ToString();
                        obra.Telefono1 = reader["Tel1"].ToString();
                        obra.Telefono2 = reader["Tel2"].ToString();
                        obra.Telefono3 = reader["Tel3"].ToString();
                        obra.Observaciones = reader["Obs"].ToString();
                        obra.Activo = Convert.ToInt32(reader["lActivo"]);
                        obra.TipoDistr = Convert.ToInt32(reader["TpoDist"]);
                        obra.Abreviado = reader["Abreviado"].ToString();
                        obra.TipoOrganismoStr = reader["DescTpo"].ToString();
                        obra.Distribucion = reader["Distribucion"].ToString();

                        catalogoOrganismo.Add(obra);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoOrganismo;
        }


        /// <summary>
        /// Obtiene el listado de los organismos activos con los datos básicos para relacionar un 
        /// organismo con un titular
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Organismo> GetOrganismoForAdscripcion()
        {
            ObservableCollection<Organismo> catalogoOrganismo = new ObservableCollection<Organismo>();

            string sqlCadena = "SELECT IdOrg,DescOrg,DescOrgMay FROM C_Organismo ORDER BY IdOrg";


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
                        Organismo obra = new Organismo();
                        obra.IdOrganismo = Convert.ToInt32(reader["IdOrg"]);
                        obra.OrganismoDesc = reader["DescOrg"].ToString();
                        obra.OrganismoStr = reader["DescOrgMay"].ToString();

                        catalogoOrganismo.Add(obra);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,OrganismosModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoOrganismo;
        }



        public bool InsertaAutor(Organismo organismo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            organismo.IdOrganismo = DataBaseUtilities.GetNextIdForUse("C_Organismo", "IdOrg", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Organismo(IdOrg,TpoOrg,DescOrg,Cto,Ordinal,Materia,Ciudad,Estado,OrdenVer,DescOrgMay,Calle,Colonia,Delegacion,CP,Tel,Tel1,Tel2,Tel3,IdUsr,Fecha,Obs,lActivo,TpoDist,Abreviado)" +
                                "VALUES (@IdOrg,@TpoOrg,@DescOrg,@Cto,@Ordinal,@Materia,@Ciudad,@Estado,@OrdenVer,@DescOrgMay,@Calle,@Colonia,@Delegacion,@CP,@Tel,@Tel1,@Tel2,@Tel3,@IdUsr,@Fecha,@Obs,@lActivo,@TpoDist,@Abreviado)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdOrg", organismo.IdOrganismo);
                cmd.Parameters.AddWithValue("@TpoOrg", organismo.TipoOrganismo);
                cmd.Parameters.AddWithValue("@DescOrg", organismo.OrganismoDesc);
                cmd.Parameters.AddWithValue("@Cto", organismo.Circuito);
                cmd.Parameters.AddWithValue("@Ordinal", organismo.Ordinal);
                cmd.Parameters.AddWithValue("@Materia", organismo.Materia);
                cmd.Parameters.AddWithValue("@Ciudad", organismo.Ciudad);
                cmd.Parameters.AddWithValue("@Estado", organismo.Estado);
                cmd.Parameters.AddWithValue("@OrdenVer", organismo.Orden);
                cmd.Parameters.AddWithValue("@DescOrgMay",StringUtilities.PrepareToAlphabeticalOrder(organismo.OrganismoDesc));
                cmd.Parameters.AddWithValue("@Calle", organismo.Calle);
                cmd.Parameters.AddWithValue("@Colonia", organismo.Colonia);
                cmd.Parameters.AddWithValue("@Delegacion", organismo.Delegacion);
                cmd.Parameters.AddWithValue("@CP", organismo.Cp);
                cmd.Parameters.AddWithValue("@Tel", organismo.Telefono);
                cmd.Parameters.AddWithValue("@Tel1", organismo.Telefono1);
                cmd.Parameters.AddWithValue("@Tel2", organismo.Telefono2);
                cmd.Parameters.AddWithValue("@Tel3", organismo.Telefono3);
                cmd.Parameters.AddWithValue("@IdUsr", 0);
                cmd.Parameters.AddWithValue("@Fecha", DateTimeUtilities.DateToInt(DateTime.Now));
                cmd.Parameters.AddWithValue("@Obs", organismo.Observaciones);
                cmd.Parameters.AddWithValue("@lActivo", organismo.Activo);
                cmd.Parameters.AddWithValue("@TpoDist", organismo.TipoDistr);
                cmd.Parameters.AddWithValue("@Abreviado", organismo.Abreviado);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                insertCompleted = true;
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutorModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AutorModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return insertCompleted;
        }


    }
}
