using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PadronApi.Dto;
using PadronApi.Model;
using PadronApi.Singletons;
using ScjnUtilities;
using System.Windows.Media;
using Organismos.Ciudades;
using System.Collections.Generic;

namespace Organismos
{
    /// <summary>
    /// Interaction logic for AgregaOrganismo.xaml
    /// </summary>
    public partial class AgregaOrganismo : Window
    {
        private Pais selectedPais;
        private Estado selectedEstado;
        private Ciudad selectedCiudad;

        private Titular selectedTitular;
        private ElementalProperties selectedTipoOrg;

        private ObservableCollection<Organismo> listaOrganismos;
        private ObservableCollection<Materia> listaMaterias;

        private Organismo organismo;
        private bool? isUpdating;

        /// <summary>
        /// Permite generar un nuevo registro de Organismo y al finalizar agregar dicho organismo al listado previo
        /// </summary>
        /// <param name="listaOrganismos"></param>
        public AgregaOrganismo(ObservableCollection<Organismo> listaOrganismos)
        {
            InitializeComponent();
            this.listaOrganismos = listaOrganismos;
            this.organismo = new Organismo();
            this.organismo.Integrantes = new ObservableCollection<Titular>();
            this.isUpdating = null;
        }

        /// <summary>
        /// Permite actualizar la información relativa al organismo señalado
        /// </summary>
        /// <param name="organismo">Organismo que se va a actualizar</param>
        /// <param name="isUpdating">Indica si el organismo podrá ser modificado o solamente se visualizará la información</param>
        public AgregaOrganismo(Organismo organismo, bool isUpdating)
        {
            InitializeComponent();
            this.organismo = organismo;
            this.isUpdating = isUpdating;
            Principal.IsEnabled = isUpdating;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxTipoOrg.DataContext = ElementalPropertiesSingleton.TipoOrganismo;
            CbxDistribucion.DataContext = ElementalPropertiesSingleton.Distribucion;
            CbxCircuito.DataContext = new ElementalPropertiesModel().GetCircuitos();
            CbxOrdinal.DataContext = new ElementalPropertiesModel().GetOrdinales();

            CbxPais.DataContext = PaisesSingleton.Paises;

            this.DataContext = organismo;

            GridIntegrantes.DataContext = organismo.Integrantes;

            listaMaterias = new Materia().GetMaterias();
            CbxMateria1.DataContext = listaMaterias;
            CbxMateria2.DataContext = listaMaterias;
            CbxMateria3.DataContext = listaMaterias;

            if (listaOrganismos != null)
                CbxPais.SelectedValue = 39;

            if (isUpdating != null)
                LoadNoBindings();

        }


        private void LoadNoBindings()
        {
            organismo.Integrantes = new TitularModel().GetTitulares(organismo.IdOrganismo);
            GridIntegrantes.DataContext = organismo.Integrantes;
            CbxTipoOrg.SelectedValue = organismo.TipoOrganismo;
            CbxOrdinal.SelectedValue = organismo.Ordinal;
            CbxCircuito.SelectedValue = organismo.Circuito;
            CbxDistribucion.SelectedValue = organismo.TipoDistr;
            int idPais = new PaisEstadoModel().GetPaises(organismo.Estado).IdPais;
            CbxPais.SelectedValue = idPais;
            CbxEstado.SelectedValue = organismo.Estado;
            CbxCiudad.SelectedValue = organismo.Ciudad;

            List<int> materias = ScjnUtilities.NumericUtilities.GetDecimalsInBinary(organismo.Materia);

            if (materias.Count == 1)
                CbxMateria1.SelectedValue = materias[0];
            if (materias.Count == 2)
            {
                CbxMateria1.SelectedValue = materias[0];
                CbxMateria2.SelectedValue = materias[1];
            }
            if (materias.Count == 3)
            {
                CbxMateria1.SelectedValue = materias[0];
                CbxMateria2.SelectedValue = materias[1];
                CbxMateria3.SelectedValue = materias[2];
            }

            //Pais thePais = (from n in PaisesSingleton.Paises
            //                where n.IdPais == idPais
            //                select n).ToList()[0];

            //CbxPais.SelectedItem = thePais;

        }



