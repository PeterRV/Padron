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
    public class ElementalPropertiesSingleton
    {

         private static ObservableCollection<ElementalProperties> estatus;

         private ElementalPropertiesSingleton()
        {
        }

         public static ObservableCollection<ElementalProperties> Estatus
        {
            get
            {
                if (estatus == null)
                    estatus = new ElementalPropertiesModel().GetEstatus();

                return estatus;
            }
        }



        #region Organismos 

         private static ObservableCollection<ElementalProperties> tipoOrganismo;
         private static ObservableCollection<ElementalProperties> distribucion;

         public static ObservableCollection<ElementalProperties> TipoOrganismo
         {
             get
             {
                 if (tipoOrganismo == null)
                     tipoOrganismo = new ElementalPropertiesModel().GetTipoOrganismo();

                 return tipoOrganismo;
             }
         }


         public static ObservableCollection<ElementalProperties> Distribucion
         {
             get
             {
                 if (distribucion == null)
                     distribucion = new ElementalPropertiesModel().GetTiposDistribucion();

                 return distribucion;
             }
         }
        #endregion

    }
}
