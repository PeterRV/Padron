using PadronApi.Model;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;

namespace Padron
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {


            string path = ConfigurationManager.AppSettings["ErrorPath"].ToString();

            if (!File.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (new AccesoModel().ObtenerUsuarioContraseña("Prueba", "PRUEBA"))
            {
                PadronWin padron = new PadronWin();
                padron.Show();
            }

            this.Close();
        }
    }
}
