using System;
using System.Linq;

namespace PadronApi.Dto
{
    public class Ciudad
    {
        private int idCiudad;
        private string ciudad;
        private string ciudadStr;
        private int idEstado;

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

        public string CiudadDesc
        {
            get
            {
                return this.ciudad;
            }
            set
            {
                this.ciudad = value;
            }
        }

        public string CiudadStr
        {
            get
            {
                return this.ciudadStr;
            }
            set
            {
                this.ciudadStr = value;
            }
        }

        public int IdEstado
        {
            get
            {
                return this.idEstado;
            }
            set
            {
                this.idEstado = value;
            }
        }
    }
}
