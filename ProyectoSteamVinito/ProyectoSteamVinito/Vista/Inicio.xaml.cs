
using ProyectoSteamVinito.VistaModelo;
using System;
using System.Timers;
using System.Windows;


namespace ProyectoSteamVinito.Vista
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        private VistaModeloVistaPrincipal vmvp;
        private static Boolean esCarga = true;
        private static Timer timerPantallaCarga = new System.Timers.Timer();
        public Inicio()
        {
            InitializeComponent();
            //Timer para la pantalla de carga
           
                
            timerPantallaCarga.Elapsed += timer_Tick;
            timerPantallaCarga.Interval = 3000;
            timerPantallaCarga.Enabled = true;
            timerPantallaCarga.Start();
            
            
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                botoneraSuperior.Visibility = Visibility.Visible;
                vistaPrincipal.Visibility = Visibility.Visible;
                vistaAjustes.Visibility = Visibility.Collapsed;
                pantallaCarga.Visibility = Visibility.Collapsed;
                timerPantallaCarga.Stop();
            }));
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            botoneraSuperior.Visibility = Visibility.Collapsed;
            vistaPrincipal.Visibility = Visibility.Collapsed;
            vistaAjustes.Visibility = Visibility.Collapsed;
            pantallaCarga.Visibility = Visibility.Visible;

            vmvp = new VistaModeloVistaPrincipal();
            vmvp.CargarRegistros(new String[] { null, null, null, null, null,null, null });
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
    }
}
