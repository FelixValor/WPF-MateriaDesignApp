using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProyectoSteamVinito.Modelo
{
    public class ModeloEquipo : INotifyPropertyChanged
    {
        private string id, nombre;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propiedad)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    RaisePropertyChanged("Nombre");
                }
            }
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
    }
}
