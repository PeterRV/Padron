using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Funcionarios;
using Obras;
using Obras.Padron;
using Organismos;
using Padron.PapeleriaFolder;
using PadronApi.Model;

namespace Padron
{
    /// <summary>
    /// Interaction logic for PadronWin.xaml
    /// </summary>
    public partial class PadronWin : Window
    {
        PorAutor autorControl;
        CatalogoObrasPadron obraControl;
        Papeleria papeleriaControl;
        ListaFuncionarios funcionariosControl;
        ListaOrganismos organismosControl;

        public PadronWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;

            int switchy = Convert.ToInt32(item.Tag);
            this.RemovePrevControls();

            switch (switchy)
            {
                case 1:
                    if (obraControl == null)
                        obraControl = new CatalogoObrasPadron();

                    CentralPanel.Children.Add(obraControl);
                    break;
                case 3:
                    if (papeleriaControl == null)
                        papeleriaControl = new Papeleria();

                    CentralPanel.Children.Add(papeleriaControl);
                    break;
                case 4: 
                    break;
                case 5:
                    if (funcionariosControl == null)
                        funcionariosControl = new ListaFuncionarios();

                    CentralPanel.Children.Add(funcionariosControl);
                    break;
                case 6:
                    if (organismosControl == null)
                        organismosControl = new ListaOrganismos();

                    CentralPanel.Children.Add(organismosControl);
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
            }
        }
       
        private void RemovePrevControls()
        {
            if (CentralPanel.Children.Count > 0)
                CentralPanel.Children.RemoveAt(0);
        }

       

        private void GeneraOrganismos_Click(object sender, RoutedEventArgs e)
        {
            PapeleriaConfig papeConfig = new PapeleriaConfig();
            papeConfig.ShowDialog();
        }

        

        

       

        

        

        #region Obras

        private void AgregarObra_Click(object sender, RoutedEventArgs e)
        {
            ObrasWin addObra = new ObrasWin(obraControl.CatalogoObras);
            addObra.ShowDialog();
        }

        private void VerObra_Click(object sender, RoutedEventArgs e)
        {
            if (obraControl == null || obraControl.SelectedObra == null)
            {
                MessageBox.Show("Primero debes seleccionar la obra de la cual deseas ver la información", "Atención:", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            ObrasWin update = new ObrasWin(obraControl.SelectedObra, false);
            update.Owner = this;
            update.ShowDialog();
        }

        private void EditarObra_Click(object sender, RoutedEventArgs e)
        {
            if (obraControl == null || obraControl.SelectedObra == null)
            {
                MessageBox.Show("Primero debes seleccionar la obra que deseas actualizar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            ObrasWin update = new ObrasWin(obraControl.SelectedObra, true);
            update.Owner = this;
            update.ShowDialog();
        }

        /// <summary>
        /// Cambia el estatus de una obra activa por el de inactiva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EliminarObra_Click(object sender, RoutedEventArgs e)
        {
            if (obraControl == null || obraControl.SelectedObra == null)
            {
                MessageBox.Show("Primero debes seleccionar la obra que deseas desactivar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            MessageBoxResult result = MessageBox.Show("¿Estas seguro de desactivar la obra: " + obraControl.SelectedObra.Titulo + "?", "Atención:", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                new ObraModel().EstadoObra(obraControl.SelectedObra,0);
                obraControl.CatalogoObras.Remove(obraControl.SelectedObra);
            }
        }

        /// <summary>
        /// Cambia el estatus de una obra desactivada por el de activa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActivarObra_Click(object sender, RoutedEventArgs e)
        {
            if (obraControl == null || obraControl.SelectedObra == null)
            {
                MessageBox.Show("Primero debes seleccionar la obra que deseas activar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            MessageBoxResult result = MessageBox.Show("¿Estas seguro de activar la obra: " + obraControl.SelectedObra.Titulo + "?", "Atención:", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                new ObraModel().EstadoObra(obraControl.SelectedObra, 1);
                obraControl.CatalogoObras.Remove(obraControl.SelectedObra);
            }
        }

        /// <summary>
        /// Muestra todas las obras que han sido desactivadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObrasDesctivadas_Click(object sender, RoutedEventArgs e)
        {
            obraControl.EstadoObras = 0;
            ObrasDesctivadas.Visibility = Visibility.Collapsed;
            EliminarObra.Visibility = Visibility.Collapsed;
            ActivarObra.Visibility = Visibility.Visible;
            ObrasActivas.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// Muestras las obras activas que forman parte del padrón de distribución
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ObrasActivas_Click(object sender, RoutedEventArgs e)
        {
            obraControl.EstadoObras = 1;
            ObrasDesctivadas.Visibility = Visibility.Visible;
            EliminarObra.Visibility = Visibility.Visible;
            ActivarObra.Visibility = Visibility.Collapsed;
            ObrasActivas.Visibility = Visibility.Collapsed;
        }

        #endregion


        #region Titulares

        private void AgregaTitular_Click(object sender, RoutedEventArgs e)
        {
            if (funcionariosControl == null)
            {
                MessageBox.Show("Primero debes de cargar el listado de titulares");
                return;
            }

            AgregaFuncionario addFuncionario = new AgregaFuncionario(funcionariosControl.CatalogoTitulares);
            addFuncionario.ShowDialog();
        }

        private void ModificaTitular_Click(object sender, RoutedEventArgs e)
        {
            if (funcionariosControl == null)
            {
                MessageBox.Show("Primero debes de cargar el listado de titulares");
                return;
            }

            AgregaFuncionario update = new AgregaFuncionario(funcionariosControl.SelectedTitular, true);
            update.Owner = this;
            update.ShowDialog();
        }

        private void InfoTitular_Click(object sender, RoutedEventArgs e)
        {
            if (funcionariosControl == null)
            {
                MessageBox.Show("Primero debes de cargar el listado de titulares");
                return;
            }

            AgregaFuncionario view = new AgregaFuncionario(funcionariosControl.SelectedTitular, false);
            view.Owner = this;
            view.ShowDialog();
        }

        #endregion



        #region Organismos

        private void AgregaOrganismo_Click(object sender, RoutedEventArgs e)
        {
            if (organismosControl == null)
            {
                MessageBox.Show("Primero debes de cargar el listado de titulares");
                return;
            }

            AgregaOrganismo addOrg = new AgregaOrganismo(organismosControl.CatalogoOrganismo);
            addOrg.ShowDialog();
        }


        private void InfoOrganismo_Click(object sender, RoutedEventArgs e)
        {
            AgregaOrganismo editOrg = new AgregaOrganismo(organismosControl.SelectedOrganismo, false);
            editOrg.ShowDialog();
        }

        private void ModificaOrganismo_Click(object sender, RoutedEventArgs e)
        {
            AgregaOrganismo editOrg = new AgregaOrganismo(organismosControl.SelectedOrganismo, true);
            editOrg.ShowDialog();
        }

        #endregion

        

        

        

        


    }
}