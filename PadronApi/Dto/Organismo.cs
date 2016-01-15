using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PadronApi.Dto
{
    public class Organismo
    {
        private int idOrganismo;
        private string organismoDesc = String.Empty;
        private string organismoStr = String.Empty;
        private int tipoOrganismo;
        private string tipoOrganismoStr = String.Empty;
        private int circuito;
        private int ordinal;
        private int materia;
        private int ciudad;
        private int estado;
        private string calle = String.Empty;
        private string colonia = String.Empty;
        private string delegacion = String.Empty;
        private string cp = String.Empty;
        private string telefono = String.Empty;
        private string telefono1 = String.Empty;
        private string telefono2 = String.Empty;
        private string telefono3 = String.Empty;
        private string mail = String.Empty;
        private string observaciones = String.Empty;
        private int activo;
        private int tipoDistr;
        private string distribucion = String.Empty;
        private string abreviado = String.Empty;
        private int orden;
        private ObservableCollection<Titular> integrantes;
        private int idUsuario;
        private int fecha;

        public int IdOrganismo
        {
            get
            {
                return this.idOrganismo;
            }
            set
            {
                this.idOrganismo = value;
            }
        }

        public string OrganismoDesc
        {
            get
            {
                return this.organismoDesc;
            }
            set
            {
                this.organismoDesc = value;
            }
        }

        public string OrganismoStr
        {
            get
            {
                return this.organismoStr;
            }
            set
            {
                this.organismoStr = value;
            }
        }

        public int TipoOrganismo
        {
            get
            {
                return this.tipoOrganismo;
            }
            set
            {
                this.tipoOrganismo = value;
            }
        }

        public string TipoOrganismoStr
        {
            get
            {
                return this.tipoOrganismoStr;
            }
            set
            {
                this.tipoOrganismoStr = value;
            }
        }

        public int Circuito
        {
            get
            {
                return this.circuito;
            }
            set
            {
                this.circuito = value;
            }
        }

        public int Ordinal
        {
            get
            {
                return this.ordinal;
            }
            set
            {
                this.ordinal = value;
            }
        }

        public int Materia
        {
            get
            {
                return this.materia;
            }
            set
            {
                this.materia = value;
            }
        }

        public int Ciudad
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

        public int Estado
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

        public string Calle
        {
            get
            {
                return this.calle;
            }
            set
            {
                this.calle = value;
            }
        }

        public string Colonia
        {
            get
            {
                return this.colonia;
            }
            set
            {
                this.colonia = value;
            }
        }

        public string Delegacion
        {
            get
            {
                return this.delegacion;
            }
            set
            {
                this.delegacion = value;
            }
        }

        public string Cp
        {
            get
            {
                return this.cp;
            }
            set
            {
                this.cp = value;
            }
        }

        public string Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }

        public string Telefono1
        {
            get
            {
                return this.telefono1;
            }
            set
            {
                this.telefono1 = value;
            }
        }

        public string Telefono2
        {
            get
            {
                return this.telefono2;
            }
            set
            {
                this.telefono2 = value;
            }
        }

        public string Telefono3
        {
            get
            {
                return this.telefono3;
            }
            set
            {
                this.telefono3 = value;
            }
        }

        public string Mail
        {
            get
            {
                return this.mail;
            }
            set
            {
                this.mail = value;
            }
        }

        public string Observaciones
        {
            get
            {
                return this.observaciones;
            }
            set
            {
                this.observaciones = value;
            }
        }

        public int Activo
        {
            get
            {
                return this.activo;
            }
            set
            {
                this.activo = value;
            }
        }

        public int TipoDistr
        {
            get
            {
                return this.tipoDistr;
            }
            set
            {
                this.tipoDistr = value;
            }
        }

        public string Distribucion
        {
            get
            {
                return this.distribucion;
            }
            set
            {
                this.distribucion = value;
            }
        }

        public string Abreviado
        {
            get
            {
                return this.abreviado;
            }
            set
            {
                this.abreviado = value;
            }
        }

        public int Orden
        {
            get
            {
                return this.orden;
            }
            set
            {
                this.orden = value;
            }
        }

        public ObservableCollection<Titular> Integrantes
        {
            get
            {
                return this.integrantes;
            }
            set
            {
                this.integrantes = value;
            }
        }

        public int IdUsuario
        {
            get
            {
                return this.idUsuario;
            }
            set
            {
                this.idUsuario = value;
            }
        }

        public int Fecha
        {
            get
            {
                return this.fecha;
            }
            set
            {
                this.fecha = value;
            }
        }

        public bool IsEqualTo(Organismo compareTo)
        {
            return (TipoOrganismo == compareTo.TipoOrganismo && OrganismoDesc.Equals(compareTo.organismoDesc) && 
                Circuito == compareTo.Circuito && Ordinal == compareTo.Ordinal && Materia == compareTo.Materia && 
                Ciudad == compareTo.Ciudad && Estado == compareTo.Estado && Calle.Equals(compareTo.Calle) && 
                Colonia.Equals(compareTo.Colonia) && Delegacion.Equals(compareTo.Delegacion) && Cp.Equals(compareTo.Cp) && 
                TipoDistr == compareTo.TipoDistr && Activo == compareTo.Activo);
        }
    }
}
