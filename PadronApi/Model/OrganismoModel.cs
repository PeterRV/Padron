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
    public class OrganismoModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;


        public ObservableCollection<Organismo> GetOrganismos()
        {
            ObservableCollection<Organismo> catalogoOrganismo = new ObservableCollection<Organismo>();

            string sqlCadena = "SELECT * FROM C_Organismo ORDER BY OrdenVer";


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



    }
}
