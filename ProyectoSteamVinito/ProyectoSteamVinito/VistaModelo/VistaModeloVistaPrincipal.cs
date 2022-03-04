﻿using ProyectoSteamVinito.Core;
using ProyectoSteamVinito.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace ProyectoSteamVinito.VistaModelo
{
    public class VistaModeloVistaPrincipal
    {
        FuncionesBaseDatos fbd = new FuncionesBaseDatos();

        public ObservableCollection<ModeloRegistro> Registros
        {
            get; set;
        }

        public ObservableCollection<ModeloEquipo> Equipos
        {
            get; set;
        }

        public ObservableCollection<ModeloGrupo> Grupos
        {
            get; set;
        }

        public ObservableCollection<ModeloLocalizacion> Localizaciones
        {
            get; set;
        }

        public ObservableCollection<ModeloObjetivo> Objetivos
        {
            get; set;
        }

        public ObservableCollection<ModeloOperacion> Operaciones
        {
            get; set;
        }

        public void CargarRegistros(String[] datos)
        {
            ObservableCollection<ModeloRegistro> registros;
            registros = fbd.consultarRegistros(filtrado: datos);
            Registros = registros;
            ////////////////
            /////////////////
            //////////////
            //Aqui tienes que avisar a la pantalla de carga que ya se puede ir
            ////////////////
            /////////////////
            //////////////
        }

        public void CargarEquipos()
        {
            ObservableCollection<ModeloEquipo> equipos;
            equipos = fbd.consultarEquipos();
            Equipos = equipos;
        }

        public void CargarGrupos()
        {
            ObservableCollection<ModeloGrupo> grupos;
            grupos = fbd.consultarGrupos();
            Grupos = grupos;
        }

        public void CargarLocalizaciones()
        {
            ObservableCollection<ModeloLocalizacion> localizaciones;
            localizaciones = fbd.consultarLocalizaciones();
            Localizaciones = localizaciones;
        }

        public void CargarObjetivos()
        {
            ObservableCollection<ModeloObjetivo> objetivos;
            objetivos = fbd.consultarObjetivo();
            Objetivos = objetivos;
        }

        public void CargarOperaciones()
        {
            ObservableCollection<ModeloOperacion> operaciones;
            operaciones = fbd.consultarOperacion();
            Operaciones = operaciones;
        }
    }
}