        private void CbxTipoOrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TxtOrganismo.Text = String.Empty;
            selectedTipoOrg = CbxTipoOrg.SelectedItem as ElementalProperties;

            if (selectedTipoOrg.IdElemento < 2 || selectedTipoOrg.IdElemento > 10)
            {
                GpxMaterias.IsEnabled = false;
                CbxOrdinal.IsEnabled = false;
                CbxCircuito.IsEnabled = false;
                LblDescripcion.IsEnabled = false;
                TxtOrganismo.IsEnabled = true;

                CbxCircuito.SelectedIndex = -1;
                CbxOrdinal.SelectedIndex = -1;

                foreach (Materia materia in listaMaterias)
                    materia.IsChecked = false;
            }
            else
            {
                GpxMaterias.IsEnabled = true;
                CbxOrdinal.IsEnabled = true;
                CbxCircuito.IsEnabled = true;
                LblDescripcion.IsEnabled = true;
                TxtOrganismo.IsEnabled = false;
            }
        }

        private void GridIntegrantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTitular = GridIntegrantes.SelectedItem as Titular;
        }

        private void RbtnAgregaFuncionario_Click(object sender, RoutedEventArgs e)
        {
            SelecccionaFuncionarios select = new SelecccionaFuncionarios(organismo);
            select.Owner = this;
            select.ShowDialog();
        }

        private void RbtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTitular == null)
            {
                MessageBox.Show("Antes de continuar debes seleccionar al titular que ya no pertenece a esta integración");
                return;
            }

            MessageBoxResult result = MessageBox.Show("¿Estas seguro de que este funcionario ya no es integrante de este tribunal?", "Atención", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                organismo.Integrantes.Remove(selectedTitular);
            }
        }

        #region Valida informacion

        private void TxtPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (TxtCp.Text.Length >= 5)
            {
                e.Handled = true;
                return;
            }

            e.Handled = VerificationUtilities.IsNumber(e.Text);
            TxtCp.Text.Trim();
        }

        private void TxtTelValidation(object sender, TextCompositionEventArgs e)
        {
            e.Handled = VerificationUtilities.IsNumberOrGuion(e.Text);
        }

        private void TxtsLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;

            if (!String.IsNullOrEmpty(box.Text) || !String.IsNullOrWhiteSpace(box.Text))
                box.Text = VerificationUtilities.TextBoxStringValidation(box.Text);

        }

        
        #endregion


        #region Direccion

        private void CbxPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPais = CbxPais.SelectedItem as Pais;

            if (selectedPais.IdPais == 999999999)
            {
                Pais newPais = new Pais();
                PaisEstadoWin addPais = new PaisEstadoWin(newPais, false);
                addPais.Owner = this;
                addPais.ShowDialog();

                if (addPais.DialogResult == true)
                {
                    PaisesSingleton.Paises.Insert(0, newPais);
                    CbxPais.SelectedItem = newPais;
                }
                else
                {
                    CbxPais.SelectedValue = 39;
                }

            }
            else
            {
                if (selectedPais.Estados == null)
                    selectedPais.Estados = new PaisEstadoModel().GetEstados(selectedPais.IdPais);
            }

            CbxEstado.DataContext = selectedPais.Estados;
            CbxEstado.IsEnabled = true;
        }

        private void CbxEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedEstado != null)
            {
                selectedEstado = CbxEstado.SelectedItem as Estado;

                if (selectedEstado.IdEstado == 999999999)
                {
                    Estado estado = new Estado();
                    estado.IdPais = selectedPais.IdPais;
                    PaisEstadoWin addEstado = new PaisEstadoWin(estado, false);
                    addEstado.Owner = this;
                    addEstado.ShowDialog();

                    if (addEstado.DialogResult == true)
                    {
                        selectedPais.Estados.Insert(0, estado);
                        CbxEstado.SelectedItem = estado;
                    }
                    else
                    {
                        CbxEstado.SelectedIndex = -1;
                    }
                }
                else
                {

                    if (selectedEstado.Ciudades == null)
                        selectedEstado.Ciudades = new PaisEstadoModel().GetCiudades(selectedEstado.IdEstado);
                }

                CbxCiudad.DataContext = selectedEstado.Ciudades;
                CbxCiudad.IsEnabled = true;
            }
        }

       

        private void CbxCiudad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedCiudad != null)
            {
                selectedCiudad = CbxCiudad.SelectedItem as Ciudad;

                if (selectedCiudad.IdCiudad == 999999999)
                {
                    AddCiudad addCiudad = new AddCiudad(selectedEstado);
                    addCiudad.Owner = this;
                    addCiudad.ShowDialog();

                    if (addCiudad.DialogResult == true)
                    {
                        CbxCiudad.SelectedIndex = 0;
                    }
                    else
                    {
                        CbxCiudad.SelectedIndex = -1;
                    }
                }
            }
        }

        #endregion

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if ((selectedTipoOrg.IdElemento > 2 && selectedTipoOrg.IdElemento < 10) && (CbxOrdinal.SelectedIndex == -1 || CbxCircuito.SelectedIndex == -1))
            {
                MessageBox.Show("Antes de continuar debes de seleccionar el Circuito y Ordinal del organismo que intentas crear");
                return;
            }
            else
            {
                organismo.Ordinal = Convert.ToInt32(CbxOrdinal.SelectedValue);
                organismo.Circuito = Convert.ToInt32(CbxCircuito.SelectedValue);

                if (CbxMateria1.SelectedIndex != -1)
                {
                    organismo.Materia += ((Materia)CbxMateria1.SelectedItem).DecimalValue;

                    if (CbxMateria2.SelectedIndex != -1)
                    {
                        organismo.Materia += ((Materia)CbxMateria2.SelectedItem).DecimalValue;

                        if (CbxMateria3.SelectedIndex != -1)
                        {
                            organismo.Materia += ((Materia)CbxMateria3.SelectedItem).DecimalValue;
                        }
                    }
                }
            }

            if (String.IsNullOrEmpty(TxtOrganismo.Text) || String.IsNullOrWhiteSpace(TxtOrganismo.Text))
            {
                MessageBox.Show("Para continuar ingresa el nombre o descripción del organismo que intentas crear");
                return;
            }

            if (CbxEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar el estado donde esta localizado el organismo");
                return;
            }

            if (String.IsNullOrEmpty(TxtCalle.Text) || String.IsNullOrWhiteSpace(TxtCalle.Text))
            {
                MessageBox.Show("Ingresa la calle y número donde se encuentra ubicado el organismo");
                return;
            }
            else if(TxtCalle.Text.StartsWith("Calle"))
            {
                char[] letras = TxtCalle.Text.ToCharArray();

                if (!VerificationUtilities.IsNumber(letras[7].ToString()))
                {
                    MessageBox.Show("El campo Calle no puede contener la palabra calle");
                    return;
                }

            }

            if (TxtCalle.Text.StartsWith("Col ") || TxtCalle.Text.StartsWith("Col. ") || TxtCalle.Text.StartsWith("Colonia "))
            {
                MessageBox.Show("El campo Colonia no puede contener la palabra colonia, ni ninguna de sus abreviaturas");
                return;
            }

            if (TxtCalle.Text.StartsWith("Del ") || TxtCalle.Text.StartsWith("Del. ") || TxtCalle.Text.StartsWith("Delegacion ") || TxtCalle.Text.StartsWith("Delegación ") || TxtCalle.Text.StartsWith("Municipio ") || TxtCalle.Text.StartsWith("Mun. ") || TxtCalle.Text.StartsWith("Mun "))
            {
                MessageBox.Show("El campo Dlegación/Municipio no puede contener estas palabras, ni ninguna de sus abreviaturas");
                return;
            }


            if ((String.IsNullOrEmpty(TxtCp.Text) || String.IsNullOrWhiteSpace(TxtCp.Text)) || TxtCp.Text.Length < 4)
            {
                MessageBox.Show("Ingresa un Código Postal válido");
                return;
            }

            if (selectedPais.IdPais == 1 && (String.IsNullOrEmpty(TxtDelMun.Text) || String.IsNullOrWhiteSpace(TxtDelMun.Text)))
            {
                if (selectedEstado.IdEstado == 9)
                {
                    MessageBox.Show("Ingresa la delegación donde se encuentra ubicado el organismo");
                    return;
                }
                else
                {
                    MessageBox.Show("Ingresa el Municipio donde se encuentra ubicado el organismo");
                    return;
                }
            }

            organismo.TipoOrganismo = Convert.ToInt32(CbxTipoOrg.SelectedValue);
            organismo.TipoDistr = Convert.ToInt32(CbxDistribucion.SelectedValue);
            organismo.Estado = Convert.ToInt32(CbxEstado.SelectedValue);

            if (CbxCiudad.SelectedIndex != -1)
                organismo.Ciudad = Convert.ToInt32(CbxCiudad.SelectedValue);

            OrganismoModel model = new OrganismoModel();

            if (isUpdating == null)
            {
                bool complete = model.InsertaOrganismo(organismo);

                if (complete)
                {
                    listaOrganismos.Insert(0, organismo);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un error al intentar crear el organismo, intentelo nuevamente", "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (isUpdating == true)
            {
                Organismo orHistorial = model.GetOrganismos(organismo.IdOrganismo);

                if (!organismo.IsEqualTo(orHistorial))
                {
                    model.UpdateOrganismo(organismo);
                    model.InsertaHistorial(orHistorial);
                }

                this.Close();
                
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LblDescripcion_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string materias = String.Empty;

            if (CbxMateria1.SelectedIndex != -1)
            {
                materias += "en materia " + CbxMateria1.Text + " ";

                if (CbxMateria2.SelectedIndex != -1)
                {
                    if (CbxMateria3.SelectedIndex != -1)
                    {
                        materias += ", " + CbxMateria2.Text + " y " + CbxMateria3.Text + " ";
                    }
                    else
                    {
                        materias += " y " + CbxMateria2.Text + " ";
                    }

                }
                    
            }

            if (selectedTipoOrg.IdElemento == 2)
            {
                if (CbxCircuito.SelectedIndex != -1)
                    TxtOrganismo.Text = ((CbxOrdinal.SelectedIndex != -1) ? CbxOrdinal.Text + " " : String.Empty) +
                        "Tribunal Colegiado " + materias + "del " + CbxCircuito.Text;
                else
                    MessageBox.Show("Selecciona el circuito al cual pertenece el tribunal");
            }
            else if (selectedTipoOrg.IdElemento == 4)
            {
                if (CbxCircuito.SelectedIndex != -1)
                    TxtOrganismo.Text = ((CbxOrdinal.SelectedIndex != -1) ? CbxOrdinal.Text + " " : String.Empty) +
                        "Tribunal Unitario " + materias + "del " + CbxCircuito.Text;
                else
                    MessageBox.Show("Selecciona el circuito al cual pertenece el tribunal");
            }
            else if (selectedTipoOrg.IdElemento == 8)
            {
                if (CbxCircuito.SelectedIndex != -1 )
                    TxtOrganismo.Text = "Juzgado " + ((CbxOrdinal.SelectedIndex != -1) ? CbxOrdinal.Text + " " : String.Empty) + " de Distrito " +
                         materias + "del " + CbxCircuito.Text;
                else
                    MessageBox.Show("Selecciona el ordinal y el circuito al cual pertenece el tribunal");
            }
        }

        private void CbxMateria1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbxMateria2.IsEnabled = true;
        }

        private void CbxMateria2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CbxMateria3.IsEnabled = true;
        }

        private void TxtCp_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        

        

        
    }
}