package ar.fi.uba.tda.colecciones;

import java.util.Iterator;

public class ListaEnlazada<T> {
	
	private Elemento<T> header = new Elemento<T>(null, null, null);
	private Integer tamanio = 0;

	public ListaEnlazada () {
		
		header.siguiente = header.anterior = header;
	}
	
	public Boolean vacia() {
		return true;
	}

	public T primero() {
		return header.siguiente.elemento;
	}

	public T ultimo() {
		return header.anterior.elemento;
	}
	
	public void agregar(T elemento) {
		agregarAntes(elemento, header);
	}
	
	private void agregarAntes(T elemento, Elemento<T> siguiente) {
		
		Elemento<T> nuevo = new Elemento<T>(elemento, siguiente, siguiente.anterior);
		nuevo.anterior.siguiente = nuevo;
		nuevo.siguiente.anterior = nuevo;
		tamanio++;
	}
	
	public Integer tamanio() {
		return tamanio;
	}

	public Iterator<T> iterador() {
		return new IteradorListaEnlazada();
	}
	
	private class IteradorListaEnlazada implements Iterator<T> {

		private int siguiente;
		private Elemento<T> siguienteElemento;
		
		public IteradorListaEnlazada () {
		
			siguiente = 0;
			siguienteElemento = header;
		}
		
		@Override
		public boolean hasNext() {
			return siguiente != tamanio;
		}

		@Override
		public T next() {
			
			T aRetornar = null;
			
			if (siguiente < tamanio) {
				
				aRetornar = siguienteElemento.siguiente.elemento;
				siguienteElemento = siguienteElemento.siguiente;
				siguiente++;
			}
			
			return aRetornar;
		}

		@Override
		public void remove() {
			
		}
		
	}
	
	private class Elemento<T> {
		
		T elemento;
		Elemento<T> anterior;
		Elemento<T> siguiente;
		
		public Elemento(T elemento, Elemento<T> siguiente, Elemento<T> anterior) {
			
			this.elemento = elemento;
			this.anterior = anterior;
			this.siguiente = siguiente;
		}
	}

}
