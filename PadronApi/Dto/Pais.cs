using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PadronApi.Dto
{
    public class Pais
    {
        private int idPais;
        private string pais;
        private string paisStr;
        private ObservableCollection<Estado> estados;

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

        public string PaisDesc
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

        public string PaisStr
        {
            get
            {
                return this.paisStr;
            }
            set
            {
                this.paisStr = value;
            }
        }

        public ObservableCollection<Estado> Estados
        {
            get
            {
                return this.estados;
            }
            set
            {
                this.estados = value;
            }
        }
    }
}
