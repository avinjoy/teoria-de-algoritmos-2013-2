using System;
using System.Collections.Generic;
using System.Text;

namespace Robustez
{
    class Nodo
    {
        public Nodo() 
        {

        }

        private Int32 nroCiclo;
        public Int32 NroCiclo
        {
            get { return nroCiclo; }
            set { nroCiclo = value; }
        }

        private Int32 nroAdyacentes;
        public Int32 NroAdyacentes
        {
            get { return nroAdyacentes; }
            set { nroAdyacentes = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
}
