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
using ProyectoSteamVinito.VistaModelo;
using ProyectoSteamVinito.Modelo;
using System.Windows.Shapes;

namespace ProyectoSteamVinito.Vista
{
    /// <summary>
    /// Lógica de interacción para vistaPrincipal.xaml
    /// </summary>
    public partial class vistaPrincipal : UserControl
    {
        public vistaPrincipal()
        {
            InitializeComponent();
        }

        private void btnDefecto_Click(object sender, RoutedEventArgs e)
        {
            dtpFFinal.SelectedDate=null;
            dtpFInicio.SelectedDate = null;
            cmbEquipo.SelectedIndex = -1;
            cmbGrupo.SelectedIndex = -1;
            cmbLocalizacion.SelectedIndex = -1;
            cmbObjetivo.SelectedIndex = -1;
            cmbOperaciones.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            //ARRAY CON TODOS LOS FILTROS
            string[] datos = new string[7];

            datos[1] = ((ModeloGrupo)cmbGrupo.SelectedItem).Id;
            datos[2] = ((ModeloLocalizacion)cmbLocalizacion.SelectedItem).Id;
            datos[3] = ((ModeloObjetivo)cmbObjetivo.SelectedItem).Id;
            datos[4] = ((ModeloOperacion)cmbOperaciones.SelectedItem).Id;
            datos[5] = dtpFInicio.SelectedDate.ToString();
            datos[6] = dtpFFinal.SelectedDate.ToString();

            VistaModeloVistaPrincipal vmvp = new VistaModeloVistaPrincipal();
            vmvp.CargarRegistros(datos);
        }
    }
}
