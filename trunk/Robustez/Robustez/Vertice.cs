using System;

namespace Robustez
{
    public class Vertice<T>
    {
        private T _contenido;
        private bool _visitado;
        private ListaEnlazada<Vertice<T>> _adyacentes;
        private long _index;
        private long _lowLink;

        public long Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public long LowLink
        {
            get { return _lowLink; }
            set { _lowLink = value; }
        }

        public T Contenido
        {
            get { return _contenido; }
            set { _contenido = value; }
        }


        public bool Visitado
        {
            get { return _visitado; }
            set { _visitado = value; }
        }


        public ListaEnlazada<Vertice<T>> Adyacentes
        {
            get { return _adyacentes; }
            set { _adyacentes = value; }
        }

        public Vertice()
        {
            Adyacentes = new ListaEnlazada<Vertice<T>>();
        }

        public Vertice(T contenido)
        {
            Contenido = contenido;
            Adyacentes = new ListaEnlazada<Vertice<T>>();
        }

        
        public Int32 GetGradoVertice()
        {
            return _adyacentes.Tamanio;
        }



        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result
                    + ((Contenido == null) ? 0 : Contenido.GetHashCode());
            return result;
        }

        /// <summary>
        /// Devuelve true o false segun si un vertice es igual a otro respectivamente.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (this == null && obj == null)
                return true;
            else
            {
                if (this == null || obj == null)
                    return false;
                else
                {
                    Vertice<T> otroVertice = (Vertice<T>) obj;
                    if (Contenido == null && otroVertice.Contenido == null)
                        return true;
                    else
                    {
                        if (Contenido == null || otroVertice.Contenido == null)
                            return false;
                        else
                            return Contenido.Equals(otroVertice.Contenido);
                    }

                }
            }
        }

        /// <summary>
        /// Metodo sobreescrito para mostrar claramente el vertice.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Vertice: " + Contenido + " (i: " + Index + " , l: " + LowLink + ")";
        }
    }
}
