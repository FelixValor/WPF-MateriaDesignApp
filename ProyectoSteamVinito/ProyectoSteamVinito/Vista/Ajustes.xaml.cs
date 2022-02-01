using ProyectoSteamVinito.Core;
using ProyectoSteamVinito.Modelo;
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
using Microsoft.Win32;
using System.Data;

namespace ProyectoSteamVinito.Vista
{
    /// <summary>
    /// Lógica de interacción para Ajustes.xaml
    /// </summary>
    public partial class Ajustes : UserControl
    {
        private VistaModeloAjustes vma;
        private string tablaActual;
        private FuncionesBaseDatos fbd = new FuncionesBaseDatos();
        private OpenFileDialog dlg = new OpenFileDialog();
        private String imagen=null;
        private String accion="";
        private String id = "";
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
            tablaActual = "grupo";
            colImagen.Visibility = Visibility.Collapsed;
        }

        private void btnGrupos_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarGrupos();
            dataGridAjustes.ItemsSource = vma.Grupos;
            tablaActual = "grupo";
            colImagen.Visibility = Visibility.Collapsed;
        }

        private void btnLoc_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarLocalizaciones();
            dataGridAjustes.ItemsSource = vma.Localizaciones;
            tablaActual = "localizacion";
            colImagen.Visibility = Visibility.Visible;
            colImagen.Source = null;
        }

        private void btnEquipo_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarEquipos();
            dataGridAjustes.ItemsSource = vma.Equipos;
            tablaActual = "equipo";
            colImagen.Visibility = Visibility.Visible;
            colImagen.Source = null;
        }

        private void btnOperacion_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarOperaciones();
            dataGridAjustes.ItemsSource = vma.Operaciones;
            tablaActual = "operacion";
            colImagen.Visibility = Visibility.Collapsed;
        }

        private void btnObjetivo_Large_Click(object sender, RoutedEventArgs e)
        {
            vma.CargarObjetivos();
            dataGridAjustes.ItemsSource = vma.Objetivos;
            tablaActual = "objetivo";
            colImagen.Visibility = Visibility.Collapsed;
        }

        private void EjecutarAgregado(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Agregado");
        }        
        
        private void EjecutarModificado(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Modificado");
        }        
        
        private void EjecutarEliminado(object sender, ExecutedRoutedEventArgs e)
        {
            if (dataGridAjustes.SelectedIndex != -1)
            {
                if (tablaActual.Equals("grupo"))
                {
                    if (fbd.EliminarRegistro(tablaActual, ((ModeloGrupo)dataGridAjustes.SelectedItem).Id)) MessageBox.Show("Se ha eliminado el registro correctamente");
                    else MessageBox.Show("¡No se ha podido eliminar el registro!", "Imposible eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else if (tablaActual.Equals("localizacion")) {
                    if (fbd.EliminarRegistro(tablaActual, ((ModeloLocalizacion)dataGridAjustes.SelectedItem).Id)) MessageBox.Show("Se ha eliminado el registro correctamente");
                    else MessageBox.Show("¡No se ha podido eliminar el registro!", "Imposible eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                }                
                
                else if (tablaActual.Equals("equipo")) {
                    if (fbd.EliminarRegistro(tablaActual, ((ModeloEquipo)dataGridAjustes.SelectedItem).Id)) MessageBox.Show("Se ha eliminado el registro correctamente");
                    else MessageBox.Show("¡No se ha podido eliminar el registro!", "Imposible eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                }                
                
                else if (tablaActual.Equals("operacion")) {
                    if (fbd.EliminarRegistro(tablaActual, ((ModeloOperacion)dataGridAjustes.SelectedItem).Id)) MessageBox.Show("Se ha eliminado el registro correctamente");
                    else MessageBox.Show("¡No se ha podido eliminar el registro!", "Imposible eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                }                
                
                else if (tablaActual.Equals("objetivo")) {
                    if (fbd.EliminarRegistro(tablaActual, ((ModeloObjetivo)dataGridAjustes.SelectedItem).Id)) MessageBox.Show("Se ha eliminado el registro correctamente");
                    else MessageBox.Show("¡No se ha podido eliminar el registro!", "Imposible eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else MessageBox.Show("¡Elige un dato a eliminar!", "Imposible eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void dataGridAjustes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridAjustes.SelectedIndex != -1)
            {
                btnModificarRegistro.IsEnabled = true;
                if (tablaActual.Equals("localizacion"))
                {
                    colImagen.Source = ((ModeloLocalizacion)dataGridAjustes.SelectedItem).Image;
                }

                if (tablaActual.Equals("equipo"))
                {
                    colImagen.Source = ((ModeloEquipo)dataGridAjustes.SelectedItem).Image;
                }
            }
            else
            {
                btnModificarRegistro.IsEnabled = false;
            }
        }

        public void btnImportarImagen_Click(object sender, RoutedEventArgs e)
        {
            
            dlg.Title = "Selecciona una imagen";
            dlg.Filter = "Imagenes (.png)|*.jpg;*.jpeg;*.png;";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == true)
            {
                imagen = dlg.FileName;
            }
            
        }

        public void verBtnImportar()
        {
            if (tablaActual.Equals("equipo") || tablaActual.Equals("localizacion"))
            {
                btnImportarImagen.Visibility = Visibility.Visible;
            }
            else
            {
                btnImportarImagen.Visibility = Visibility.Collapsed;
            }
        }

        private void btnAnnadir_Click(object sender, RoutedEventArgs e)
        {
            if (accion.Equals("a"))
            {
                String nombre = txtDialog.Text;
                fbd.AgregarRegistroDB(imagen, tablaActual, nombre);
                txtDialog.Clear();
                dlg.Reset();
            }
            else
            {
                String nombre = txtDialog.Text;
                fbd.ActualizarRegistroDB(imagen, tablaActual, nombre,id);
                txtDialog.Clear();
                dlg.Reset();
            }
            
        }

        private void btnAnnadirRegistro_Click(object sender, RoutedEventArgs e)
        {
            txtDialog.Clear();
            dlg.Reset();
            verBtnImportar();
            accion = "a";
        }

        private void btnModificarRegistro_Click(object sender, RoutedEventArgs e)
        {
            verBtnImportar();
            accion = "m";
            if (dataGridAjustes.SelectedItems.Count > 0)
            {
                txtDialog.Text = dataGridAjustes.SelectedItem.ToString();
                if (tablaActual.Equals("grupo"))
                {
                    id = ((ModeloGrupo)dataGridAjustes.SelectedItem).Id.ToString();
                }
                else if (tablaActual.Equals("localizacion"))
                {
                    id = ((ModeloLocalizacion)dataGridAjustes.SelectedItem).Id.ToString();
                }
                else if (tablaActual.Equals("equipo"))
                {
                    id = ((ModeloEquipo)dataGridAjustes.SelectedItem).Id.ToString();
                }
                else if (tablaActual.Equals("operacion"))
                {
                    id = ((ModeloOperacion)dataGridAjustes.SelectedItem).Id.ToString();
                }
                else if (tablaActual.Equals("objetivo"))
                {
                    id = ((ModeloObjetivo)dataGridAjustes.SelectedItem).Id.ToString();
                }
            }
        }
    }

    public static class Comando
    {
        public static readonly RoutedUICommand Eliminar = new RoutedUICommand("Accion de eliminar registro", "Eliminar", typeof(Comando));
    }
}
