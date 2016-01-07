using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PadronApi.Dto;
using PadronApi.Model;

namespace Organismos
{
    /// <summary>
    /// Interaction logic for SelecccionaFuncionarios.xaml
    /// </summary>
    public partial class SelecccionaFuncionarios : Window
    {
        private Organismo currentOrganismo;
        private Titular selectedTitular;
        private ObservableCollection<Titular> listaTitulares;

        public SelecccionaFuncionarios(Organismo currentOrganismo)
        {
            InitializeComponent();
            this.currentOrganismo = currentOrganismo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listaTitulares= new TitularModel().GetTitularesSinAdscripcion();
            GTitulares.DataContext = listaTitulares;
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
                GTitulares.DataContext = (from n in listaTitulares
                                          where n.NombreStr.ToUpper().Contains(tempString)
                                          select n).ToList();
            else
                GTitulares.DataContext = listaTitulares;
        }

        private void GTitulares_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTitular = GTitulares.SelectedItem as Titular;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTitular == null)
            {
                MessageBox.Show("Para poder esablecer una relación Organismo-Titular debes seleccionar un funcionario");
                return;
            }
            else
            {
                if (currentOrganismo.Integrantes == null)
                    currentOrganismo.Integrantes = new ObservableCollection<Titular>();

                currentOrganismo.Integrantes.Add(selectedTitular);
                this.Close();
            }

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
