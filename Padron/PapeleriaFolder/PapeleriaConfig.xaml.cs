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
