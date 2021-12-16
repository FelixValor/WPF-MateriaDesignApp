using MySql.Data.MySqlClient;
using ProyectoSteamVinito.Modelo;
using System;

using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace ProyectoSteamVinito.Core
{
    public class FuncionesBaseDatos
    {
        //CONEXION BASE DE DATOS
        private string servidor = "localhost"; //Nombre o ip del servidor de MySQL
        private string bd = "bodega"; //Nombre de la base de datos
        private string usuario = "root"; //Usuario de acceso a MySQL
        private string password = "admin"; //Contraseña de usuario de acceso a MySQL
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

        public ObservableCollection<ModeloRegistro> consultarRegistros()
        {
            ObservableCollection<ModeloRegistro> lista = new ObservableCollection<ModeloRegistro>();
            try
            {
                comando = new MySqlCommand("select * from registro");
                comando.Connection = conexionBD;
                AbrirConexion();
                reader = comando.ExecuteReader();
                MySqlDataReader readerById;
                ModeloRegistro mr = new ModeloRegistro();
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);

                while (reader.Read())
                {
                    comando = new MySqlCommand("select * from equipo");
                    comando.Connection = conexion;
                    conexion.Open();
                    readerById = comando.ExecuteReader();

                    while (readerById.Read())
                    {
                        mr.PropModeloEquipo = new ModeloEquipo() { Id = readerById.GetString(0), Nombre = readerById.GetString(1) };
                    }
                    conexion.Close();
                    readerById.Close();

                    comando = new MySqlCommand("select * from grupo");
                    comando.Connection = conexion;
                    conexion.Open();
                    readerById = comando.ExecuteReader();

                    while (readerById.Read())
                    {
                        mr.PropModeloGrupo = new ModeloGrupo() { Id = readerById.GetString(0), Nombre = readerById.GetString(1) };
                    }
                    conexion.Close();
                    readerById.Close();

                    comando = new MySqlCommand("select * from objetivo");
                    comando.Connection = conexion;
                    conexion.Open();
                    readerById = comando.ExecuteReader();

                    while (readerById.Read())
                    {
                        mr.PropModeloObjetivo = new ModeloObjetivo() { Id = readerById.GetString(0), Nombre = readerById.GetString(1) };
                    }
                    conexion.Close();
                    readerById.Close();

                    comando = new MySqlCommand("select * from localizacion");
                    comando.Connection = conexion;
                    conexion.Open();
                    readerById = comando.ExecuteReader();

                    while (readerById.Read())
                    {
                        mr.PropModeloLocalizacion = new ModeloLocalizacion() { Id = readerById.GetString(0), Nombre = readerById.GetString(1) };
                    }
                    conexion.Close();
                    readerById.Close();

                    comando = new MySqlCommand("select * from operacion");
                    comando.Connection = conexion;
                    conexion.Open();
                    readerById = comando.ExecuteReader();

                    while (readerById.Read())
                    {
                        mr.PropModeloOperacion = new ModeloOperacion() { Id = readerById.GetString(0), Nombre = readerById.GetString(1) };
                    }
                    conexion.Close();
                    readerById.Close();

                    lista.Add(mr);
                }
                CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}
