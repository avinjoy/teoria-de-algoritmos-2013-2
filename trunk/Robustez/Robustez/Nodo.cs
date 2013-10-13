using System;
using System.Collections.Generic;
using System.Text;

namespace TeoriaDelAlgoritmosCSHARP
{
    public class Nodo
    {
        public Nodo() 
        {

        }

        private Int32 nroCiclo;
        private Int32 nroAdyacentes;
        private string nombre;


        public Int32 NroCiclo
        {
            get { return nroCiclo; }
            set { nroCiclo = value; }
        }

        
        public Int32 NroAdyacentes
        {
            get { return nroAdyacentes; }
            set { nroAdyacentes = value; }
        }

        
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
}
