using PadronApi.Dto;
using PadronApi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadronApi.Singletons
{
    public class TituloSingleton
    { 
        private static ObservableCollection<ElementalProperties> titulos;

        private TituloSingleton()
        {
        }

        public static ObservableCollection<ElementalProperties> Titulos
        {
            get
            {
                if (titulos == null)
                    titulos = new ElementalPropertiesModel().GetTitulos();

                return titulos;
            }
        }
    }
}
