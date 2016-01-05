using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PadronApi.Dto
{
    public class Estado
    {
        private int idEstado;
        private string estado;
        private string estadoStr;
        private string abreviatura;
        private int idPais;
        private ObservableCollection<Ciudad> ciudades; 

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

        public string EstadoDesc
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string EstadoStr
        {
            get
            {
                return this.estadoStr;
            }
            set
            {
                this.estadoStr = value;
            }
        }

        public string Abreviatura
        {
            get
            {
                return this.abreviatura;
            }
            set
            {
                this.abreviatura = value;
            }
        }

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

        public ObservableCollection<Ciudad> Ciudades
        {
            get
            {
                return this.ciudades;
            }
            set
            {
                this.ciudades = value;
            }
        }
    }
}
