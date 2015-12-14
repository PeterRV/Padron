using PadronApi.Dto;
using PadronApi.Singletons;
using ScjnUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Organismos
{
    /// <summary>
    /// Interaction logic for AgregaOrganismo.xaml
    /// </summary>
    public partial class AgregaOrganismo : Window
    {

        private ElementalProperties selectedTipoOrg;

        public AgregaOrganismo()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxTipoOrg.DataContext = ElementalPropertiesSingleton.TipoOrganismo;
            CbxDistribucion.DataContext = ElementalPropertiesSingleton.Distribucion;
        }

        private void TxtPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (TxtCp.Text.Length >= 5)
            {
                e.Handled = true;
                return;
            }

            e.Handled = VerificationUtilities.IsNumber(e.Text);
        }

        private void TxtTelValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = VerificationUtilities.IsNumberOrGuion(e.Text);
        }

        private void CbxTipoOrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTipoOrg = CbxTipoOrg.SelectedItem as ElementalProperties;

            if (selectedTipoOrg.IdElemento < 2 && selectedTipoOrg.IdElemento > 10)
            {
                GbxMaterias.IsEnabled = false;
                CbxOrdinal.IsEditable = false;
                CbxCircuito.IsEnabled = false;

                CbxCircuito.SelectedIndex = -1;
                CbxOrdinal.SelectedIndex = -1;
            }
            else
            {
                GbxMaterias.IsEnabled = true;
                CbxOrdinal.IsEditable = true;
                CbxCircuito.IsEnabled = true;
            }
        }
    }
}
