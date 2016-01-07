using System;
using System.Linq;
using System.Windows;

namespace Padron.PapeleriaFolder
{
    /// <summary>
    /// Interaction logic for PapeleriaConfig.xaml
    /// </summary>
    public partial class PapeleriaConfig : Window
    {
        public PapeleriaConfig()
        {
            InitializeComponent();
        }

        private void BtnParra1_Click(object sender, RoutedEventArgs e)
        {
            Parrafos parra = new Parrafos();
            parra.ShowDialog();
        }
    }
}
