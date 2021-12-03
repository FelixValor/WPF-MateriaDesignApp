using System;
using System.Windows;


namespace ProyectoSteamVinito.Vista
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        public Inicio()
        {
            InitializeComponent();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vistaAjustes.Visibility = Visibility.Collapsed;
            vistaPrincipal.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vistaAjustes.Visibility = Visibility.Visible;
            vistaPrincipal.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            botoneraSuperior.Visibility = Visibility.Collapsed;
            vistaPrincipal.Visibility = Visibility.Collapsed;
            vistaAjustes.Visibility = Visibility.Collapsed;
            pantallaCarga.Visibility = Visibility.Visible;
        }

        private void bton_Click(object sender, RoutedEventArgs e)
        {
            botoneraSuperior.Visibility = Visibility.Visible;
            vistaPrincipal.Visibility = Visibility.Visible;
            vistaAjustes.Visibility = Visibility.Collapsed;
            pantallaCarga.Visibility = Visibility.Collapsed;
        }
    }
}
