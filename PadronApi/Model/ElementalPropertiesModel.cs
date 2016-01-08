using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using PadronApi.Dto;
using ScjnUtilities;

namespace PadronApi.Model
{
    public class ElementalPropertiesModel
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        #region Titulares
        public ObservableCollection<ElementalProperties> GetTitulos()
        {
            ObservableCollection<ElementalProperties> catalogoTitulos = new ObservableCollection<ElementalProperties>();

            string sqlCadena = "SELECT * FROM C_Titulo ORDER BY IdTitulo";


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
                        ElementalProperties elemento = new ElementalProperties();
                        elemento.IdElemento = Convert.ToInt32(reader["IdTitulo"]);
                        elemento.Descripcion = reader["TituloMay"].ToString();
                        elemento.ElementoAuxiliar = reader["TituloAbr"].ToString();

                        catalogoTitulos.Add(elemento);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoTitulos;
        }

        public ObservableCollection<ElementalProperties> GetFunciones()
        {
            ObservableCollection<ElementalProperties> catalogoTitulos = new ObservableCollection<ElementalProperties>();

            string sqlCadena = "SELECT * FROM C_Funcion ORDER BY IdFuncion";


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
                        ElementalProperties elemento = new ElementalProperties();
                        elemento.IdElemento = Convert.ToInt32(reader["IdFuncion"]);
                        elemento.Descripcion = reader["DescFuncion"].ToString();

                        catalogoTitulos.Add(elemento);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoTitulos;
        }

        public ObservableCollection<ElementalProperties> GetEstatus()
        {
            ObservableCollection<ElementalProperties> catalogoTitulos = new ObservableCollection<ElementalProperties>();

            string sqlCadena = "SELECT * FROM C_Estatus ORDER BY IdEstatus";


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
                        ElementalProperties elemento = new ElementalProperties();
                        elemento.IdElemento = Convert.ToInt32(reader["IdEstatus"]);
                        elemento.Descripcion = reader["Estatus"].ToString();

                        catalogoTitulos.Add(elemento);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoTitulos;
        }

        #endregion

        #region Obras

        public ObservableCollection<ElementalProperties> GetPresentacion()
        {
            ObservableCollection<ElementalProperties> catalogoPresentacion = new ObservableCollection<ElementalProperties>();

            string sqlCadena = "SELECT * FROM C_Presentacion ORDER BY IdPresentacion";


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
                        ElementalProperties elemento = new ElementalProperties();
                        elemento.IdElemento = Convert.ToInt32(reader["IdPresentacion"]);
                        elemento.Descripcion = reader["Presentacion"].ToString();

                        catalogoPresentacion.Add(elemento);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoPresentacion;
        }


        public ObservableCollection<ElementalProperties> GetTipoObra()
        {
            ObservableCollection<ElementalProperties> catalogoTipoObra = new ObservableCollection<ElementalProperties>();

            string sqlCadena = "SELECT * FROM C_TipoObra ORDER BY IdTipoObra";


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
                        ElementalProperties elemento = new ElementalProperties();
                        elemento.IdElemento = Convert.ToInt32(reader["IdTipoObra"]);
                        elemento.Descripcion = reader["TipoObra"].ToString();

                        catalogoTipoObra.Add(elemento);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoTipoObra;
        }


        #endregion


        #region Organismos

        public ObservableCollection<ElementalProperties> GetTiposDistribucion()
        {
            ObservableCollection<ElementalProperties> catalogoDistribucion = new ObservableCollection<ElementalProperties>();

            string sqlCadena = "SELECT * FROM C_Distribucion ORDER BY IdDistribucion";


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
                        ElementalProperties elemento = new ElementalProperties();
                        elemento.IdElemento = Convert.ToInt32(reader["IdDistribucion"]);
                        elemento.Descripcion = reader["Distribucion"].ToString();

                        catalogoDistribucion.Add(elemento);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoDistribucion;
        }


        public ObservableCollection<ElementalProperties> GetTipoOrganismo()
        {
            ObservableCollection<ElementalProperties> catalogoTipoObras = new ObservableCollection<ElementalProperties>();

            string sqlCadena = "SELECT * FROM C_TipoOrganismo ORDER BY IdTpoOrg";


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
                        ElementalProperties elemento = new ElementalProperties();
                        elemento.IdElemento = Convert.ToInt32(reader["IdTpoOrg"]);
                        elemento.Descripcion = reader["TpoOrgAvr"].ToString();

                        catalogoTipoObras.Add(elemento);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoTipoObras;
        }


        public ObservableCollection<ElementalProperties> GetOrdinales()
        {
            ObservableCollection<ElementalProperties> catalogoOrdinales = new ObservableCollection<ElementalProperties>();

            string sqlCadena = "SELECT * FROM C_Ordinal ORDER BY IdOrdinal";


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
                        ElementalProperties elemento = new ElementalProperties();
                        elemento.IdElemento = Convert.ToInt32(reader["IdOrdinal"]);
                        elemento.Descripcion = reader["Ordinal"].ToString();

                        catalogoOrdinales.Add(elemento);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoOrdinales;
        }

        public ObservableCollection<ElementalProperties> GetCircuitos()
        {
            ObservableCollection<ElementalProperties> catalogoCircuitos = new ObservableCollection<ElementalProperties>();

            string sqlCadena = "SELECT * FROM C_Ordinal ORDER BY IdOrdinal";


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
                        ElementalProperties elemento = new ElementalProperties();
                        elemento.IdElemento = Convert.ToInt32(reader["IdOrdinal"]);
                        elemento.Descripcion = reader["Ordinal"].ToString() + " Circuito";

                        catalogoCircuitos.Add(elemento);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,ElementalPropertiesModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoCircuitos;
        }

        #endregion

    }
}
