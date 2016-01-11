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
    /// Interaction logic for ListaFuncionarios.xaml
    /// </summary>
    public partial class ListaFuncionarios : UserControl
    {

        public ObservableCollection<Titular> CatalogoTitulares;
        public Titular SelectedTitular;

        public ListaFuncionarios()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CatalogoTitulares = new TitularModel().GetTitulares();

            GTitulares.DataContext = CatalogoTitulares;
            LblTotales.Content = CatalogoTitulares.Count.ToString() + " registros";
        }

        private void GTitulares_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTitular = GTitulares.SelectedItem as Titular;
            LblTotales.Content = (GTitulares.SelectedIndex + 1) + " de " + CatalogoTitulares.Count.ToString() + " registros";
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
            {
                var temporal = (from n in CatalogoTitulares
                                          where n.NombreStr.ToUpper().Contains(tempString) || n.OrganismoAdscripcion.ToUpper().Contains(tempString)
                                          select n).ToList();
                LblTotales.Content = temporal.Count + " registros";
                GTitulares.DataContext = temporal;
            }
            else
            {
                GTitulares.DataContext = CatalogoTitulares;
                LblTotales.Content = CatalogoTitulares.Count + " registros";
            }
        }
    }
}
