using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoSteamVinito.Vista
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : Window
    {
        MainWindow mw;
        public Inicio(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mw.Close();
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
            vistaPrincipal.Visibility = Visibility.Visible;
            vistaAjustes.Visibility = Visibility.Collapsed;
        }
    }
}
