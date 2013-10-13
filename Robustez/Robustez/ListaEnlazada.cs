using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TeoriaDelAlgoritmosCSHARP
{
    public class ListaEnlazada<T>
    {
        private static Elemento<T> _header = new Elemento<T>(default(T), null, null);
        private static Int32 _tamanio = 0;

        public static Int32 Tamanio
        {
            get { return ListaEnlazada < T >._tamanio; }
            set { ListaEnlazada<T>._tamanio = value; }
        }

	    public ListaEnlazada () {
            _tamanio = 0;
            _header.Siguiente = _header;
            _header.Anterior = _header;
	    }
	
	    public bool Vacia() {
		    return _tamanio == 0;
	    }

	    public T Primero() {
            return _header.Siguiente.Vertice;
	    }

	    public T Ultimo() {
		    return _header.Anterior.Vertice;
	    }
	
	    public void agregar(T elemento) {
		    AgregarAntes(elemento, _header);
	    }
        public Int32 GetTamanio()
        {
            return _tamanio;
        }
	
	    private void AgregarAntes(T elemento, Elemento<T> siguiente) {
		  
            Elemento<T> nuevo = new Elemento<T>(elemento, siguiente, siguiente.Anterior);
		    nuevo.Anterior.Siguiente = nuevo;
            nuevo.Siguiente.Anterior = nuevo;
            
		    _tamanio++;
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
			    siguienteElemento = _header;
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
