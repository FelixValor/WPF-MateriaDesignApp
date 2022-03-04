using MySql.Data.MySqlClient;
using ProyectoSteamVinito.Modelo;
using System;

using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace ProyectoSteamVinito.Core
{
    public class FuncionesBaseDatos
    {
        //CONEXION BASE DE DATOS
        private string servidor; //Nombre o ip del servidor de MySQL
        private string bd; //Nombre de la base de datos
        private string usuario; //Usuario de acceso a MySQL
        private string password; //Contraseña de usuario de acceso a MySQL
        private MySqlConnection conexionBD;
        private MySqlDataReader reader;
        private MySqlCommand comando;
        private bool error;
        private string cadenaConexion;
        private string RutaArchivoXML = "../../../Core/setting.xml";
        public FuncionesBaseDatos()
        {
            XmlSerializer reader = new XmlSerializer(typeof(Setting));
            StreamReader archivoleer = new StreamReader(RutaArchivoXML);
            Setting config = (Setting)reader.Deserialize(archivoleer);
            archivoleer.Close();
            servidor = config.Servidor;
            bd = config.BD;
            usuario = config.Usuario;
            password = config.Password;
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

        public BitmapImage SacarImagenDB(byte[] bytes)
        {
            BitmapImage imageSource = null;
            if(bytes != null)
            {
                MemoryStream ms = new MemoryStream(bytes);
                imageSource = new BitmapImage();
                imageSource.BeginInit();
                imageSource.StreamSource = ms;
                imageSource.EndInit();
            }

            return imageSource;
        }

        public void AgregarRegistroDB(String ruta,String tabla,String nombre)
        {
            if (tabla.Equals("equipo") || tabla.Equals("localizacion"))
            {

                string sql = "INSERT INTO " + tabla + " (nombre,imagen) VALUES (@name,@file)";
                // remember 'using' statements to efficiently release unmanaged resources
                using (conexionBD)
                {
                    AbrirConexion();
                    using (var cmd = new MySqlCommand(sql, conexionBD))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@name", nombre);
                            if (ruta != null)
                            {
                                cmd.Parameters.AddWithValue("@file", File.ReadAllBytes(ruta));
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@file", null);
                            }
                            cmd.ExecuteNonQuery();
                            CerrarConexion();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error con la base de datos\n\nCausa:\n" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }

            }
            else
            {
                string sql = "INSERT INTO " + tabla + " (nombre) VALUES (@name)";
                // remember 'using' statements to efficiently release unmanaged resources
                using (conexionBD)
                {
                    AbrirConexion();
                    using (var cmd = new MySqlCommand(sql, conexionBD))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@name", nombre);
                            cmd.ExecuteNonQuery();
                            CerrarConexion();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error con la base de datos\n\nCausa:\n" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        }
                        
                    }
                }
            }


        }

        public void ActualizarRegistroDB(String ruta, String tabla, String nombre,String id)
        {
            if (tabla.Equals("equipo") || tabla.Equals("localizacion"))
            {
                string sql = "UPDATE " + tabla + " SET nombre=@name,imagen=@file WHERE id_" + tabla + "=" + id;

                using (conexionBD)
                {
                    AbrirConexion();
                    using (var cmd = new MySqlCommand(sql, conexionBD))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@name", nombre);
                            if (ruta != null)
                            {
                                cmd.Parameters.AddWithValue("@file", File.ReadAllBytes(ruta));
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@file", null);
                            }

                            cmd.ExecuteNonQuery();
                            CerrarConexion();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error con la base de datos\n\nCausa:\n" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        
                    }
                }
            }
            else
            {
                string sql = "UPDATE " + tabla + " SET nombre=@name WHERE id_" + tabla + "=" + id;

                using (conexionBD)
                {
                    AbrirConexion();
                    using (var cmd = new MySqlCommand(sql, conexionBD))
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue("@name", nombre);
                            cmd.ExecuteNonQuery();
                            CerrarConexion();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error con la base de datos\n\nCausa:\n" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        
                    }
                }
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
            error = false;
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
                    try
                    {
                        if (!reader[2].GetType().ToString().Equals("System.DBNull")) mr.PropImagenEquipo = SacarImagenDB((byte[])reader[2]);

                        if (!reader[2].GetType().ToString().Equals("System.DBNull")) mr.PropImagenLoc = SacarImagenDB((byte[])reader[7]);

                    }catch(Exception e)
                    {
                        if (!error)
                        {
                            //MessageBox.Show("Registros sin imagen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            error = true;
                        }
                    }

                    lista.Add(mr);
                }
                reader.Close();
                CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Consultar Registros: " + ex.Message);
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
                    BitmapImage img = null;
                    if (!reader[2].GetType().ToString().Equals("System.DBNull")) img = SacarImagenDB((byte[])reader[2]);

                    lista.Add(new ModeloEquipo() { Id = reader.GetString(0), Nombre = reader.GetString(1), Image = img});
                }
                CerrarConexion();
            }catch (Exception ex)
            {
                MessageBox.Show("Error Consultar Equipos: "+ex.Message);
                CerrarConexion();
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
                MessageBox.Show("Error Consultar Grupos: " + ex.Message);
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
                    BitmapImage img = null;
                    if (!reader[2].GetType().ToString().Equals("System.DBNull")) img = SacarImagenDB((byte[])reader[2]);
                    lista.Add(new ModeloLocalizacion() { Id = reader.GetString(0), Nombre = reader.GetString(1), Image = img });
                }
                CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Consultar Localizacion: " + ex.Message);
                CerrarConexion();
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
                MessageBox.Show("Error Consultar Objetivo: " + ex.Message);
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
                MessageBox.Show("Error Consultar Operacion: " + ex.Message);
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
                MessageBox.Show("Error Eliminar Registro: " + ex.Message);
            }
            CerrarConexion();
            return eliminado;
        }

        
    }
}
