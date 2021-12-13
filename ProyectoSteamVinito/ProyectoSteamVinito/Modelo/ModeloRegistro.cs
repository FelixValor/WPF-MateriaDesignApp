using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProyectoSteamVinito.Modelo
{
    public class ModeloRegistro : INotifyPropertyChanged
    {

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
