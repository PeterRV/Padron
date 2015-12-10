using System;
using System.Linq;

namespace PadronApi.Dto
{
    public class PaisEstado
    {
        private int idPais;
        private int idEstdo;
        private int idCiudad;
        private string descripcion;

        public int IdPais
        {
            get
            {
                return this.idPais;
            }
            set
            {
                this.idPais = value;
            }
        }

        public int IdEstdo
        {
            get
            {
                return this.idEstdo;
            }
            set
            {
                this.idEstdo = value;
            }
        }

        public int IdCiudad
        {
            get
            {
                return this.idCiudad;
            }
            set
            {
                this.idCiudad = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
    }
}
