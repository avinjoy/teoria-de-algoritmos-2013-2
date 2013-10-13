using System;
using System.Collections.Generic;
using System.Text;

namespace Robustez
{
    class ListaEnlazada<T>
    {
        private static Elemento<T> header = new Elemento<T>(default(T), null, null);
        private static Int32 tamanio = 0;

        public static Int32 Tamanio
        {
            get { return ListaEnlazada < T >.tamanio; }
            set { ListaEnlazada<T>.tamanio = value; }
        }

	    public ListaEnlazada () {

		    header.Siguiente = header.Anterior = header;
	    }
	
	    public bool vacia() {
		    return true;
	    }

	    public T primero() {
            return header.Siguiente.Vertice;
	    }

	    public T ultimo() {
		    return header.Anterior.Vertice;
	    }
	
	    public void agregar(T elemento) {
		    agregarAntes(elemento, header);
	    }
        public Int32 GetTamanio()
        {
            return tamanio;
        }
	
	    private void agregarAntes(T elemento, Elemento<T> siguiente) {
		
		    Elemento<T> nuevo = new Elemento<T>(elemento, siguiente, siguiente.Anterior);
		    nuevo.Anterior.Siguiente = nuevo;
            nuevo.Siguiente.Anterior = nuevo;
		    tamanio++;
	    }

        public IteradorListaEnlazada iterador()
        {
		    return new IteradorListaEnlazada();
	    }
	
	    public class IteradorListaEnlazada  {

		    private int siguiente;
		    private Elemento<T> siguienteElemento;
		
		    public IteradorListaEnlazada () {
		
			    siguiente = 0;
			    siguienteElemento = header;
		    }
		

		    public bool hasNext() {
			    return siguiente != tamanio;
		    }

		    public T next() {
			
			    T aRetornar = default(T);
			
			    if (siguiente < Tamanio) {
				
				    aRetornar = siguienteElemento.Siguiente.Vertice;
				    siguienteElemento = siguienteElemento.Siguiente;
				    siguiente++;
			    }
			
			    return aRetornar;
		    }


		    public void remove() {
			
		    }

            /*
            #region IEnumerable<T> Members

            public IEnumerator<T> GetEnumerator()
            {
                throw new Exception("The method or operation is not implemented.");
            }

            #endregion

            #region IEnumerable Members

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                throw new Exception("The method or operation is not implemented.");
            }

            #endregion
             */
        }
	
	    private class Elemento<T> {

            private T vertice;
            private Elemento<T> anterior;
            private Elemento<T> siguiente;

            public T Vertice
            {
                get { return vertice; }
                set { vertice = value; }
            }
            
            public Elemento<T> Anterior
            {
                get { return anterior; }
                set { anterior = value; }
            }
            

            public Elemento<T> Siguiente
            {
                get { return siguiente; }
                set { siguiente = value; }
            }
		
		    public Elemento(T elemento, Elemento<T> siguiente, Elemento<T> anterior) {
			
			    this.vertice = elemento;
			    this.anterior = anterior;
			    this.siguiente = siguiente;
		    }

	    }

	    public bool contiene(T datoBuscado) {
		
		    bool encontrado = false;
            IteradorListaEnlazada iterador = this.iterador();
		
		    while (!encontrado && iterador.hasNext()) {
			
			    T item = iterador.next();
			
			    if (item.Equals(datoBuscado)) {
				    encontrado = true;
			    }
		    }
		
		    return encontrado;
	    }

       
    }
}
