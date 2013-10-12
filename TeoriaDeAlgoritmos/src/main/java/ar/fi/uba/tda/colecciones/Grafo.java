package ar.fi.uba.tda.colecciones;

import java.util.Iterator;

public class Grafo<T> {

	private ListaEnlazada<Vertice<T>> vertices;
	private ListaEnlazada<Vertice<T>> recorridoDFS;
	private ListaEnlazada<Vertice<T>> recorridoBFS;
	private ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclosGrafo;

	public Grafo(ListaEnlazada<Vertice<T>> vertices) {
		super();
		this.vertices = vertices;
	}

	public Grafo() {
		this.vertices = new ListaEnlazada<Vertice<T>>();
		this.recorridoDFS = new ListaEnlazada<Vertice<T>>();
		this.recorridoBFS = new ListaEnlazada<Vertice<T>>();
		this.ciclosGrafo = new ListaEnlazada<ListaEnlazada<Vertice<T>>>();
	}

	public ListaEnlazada<Vertice<T>> getVertices() {
		return vertices;
	}

	public void setVertices(ListaEnlazada<Vertice<T>> vertices) {
		this.vertices = vertices;
	}

	public Integer getCantidadDeNodosGrafo() {
		return this.vertices.tamanio();
	}

	/**
	 * Recorrido en profundidad
	 */
	public void recorridoDFS(ListaEnlazada<Vertice<T>> vertices) {

		Iterator<Vertice<T>> iterador = vertices.iterador();

		while (iterador.hasNext()) {
			Vertice<T> vert = iterador.next();
			if (!vert.isVisitado()) {
				vert.setVisitado(true);
				//System.out.println(vert);
				getRecorridoDFS().agregar(vert);
				recorridoDFS(vert.getAdyacentes());
			}
		}
		return;
	}

	/**
	 * Recorrido en ancho
	 */
	public void recorridoBFS(ListaEnlazada<Vertice<T>> vertices) {

		Iterator<Vertice<T>> iterador = vertices.iterador();

		while (iterador.hasNext()) {
			Vertice<T> vert = iterador.next();

			if (!vert.isVisitado()) {
				vert.setVisitado(true);
				//System.out.println(vert);
				getRecorridoBFS().agregar(vert);
			}

			Iterator<Vertice<T>> iteVertice = vert.getAdyacentes().iterador();
			while (iteVertice.hasNext()) {
				Vertice<T> vertAdy = iteVertice.next();
				if (!vertAdy.isVisitado()) {
					vertAdy.setVisitado(true);
					//System.out.println(vertAdy);
					getRecorridoBFS().agregar(vertAdy);
				}
			}

		}

		return;
	}

	public ListaEnlazada<Vertice<T>> getRecorridoDFS() {
		return recorridoDFS;
	}

	public void setRecorridoDFS(ListaEnlazada<Vertice<T>> recorridoDFS) {
		this.recorridoDFS = recorridoDFS;
	}

	public ListaEnlazada<Vertice<T>> getRecorridoBFS() {
		return recorridoBFS;
	}

	public void setRecorridoBFS(ListaEnlazada<Vertice<T>> recorridoBFS) {
		this.recorridoBFS = recorridoBFS;
	}

	public ListaEnlazada<ListaEnlazada<Vertice<T>>> getCiclosGrafo() {
		return ciclosGrafo;
	}

	public void setCiclosGrafo(ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclosGrafo) {
		this.ciclosGrafo = ciclosGrafo;
	}

	/**
	 * Agrega un v�rtice al grafo
	 * 
	 * @param vert
	 */
	public void agregarVertice(Vertice<T> vert) {
		if (vert != null && vert.getContenido() != null
				&& !this.contieneVertice(vert)) {
			this.vertices.agregar(vert);
		}

	}

	/**
	 * Crea un arco entre 2 v�rtices (no es grafo dirigido)
	 * 
	 * @param inicio
	 * @param fin
	 */
	public void agregarArco(Vertice<T> inicio, Vertice<T> fin) {
		//TODO:Validaciones!!!
		Vertice<T> inicioEnGrafo = this.obtener(inicio);
		
		if (inicioEnGrafo != null) {
			inicio = inicioEnGrafo;
		}
		
		Vertice<T> finEnGrafo = this.obtener(fin);
		
		if (finEnGrafo != null) {
			fin = finEnGrafo;
		}
		
		inicio.getAdyacentes().agregar(fin);
		fin.getAdyacentes().agregar(inicio);

		this.agregarVertice(inicio);
		this.agregarVertice(fin);

	}

	private Vertice<T> obtener(Vertice<T> buscado) {
		
		return this.vertices.obtener(buscado);
	}

	public boolean contieneVertice(Vertice<T> verticeBuscado) {

		return vertices.contiene(verticeBuscado);
	}

}
