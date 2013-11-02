using System;
using System.Collections.Generic;


namespace Robustez
{
    public class Grafo<T>
    {
        private ListaEnlazada<Vertice<T>> _vertices;
        private ListaCircular<ListaCircular<Vertice<T>>> _ciclosGrafo;    
        private long _tiempo;

        public long Tiempo
        {
            get { return _tiempo; }
            set { _tiempo = value; }
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

        public Grafo()
        {
            Vertices = new ListaEnlazada<Vertice<T>>();
            CiclosGrafo = new ListaCircular<ListaCircular<Vertice<T>>>();           
            Tiempo = 0;
        }

        public Grafo(ListaEnlazada<Vertice<T>> vertices)
        {
            Vertices = vertices;
        }

        public Int32 GetCantidadDeVertices()
        {
            return Vertices.Tamanio;
        }


        public void RecorridoDFS()
        {
            Vertices.ResetIterator();
            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterador = Vertices.Iterador;
            while (iterador.HasNext())
            {
                Vertice<T> v = iterador.Next();
                v.Color = Color.blanco;
                v.Padre = null;
            }

            Tiempo = 0;

            Vertices.Iterador = new ListaEnlazada<Vertice<T>>.IteradorListaEnlazada(Vertices);
            iterador = Vertices.Iterador;
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
            Tiempo++;
            v.NroCreciente = Tiempo;
            v.Color = Color.gris;

            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterAdyacente = v.Adyacentes.Iterador;
            while (iterAdyacente.HasNext())
            {
                Vertice<T> vertAdy = iterAdyacente.Next();
                if (vertAdy.Color == Color.gris && vertAdy != v.Padre && !vertAdy.AgregadoEnListaCiclo)
                    procesarCiclo(v, vertAdy);
                if (vertAdy.Color == Color.blanco)
                {
                    vertAdy.Padre = v;
                    DFS_Visitar(vertAdy);
                }
            }

            v.Color = Color.negro;
            Tiempo++;
            v.NroDecreciente = Tiempo;
        }

        private void procesarCiclo(Vertice<T> v1, Vertice<T> v2)
        {
            Vertice<T> vAux = v1.Padre;
            ListaCircular<Vertice<T>>  cicloAux = new ListaCircular<Vertice<T>>();
            v1.AgregadoEnListaCiclo = true;
            v1.NroComponenteConexa = CiclosGrafo.Tamanio + 1;
            cicloAux.Agregar(v1);
            while (vAux != v2) 
            {
                vAux.AgregadoEnListaCiclo = true;
                vAux.NroComponenteConexa = CiclosGrafo.Tamanio + 1;
                cicloAux.Agregar(vAux);
                vAux = vAux.Padre;
            }
            v2.AgregadoEnListaCiclo = true;
            v2.NroComponenteConexa = CiclosGrafo.Tamanio + 1;
            cicloAux.Agregar(v2);

            CiclosGrafo.Agregar(cicloAux);
        }

        public void EnlistarVerticesDiscontinuos()
        {
            ListaEnlazada<Vertice<T>> lista = this.Vertices;
            lista.ResetIterator();
            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iter = lista.Iterador;
            ListaCircular<Vertice<T>> cicloAux;

            while (iter.HasNext())
            {
                Vertice<T> vActual = iter.Next();
                if (vActual.NroDecreciente == vActual.NroCreciente + 1 && !vActual.AgregadoEnListaCiclo)
                {
                    Vertice<T> vAux = vActual.Padre;
                    cicloAux = new ListaCircular<Vertice<T>>();
                    vActual.NroComponenteConexa = CiclosGrafo.Tamanio + 1;
                    cicloAux.Agregar(vActual);
                    while (vAux != null)
                    {
                        vAux.NroComponenteConexa = CiclosGrafo.Tamanio + 1;
                        cicloAux.Agregar(vAux);
                        vAux = vAux.Padre;
                    }

                    CiclosGrafo.Agregar(cicloAux);
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

        /*
        public Vertice<T> obtenerVertice(int i, string tipo)
        {
            if (tipo == "origen")
            {
                this.Vertices.ResetIterator();
                ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterV = this.Vertices.Iterador;

                while (iterV.HasNext())
                {
                    Vertice<T> v = iterV.Next();
                    if (v.NroComponenteConexa == i)
                        return v;
                }
            }
            else 
            {
                if (i == this.CiclosGrafo.Tamanio) i--;
                else i++;

                this.Vertices.ResetIterator();
                ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterV = this.Vertices.Iterador;
                while (iterV.HasNext())
                {
                    Vertice<T> v = iterV.Next();
                    if (v.NroComponenteConexa == i)
                        return v;
                }
            }

            return null;
        }
        */

        internal Arista<T> obtenerVertice(int i)
        {
            this.Vertices.ResetIterator();
            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada iterV = this.Vertices.Iterador;
            Vertice<T> origen = new Vertice<T>();
            Vertice<T> destino = new Vertice<T>();

            while (iterV.HasNext())
            {
                origen = iterV.Next();
                if (origen.NroComponenteConexa == i)
                    break;
            }

            this.Vertices.ResetIterator();
            iterV = this.Vertices.Iterador;

            while (iterV.HasNext())
            {
                destino = iterV.Next();
                if (!origen.Adyacentes.Contiene(destino) && !origen.Equals(destino) && destino.NroComponenteConexa != i)
                    break;
            }

            return new Arista<T>(origen, destino);

        }
    }
}
