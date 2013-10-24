using System;
using System.Collections.Generic;
using System.Text;

namespace Robustez
{
    public class ListaCircular<T>
    {
        private readonly Elemento<T> _header = new Elemento<T>(default(T), null, null);
        private Int32 _tamanio;
        private IteradorListaCircular _iterador;


        public Int32 Tamanio
        {
            get { return _tamanio; }
            set { _tamanio = value; }
        }

        private Elemento<T> Header
        {
            get { return _header; }
        }

        public IteradorListaCircular Iterador
        {
            get { return _iterador; }
            set { _iterador = value; }
        }

        public ListaCircular()
        {
            Tamanio = 0;
            Header.Siguiente = _header;
            Header.Anterior = _header;
            Iterador = new IteradorListaCircular(this);
        }

        public bool Vacia()
        {
            return Tamanio == 0;
        }

        public void ResetIterator()
        {
            Iterador = new IteradorListaCircular(this);
        }

        public T Primero()
        {
            return _header.Siguiente.Vertice;
        }

        public T Ultimo()
        {
            return _header.Anterior.Vertice;
        }

        public void Agregar(T elemento)
        {
            AgregarAntes(elemento, _header);
        }


        private void AgregarAntes(T elemento, Elemento<T> siguiente)
        {


            Elemento<T> nuevo = new Elemento<T>(elemento, siguiente, siguiente.Anterior);
            nuevo.Anterior.Siguiente = nuevo;
            nuevo.Siguiente.Anterior = nuevo;


            Tamanio += 1;
        }

        public class IteradorListaCircular
        {

            private int _siguiente;
            private Elemento<T> _siguienteElemento;
            private ListaCircular<T> _lista;

            public int Siguiente
            {
                get { return _siguiente; }
                set { _siguiente = value; }
            }

            private Elemento<T> SiguienteElemento
            {
                get { return _siguienteElemento; }
                set { _siguienteElemento = value; }
            }

            public ListaCircular<T> Lista
            {
                get { return _lista; }
                set { _lista = value; }
            }

            public IteradorListaCircular(ListaCircular<T> lista)
            {
                Siguiente = 0;
                SiguienteElemento = lista.Header;
                Lista = lista;
            }


            public bool HasNext()
            {
                return _siguiente != _lista.Tamanio;
            }

            public T Next()
            {

                T aRetornar = default(T);

                if (Siguiente >= _lista.Tamanio)
                {
                    aRetornar = _lista.Primero();
                    SiguienteElemento = SiguienteElemento.Siguiente;
                    Siguiente = 0;
                  
                }
                else {
                    aRetornar = _siguienteElemento.Siguiente.Vertice;
                    SiguienteElemento = SiguienteElemento.Siguiente;
                    Siguiente++;
                  
                }

                return aRetornar;
            }

            public bool HasPrevious()
            {
                return Siguiente != 0;
            }


            public T Previous()
            {

                T aRetornar = default(T);

                if (Siguiente > 0)
                {

                    aRetornar = SiguienteElemento.Anterior.Vertice;
                    SiguienteElemento = SiguienteElemento.Anterior;
                    Siguiente--;
                }

                return aRetornar;
            }

        }

        public bool Contiene(T datoBuscado)
        {

            return Obtener(datoBuscado) != null;

        }

        public T Obtener(T datoBuscado)
        {

            T encontrado = default(T);
            Iterador = new IteradorListaCircular(this);

            while (encontrado == null && Iterador.HasNext())
            {
                T item = Iterador.Next();

                if (item.Equals(datoBuscado))
                {
                    encontrado = item;
                }
            }

            return encontrado;
        }

        private class Elemento<T>
        {

            private T _vertice;
            private Elemento<T> _anterior;
            private Elemento<T> _siguiente;

            public T Vertice
            {
                get { return _vertice; }
                set { _vertice = value; }
            }

            public Elemento<T> Anterior
            {
                get { return _anterior; }
                set { _anterior = value; }
            }


            public Elemento<T> Siguiente
            {
                get { return _siguiente; }
                set { _siguiente = value; }
            }

            public Elemento(T elemento, Elemento<T> siguiente, Elemento<T> anterior)
            {

                Vertice = elemento;
                Anterior = anterior;
                Siguiente = siguiente;
            }

        }


    }
}
