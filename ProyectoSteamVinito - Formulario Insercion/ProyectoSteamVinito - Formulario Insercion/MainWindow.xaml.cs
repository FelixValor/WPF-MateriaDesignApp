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
using System.Windows.Threading;

using MySql.Data.MySqlClient;

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

            //SACAR FECHA Y HORA ACTUALIZADA
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();


            //CONEXION BASE DE DATOS
            string servidor = "localhost"; //Nombre o ip del servidor de MySQL
            string bd = "bodega"; //Nombre de la base de datos
            string usuario = "root"; //Usuario de acceso a MySQL
            string password = "inves"; //Contraseña de usuario de acceso a MySQL
            string datos = null; //Variable para almacenar el resultado

            //Crearemos la cadena de conexión concatenando las variables
            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            //Instancia para conexión a MySQL, recibe la cadena de conexión
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null; //Variable para leer el resultado de la consulta

            //Agregamos try-catch para capturar posibles errores de conexión o sintaxis.
            try
            {
                
                CompletarCMB("select nombre from equipo", cmbEquipo, cmbEquipo2, conexionBD, reader, datos);//SACAMOS LOS EQUIPOS
                CompletarCMB("select nombre from grupo", cmbGrupo, cmbGrupo2, conexionBD, reader, datos);//SACAMOS LOS GRUPOS
                CompletarCMB("select nombre from localizacion", cmbLocalizacion, cmbLocalizacion2, conexionBD, reader, datos);//SACAMOS LAS LOCALIZACIONES
                CompletarCMB("select nombre from objetivo", cmbObjetivo, cmbObjetivo2, conexionBD, reader, datos);//SACAMOS LOS OBJETIVOS
                CompletarCMB("select nombre from operacion", cmbOperacion, cmbOperacion2, conexionBD, reader, datos);//SACAMOS LAS OPERACIONES

                //MessageBox.Show(datos); //Imprime en cuadro de dialogo el resultado
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message); //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                conexionBD.Close(); //Cierra la conexión a MySQL
            }



        }


        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            lblFecha.Content = DateTime.Now.ToString();
            lblFecha2.Content = DateTime.Now.ToString();
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

        //FUNCION QUE INSERTA DATOS EN LA BASE DE DATOS
        private void CompletarCMB(String consulta, ComboBox combo, ComboBox combo2, MySqlConnection conexionBD, MySqlDataReader reader, String datos)
        {
            //string equipos = "select nombre from equipo"; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
            MySqlCommand comando = new MySqlCommand(consulta); //Declaración SQL para ejecutar contra una base de datos MySQL
            comando.Connection = conexionBD; //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
            conexionBD.Open(); //Abre la conexión

            reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

            while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
            {
                datos += reader.GetString(0) + "\n"; //Almacena cada registro con un salto de linea
                combo.Items.Add(reader.GetString(0) + "\n");
                combo2.Items.Add(reader.GetString(0) + "\n");
            }
            conexionBD.Close();
        }
    }
}
