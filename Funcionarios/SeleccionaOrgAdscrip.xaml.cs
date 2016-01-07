using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PadronApi.Dto;
using PadronApi.Model;

namespace Funcionarios
{
    /// <summary>
    /// Interaction logic for SeleccionaOrgAdscrip.xaml
    /// </summary>
    public partial class SeleccionaOrgAdscrip : Window
    {
        Titular titular;
        Organismo organismo;
        ObservableCollection<Organismo> catalogoOrganismo; 

        public SeleccionaOrgAdscrip(Titular titular)
        {
            InitializeComponent();
            this.titular = titular;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            catalogoOrganismo = new OrganismoModel().GetOrganismoForAdscripcion();
            GOrganismos.DataContext = catalogoOrganismo;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            titular.IdOrganismoAdscripcion =0;
            titular.OrganismoAdscripcion = String.Empty;
            DialogResult = false;
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (organismo == null)
            {
                MessageBox.Show("Debes seleccionar el organismo al cual esta adscrito el titular, de los contrario presiona cancelar");
                return;
            }

            titular.IdOrganismoAdscripcion = organismo.IdOrganismo;
            titular.OrganismoAdscripcion = organismo.OrganismoDesc;

            DialogResult = true;
            this.Close();
        }

        private void GOrganismos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            organismo = GOrganismos.SelectedItem as Organismo;
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ScjnUtilities.StringUtilities.PrepareToAlphabeticalOrder( ((TextBox)sender).Text);

            if (!String.IsNullOrEmpty(tempString))
                GOrganismos.DataContext = (from n in catalogoOrganismo
                                          where n.OrganismoStr.Contains(tempString) 
                                          select n).ToList();
            else
                GOrganismos.DataContext = catalogoOrganismo;
        }
    }
}
