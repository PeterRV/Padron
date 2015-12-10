using PadronApi.Dto;
using PadronApi.Model;
using System;
using System.Collections.Generic;
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

namespace Organismos.Ciudades
{
    /// <summary>
    /// Interaction logic for PaisEstado.xaml
    /// </summary>
    public partial class PaisEstadoWin : Window
    {
        /// <summary>
        /// Indica si estoy agregando un estado o un país
        /// 1 País
        /// 2 Estado
        /// </summary>
        private int queAgrego;
        private PaisEstado elemento;
        
        public PaisEstadoWin(int queAgrega)
        {
            InitializeComponent();
            this.queAgrego = queAgrega;
            this.elemento = new PaisEstado();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            PaisEstadoModel model = new PaisEstadoModel();
            elemento.Descripcion = TxtPaisEstado.Text;

            if (queAgrego == 1)
            {
                model.InsertaPais(elemento);
                this.Close();
            }
            else
            {

            }
        }
    }
}
