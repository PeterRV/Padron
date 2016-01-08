using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PadronApi.Dto;
using PadronApi.Model;
using ScjnUtilities;
using System.Windows.Controls;

namespace Obras
{
    /// <summary>
    /// Interaction logic for ObrasWin.xaml
    /// </summary>
    public partial class ObrasWin : Window
    {
        private Obra obra;
        private bool isUpdating;
        private ObservableCollection<Obra> catalogoObras;
        private bool llenarCombos;

        public ObrasWin(ObservableCollection<Obra> catalogoObras)
        {
            InitializeComponent();
            this.obra = new Obra();
            this.isUpdating = false;
            this.catalogoObras = catalogoObras;
        }

        public ObrasWin(Obra obra, bool isUpdating)
        {
            InitializeComponent();
            this.obra = obra;
            this.isUpdating = isUpdating;
            this.llenarCombos = !isUpdating;

            if (!isUpdating)
            {
                PanelCentral.IsEnabled = false;
                BtnGuardar.Visibility = Visibility.Hidden;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = obra;

            TxtYear.Maximum = DateTime.Now.Year + 1;

            CbxPresentacion.DataContext = new ElementalPropertiesModel().GetPresentacion();
            CbxTipoObra.DataContext = new ElementalPropertiesModel().GetTipoObra();

            CbxPresentacion.SelectedValue = obra.Presentacion;
            CbxTipoObra.SelectedValue = obra.TipoObra;
            
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtTitulo.Text) || String.IsNullOrWhiteSpace(TxtTitulo.Text))
            {
                MessageBox.Show("Para dar de alta una obra debes ingresar su título");
                return;
            }

            if (String.IsNullOrEmpty(TxtNumMaterial.Text) || String.IsNullOrWhiteSpace(TxtNumMaterial.Text))
            {
                MessageBox.Show("Para dar de alta una obra debes ingresar el número de material");
                return;
            }
            else if (TxtNumMaterial.Text.Length < 8)
            {
                MessageBox.Show("El número de material debe contener al menos 8 cifras");
                return;
            }

            if ((TxtIsbn.Text.Length > 0) && !VerificationUtilities.IsbnValidation(TxtIsbn.Text))
            {
                MessageBoxResult result = MessageBox.Show("El número de ISBN que ingresaste es incorrecto sino cuentas con el y deseas continuar presiona SI y el campo se vaciará, para revisar el ISBN presona NO", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                    TxtIsbn.Text = String.Empty;
                else
                    return;
            }

            if (CbxPresentacion.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar la presentación de la obra");
                return;
            }

            if (CbxTipoObra.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar el tipo de obra");
                return;
            }

            bool exito = false;

            ElementalProperties pres = CbxPresentacion.SelectedItem as ElementalProperties;
            ElementalProperties tipo = CbxTipoObra.SelectedItem as ElementalProperties;

            obra.Presentacion = pres.IdElemento;
            obra.TipoObra = tipo.IdElemento;

            ObraModel model = new ObraModel();

            obra.Titulo = VerificationUtilities.TextBoxStringValidation(obra.Titulo);
            obra.NumMaterial = VerificationUtilities.TextBoxStringValidation(obra.NumMaterial);

            if (isUpdating)
            {
                exito = model.UpdateObra(obra);

                if (!exito)
                {
                    MessageBox.Show("Algo salio mal al intentar actualizar, por favor vuelve a intentarlo");
                    return;
                }
            }
            else
            {
                exito = model.InsertaObra(obra);

                if (!exito)
                {
                    MessageBox.Show("Algo salio mal al intentar agregar la obra al catálogo, por favor vuelve a intentarlo");
                    return;
                }

                catalogoObras.Insert(0, obra);
            }

            this.Close();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = StringUtilities.IsTextAllowed(e.Text);
        }

        private void TxtIsbn_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtIsbn.Text) || !String.IsNullOrWhiteSpace(TxtIsbn.Text))
            {
                if (!VerificationUtilities.IsbnValidation(TxtIsbn.Text))
                {
                    MessageBox.Show("El número de ISBN que ingresaste es incorrecto, sino cuentas con el deja el campo en blanco", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
           
        }

        private void TxtNumMaterial_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (TxtNumMaterial.Text.Contains("-") && e.Text.Equals("-"))
            {
                e.Handled = true;
                return;
            }

            if (TxtNumMaterial.Text.Length > 20)
            {
                e.Handled = true;
                return;
            }

            e.Handled = VerificationUtilities.IsNumberOrGuion(e.Text);
            TxtNumMaterial.Text = TxtNumMaterial.Text.Trim();
        }

        private void TxtsLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;

            box.Text = VerificationUtilities.TextBoxStringValidation(box.Text);
        }

        private void TxtIsbn_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = VerificationUtilities.IsNumberOrGuion(e.Text);
            
        }

        private void TxtsPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }



       
    }
}