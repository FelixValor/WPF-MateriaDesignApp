
using ProyectoSteamVinito.VistaModelo;
using System;
using System.Windows;


namespace ProyectoSteamVinito.Vista
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        VistaModeloVistaPrincipal vmvp;
        public Inicio()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            botoneraSuperior.Visibility = Visibility.Collapsed;
            vistaPrincipal.Visibility = Visibility.Collapsed;
            vistaAjustes.Visibility = Visibility.Collapsed;
            pantallaCarga.Visibility = Visibility.Visible;

            vmvp = new VistaModeloVistaPrincipal();
            vmvp.CargarRegistros();
            vmvp.CargarEquipos();
            vmvp.CargarGrupos();
            vmvp.CargarLocalizaciones();
            vmvp.CargarObjetivos();
            vmvp.CargarOperaciones();
            vistaPrincipal.DataContext = vmvp;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vistaAjustes.Visibility = Visibility.Collapsed;
            vistaPrincipal.Visibility = Visibility.Visible;
            Title = "Proyecto Vinito -- Inicio";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vistaAjustes.Visibility = Visibility.Visible;
            vistaPrincipal.Visibility = Visibility.Collapsed;
            Title = "Proyecto Vinito -- Ajustes";
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            botoneraSuperior.Visibility = Visibility.Visible;
            vistaPrincipal.Visibility = Visibility.Visible;
            bton.Visibility = Visibility.Collapsed;
            vistaAjustes.Visibility = Visibility.Collapsed;
            pantallaCarga.Visibility = Visibility.Collapsed;
        }
    }
}
