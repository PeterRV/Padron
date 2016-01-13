using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using PadronApi.Dto;
using PadronApi.Model;
using PadronApi.Singletons;
using ScjnUtilities;

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
        string qCambio = String.Empty;

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
            else
                CbxEstado.SelectedIndex = 0;

            qCambio = String.Empty;
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

            qCambio += "O";
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (CbxGrado.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona el título con el cual se deben dirigir los oficios al titular", "Agregar Titular", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrEmpty(TxtNombre.Text) || String.IsNullOrEmpty(TxtApellidos.Text))
            {
                MessageBox.Show("Ingresa el nombre y los apellidos del titular", "Agregar Titular", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if ((titular.IdOrganismoAdscripcion != 0 && titular.IdOrganismoAdscripcion != 7090) && CbxFuncion.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona la función del titular dentro del organismo", "Agregar Titular", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (titular.IdOrganismoAdscripcion == 0)
            {
                MessageBoxResult result = MessageBox.Show("Este titular no ha sido adscrito a ningún organismo ¿Deseas continuar?", "Titulares", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    return;
            }

            titular.IdTitulo = Convert.ToInt32(CbxGrado.SelectedValue);
            titular.Estado = Convert.ToInt32(CbxEstado.SelectedValue);

            if ((titular.IdOrganismoAdscripcion != 0 && titular.IdOrganismoAdscripcion != 7090))
            {
                titular.Funcion = Convert.ToInt32(CbxFuncion.SelectedValue);
            }

            if ((!String.IsNullOrWhiteSpace(titular.Correo) && !String.IsNullOrEmpty(titular.Correo) && !VerificationUtilities.IsMailAddress(titular.Correo)))
            {
                MessageBox.Show("El correo electrónico ingresado no es válido, si no cuentas con uno deja el campo en blanco", "Titulares", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            TitularModel model = new TitularModel();
            bool exito = false;

            titular.Nombre = VerificationUtilities.TextBoxStringValidation(titular.Nombre);
            titular.Apellidos = VerificationUtilities.TextBoxStringValidation(titular.Apellidos);

            if (isUpdating)
            {
                Titular dummyTitular = model.GetTitulares(titular);
                
                exito = model.UpdateTitular(titular);

                if (!exito)
                {
                    MessageBox.Show("Hubo un problema con la actualización intentelo nuevamente");
                    return;
                }
                else
                {
                    if ((titular.IdOrganismoAdscripcion != dummyTitular.IdOrganismoAdscripcion) || (titular.Funcion != dummyTitular.Funcion) || (titular.Activo != dummyTitular.Activo) )
                    {
                        model.InsertaHistorico(dummyTitular);
                    }
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

        private void TxtPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = VerificationUtilities.ContieneCaractNoPermitidos(e.Text);
        }

        private void CbxFuncion_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            qCambio += "F";
        }

        private void ChkActivado_Unchecked(object sender, RoutedEventArgs e)
        {
            qCambio += "A";
        }

        private void ChkActivado_Checked(object sender, RoutedEventArgs e)
        {
            qCambio += "A";
        }
    }
}