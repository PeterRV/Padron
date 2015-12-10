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
    public class FuncionesSingleton
    {
        private static ObservableCollection<ElementalProperties> funciones;

        private FuncionesSingleton()
        {
        }

        public static ObservableCollection<ElementalProperties> Funciones
        {
            get
            {
                if (funciones == null)
                    funciones = new ElementalPropertiesModel().GetFunciones();

                return funciones;
            }
        }
    }
}
