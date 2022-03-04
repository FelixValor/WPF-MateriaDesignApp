using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Media.Imaging;

namespace ProyectoSteamVinito.Modelo
{
    public class ModeloRegistro : INotifyPropertyChanged
    {
        private String fechaRegistro;
        private ModeloEquipo modeloEquipo;
        private ModeloGrupo modeloGrupo;
        private ModeloObjetivo modeloObjetivo;
        private ModeloOperacion modeloOperacion;
        private ModeloLocalizacion modeloLocalizacion;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propiedad)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
        }

        public BitmapImage PropImagenEquipo
        {
            get { return modeloEquipo.Image; }
            set
            {
                if (modeloEquipo.Image != null)
                {
                    if (modeloEquipo.Image.Equals(value))
                    {
                        modeloEquipo.Image = value;
                        RaisePropertyChanged("PropImagenEquipo");
                    }
                }
                else{
                    modeloEquipo.Image = value;
                    RaisePropertyChanged("PropImagenEquipo");
                }
            }
        }

        public BitmapImage PropImagenLoc
        {
            get { return modeloLocalizacion.Image; }
            set
            {
                if (modeloLocalizacion.Image != null)
                {
                    if (modeloLocalizacion.Image.Equals(value))
                    {
                        modeloLocalizacion.Image = value;
                        RaisePropertyChanged("PropImagenLoc");
                    }
                }
                else
                {
                    modeloLocalizacion.Image = value;
                    RaisePropertyChanged("PropImagenLoc");
                }
            }
        }

        public String PropFecha
        {
            get { return fechaRegistro; }
            set
            {
                if (fechaRegistro.Equals(value))
                {
                    fechaRegistro = value;
                    RaisePropertyChanged("PropFecha");
                }
            }
        }

        public ModeloEquipo PropModeloEquipo
        {
            get { return modeloEquipo; }
            set
            {
                if (modeloEquipo != value)
                {
                    modeloEquipo = value;
                    RaisePropertyChanged("PropModeloEquipo");
                }
            }
        }

        public ModeloGrupo PropModeloGrupo
        {
            get { return modeloGrupo; }
            set
            {
                if (modeloGrupo != value)
                {
                    modeloGrupo = value;
                    RaisePropertyChanged("PropModeloGrupo");
                }
            }
        }

        public ModeloLocalizacion PropModeloLocalizacion
        {
            get { return modeloLocalizacion; }
            set
            {
                if (modeloLocalizacion != value)
                {
                    modeloLocalizacion = value;
                    RaisePropertyChanged("modeloLocalizacion");
                }
            }
        }

        public ModeloObjetivo PropModeloObjetivo
        {
            get { return modeloObjetivo; }
            set
            {
                if (modeloObjetivo != value)
                {
                    modeloObjetivo = value;
                    RaisePropertyChanged("PropModeloObjetivo");
                }
            }
        }

        public ModeloOperacion PropModeloOperacion
        {
            get { return modeloOperacion; }
            set
            {
                if (modeloOperacion != value)
                {
                    modeloOperacion = value;
                    RaisePropertyChanged("PropModeloOperacion");
                }
            }
        }
    }
}
