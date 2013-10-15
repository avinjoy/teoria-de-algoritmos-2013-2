using System;
using System.Collections.Generic;
using System.Text;


namespace Robustez
{
    public class Grafo<T>
    {
        private ListaEnlazada<Vertice<T>> _vertices;
        private ListaEnlazada<Vertice<T>> _listaRecorridoDFS;
        private ListaEnlazada<Vertice<T>> _listaRecorridoBFS;
        private ListaEnlazada<ListaEnlazada<Vertice<T>>> _ciclosGrafo;
        private ListaEnlazada<Vertice<T>> _subset;
        private List<Vertice<T>> _visitados;
        private long _index;


        public ListaEnlazada<Vertice<T>> Vertices
        {
            get { return _vertices; }
            set { _vertices = value; }
        }

        public ListaEnlazada<Vertice<T>> ListaRecorridoDFS
        {
            get { return _listaRecorridoDFS; }
            set { _listaRecorridoDFS = value; }
        }

        public ListaEnlazada<Vertice<T>> ListaRecorridoBFS
        {
            get { return _listaRecorridoBFS; }
            set { _listaRecorridoBFS = value; }
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
            ListaRecorridoDFS = new ListaEnlazada<Vertice<T>>();
            ListaRecorridoBFS = new ListaEnlazada<Vertice<T>>();
            CiclosGrafo = new ListaEnlazada<ListaEnlazada<Vertice<T>>>();
            Subset = new ListaEnlazada<Vertice<T>>();
            Visitados = new List<Vertice<T>>();

        }
        public Grafo(ListaEnlazada<Vertice<T>> vertices)
            : base()
        {
            Vertices = vertices;
        }

        public Int32 GetCantidadDeNodosGrafo()
        {
            return Vertices.Tamanio;
        }

      
       

        /**
         * Recorrido en profundidad
         */
        public void RecorridoDFS(ListaEnlazada<Vertice<T>> vertices)
        {

            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterador = vertices.Iterador;

            while (iterador.HasNext())
            {
                Vertice<T> vert = iterador.Next();
                if (!vert.Visitado)
                {
                    vert.Visitado = true;
                    // System.out.println(vert);
                    ListaRecorridoDFS.Agregar(vert);
                    RecorridoDFS(vert.Adyacentes);
                }
            }
            return;
        }

        /**
         * Recorrido en ancho
         */
        public void RecorridoBFS(ListaEnlazada<Vertice<T>> vertices)
        {

            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterador = vertices.Iterador;

            while (iterador.HasNext())
            {
                Vertice<T> vert = iterador.Next();

                if (!vert.Visitado)
                {
                    vert.Visitado = true;
                    // System.out.println(vert);
                    ListaRecorridoBFS.Agregar(vert);
                }

                ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iteVertice = vert.Adyacentes.Iterador;
                while (iteVertice.HasNext())
                {
                    Vertice<T> vertAdy = iteVertice.Next();
                    if (!vertAdy.Visitado)
                    {
                        vertAdy.Visitado = true;
                        // System.out.println(vertAdy);
                        ListaRecorridoBFS.Agregar(vertAdy);
                    }
                }

            }

            return;
        }

        /*
        //Todavia no está terminado porque no calcula bien. 
        //Hay que revisar.
        public void EncontrarCiclos(ListaEnlazada<Vertice<T>> vertices)
        {

            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterador = vertices.Iterador;

            while (iterador.HasNext())
            {
                Vertice<T> vert = iterador.Next();
                if (!vert.Visitado)
                {
                    vert.Visitado = true;
                    vert.Index = _index;
                    vert.LowLink = _index;
                    _index++;
                    _stack.Push(vert);
                    // System.out.println(vert);

                    ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterAdyacente = vert.Adyacentes.Iterador;

                    while (iterAdyacente.HasNext())
                    {
                        Vertice<T> vertAdyacente = iterAdyacente.Next();

                        if (!vertAdyacente.Visitado)
                        {
                            EncontrarCiclos(vert.Adyacentes);
                            vert.LowLink = Math.Min(vert.LowLink,vertAdyacente.LowLink);
                        }
                        else if (_stack.Contains(vertAdyacente))
                        {
                            vert.LowLink = Math.Min(vert.LowLink,
                                    vertAdyacente.Index);
                        }
                    }

                    if (vert.LowLink == vert.Index)
                    {
                        Vertice<T> neighbor = null;
                        while (!vert.Equals(neighbor))
                        {
                            neighbor = _stack.Pop();
                            _subset.Agregar(neighbor);
                        }

                        _ciclosGrafo.Agregar(_subset);
                    }
                }
            }
            return;
        }
        */


        public void encontrarCiclos(Vertice<T> vert)
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
                        encontrarCiclos(vertAdyacente);
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
                return;
            }
        }

        public void AgregarVertice(Vertice<T> vertice)
        {
            if (vertice != null && vertice.Contenido != null && !this.ContieneVertice(vertice))
            {
                Vertices.Agregar(vertice);
            }

        }

   
        public void agregarArco(Vertice<T> inicio, Vertice<T> fin)
        {
            
            Vertice<T> inicioEnGrafo = Obtener(inicio);

            if (inicioEnGrafo != null)
            {
                inicio = inicioEnGrafo;
            }

            Vertice<T> finEnGrafo = Obtener(fin);

            if (finEnGrafo != null)
            {
                fin = finEnGrafo;
            }

            inicio.Adyacentes.Agregar(fin);
            fin.Adyacentes.Agregar(inicio);

            AgregarVertice(inicio);
            AgregarVertice(fin);

        }

        private Vertice<T> Obtener(Vertice<T> buscado)
        {

            return Vertices.Obtener(buscado);
        }

        public bool ContieneVertice(Vertice<T> verticeBuscado)
        {

            return Vertices.Contiene(verticeBuscado);
        }
    }
}
