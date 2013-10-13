using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TeoriaDelAlgoritmosCSHARP
{
    public class ListaEnlazada<T>
    {
        private static Elemento<T> header = new Elemento<T>(default(T), null, null);
        private static Int32 tamanio = 0;

        public static Int32 Tamanio
        {
            get { return ListaEnlazada < T >.tamanio; }
            set { ListaEnlazada<T>.tamanio = value; }
        }

	    public ListaEnlazada () {
            tamanio = 0;
            header.Siguiente = header;
            header.Anterior = header;
	    }
	
	    public bool Vacia() {
		    return tamanio == 0;
	    }

	    public T Primero() {
            return header.Siguiente.Vertice;
	    }

	    public T Ultimo() {
		    return header.Anterior.Vertice;
	    }
	
	    public void agregar(T elemento) {
		    AgregarAntes(elemento, header);
	    }
        public Int32 GetTamanio()
        {
            return tamanio;
        }
	
	    private void AgregarAntes(T elemento, Elemento<T> siguiente) {
		  
            Elemento<T> nuevo = new Elemento<T>(elemento, siguiente, siguiente.Anterior);
		    nuevo.Anterior.Siguiente = nuevo;
            nuevo.Siguiente.Anterior = nuevo;
            
		    tamanio++;
	    }
	
        public IteradorListaEnlazada Iterador()
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
		

		    public bool HasNext() {
			    return siguiente != Tamanio;
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


		    public void Remove() {
			
		    }


         
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

	    public bool Contiene(T datoBuscado) {
		
		    bool encontrado = false;
            IteradorListaEnlazada iterador = this.Iterador();
		
		    while (!encontrado && iterador.HasNext()) {
			
			    T item = iterador.next();
			
			    if (item.Equals(datoBuscado)) {
				    encontrado = true;
			    }
		    }
		
		    return encontrado;
	    }

       
    }
}
