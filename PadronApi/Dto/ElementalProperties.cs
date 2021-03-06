﻿using System;
using System.Linq;

namespace PadronApi.Dto
{
    /// <summary>
    /// Clase de referencia para todos aquellos catálogos que únicamente estén compuestos
    /// por dos o tres atributos
    /// </summary>
    public class ElementalProperties
    {
        private bool isChecked;
        private int idElemento;
        private string descripcion;
        private string elementoAuxiliar;

        public bool IsChecked
        {
            get
            {
                return this.isChecked;
            }
            set
            {
                this.isChecked = value;
            }
        }
        
        public int IdElemento
        {
            get
            {
                return this.idElemento;
            }
            set
            {
                this.idElemento = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
        public string ElementoAuxiliar
        {
            get
            {
                return this.elementoAuxiliar;
            }
            set
            {
                this.elementoAuxiliar = value;
            }
        }


    }
}
