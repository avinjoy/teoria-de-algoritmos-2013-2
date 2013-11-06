package ar.fi.uba.tda.colecciones;

import java.util.HashMap;
import java.util.ListIterator;
import java.util.Map;

public class ListaEnlazada<T> {
	
	private Elemento header = new Elemento(null, null, null);
	private Integer tamanio = 0;
	
	private Map<T, T> elementos;

	/**
	 * Construye la lista enlazada. Inicializa los punteros necesarios para su utilización.
	 * Construye a su vez la colección auxiliar utilizada para buscar los elementos.
	 * 
	 * Estas dos operaciones tienen costo O(1) por lo que el costo de inicializar la colección es O(1).
	 */
	public ListaEnlazada () {
		
		header.siguiente = header.anterior = header;
		elementos = new HashMap<T, T>();
	}
	
	/**
	 * Verifica el tamaño de la lista, costo O(1)
	 * 
	 * @return true si la lista está vacía
	 */
	public Boolean vacia() {
		return tamanio == 0;
	}

	/**
	 * Obtiene el primer elemento, dado que guardamos una referencia al primer elemento
	 * el costo de esta operación es O(1).
	 * 
	 * @return primer elemento de la lista.
	 */
	public T primero() {
		return header.siguiente.elemento;
	}

	/**
	 * Obtiene el último elemento, dado que guardamos una referencia al último elemento
	 * el costo de esta operación es O(1).
	 * 
	 * @return último elemento de la lista.
	 */
	public T ultimo() {
		return header.anterior.elemento;
	}
	
	/**
	 * Agrega el elemento al final de la lista, es simplemente una operación entre punteros
	 * por lo que el costo de esta operación es O(1).
	 * 
	 *  Adicionalmente agrega el elemento a la estructrua auxiliar, acorde a la documentación
	 *  de dicha estructura de datos el costo es constante.
	 *  
	 *  Por lo antedicho, el costo de agregar un elemento es O(1).
	 *  
	 * @param elemento a agregar en la lista
	 */
	public void agregar(T elemento) {
		agregarAntes(elemento, header);
		elementos.put(elemento, elemento);
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

	/**
	 * Comprueba si esta colección contiene o no el datoBuscado.
	 * 
	 * El chequeo se hace contra la estructura auxiliar, elementos, esta colección garantiza que 
	 * la operación de get se realiza en tiempo constante, por lo que esta operación es O(1).
	 * 
	 * @param datoBuscado item que se quiere saber si está o no en la lista
	 * @return true si el datoBuscado está en esta colección.
	 */
	public boolean contiene(T datoBuscado) {
		
		return this.elementos.containsKey(datoBuscado);
	}

	/**
	 * Devuelve una referencia al dato buscado.
	 * 
	 * El chequeo se hace contra la estructura auxiliar, elementos, esta colección garantiza que 
	 * la operación de get se realiza en tiempo constante, por lo que esta operación es O(1).
	 * 
	 * @param buscado item del que se requiere una referencia que esté en esta lista.
	 * @return una nueva referencia a buscado, que se encuentra en esta lista, null si el item no está en la colección.
	 */
	public T obtener(T buscado) {
		
		return elementos.get(buscado);
	}
	
	public ListIterator<T> iterador() {
		return new IteradorListaEnlazada();
	}
	
	private class IteradorListaEnlazada implements ListIterator<T> {

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
		public boolean hasPrevious() {
			return siguiente != 0;
		}

		@Override
		public T previous() {
			
			T aRetornar = null;
			
			if (siguiente > 0) {
				
				aRetornar = siguienteElemento.anterior.elemento;
				siguienteElemento = siguienteElemento.anterior;
				siguiente--;
			}
			
			return aRetornar;
		}
		
		@Override
		public void remove() {
			
		}

		@Override
		public int nextIndex() {
			return 0;
		}

		@Override
		public int previousIndex() {
			return 0;
		}

		@Override
		public void set(T e) {
		}

		@Override
		public void add(T e) {
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

}
