using System;
using System.Collections.Generic;


namespace Robustez
{
    public class Grafo<T>
    {
        private ListaEnlazada<Vertice<T>> _vertices;
        private ListaCircular<ListaCircular<Vertice<T>>> _ciclosGrafo;
        private ListaCircular<Vertice<T>> _subset;
        private List<Vertice<T>> _visitados;
        private long _index;

        private ListaEnlazada<Vertice<T>> _recorridoBFS;
        private long _nroCreciente;
        private long _nroDecreciente;
        public ListaEnlazada<Vertice<T>> RecorridoDFS
        {
            get { return _recorridoBFS; }
            set { _recorridoBFS = value; }
        }
        public long NroCreciente
        {
            get { return _nroCreciente; }
            set { _nroCreciente = value; }
        }
        public long NroDecreciente
        {
            get { return _nroDecreciente; }
            set { _nroDecreciente = value; }
        }

        public ListaEnlazada<Vertice<T>> Vertices
        {
            get { return _vertices; }
            set { _vertices = value; }
        }

        public ListaCircular<ListaCircular<Vertice<T>>> CiclosGrafo
        {
            get { return _ciclosGrafo; }
            set { _ciclosGrafo = value; }
        }


        public ListaCircular<Vertice<T>> Subset
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
            CiclosGrafo = new ListaCircular<ListaCircular<Vertice<T>>>();
            Subset = new ListaCircular<Vertice<T>>();
            Visitados = new List<Vertice<T>>();
            RecorridoDFS = new ListaEnlazada<Vertice<T>>();

            NroCreciente = 0;
            NroDecreciente = 0;
        }
        public Grafo(ListaEnlazada<Vertice<T>> vertices)
        {
            Vertices = vertices;
        }

        public Int32 GetCantidadDeVertices()
        {
            return Vertices.Tamanio;
        }


        public void recorridoDFS(Grafo<T> grafo)
        {
            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterador = grafo.Vertices.Iterador;
            while (iterador.HasNext())
            {
                Vertice<T> v = iterador.Next();
                v.Color = Color.blanco;
                v.Padre = null;
            }

            NroCreciente = 0;

            grafo.Vertices.Iterador = new ListaEnlazada<Vertice<T>>.IteradorListaEnlazada(grafo.Vertices);
            iterador = grafo.Vertices.Iterador;
            while (iterador.HasNext())
            {
                Vertice<T> v = iterador.Next();
                if (v.Color == Color.blanco) 
                {
                    DFS_Visitar(v);
                }
            }
        }

        private void DFS_Visitar(Vertice<T> v)
        {
            NroCreciente++;
            v.Index = NroCreciente;
            v.Color = Color.gris;

            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterAdyacente = v.Adyacentes.Iterador;
            while (iterAdyacente.HasNext())
            {
                Vertice<T> vertAdy = iterAdyacente.Next();
                if (vertAdy.Color == Color.gris && vertAdy != v.Padre)
                    procesarCiclo(v, vertAdy);
                if (vertAdy.Color == Color.blanco)
                {
                    vertAdy.Padre = v;
                    DFS_Visitar(vertAdy);
                }
            }

            v.Color = Color.negro;
            NroCreciente++;
            v.LowLink = NroCreciente;
        }

        private void procesarCiclo(Vertice<T> v1, Vertice<T> v2)
        {
            Vertice<T> vAux = v1.Padre;
            _subset = new ListaCircular<Vertice<T>>();
            v1.AgregadoEnListaCiclo = true;
            _subset.Agregar(v1);
            while (vAux != v2) 
            {
                vAux.AgregadoEnListaCiclo = true;
                _subset.Agregar(vAux);
                vAux = vAux.Padre;
            }
            v2.AgregadoEnListaCiclo = true;
            _subset.Agregar(v2);

            _ciclosGrafo.Agregar(_subset);
        }

        //public void EncontrarCiclos(Vertice<T> vertice)
        //{
        //    vertice.Visitado = true;
        //    NroCreciente++;
        //    vertice.Index = NroCreciente;

        //    ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterAdyacente = vertice.Adyacentes.Iterador;
        //    while (iterAdyacente.HasNext())
        //    {
        //        Vertice<T> vertAdy = iterAdyacente.Next();
        //        if (!vertAdy.Visitado)
        //        {
        //            RecorridoDFS.Agregar(vertAdy);
        //            EncontrarCiclos(vertAdy);
        //        }

        //        NroDecreciente++;
        //        vertice.LowLink = NroDecreciente;
        //    }
        //    return;
        //}


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
                            _subset = new ListaCircular<Vertice<T>>();
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

            Vertice<T> finEnGrafo = ObtenerVertice(fin);

            if (finEnGrafo != null)
            {
                fin = finEnGrafo;
            }

            AgregarVertice(inicio);
            AgregarVertice(fin);

            inicio.Adyacentes.Agregar(fin);
           
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
