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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoSteamVinito___Formulario_Insercion
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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width <= 500)
            {
                VistaColumnas.Visibility = Visibility.Visible;
                VistaTabular.Visibility = Visibility.Collapsed;
            }
            else
            {
                VistaColumnas.Visibility = Visibility.Collapsed;
                VistaTabular.Visibility = Visibility.Visible;
            }
        }
    }
}
