using MySql.Data.MySqlClient;
using ProyectoSteamVinito.Modelo;
using System;

using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ProyectoSteamVinito.Core
{
    public class FuncionesBaseDatos
    {
        //CONEXION BASE DE DATOS
        private string servidor = "localhost"; //Nombre o ip del servidor de MySQL
        private string bd = "bodega"; //Nombre de la base de datos
        private string usuario = "root"; //Usuario de acceso a MySQL
        private string password = "inves"; //Contraseña de usuario de acceso a MySQL
        private string datos = null; //Variable para almacenar el resultado
        private MySqlConnection conexionBD;
        private MySqlDataReader reader;
        private MySqlCommand comando;
        private string cadenaConexion;

        public FuncionesBaseDatos()
        {
            //Crearemos la cadena de conexión concatenando las variables
            cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            //Instancia para conexión a MySQL, recibe la cadena de conexión
            reader = null; //Variable para leer el resultado de la consulta
            try
            {
                conexionBD = new MySqlConnection(cadenaConexion);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public BitmapImage SacarImagenEquipo(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = ms;
            imageSource.EndInit();

            return imageSource;
        }

        public BitmapImage SacarImagenLocalizacion(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = ms;
            imageSource.EndInit();

            return imageSource;
        }

        public void AbrirConexion()
        {
            try
            {
                this.conexionBD.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                this.conexionBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ObservableCollection<ModeloRegistro> consultarRegistros(String [] filtrado)
        {
            ObservableCollection<ModeloRegistro> lista = new ObservableCollection<ModeloRegistro>();
            String query = query = "select equipo.id_equipo, equipo.nombre, equipo.imagen, grupo.id_grupo, grupo.nombre, localizacion.id_localizacion, localizacion.nombre, localizacion.imagen, objetivo.id_objetivo, objetivo.nombre, operacion.id_operacion, operacion.nombre " +
                                       "from registro, equipo, grupo, localizacion, objetivo, operacion " +
                                            "where registro.id_grupo = grupo.id_grupo and registro.id_operacion = operacion.id_operacion and registro.id_objetivo = objetivo.id_objetivo" +
                                            " and registro.id_operacion = operacion.id_operacion and registro.id_equipo = equipo.id_equipo and registro.id_localizacion = localizacion.id_localizacion";

            if (filtrado[0] != null) //Filtrado del equipo
            {
                query += " and registro.id_equipo = " + int.Parse(filtrado[0]);
            }

            if (filtrado[1] != null) //Filtrado del grupo
            {
                query += " and registro.id_grupo = " + int.Parse(filtrado[1]);
            }

            if (filtrado[2] != null) //Filtrado del localizacion
            {
                query += " and registro.id_localizacion = " + int.Parse(filtrado[2]);
            }

            if (filtrado[3] != null) //Filtrado del objetivo
            {
                query += " and registro.id_objetivo = " + int.Parse(filtrado[3]);
            }

            if (filtrado[4] != null) //Filtrado del operacion
            {
                query += " and registro.id_operacion = " + int.Parse(filtrado[4]);
            }

            if (filtrado[6] != null && filtrado[5] != null) //Filtrado del operacion
            {
                String fechaini = filtrado[5].Substring(6, 4) + "-" + filtrado[5].Substring(3, 2) + "-" + filtrado[5].Substring(0, 2) + " " + filtrado[5].Substring(11, 7);
                String fechafin = filtrado[6].Substring(6, 4) + "-" + filtrado[6].Substring(3, 2) + "-" + filtrado[6].Substring(0, 2) + " " + filtrado[6].Substring(11, 7);

                query += " and registro.fecha_hora BETWEEN '" + fechaini + "' and '"+ fechafin+"'";
            }
            else if(filtrado[6] != null){
                String fechafin = filtrado[6].Substring(6, 4) + "-" + filtrado[6].Substring(3, 2) + "-" + filtrado[6].Substring(0, 2) + " " + filtrado[6].Substring(11, 7);


                query += " and registro.fecha_hora BETWEEN '*' and '" + fechafin + "'";

            }
            else if (filtrado[5] != null)
            {
                String fechaini = filtrado[5].Substring(6, 4) + "-" + filtrado[5].Substring(3, 2) + "-" + filtrado[5].Substring(0, 2) + " " + filtrado[5].Substring(11, 7);

                query += " and registro.fecha_hora BETWEEN '" + fechaini + "' and '9999-12-31 0:00:00'";
            }

            comando = new MySqlCommand(query);
            comando.Connection = conexionBD;
            AbrirConexion();
            ModeloRegistro mr;

            try
            {
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    mr = new ModeloRegistro();
                    mr.PropModeloEquipo = new ModeloEquipo() { Id = reader.GetString(0), Nombre = reader.GetString(1) };
                    mr.PropModeloGrupo = new ModeloGrupo() { Id = reader.GetString(3), Nombre = reader.GetString(4) };
                    mr.PropModeloLocalizacion = new ModeloLocalizacion() { Id = reader.GetString(5), Nombre = reader.GetString(6) };
                    mr.PropModeloObjetivo = new ModeloObjetivo() { Id = reader.GetString(8), Nombre = reader.GetString(9) };
                    mr.PropModeloOperacion = new ModeloOperacion() { Id = reader.GetString(10), Nombre = reader.GetString(11) };
                    mr.PropImagenEquipo = SacarImagenEquipo((byte[])reader[2]);//Funcion que devuelva un Objeto de BitmapImage pasandole esto --> reader.GetString(12)
                    mr.PropImagenLoc = SacarImagenLocalizacion((byte[])reader[7]);//Funcion que devuelva un Objeto de BitmapImage pasandole esto --> reader.GetString(13)

                    lista.Add(mr);
                }
                reader.Close();
                CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CerrarConexion();
            }

            return lista;
        }

        public ObservableCollection<ModeloEquipo> consultarEquipos()
        {
            ObservableCollection<ModeloEquipo> lista = new ObservableCollection<ModeloEquipo>();
            try
            {
                comando = new MySqlCommand("select * from equipo");
                comando.Connection = conexionBD;
                AbrirConexion();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new ModeloEquipo() { Id = reader.GetString(0), Nombre = reader.GetString(1)});
                }
                CerrarConexion();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return lista;
        }

        public ObservableCollection<ModeloGrupo> consultarGrupos()
        {
            ObservableCollection<ModeloGrupo> lista = new ObservableCollection<ModeloGrupo>();
            try
            {
                comando = new MySqlCommand("select * from grupo");
                comando.Connection = conexionBD;
                AbrirConexion();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new ModeloGrupo() { Id = reader.GetString(0), Nombre = reader.GetString(1) });
                }
                CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return lista;
        }

        public ObservableCollection<ModeloLocalizacion> consultarLocalizaciones()
        {
            ObservableCollection<ModeloLocalizacion> lista = new ObservableCollection<ModeloLocalizacion>();
            try
            {
                comando = new MySqlCommand("select * from localizacion");
                comando.Connection = conexionBD;
                AbrirConexion();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new ModeloLocalizacion() { Id = reader.GetString(0), Nombre = reader.GetString(1) });
                }
                CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return lista;
        }

        public ObservableCollection<ModeloObjetivo> consultarObjetivo()
        {
            ObservableCollection<ModeloObjetivo> lista = new ObservableCollection<ModeloObjetivo>();
            try
            {
                comando = new MySqlCommand("select * from objetivo");
                comando.Connection = conexionBD;
                AbrirConexion();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new ModeloObjetivo() { Id = reader.GetString(0), Nombre = reader.GetString(1) });
                }
                CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return lista;
        }

        public ObservableCollection<ModeloOperacion> consultarOperacion()
        {
            ObservableCollection<ModeloOperacion> lista = new ObservableCollection<ModeloOperacion>();
            try
            {
                comando = new MySqlCommand("select * from operacion");
                comando.Connection = conexionBD;
                AbrirConexion();
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new ModeloOperacion() { Id = reader.GetString(0), Nombre = reader.GetString(1) });
                }
                CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return lista;
        }

        public bool EliminarRegistro(string tabla, string idRegistro)
        {
            bool eliminado = false;

            try
            {
                comando = new MySqlCommand("delete from "+tabla+" where id_"+tabla+" = "+idRegistro);
                comando.Connection = conexionBD;
                AbrirConexion();
                if(comando.ExecuteNonQuery() == 1) eliminado = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CerrarConexion();
            return eliminado;
        }
    }
}
