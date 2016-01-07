using PadronApi.Dto;
using PadronApi.Model;
using PadronApi.Singletons;
using ScjnUtilities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Organismos.Ciudades
{
    /// <summary>
    /// Interaction logic for Ciudad.xaml
    /// </summary>
    public partial class AddCiudad : Window
    {
        Estado estado;
        Pais selectedPais;

        public AddCiudad()
        {
            InitializeComponent();
        }

        public AddCiudad(Estado estado)
        {
            InitializeComponent();
            this.estado = estado;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxPais.DataContext = PaisesSingleton.Paises;
            CbxPais.SelectedValue = estado.IdPais;
        }

        private void CbxPais_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedPais = CbxPais.SelectedItem as Pais;

            CbxEstado.DataContext = selectedPais.Estados;
            CbxEstado.SelectedItem = estado;
        }

        private void TxtCiudad_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;

            box.Text = VerificationUtilities.TextBoxStringValidation(box.Text);
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtCiudad.Text) || String.IsNullOrWhiteSpace(TxtCiudad.Text))
            {
                MessageBox.Show("Para continuar debes ingresar el nombre de la ciudad que deseas agregar, de lo contrario presiona Cancelar");
                return;
            }

            Ciudad newciudad = new Ciudad();
            newciudad.CiudadDesc = TxtCiudad.Text;
            newciudad.CiudadStr = StringUtilities.PrepareToAlphabeticalOrder(TxtCiudad.Text);
            newciudad.IdEstado = estado.IdEstado;

            bool complete = new PaisEstadoModel().InsertaCiudad(newciudad);

            if (complete)
            {
                estado.Ciudades.Insert(0, newciudad);
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo completar la operación, intentalo nuevamente");
                return;
            }
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
