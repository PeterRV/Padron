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
    public class PaisEstadoSingleton
    {
         private static ObservableCollection<PaisEstado> ciudades;

         private PaisEstadoSingleton()
        {
        }

         public static ObservableCollection<PaisEstado> Ciudades
        {
            get
            {
                if (ciudades == null)
                    ciudades = new PaisEstadoModel().GetCiudades();

                return ciudades;
            }
        }
    }
}
