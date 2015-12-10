using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PadronApi.Dto
{
    public class Obra
    {
        private int idObra;
        private int orden;
        private string titulo;
        private string tituloStr;
        private string sintesis;
        private string sintesisStr;
        private string numMaterial;
        private int anioPublicacion = DateTime.Now.Year;
        private string edicion;
        private string isbn;
        private int pais;
        private int idIdioma;
        private int paginas;
        private int numLibros = 1;
        private string clasificacion;
        private int tipoObra;
        private int medioPublicacion;
        private int presentacion;
        private int materia;
        private string descripcion;
        private string descripcionStr;
        private int consecutivo;
        private string precio;
        private string imagePath;
        private int conMay;
        private int nivel;
        private int padre;
        private int idUsuario;
        private DateTime fechaUsuario;
        private int fechaUsuarioInt;
        private int agotado;
        private int activo;

        /// <summary>
        /// Indica si la obra deberá se mostrada en el Kiosko
        /// 1. Incluye
        /// 2. Excluye
        /// </summary>
        private int catalogo;

        private ObservableCollection<Autor> autores;
        
        public int IdObra
        {
            get
            {
                return this.idObra;
            }
            set
            {
                this.idObra = value;
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

        public string Titulo
        {
            get
            {
                return this.titulo;
            }
            set
            {
                this.titulo = value;
            }
        }

        public string TituloStr
        {
            get
            {
                return this.tituloStr;
            }
            set
            {
                this.tituloStr = value;
            }
        }

        public string Sintesis
        {
            get
            {
                return this.sintesis;
            }
            set
            {
                this.sintesis = value;
            }
        }

        public string SintesisStr
        {
            get
            {
                return this.sintesisStr;
            }
            set
            {
                this.sintesisStr = value;
            }
        }

        public string NumMaterial
        {
            get
            {
                return this.numMaterial;
            }
            set
            {
                this.numMaterial = value;
            }
        }

        public int AnioPublicacion
        {
            get
            {
                return this.anioPublicacion;
            }
            set
            {
                this.anioPublicacion = value;
            }
        }

        public string Edicion
        {
            get
            {
                return this.edicion;
            }
            set
            {
                this.edicion = value;
            }
        }

        public string Isbn
        {
            get
            {
                return this.isbn;
            }
            set
            {
                this.isbn = value;
            }
        }

        public int Pais
        {
            get
            {
                return this.pais;
            }
            set
            {
                this.pais = value;
            }
        }

        public int IdIdioma
        {
            get
            {
                return this.idIdioma;
            }
            set
            {
                this.idIdioma = value;
            }
        }

        public int Paginas
        {
            get
            {
                return this.paginas;
            }
            set
            {
                this.paginas = value;
            }
        }

        public int NumLibros
        {
            get
            {
                return this.numLibros;
            }
            set
            {
                this.numLibros = value;
            }
        }

        public string Clasificacion
        {
            get
            {
                return this.clasificacion;
            }
            set
            {
                this.clasificacion = value;
            }
        }

        public int TipoObra
        {
            get
            {
                return this.tipoObra;
            }
            set
            {
                this.tipoObra = value;
            }
        }

        public int MedioPublicacion
        {
            get
            {
                return this.medioPublicacion;
            }
            set
            {
                this.medioPublicacion = value;
            }
        }

        public int Presentacion
        {
            get
            {
                return this.presentacion;
            }
            set
            {
                this.presentacion = value;
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

        public string DescripcionStr
        {
            get
            {
                return this.descripcionStr;
            }
            set
            {
                this.descripcionStr = value;
            }
        }

        public int Consecutivo
        {
            get
            {
                return this.consecutivo;
            }
            set
            {
                this.consecutivo = value;
            }
        }

        public string Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }
            set
            {
                this.imagePath = value;
            }
        }

        public int ConMay
        {
            get
            {
                return this.conMay;
            }
            set
            {
                this.conMay = value;
            }
        }

        public int Nivel
        {
            get
            {
                return this.nivel;
            }
            set
            {
                this.nivel = value;
            }
        }

        public int Padre
        {
            get
            {
                return this.padre;
            }
            set
            {
                this.padre = value;
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

        public DateTime FechaUsuario
        {
            get
            {
                return this.fechaUsuario;
            }
            set
            {
                this.fechaUsuario = value;
            }
        }

        public int FechaUsuarioInt
        {
            get
            {
                return this.fechaUsuarioInt;
            }
            set
            {
                this.fechaUsuarioInt = value;
            }
        }

        public int Agotado
        {
            get
            {
                return this.agotado;
            }
            set
            {
                this.agotado = value;
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

        public int Catalogo
        {
            get
            {
                return this.catalogo;
            }
            set
            {
                this.catalogo = value;
            }
        }

        public ObservableCollection<Autor> Autores
        {
            get
            {
                return this.autores;
            }
            set
            {
                this.autores = value;
            }
        }
    }
}
