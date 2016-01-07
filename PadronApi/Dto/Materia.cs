using System;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using ScjnUtilities;
using System.Configuration;

namespace PadronApi.Dto
{
    public class Materia
    {

        private int idMateria;
        private bool isChecked;
        private string materiaDesc;
        private string materiaStr;
        private int decimalValue;


        public int IdMateria
        {
            get
            {
                return this.idMateria;
            }
            set
            {
                this.idMateria = value;
            }
        }

        public bool IsChecked
        {
            get
            {
                return this.isChecked;
            }
            set
            {
                this.isChecked = value;
            }
        }

        public string MateriaDesc
        {
            get
            {
                return this.materiaDesc;
            }
            set
            {
                this.materiaDesc = value;
            }
        }

        public string MateriaStr
        {
            get
            {
                return this.materiaStr;
            }
            set
            {
                this.materiaStr = value;
            }
        }

        public int DecimalValue
        {
            get
            {
                return this.decimalValue;
            }
            set
            {
                this.decimalValue = value;
            }
        }

        public ObservableCollection<Materia> GetMaterias()
        {
            ObservableCollection<Materia> catalogoMaterias = new ObservableCollection<Materia>();

            string sqlCadena = "SELECT * FROM C_Materia WHERE IdTipoMateria = 1 ORDER BY IdMateria";

            OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["Base"].ConnectionString);
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
                        Materia materia = new Materia();
                        materia.IdMateria = Convert.ToInt32(reader["IdMateria"]);
                        materia.isChecked = false;
                        materia.MateriaDesc = reader["Materia"].ToString();
                        materia.DecimalValue = Convert.ToInt32(reader["MateriaBin"]);

                        catalogoMaterias.Add(materia);

                    }
                }
                cmd.Dispose();
                reader.Close();
            }
            catch (OleDbException ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Materia", "PadronApi");
            }
            catch (Exception ex)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                ErrorUtilities.SetNewErrorMessage(ex, methodName + " Exception,Materia", "PadronApi");
            }
            finally
            {
                connection.Close();
            }

            return catalogoMaterias;
        }

    }
}
