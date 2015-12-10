using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadronApi.Dto
{
    public class Titular : INotifyPropertyChanged
    {
        private int idTitular;
        private string claveTitular;
        private string nombre;
        private string nombreStr;
        private string apellidos;
        private string apellidosStr;
        private int idTitulo;
        private int cargo;
        private int funcion;
        private int activo;
        private int estado;
        private string observaciones;
        private bool quiereDistribucion;
        private int idOrganismoAdscripcion;
        private string organismoAdscripcion;
       
        public int IdTitular
        {
            get
            {
                return this.idTitular;
            }
            set
            {
                this.idTitular = value;
            }
        }

        public string ClaveTitular
        {
            get
            {
                return this.claveTitular;
            }
            set
            {
                this.claveTitular = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string NombreStr
        {
            get
            {
                return this.nombreStr;
            }
            set
            {
                this.nombreStr = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return this.apellidos;
            }
            set
            {
                this.apellidos = value;
            }
        }

        public string ApellidosStr
        {
            get
            {
                return this.apellidosStr;
            }
            set
            {
                this.apellidosStr = value;
            }
        }

        public int IdTitulo
        {
            get
            {
                return this.idTitulo;
            }
            set
            {
                this.idTitulo = value;
            }
        }

        public int Cargo
        {
            get
            {
                return this.cargo;
            }
            set
            {
                this.cargo = value;
            }
        }

        public int Funcion
        {
            get
            {
                return this.funcion;
            }
            set
            {
                this.funcion = value;
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

        public bool QuiereDistribucion
        {
            get
            {
                return this.quiereDistribucion;
            }
            set
            {
                this.quiereDistribucion = value;
            }
        }

        public int IdOrganismoAdscripcion
        {
            get
            {
                return this.idOrganismoAdscripcion;
            }
            set
            {
                this.idOrganismoAdscripcion = value;
            }
        }

        public string OrganismoAdscripcion
        {
            get
            {
                return this.organismoAdscripcion;
            }
            set
            {
                this.organismoAdscripcion = value;
                this.OnPropertyChanged("OrganismoAdscripcion");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
        
    }
}
