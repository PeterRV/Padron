using System;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using MantesisVerIusCommonObjects.Dto;
using ScjnUtilities;

namespace PadronApi.Model
{
    public class AccesoModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public bool ObtenerUsuarioContraseña(string sUsuario, string sPwd)
        {
            bool bExisteUsuario = false;
            string sSql;

            OleDbCommand cmd;
            OleDbDataReader reader;
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();

                sSql = "SELECT * FROM C_Usuario WHERE Usr = @Usr AND Pwd = @Pwd";
                cmd = new OleDbCommand(sSql, connection);
                cmd.Parameters.AddWithValue("@Usr", sUsuario);
                cmd.Parameters.AddWithValue("@Pwd", sPwd);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    AccesoUsuarioModel.Usuario = reader["Usr"].ToString();
                    AccesoUsuarioModel.Llave = Convert.ToInt16(reader["IdUsr"].ToString());
                    AccesoUsuarioModel.Nombre = reader["nombre"].ToString();
                    bExisteUsuario = true;
                }
                else
                {
                    AccesoUsuarioModel.Llave = -1;
                }
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AccesoModel", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,AccesoModel", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return bExisteUsuario;
        }
    }
}
