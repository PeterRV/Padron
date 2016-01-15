using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using PadronApi.Dto;
using ScjnUtilities;
using MantesisVerIusCommonObjects.Dto;

namespace PadronApi.Model
{
    public class OrganismoModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<Organismo> GetOrganismos()
        {
            ObservableCollection<Organismo> catalogoOrganismo = new ObservableCollection<Organismo>();

            string sqlCadena = "SELECT C_Organismo.*, C_TipoOrganismo.TpoOrgAvr, C_Distribucion.Distribucion " +
                               "FROM C_Distribucion INNER JOIN (C_TipoOrganismo INNER JOIN C_Organismo ON C_TipoOrganismo.IdTpoOrg = C_Organismo.TpoOrg) " + 
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
                        Organismo organismo = new Organismo();
                        organismo.IdOrganismo = Convert.ToInt32(reader["IdOrg"]);
                        organismo.OrganismoDesc = reader["DescOrg"].ToString();
                        organismo.OrganismoStr = reader["DescOrgMay"].ToString();
                        organismo.TipoOrganismo = Convert.ToInt32(reader["TpoOrg"]);
                        organismo.Circuito = Convert.ToInt32(reader["Cto"]);
                        organismo.Ordinal = Convert.ToInt32(reader["Ordinal"]);
                        organismo.Materia = Convert.ToInt32(reader["Materia"]);
                        organismo.Ciudad = Convert.ToInt32(reader["Ciudad"]);
                        organismo.Estado = Convert.ToInt32(reader["Estado"]);
                        organismo.Orden = reader["OrdenVer"] as int? ?? 0;
                        organismo.Calle = reader["Calle"].ToString();
                        organismo.Colonia = reader["Colonia"].ToString();
                        organismo.Delegacion = reader["Delegacion"].ToString();
                        organismo.Cp = reader["Cp"].ToString();
                        organismo.Telefono = reader["Tel"].ToString();
                        organismo.Telefono1 = reader["Tel1"].ToString();
                        organismo.Telefono2 = reader["Tel2"].ToString();
                        organismo.Telefono3 = reader["Tel3"].ToString();
                        organismo.Observaciones = reader["Obs"].ToString();
                        organismo.Activo = Convert.ToInt32(reader["Activo"]);
                        organismo.TipoDistr = Convert.ToInt32(reader["TpoDist"]);
                        organismo.Abreviado = reader["Abreviado"].ToString();
                        organismo.TipoOrganismoStr = reader["TpoOrgAvr"].ToString();
                        organismo.Distribucion = reader["Distribucion"].ToString();

                        catalogoOrganismo.Add(organismo);

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

