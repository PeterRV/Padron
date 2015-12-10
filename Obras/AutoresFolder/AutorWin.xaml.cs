using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using PadronApi.Dto;
using PadronApi.Model;
using ScjnUtilities;

namespace Obras.AutoresFolder
{
    /// <summary>
    /// Interaction logic for AutorWin.xaml
    /// </summary>
    public partial class AutorWin : Window
    {
        Autor autor;
        ObservableCollection<Autor> catalogoAutores;
        private readonly bool isUpdating;

        /// <summary>
        /// Utilizado para agregar autores al catalogo
        /// </summary>
        /// <param name="catalogoAutores">Catalogo de autores cargado previamente al que se agregara el nuevo autor</param>
        public AutorWin(ObservableCollection<Autor> catalogoAutores)
        {
            InitializeComponent();
            this.autor = new Autor();
            this.catalogoAutores = catalogoAutores;
            isUpdating = false;
        }

        /// <summary>
        /// Permite actualizar la información de un autor existente
        /// </summary>
        /// <param name="autor"></param>
        public AutorWin(Autor autor)
        {
            InitializeComponent();
            this.autor = autor;
            isUpdating = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CbxTitulo.DataContext = new ElementalPropertiesModel().GetTitulos();
            TxtNombre.Text = autor.Nombre;

            if (isUpdating)
                CbxTitulo.SelectedValue = autor.Grado;
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (CbxTitulo.SelectedIndex == -1)
            {
                MessageBox.Show("Antes de continuar recuerda seleccionar el grado académico");
                return;
            }

            AutorModel model = new AutorModel();
            bool dbResult = false;

            autor.Nombre = TxtNombre.Text;

            if (isUpdating)
            {
                dbResult = model.UpdateAutor(autor);

                if (dbResult)
                    this.Close();
                else
                    MessageBox.Show("Hubo problemas con la actualización, vuelve a intentarlo");
            }
            else
            {
                int coincidencias = 0;
                foreach (Autor item in catalogoAutores)
                {
                    double porcentaje = 0;
                    StringUtilities.LevenshteinDistance(item.Nombre, autor.Nombre, out porcentaje);

                    if (porcentaje <= .25)
                        coincidencias++;
                }

                if (coincidencias > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Se encontraron " + coincidencias +
                                                              " registros similares al que esta intentando ingresar. VERIFIQUE el catálogo existente antes de continuar. " +
                                                              "Si ya VERIFICÓ presione Si, de lo contrario presione No", "Atención:", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        dbResult = model.InsertaAutor(autor);

                        if (dbResult)
                        {
                            catalogoAutores.Add(autor);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el autor, vuelve a intentarlo");
                        }
                    }
                }
                else
                {
                    dbResult = model.InsertaAutor(autor);

                    if (dbResult)
                    {
                        catalogoAutores.Add(autor);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el autor, vuelve a intentarlo");
                    }
                }
            }
        }
    }
}