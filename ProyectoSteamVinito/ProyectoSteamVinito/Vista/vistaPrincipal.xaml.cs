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
    }
}