        public Organismo GetOrganismos(int idOrganismo)
        {
            Organismo organismo = null;
            string sqlCadena = "SELECT C_Organismo.*, C_TipoOrganismo.TpoOrgAvr, C_Distribucion.Distribucion " +
                               "FROM C_Distribucion INNER JOIN (C_TipoOrganismo INNER JOIN C_Organismo ON C_TipoOrganismo.IdTpoOrg = C_Organismo.TpoOrg) " +
                               " ON C_Distribucion.IdDistribucion = C_Organismo.tpodist WHERE C_Organismo.IdOrg = @IdOrg ORDER BY OrdenVer";


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
                        organismo = new Organismo();
                        organismo.IdOrganismo = Convert.ToInt32(reader["IdOrg"]);
                        organismo.OrganismoDesc = reader["DescOrg"].ToString();
                        organismo.OrganismoStr = reader["DescOrgMay"].ToString();
                        organismo.TipoOrganismo = Convert.ToInt32(reader["TpoOrg"]);
                        organismo.Circuito = Convert.ToInt32(reader["Cto"]);
                        organismo.Ordinal = Convert.ToInt32(reader["Ordinal"]);
                        organismo.Materia = Convert.ToInt32(reader["Materia"]);
                        organismo.Ciudad = Convert.ToInt32(reader["Ciudad"]);
                        organismo.Estado = Convert.ToInt32(reader["Estado"]);
                        organismo.Orden = reader["OrdenVer"] as int? ?? 0;
                        organismo.Calle = reader["Calle"].ToString();
                        organismo.Colonia = reader["Colonia"].ToString();
                        organismo.Delegacion = reader["Delegacion"].ToString();
                        organismo.Cp = reader["Cp"].ToString();
                        organismo.Telefono = reader["Tel"].ToString();
                        organismo.Telefono1 = reader["Tel1"].ToString();
                        organismo.Telefono2 = reader["Tel2"].ToString();
                        organismo.Telefono3 = reader["Tel3"].ToString();
                        organismo.Observaciones = reader["Obs"].ToString();
                        organismo.Activo = Convert.ToInt32(reader["Activo"]);
                        organismo.TipoDistr = Convert.ToInt32(reader["TpoDist"]);
                        organismo.Abreviado = reader["Abreviado"].ToString();
                        organismo.TipoOrganismoStr = reader["TpoOrgAvr"].ToString();
                        organismo.Distribucion = reader["Distribucion"].ToString();
                        organismo.IdUsuario = Convert.ToInt32(reader["IdUsr"]);
                        organismo.Fecha = Convert.ToInt32(reader["Fecha"]);


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
            return organismo;
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





        public bool InsertaOrganismo(Organismo organismo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            organismo.IdOrganismo = DataBaseUtilities.GetNextIdForUse("C_Organismo", "IdOrg", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Organismo(IdOrg,TpoOrg,DescOrg,Cto,Ordinal,Materia,Ciudad,Estado,OrdenVer,DescOrgMay,Calle,Colonia,Delegacion,CP,Tel,Tel1,Tel2,Tel3,IdUsr,Fecha,Obs,Activo,TpoDist,Abreviado)" +
                                "VALUES (@IdOrg,@TpoOrg,@DescOrg,@Cto,@Ordinal,@Materia,@Ciudad,@Estado,@OrdenVer,@DescOrgMay,@Calle,@Colonia,@Delegacion,@CP,@Tel,@Tel1,@Tel2,@Tel3,@IdUsr,@Fecha,@Obs,@Activo,@TpoDist,@Abreviado)";

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
                cmd.Parameters.AddWithValue("@IdUsr", AccesoUsuarioModel.Llave);
                cmd.Parameters.AddWithValue("@Fecha", DateTimeUtilities.DateToInt(DateTime.Now));
                cmd.Parameters.AddWithValue("@Obs", organismo.Observaciones);
                cmd.Parameters.AddWithValue("@Activo", 1);
                cmd.Parameters.AddWithValue("@TpoDist", organismo.TipoDistr);
                cmd.Parameters.AddWithValue("@Abreviado", organismo.Abreviado);

                cmd.ExecuteNonQuery();

                cmd.Dispose();

                if (organismo.Integrantes != null && organismo.Integrantes.Count > 0)
                    new TitularModel().EstableceAdscripcion(organismo.IdOrganismo, organismo.Integrantes);

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

        public bool UpdateOrganismo(Organismo organismo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;


            try
            {
                connection.Open();

                string sqlQuery = "UPDATE C_Organismo SET TpoOrg = @TpoOrg,DescOrg = @DescOrg,Cto = @Cto,Ordinal = @Ordinal," + 
                            "Materia = @Materia,Ciudad = @Ciudad,Estado = @Estado,OrdenVer = @OrdenVer,DescOrgMay = @DescOrgMay," +
                            "Calle = @Calle,Colonia = @Colonia,Delegacion = @Delegacion,CP = @CP,Tel = @Tel,Tel1 = @Tel1,"+
                            "Tel2 = @Tel1,Tel3 = @Tel3,IdUsr = @IdUsr,Fecha = @Fecha,Obs = @Obs,Activo = @Activo," +
                            "TpoDist = @TpoDist,Abreviado = @Abreviado WHERE IdOrg = IdOrg";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@TpoOrg", organismo.TipoOrganismo);
                cmd.Parameters.AddWithValue("@DescOrg", organismo.OrganismoDesc);
                cmd.Parameters.AddWithValue("@Cto", organismo.Circuito);
                cmd.Parameters.AddWithValue("@Ordinal", organismo.Ordinal);
                cmd.Parameters.AddWithValue("@Materia", organismo.Materia);
                cmd.Parameters.AddWithValue("@Ciudad", organismo.Ciudad);
                cmd.Parameters.AddWithValue("@Estado", organismo.Estado);
                cmd.Parameters.AddWithValue("@OrdenVer", organismo.Orden);
                cmd.Parameters.AddWithValue("@DescOrgMay", StringUtilities.PrepareToAlphabeticalOrder(organismo.OrganismoDesc));
                cmd.Parameters.AddWithValue("@Calle", organismo.Calle);
                cmd.Parameters.AddWithValue("@Colonia", organismo.Colonia);
                cmd.Parameters.AddWithValue("@Delegacion", organismo.Delegacion);
                cmd.Parameters.AddWithValue("@CP", organismo.Cp);
                cmd.Parameters.AddWithValue("@Tel", organismo.Telefono);
                cmd.Parameters.AddWithValue("@Tel1", organismo.Telefono1);
                cmd.Parameters.AddWithValue("@Tel2", organismo.Telefono2);
                cmd.Parameters.AddWithValue("@Tel3", organismo.Telefono3);
                cmd.Parameters.AddWithValue("@IdUsr", AccesoUsuarioModel.Llave);
                cmd.Parameters.AddWithValue("@Fecha", DateTimeUtilities.DateToInt(DateTime.Now));
                cmd.Parameters.AddWithValue("@Obs", organismo.Observaciones);
                cmd.Parameters.AddWithValue("@Activo", organismo.Activo);
                cmd.Parameters.AddWithValue("@TpoDist", organismo.TipoDistr);
                cmd.Parameters.AddWithValue("@Abreviado", organismo.Abreviado);
                cmd.Parameters.AddWithValue("@IdOrg", organismo.IdOrganismo);

                cmd.ExecuteScalar();

                cmd.Dispose();

                if (organismo.Integrantes != null && organismo.Integrantes.Count > 0)
                    new TitularModel().EstableceAdscripcion(organismo.IdOrganismo, organismo.Integrantes);

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



        public bool InsertaHistorial(Organismo organismo)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO OrganismoHistorico(IdOrg,TpoOrg,DescOrg,Cto,Ordinal,Materia,Ciudad,Estado,DescOrgMay,Calle,Colonia,Delegacion,CP,IdUsr,Fecha,TpoDist,Activo)" +
                                "VALUES (@IdOrg,@TpoOrg,@DescOrg,@Cto,@Ordinal,@Materia,@Ciudad,@Estado,@DescOrgMay,@Calle,@Colonia,@Delegacion,@CP,@IdUsr,@Fecha,@TpoDist,@Activo)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@IdOrg", organismo.IdOrganismo);
                cmd.Parameters.AddWithValue("@TpoOrg", organismo.TipoOrganismo);
                cmd.Parameters.AddWithValue("@DescOrg", organismo.OrganismoDesc);
                cmd.Parameters.AddWithValue("@Cto", organismo.Circuito);
                cmd.Parameters.AddWithValue("@Ordinal", organismo.Ordinal);
                cmd.Parameters.AddWithValue("@Materia", organismo.Materia);
                cmd.Parameters.AddWithValue("@Ciudad", organismo.Ciudad);
                cmd.Parameters.AddWithValue("@Estado", organismo.Estado);
                cmd.Parameters.AddWithValue("@DescOrgMay", StringUtilities.PrepareToAlphabeticalOrder(organismo.OrganismoDesc));
                cmd.Parameters.AddWithValue("@Calle", organismo.Calle);
                cmd.Parameters.AddWithValue("@Colonia", organismo.Colonia);
                cmd.Parameters.AddWithValue("@Delegacion", organismo.Delegacion);
                cmd.Parameters.AddWithValue("@CP", organismo.Cp);
                cmd.Parameters.AddWithValue("@IdUsr", AccesoUsuarioModel.Llave);
                cmd.Parameters.AddWithValue("@Fecha", DateTimeUtilities.DateToInt(DateTime.Now));
                cmd.Parameters.AddWithValue("@TpoDist", organismo.TipoDistr);
                cmd.Parameters.AddWithValue("@Activo", organismo.Activo);

                cmd.ExecuteNonQuery();

                cmd.Dispose();

                if (organismo.Integrantes != null && organismo.Integrantes.Count > 0)
                    new TitularModel().EstableceAdscripcion(organismo.IdOrganismo, organismo.Integrantes);

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
