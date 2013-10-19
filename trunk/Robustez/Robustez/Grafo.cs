using System;
using System.Collections.Generic;


namespace Robustez
{
    public class Grafo<T>
    {
        private ListaEnlazada<Vertice<T>> _vertices;
        private ListaEnlazada<ListaEnlazada<Vertice<T>>> _ciclosGrafo;
        private ListaEnlazada<Vertice<T>> _subset;
        private List<Vertice<T>> _visitados;
        private long _index;


        public ListaEnlazada<Vertice<T>> Vertices
        {
            get { return _vertices; }
            set { _vertices = value; }
        }

        public ListaEnlazada<ListaEnlazada<Vertice<T>>> CiclosGrafo
        {
            get { return _ciclosGrafo; }
            set { _ciclosGrafo = value; }
        }


        public ListaEnlazada<Vertice<T>> Subset
        {
            get { return _subset; }
            set { _subset = value; }
        }

        public List<Vertice<T>> Visitados
        {
            get { return _visitados; }
            set { _visitados = value; }
        }


        public long Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public Grafo()
        {
            Vertices = new ListaEnlazada<Vertice<T>>();
            CiclosGrafo = new ListaEnlazada<ListaEnlazada<Vertice<T>>>();
            Subset = new ListaEnlazada<Vertice<T>>();
            Visitados = new List<Vertice<T>>();

        }
        public Grafo(ListaEnlazada<Vertice<T>> vertices)
        {
            Vertices = vertices;
        }

        public Int32 GetCantidadDestringsGrafo()
        {
            return Vertices.Tamanio;
        }


        public void EncontrarCiclos(Vertice<T> vert)
        {
            if (!vert.Visitado)
            {
                vert.Visitado = true;
                vert.Index = _index;
                vert.LowLink = _index;
                _index++;
                Visitados.Add(vert);
                // System.out.println(vert);

                ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterAdyacente = vert.Adyacentes.Iterador;

                while (iterAdyacente.HasNext())
                {
                    Vertice<T> vertAdyacente = iterAdyacente.Next();

                    if (!vertAdyacente.Visitado)
                    {
                        EncontrarCiclos(vertAdyacente);
                        vert.LowLink = Math.Min(vert.LowLink,
                                vertAdyacente.LowLink);
                    }
                    else if (Visitados.Contains(vertAdyacente))
                    {
                        vert.LowLink = Math.Min(vert.LowLink,
                                vertAdyacente.Index);
                    }
                }
            }

            if (vert.LowLink == vert.Index)
            { // Es el primero volviendo de la recursion
                int count = 0;
                Vertice<T> verticeAux = vert;
                while (count < Visitados.Count)
                {
                    foreach (Vertice<T> ver in Visitados)
                    {
                        if (ver.LowLink == verticeAux.Index
                                || ver.Index == verticeAux.Index)
                        {
                            _subset.Agregar(ver);
                        }
                        else
                        {
                            verticeAux = ver;
                            _ciclosGrafo.Agregar(_subset);
                            _subset = new ListaEnlazada<Vertice<T>>();
                            _subset.Agregar(ver);
                        }
                        count++;
                    }
                    _ciclosGrafo.Agregar(_subset);

                }
            }
        }

        /// <summary>
        /// Agrega un nuevo vertice al grafo.
        /// En caso de existir, no lo vuelve agregar.
        /// </summary>
        /// <param name="vertice"></param>
        public void AgregarVertice(Vertice<T> vertice)
        {
            if (vertice != null && vertice.Contenido != null && !ContieneVertice(vertice))
            {
                Vertices.Agregar(vertice);
            }

        }

        /// <summary>
        /// Agrega un arco al grafo dados vertice inicio y un vertice fin.
        /// </summary>
        /// <param name="inicio"></param>
        /// <param name="fin"></param>
        public void AgregarArco(Vertice<T> inicio, Vertice<T> fin)
        {

            Vertice<T> inicioEnGrafo = ObtenerVertice(inicio);

            if (inicioEnGrafo != null)
            {
                inicio = inicioEnGrafo;
            }

            inicio.Adyacentes.Agregar(fin);

            AgregarVertice(inicio);

        }

        /// <summary>
        /// Si contiene el vertice buscado, lo devuelve.
        /// </summary>
        /// <param name="buscado"></param>
        /// <returns></returns>
        private Vertice<T> ObtenerVertice(Vertice<T> verticeBuscado)
        {

            return Vertices.Obtener(verticeBuscado);
        }

        /// <summary>
        /// Devuelve true o false segun si contiene o no el vertice buscado respectivamente.
        /// </summary>
        /// <param name="verticeBuscado"></param>
        /// <returns></returns>
        public bool ContieneVertice(Vertice<T> verticeBuscado)
        {

            return Vertices.Contiene(verticeBuscado);
        }
    }
}
