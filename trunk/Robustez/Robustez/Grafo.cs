using System;
using System.Collections.Generic;
using System.Text;

namespace TeoriaDelAlgoritmosCSHARP
{
    class Grafo <T>
    {
        private ListaEnlazada<Vertice<T>> vertices;


        public Grafo(ListaEnlazada<Vertice<T>> vertices): base()
        {
            this.vertices = vertices;
        }

        public Grafo()
        {
            this.vertices = new ListaEnlazada<Vertice<T>>();
        }

        public ListaEnlazada<Vertice<T>> getVertices()
        {
            return vertices;
        }

        public void setVertices(ListaEnlazada<Vertice<T>> vertices)
        {
            this.vertices = vertices;
        }

        public Int32 getCantidadDeNodosGrafo()
        {
            return this.vertices.GetTamanio();
        }

        /**
         * Recorrido en profundidad
         */
        public void recorridoDFS()
        {
            return;
        }



        /**
         * Recorrido en ancho
         */
        public void recorridoBFS()
        {
            return;

        }

        /**
         * Agrega un v�rtice al grafo
         * @param vert
         */
        public void agregarVertice(Vertice<T> vert)
        {
            if (vert != null && vert.getContenido() != null && !this.contieneVertice(vert))
            {
                this.vertices.agregar(vert);
            }

        }

        /**
         * Crea un arco entre 2 v�rtices (no es grafo dirigido)
         * @param inicio
         * @param fin
         */
        public void agregarArco(Vertice<T> inicio, Vertice<T> fin)
        {
            //TODO:Validaciones!!!	
            inicio.getAdyacentes().agregar(fin);
            fin.getAdyacentes().agregar(inicio);

            this.agregarVertice(inicio);
            this.agregarVertice(fin);

        }

        public bool contieneVertice(Vertice<T> verticeBuscado)
        {

            return vertices.contiene(verticeBuscado);
        }
    }
}
