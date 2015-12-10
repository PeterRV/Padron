using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PadronApi.Dto
{
    public class Autor
    {
        private int idAutor;
        private int grado;
        private string nombre;
        private string nombreStr;
        private ObservableCollection<Obra> obras;

public int IdAutor
        {
            get
            {
                return this.idAutor;
            }
            set
            {
                this.idAutor = value;
            }
        }

        public int Grado
        {
            get
            {
                return this.grado;
            }
            set
            {
                this.grado = value;
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

        public ObservableCollection<Obra> Obras
        {
            get
            {
                return this.obras;
            }
            set
            {
                this.obras = value;
            }
        }

        
    }
}
