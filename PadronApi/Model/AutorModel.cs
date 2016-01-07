using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using PadronApi.Dto;
using ScjnUtilities;

namespace PadronApi.Model
{
    public class AutorModel
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Base"].ConnectionString;

        public ObservableCollection<Autor> GetAutores()
        {
            ObservableCollection<Autor> catalogoAutores = new ObservableCollection<Autor>();

            string sqlCadena = "SELECT * FROM C_Autores ORDER BY DescMay";


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
                        Autor autor = new Autor();
                        autor.IdAutor = Convert.ToInt32(reader["Id"]);
                        autor.Grado = 0;// Convert.ToInt32(reader["Orden"]);
                        autor.Nombre = reader["Desc"].ToString();
                        autor.NombreStr = reader["DescMay"].ToString();

                        catalogoAutores.Add(autor);

                    }
                }
                cmd.Dispose();
                reader.Close();
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

            return catalogoAutores;
        }


        public bool InsertaAutor(Autor autor)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool insertCompleted = false;

            autor.IdAutor = DataBaseUtilities.GetNextIdForUse("C_Autores", "Id", connection);

            try
            {
                connection.Open();

                string sqlQuery = "INSERT INTO C_Obra(Id,GradoAcademico,Desc,DescMay)" +
                                "VALUES (@Id,@GradoAcademico,@Desc,@DescMay)";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@Id", autor.IdAutor);
                cmd.Parameters.AddWithValue("@GradoAcademico", autor.Grado);
                cmd.Parameters.AddWithValue("@Desc", autor.Nombre);
                cmd.Parameters.AddWithValue("@DescMay", StringUtilities.PrepareToAlphabeticalOrder(autor.Nombre));

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


        public bool UpdateAutor(Autor autor)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            bool updateCompleted = false;

            try
            {
                connection.Open();

                string sqlQuery = "UPDATE C_Autores SET GradoAcademico = @GradoAcademico, Desc = @Desc, DescMay = @DescMay " +
                                "WHERE Id = @Id";

                OleDbCommand cmd = new OleDbCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@GradoAcademico", autor.Grado);
                cmd.Parameters.AddWithValue("@Desc", autor.Nombre);
                cmd.Parameters.AddWithValue("@DescMay", StringUtilities.PrepareToAlphabeticalOrder(autor.Nombre));
                cmd.Parameters.AddWithValue("@Id", autor.IdAutor);

                cmd.ExecuteNonQuery();

                cmd.Dispose();
                updateCompleted = true;
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

            return updateCompleted;
        }


    }
}
