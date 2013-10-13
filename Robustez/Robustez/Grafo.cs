using System;
using System.Collections.Generic;
using System.Text;


namespace TeoriaDelAlgoritmosCSHARP
{
    public class Grafo<T>
    {
        private ListaEnlazada<Vertice<T>> _vertices;
        private ListaEnlazada<Vertice<T>> _listaRecorridoDFS;
        private ListaEnlazada<Vertice<T>> _listaRecorridoBFS;
        private ListaEnlazada<ListaEnlazada<Vertice<T>>> _ciclosGrafo;
        private ListaEnlazada<Vertice<T>> _subset;
        private Stack<Vertice<T>> _stack;
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

        public Stack<Vertice<T>> Stack
        {
            get { return _stack; }
            set { _stack = value; }
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
            Stack = new Stack<Vertice<T>>();

        }
        public Grafo(ListaEnlazada<Vertice<T>> vertices)
            : base()
        {
            Vertices = vertices;
        }

        public Int32 GetCantidadDeNodosGrafo()
        {
            return Vertices.GetTamanio();
        }

      
       

        /**
         * Recorrido en profundidad
         */
        public void RecorridoDFS(ListaEnlazada<Vertice<T>> vertices)
        {

            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterador = vertices.Iterador();

            while (iterador.HasNext())
            {
                Vertice<T> vert = iterador.next();
                if (!vert.isVisitado())
                {
                    vert.setVisitado(true);
                    // System.out.println(vert);
                    ListaRecorridoDFS.agregar(vert);
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

            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterador = vertices.Iterador();

            while (iterador.HasNext())
            {
                Vertice<T> vert = iterador.next();

                if (!vert.isVisitado())
                {
                    vert.setVisitado(true);
                    // System.out.println(vert);
                    ListaRecorridoBFS.agregar(vert);
                }

                ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iteVertice = vert.Adyacentes.Iterador();
                while (iteVertice.HasNext())
                {
                    Vertice<T> vertAdy = iteVertice.next();
                    if (!vertAdy.isVisitado())
                    {
                        vertAdy.setVisitado(true);
                        // System.out.println(vertAdy);
                        ListaRecorridoBFS.agregar(vertAdy);
                    }
                }

            }

            return;
        }


        //Todavia no está terminado porque no calcula bien. 
        //Hay que revisar.
        public void EncontrarCiclos(ListaEnlazada<Vertice<T>> vertices)
        {

            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterador = vertices.Iterador();

            while (iterador.HasNext())
            {
                Vertice<T> vert = iterador.next();
                if (!vert.isVisitado())
                {
                    vert.Visitado = true;
                    vert.Index = _index;
                    vert.LowLink = _index;
                    _index++;
                    _stack.Push(vert);
                    // System.out.println(vert);

                    ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterAdyacente = vert.Adyacentes.Iterador();

                    while (iterAdyacente.HasNext())
                    {
                        Vertice<T> vertAdyacente = iterAdyacente.next();

                        if (!vertAdyacente.isVisitado())
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
                        while (!vert.equals(neighbor))
                        {
                            neighbor = _stack.Pop();
                            _subset.agregar(neighbor);
                        }

                        _ciclosGrafo.agregar(_subset);
                    }
                }
            }
            return;
        }


        /**
         * Agrega un v�rtice al grafo
         * @param vert
         */
        public void AgregarVertice(Vertice<T> vertice)
        {
            if (vertice != null && vertice.Contenido != null && !this.ContieneVertice(vertice))
            {
                Vertices.agregar(vertice);
            }

        }

        /**
         * Crea un arco entre 2 v�rtices (no es grafo dirigido)
         * @param inicio
         * @param fin
         */
        public void AgregarArco(Vertice<T> inicio, Vertice<T> fin)
        {
            //TODO:Validaciones!!!	
            inicio.Adyacentes.agregar(fin);
            fin.Adyacentes.agregar(inicio);

            AgregarVertice(inicio);
            AgregarVertice(fin);

        }

        public bool ContieneVertice(Vertice<T> verticeBuscado)
        {

            return Vertices.Contiene(verticeBuscado);
        }
    }
}
