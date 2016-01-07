using System;
using System.Collections.ObjectModel;
using System.Linq;
using PadronApi.Dto;
using PadronApi.Model;

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
