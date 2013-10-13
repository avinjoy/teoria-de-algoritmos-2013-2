package ar.fi.uba.tda.colecciones;

import java.util.Iterator;

public class ListaEnlazada<T> {
	
	private Elemento header = new Elemento(null, null, null);
	private Integer tamanio = 0;

	public ListaEnlazada () {
		
		header.siguiente = header.anterior = header;
	}
	
	public Boolean vacia() {
		return tamanio == 0;
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
	
	private void agregarAntes(T elemento, Elemento siguiente) {
		
		Elemento nuevo = new Elemento(elemento, siguiente, siguiente.anterior);
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
		private Elemento siguienteElemento;
		
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
	
	private class Elemento {
		
		T elemento;
		Elemento anterior;
		Elemento siguiente;
		
		public Elemento(T elemento, Elemento siguiente, Elemento anterior) {
			
			this.elemento = elemento;
			this.anterior = anterior;
			this.siguiente = siguiente;
		}

	}

	public boolean contiene(T datoBuscado) {
		
		return obtener(datoBuscado) != null;
	}

	public T obtener(T buscado) {
		
		T encontrado = null;
		Iterator<T> iterador = this.iterador();
		
		while (encontrado == null && iterador.hasNext()) {
			
			T item = iterador.next();
			
			if (item.equals(buscado)) {
				encontrado = item;
			}
		}
		
		return encontrado;
	}

}
