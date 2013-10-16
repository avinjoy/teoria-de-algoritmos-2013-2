using System;

namespace Robustez
{
    public class Nodo
    {
        private int _nroCiclo;
        private int _nroAdyacentes;
        private string _nombre;

        public Nodo()
        {
        }

        public Nodo(string nombre)
        {     
            Nombre = nombre;
        }

        public int NroCiclo
        {
            get { return _nroCiclo; }
            set { _nroCiclo = value; }
        }


        public int NroAdyacentes
        {
            get { return _nroAdyacentes; }
            set { _nroAdyacentes = value; }
        }

        
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Determina cuando un nodo es igual a otro.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Nodo nodo = (Nodo)obj;
            return Nombre.Equals(nodo.Nombre);
        }

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
