using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using PadronApi.Dto;
using PadronApi.Model;
using PadronApi.Singletons;

namespace Funcionarios
{
    /// <summary>
    /// Interaction logic for AgregaFuncionario.xaml
    /// </summary>
    public partial class AgregaFuncionario : Window
    {
        private bool isUpdating;
        private ObservableCollection<Titular> catalogoTitulares;
        private Titular titular;

        public AgregaFuncionario(ObservableCollection<Titular> catalogoTitulares)
        {
            InitializeComponent();
            this.catalogoTitulares = catalogoTitulares;
            this.titular = new Titular();
            this.isUpdating = false;
            titular.Activo = 1;
            ChkActivado.IsEnabled = false;
        }

        public AgregaFuncionario(Titular titular, bool isUpdating)
        {
            InitializeComponent();
            this.titular = titular;
            this.isUpdating = isUpdating;

            if (!isUpdating)
            {
                PanelPrincipal.IsEnabled = false;
                BtnGuardar.Visibility = Visibility.Hidden;
            }
            else
            {
                if (titular.IdOrganismoAdscripcion != 0 && titular.IdOrganismoAdscripcion != 7090)
                {
                    BtnAgregaAdscripcion.IsEnabled = false;
                    BtnEliminaAdscripcion.IsEnabled = true;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxFuncion.DataContext = FuncionesSingleton.Funciones;
            CbxGrado.DataContext = TituloSingleton.Titulos;
            CbxEstado.DataContext = ElementalPropertiesSingleton.Estatus;

            this.DataContext = titular;

            if (isUpdating)
            {
                CbxFuncion.SelectedValue = titular.Funcion;
                CbxGrado.SelectedValue = titular.IdTitulo;
                CbxEstado.SelectedValue = titular.Estado;
            }
        }

        private void BtnEliminaAdscripcion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar la adscripción de este titular?", "Atención",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                titular.IdOrganismoAdscripcion = 0;
                titular.OrganismoAdscripcion = String.Empty;
                BtnAgregaAdscripcion.IsEnabled = true;
                BtnEliminaAdscripcion.IsEnabled = false;
                CbxFuncion.SelectedIndex = -1;
                //Posiblemente guardar una entrada en base de datos como testigo del cambio
            }
        }

        private void BtnAgregaAdscripcion_Click(object sender, RoutedEventArgs e)
        {
            //Mostrar la ventana de seleccion de organismo
            SeleccionaOrgAdscrip org = new SeleccionaOrgAdscrip(titular);
            org.ShowDialog();

            BtnAgregaAdscripcion.IsEnabled = false;
            BtnEliminaAdscripcion.IsEnabled = true;
            //Entrada en base de datos
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!isUpdating)
            {
                //if (CbxCargo.SelectedIndex == -1)
                //{
                //    MessageBox.Show("Debes seleccionar el cargo del titular");
                //    return;
                //}

                if ((titular.IdOrganismoAdscripcion != 0 && titular.IdOrganismoAdscripcion != 7090) && CbxFuncion.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecciona la función del titular dentro del organismo");
                    return;
                }

                if (String.IsNullOrEmpty(TxtNombre.Text) || String.IsNullOrEmpty(TxtApellidos.Text))
                {
                    MessageBox.Show("Ingresa el nombre y los apellidos del titular");
                    return;
                }
            }

            titular.IdTitulo = Convert.ToInt32(CbxGrado.SelectedValue);
            titular.Estado = Convert.ToInt32(CbxEstado.SelectedValue);

            if ((titular.IdOrganismoAdscripcion != 0 && titular.IdOrganismoAdscripcion != 7090))
            {
                titular.Funcion = Convert.ToInt32(CbxFuncion.SelectedValue);
            }

            TitularModel model = new TitularModel();
            bool exito = false;

            if (isUpdating)
            {
                exito = model.UpdateTitular(titular);

                if (!exito)
                {
                    MessageBox.Show("Hubo un problema con la actualización intentelo nuevamente");
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                exito = model.InsertaTitular(titular);

                if (!exito)
                {
                    MessageBox.Show("Hubo un problema al ingresar el titular intentelo nuevamente");
                    return;
                }
                else
                {
                    catalogoTitulares.Add(titular);
                    this.Close();
                }
            }
        }
    }
}