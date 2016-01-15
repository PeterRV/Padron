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

namespace Funcionarios.Resources
{
    /// <summary>
    /// Interaction logic for QueRecibe.xaml
    /// </summary>
    public partial class QueRecibe : Window
    {
        ObservableCollection<ElementalProperties> listaTipoObras;
        ObservableCollection<ElementalProperties> listaAcuerdos;
        Titular currentTitular;
        bool isUpdating;

        public QueRecibe(Titular currentTitular, bool isUpdating)
        {
            InitializeComponent();
            this.currentTitular = currentTitular;
            this.isUpdating = isUpdating;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ElementalPropertiesModel model = new ElementalPropertiesModel();
            listaTipoObras = model.GetTipoObra();
            listaAcuerdos = model.GetAcuerdos();

            LstTipoObras.DataContext = listaTipoObras;
            LstAcuerdos.DataContext = listaAcuerdos;

        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string obras = String.Empty;

            foreach(ElementalProperties item in (from n in listaTipoObras
                                                    orderby n.IdElemento ascending
                                                     select n)){

                if(item.IsChecked)
                    obras += "1";
                else
                    obras += "0";
            }

            string tiraje = String.Empty;

            foreach (ElementalProperties item in (from n in listaAcuerdos
                                                  orderby n.IdElemento ascending
                                                  select n))
            {

                if (item.IsChecked)
                    tiraje += "1";
                else
                    tiraje += "0";
            }

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
