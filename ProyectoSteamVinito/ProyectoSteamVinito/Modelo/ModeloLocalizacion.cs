using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media.Imaging;

namespace ProyectoSteamVinito.Modelo
{
    public class ModeloLocalizacion : INotifyPropertyChanged
    {

        private string id, nombre;
        private BitmapImage image;

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

        public BitmapImage Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    RaisePropertyChanged("Image");
                }
            }
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}
