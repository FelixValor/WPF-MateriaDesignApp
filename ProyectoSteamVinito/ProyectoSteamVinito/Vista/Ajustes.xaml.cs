using ProyectoSteamVinito.VistaModelo;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoSteamVinito.Vista
{
    /// <summary>
    /// Lógica de interacción para Ajustes.xaml
    /// </summary>
    public partial class Ajustes : UserControl
    {
        private VistaModeloAjustes vma;
        public Ajustes()
        {
            InitializeComponent();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width <= 140)
            {
                btnGrupos_Large.Visibility = Visibility.Collapsed;
                btnGrupos_Short.Visibility = Visibility.Visible;

                btnLoc_Large.Visibility = Visibility.Collapsed;
                btnLoc_Short.Visibility = Visibility.Visible;

                btnEquipo_Large.Visibility = Visibility.Collapsed;
                btnEquipo_Short.Visibility = Visibility.Visible;

                btnObjetivo_Large.Visibility = Visibility.Collapsed;
                btnObjetivo_Short.Visibility = Visibility.Visible;

                btnOperacion_Large.Visibility = Visibility.Collapsed;
                btnOperacion_Short.Visibility = Visibility.Visible;
            }
            else
            {
                btnGrupos_Large.Visibility = Visibility.Visible;
                btnGrupos_Short.Visibility = Visibility.Collapsed;

                btnLoc_Large.Visibility = Visibility.Visible;
                btnLoc_Short.Visibility = Visibility.Collapsed;

                btnEquipo_Large.Visibility = Visibility.Visible;
                btnEquipo_Short.Visibility = Visibility.Collapsed;

                btnObjetivo_Large.Visibility = Visibility.Visible;
                btnObjetivo_Short.Visibility = Visibility.Collapsed;

                btnOperacion_Large.Visibility = Visibility.Visible;
                btnOperacion_Short.Visibility = Visibility.Collapsed;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            vma = new VistaModeloAjustes();
            vma.CargarGrupos();
            dataGridAjustes.ItemsSource = vma.Grupos;
            colImagen.Visibility = Visibility.Collapsed;
        }

        private void btnGrupos_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarGrupos();
            dataGridAjustes.ItemsSource = vma.Grupos;
            colImagen.Visibility = Visibility.Collapsed;
        }

        private void btnLoc_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarLocalizaciones();
            dataGridAjustes.ItemsSource = vma.Localizaciones;
            colImagen.Visibility = Visibility.Visible;
        }

        private void btnEquipo_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarEquipos();
            dataGridAjustes.ItemsSource = vma.Equipos;
            colImagen.Visibility = Visibility.Visible;
        }

        private void btnOperacion_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarOperaciones();
            dataGridAjustes.ItemsSource = vma.Operaciones;
            colImagen.Visibility = Visibility.Collapsed;
        }

        private void btnObjetivo_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarObjetivos();
            dataGridAjustes.ItemsSource = vma.Objetivos;
            colImagen.Visibility = Visibility.Collapsed;
        }
    }
}
