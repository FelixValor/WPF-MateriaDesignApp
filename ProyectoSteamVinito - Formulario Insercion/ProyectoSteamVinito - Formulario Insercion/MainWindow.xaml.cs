using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
using System.Xml.Serialization;
using MySql.Data.MySqlClient;

namespace ProyectoSteamVinito___Formulario_Insercion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string servidor; //Nombre o ip del servidor de MySQL
        private string bd; //Nombre de la base de datos
        private string usuario; //Usuario de acceso a MySQL
        private string password; //Contraseña de usuario de acceso a MySQL
        private string datos = null; //Variable para almacenar el resultado
        private static Boolean esCarga = true;
        private static Timer timerPantallaCarga = new System.Timers.Timer();
        private string RutaArchivoXML = "../../../setting.xml";
        public MainWindow()
        {

            XmlSerializer r = new XmlSerializer(typeof(Setting));
            StreamReader archivoleer = new StreamReader(RutaArchivoXML);
            Setting config = (Setting)r.Deserialize(archivoleer);
            archivoleer.Close();
            servidor = config.Servidor;
            bd = config.BD;
            password = config.Password;
            usuario = config.Usuario;
            
            InitializeComponent();
            //btnEnviar.IsEnabled = false;
            //btnEnviar2.IsEnabled = false;

            //SACAR FECHA Y HORA ACTUALIZADA
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

            //Crearemos la cadena de conexión concatenando las variables
            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            //Instancia para conexión a MySQL, recibe la cadena de conexión
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null; //Variable para leer el resultado de la consulta

            //Agregamos try-catch para capturar posibles errores de conexión o sintaxis.
            try
            {
                
                CompletarCMB("select id_equipo, nombre from equipo", cmbEquipo, cmbEquipo2, conexionBD, reader, datos);//SACAMOS LOS EQUIPOS
                CompletarCMB("select id_grupo, nombre from grupo", cmbGrupo, cmbGrupo2, conexionBD, reader, datos);//SACAMOS LOS GRUPOS
                CompletarCMB("select id_localizacion, nombre from localizacion", cmbLocalizacion, cmbLocalizacion2, conexionBD, reader, datos);//SACAMOS LAS LOCALIZACIONES
                CompletarCMB("select id_objetivo, nombre from objetivo", cmbObjetivo, cmbObjetivo2, conexionBD, reader, datos);//SACAMOS LOS OBJETIVOS
                CompletarCMB("select id_operacion, nombre from operacion", cmbOperacion, cmbOperacion2, conexionBD, reader, datos);//SACAMOS LAS OPERACIONES

                //MessageBox.Show(datos); //Imprime en cuadro de dialogo el resultado
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message); //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                conexionBD.Close(); //Cierra la conexión a MySQL
            }

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
                VistaTabular.Visibility = Visibility.Visible;
                transitioner.SelectedIndex = 1;
                esCarga = false;
                timerPantallaCarga.Stop();
            }));
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            lblFecha.Content = DateTime.Now.ToString();
            lblFecha2.Content = DateTime.Now.ToString();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (esCarga)
            {
                VistaTabular.Visibility = Visibility.Collapsed;
                VistaColumnas.Visibility = Visibility.Collapsed;
            }
            else
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
                datos += reader.GetString(0)+ reader.GetString(1) + "\n"; //Almacena cada registro con un salto de linea
                Elemento elemento = new Elemento();
                elemento.Id = int.Parse(reader.GetString(0));
                elemento.Nombre = reader.GetString(1);
                combo.Items.Add(elemento);
                combo2.Items.Add(elemento);
            }
            conexionBD.Close();
        }

        private void btnLimpiar2_Click(object sender, RoutedEventArgs e)
        {
            cmbEquipo2.SelectedIndex = -1;
            cmbGrupo2.SelectedIndex = -1;
            cmbLocalizacion2.SelectedIndex = -1;
            cmbObjetivo2.SelectedIndex = -1;
            cmbOperacion2.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            cmbEquipo.SelectedIndex=-1;
            cmbGrupo.SelectedIndex = -1;
            cmbLocalizacion.SelectedIndex = -1;
            cmbObjetivo.SelectedIndex = -1;
            cmbOperacion.SelectedIndex = -1;


        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbEquipo.SelectedIndex==-1 || cmbGrupo.SelectedIndex == -1 || cmbLocalizacion.SelectedIndex == -1 || cmbObjetivo.SelectedIndex == -1 || cmbOperacion.SelectedIndex == -1)
            {
                MessageBox.Show("Completa todos los campos por favor", "Atención",  MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Crearemos la cadena de conexión concatenando las variables
                string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

                //Instancia para conexión a MySQL, recibe la cadena de conexiónn
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                MySqlDataReader reader = null; //Variable para leer el resultado de la consulta

                

                //string equipos = "select nombre from equipo"; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                String consulta = "insert into registro (id_grupo, id_localizacion, id_objetivo, id_operacion, id_equipo) values (" + ((Elemento)cmbGrupo.SelectedItem).Id + "," + ((Elemento)cmbLocalizacion.SelectedItem).Id +  "," + ((Elemento)cmbObjetivo.SelectedItem).Id + "," + ((Elemento)cmbOperacion.SelectedItem).Id + ","  + ((Elemento)cmbEquipo.SelectedItem).Id + ");";
                MySqlCommand comando = new MySqlCommand(consulta); //Declaración SQL para ejecutar contra una base de datos MySQL
                comando.Connection = conexionBD; //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                conexionBD.Open(); //Abre la conexión

                comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                
                conexionBD.Close();
                btnLimpiar_Click(sender, e);

            }
        }

        private void btnEnviar2_Click(object sender, RoutedEventArgs e)
        {
            if (cmbEquipo2.SelectedIndex == -1 || cmbGrupo2.SelectedIndex == -1 || cmbLocalizacion2.SelectedIndex == -1 || cmbObjetivo2.SelectedIndex == -1 || cmbOperacion2.SelectedIndex == -1)
            {
                MessageBox.Show("Completa todos los campos por favor", "Atención", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Crearemos la cadena de conexión concatenando las variables
                string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

                //Instancia para conexión a MySQL, recibe la cadena de conexiónn
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                MySqlDataReader reader = null; //Variable para leer el resultado de la consulta



                //string equipos = "select nombre from equipo"; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                String consulta = "insert into registro (id_grupo, id_localizacion, id_objetivo, id_operacion, id_equipo) values (" + ((Elemento)cmbGrupo.SelectedItem).Id + "," + ((Elemento)cmbLocalizacion.SelectedItem).Id + "," + ((Elemento)cmbObjetivo.SelectedItem).Id + "," + ((Elemento)cmbOperacion.SelectedItem).Id + "," + ((Elemento)cmbEquipo.SelectedItem).Id + ");";
                MySqlCommand comando = new MySqlCommand(consulta); //Declaración SQL para ejecutar contra una base de datos MySQL
                comando.Connection = conexionBD; //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                conexionBD.Open(); //Abre la conexión

                comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader


                conexionBD.Close();
                btnLimpiar2_Click(sender, e);
            }
        }
    }
}
