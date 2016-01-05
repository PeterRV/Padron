using PadronApi.Dto;
using PadronApi.Model;
using PadronApi.Singletons;
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
        private bool isUpdating;

        private Pais pais;
        private Estado estado;

        public PaisEstadoWin(Pais pais,bool isUpdating)
        {
            InitializeComponent();
            this.pais = pais;
            this.isUpdating = isUpdating;
        }

        public PaisEstadoWin(Estado estado, bool isUpdating)
        {
            InitializeComponent();
            this.estado = estado;
            this.isUpdating = isUpdating;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (pais != null)
            {
                TxtPaisEstado.Text = pais.PaisDesc;
            }
            else
            {
                TxtPaisEstado.Text = estado.EstadoDesc;
            }
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            PaisEstadoModel model = new PaisEstadoModel();

            if (pais != null)
            {
                pais.PaisDesc = TxtPaisEstado.Text;
                bool complete = model.InsertaPais(pais);

                if (complete)
                {
                    PaisesSingleton.Paises.Add(pais);
                    this.Close();
                }
            }
            else
            {
                estado.EstadoDesc = TxtPaisEstado.Text;
                bool complete = model.InsertaEstado(estado);

                if (complete)
                {
                    Pais myPais = (from n in PaisesSingleton.Paises
                                   where n.IdPais == estado.IdPais
                                   select n).ToList()[0];

                    if (myPais.Estados == null)
                        myPais.Estados = new System.Collections.ObjectModel.ObservableCollection<Estado>();

                    myPais.Estados.Add(estado);

                    this.Close();
                }

            }
        }
    }
}
