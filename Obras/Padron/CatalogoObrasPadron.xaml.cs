using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PadronApi.Dto;
using PadronApi.Model;
using System.ComponentModel;

namespace Obras.Padron
{
    /// <summary>
    /// Interaction logic for CatalogoObrasPadron.xaml
    /// </summary>
    public partial class CatalogoObrasPadron : UserControl, INotifyPropertyChanged
    {
        public ObservableCollection<Obra> CatalogoObras;
        public Obra SelectedObra;
        private int estadoObras = 1;

        public CatalogoObrasPadron()
        {
            InitializeComponent();
        }

        public int EstadoObras
        {
            get
            {
                return this.estadoObras;
            }
            set
            {
                this.estadoObras = value;
                this.OnPropertyChanged("EstadoObras");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CatalogoObras = new ObraModel().GetObras(estadoObras);

            LblTotales.Content = CatalogoObras.Count + " registros";
            GObras.DataContext = CatalogoObras;
        }

        private void SearchTextBox_Search(object sender, RoutedEventArgs e)
        {
            String tempString = ((TextBox)sender).Text.ToUpper();

            if (!String.IsNullOrEmpty(tempString))
                GObras.DataContext = (from n in CatalogoObras
                                        where n.Titulo.ToUpper().Contains(tempString) || n.NumMaterial.ToUpper().Contains(tempString) ||
                                        n.TituloStr.ToUpper().Contains(tempString) || n.Isbn.ToUpper().Contains(tempString)
                                        select n).ToList();
            else
                GObras.DataContext = CatalogoObras;
        }

        private void GObras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedObra = GObras.SelectedItem as Obra;

            LblTotales.Content = (GObras.SelectedIndex + 1) + " de " + CatalogoObras.Count + " registros";
        }

        private void GObras_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ObrasWin view = new ObrasWin(SelectedObra,false);
            view.ShowDialog();
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            UserControl_Loaded(null, null);
            
        }

        #endregion // INotifyPropertyChanged Members
    }
}
