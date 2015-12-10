using Funcionarios;
using Obras;
using Obras.AutoresFolder;
using Obras.Padron;
using Organismos;
using Padron.PapeleriaFolder;
using PadronApi.Dto;
using PadronApi.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private void AgregarObra_Click(object sender, RoutedEventArgs e)
        {
            ObrasWin addObra = new ObrasWin(obraControl.CatalogoObras);
            addObra.ShowDialog();
        }

        private void GeneraOrganismos_Click(object sender, RoutedEventArgs e)
        {
            PapeleriaConfig papeConfig = new PapeleriaConfig();
            papeConfig.ShowDialog();
        }

        private void AgregaTitular_Click(object sender, RoutedEventArgs e)
        {
            AgregaFuncionario addFuncionario = new AgregaFuncionario(funcionariosControl.CatalogoTitulares);
            addFuncionario.ShowDialog();
        }

        private void AgregaOrganismo_Click(object sender, RoutedEventArgs e)
        {
            if (funcionariosControl == null)
            {
                MessageBox.Show("Primero debes de cargar el listado de titulares");
                return;
            }

            AgregaOrganismo addOrg = new AgregaOrganismo();
            addOrg.ShowDialog();
        }

        private void EditarObra_Click(object sender, RoutedEventArgs e)
        {
            if (obraControl == null || obraControl.SelectedObra == null)
            {
                MessageBox.Show("Primero debes seleccionar la obra que deseas actualizar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            ObrasWin update = new ObrasWin(obraControl.SelectedObra,true);
            update.Owner = this;
            update.ShowDialog();
        }

        private void EliminarObra_Click(object sender, RoutedEventArgs e)
        {
            if (obraControl == null || obraControl.SelectedObra == null)
            {
                MessageBox.Show("Primero debes seleccionar la obra que deseas eliminar", "Atención:", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            MessageBoxResult result = MessageBox.Show("¿Estas seguro de eliminar la obra: " + obraControl.SelectedObra.Titulo + "?", "Atención:", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                new ObraModel().DesactivaObra(obraControl.SelectedObra);
                obraControl.CatalogoObras.Remove(obraControl.SelectedObra);
            }
        }

        private void ModificaTitular_Click(object sender, RoutedEventArgs e)
        {
            if (funcionariosControl == null)
            {
                MessageBox.Show("Primero debes de cargar el listado de titulares");
                return;
            }

            AgregaFuncionario update = new AgregaFuncionario(funcionariosControl.SelectedTitular,true);
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

            AgregaFuncionario view = new AgregaFuncionario(funcionariosControl.SelectedTitular,false);
            view.Owner = this;
            view.ShowDialog();
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
    }
}