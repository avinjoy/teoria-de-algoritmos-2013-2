package ar.fi.uba.tda.colecciones;

import java.util.Iterator;
import java.util.Vector;

public class Grafo<T> {

	private ListaEnlazada<Vertice<T>> vertices;
	private ListaEnlazada<Vertice<T>> recorridoDFS;
	private ListaEnlazada<Vertice<T>> recorridoBFS;
	private ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclosGrafo;
	ListaEnlazada<Vertice<T>> subset = new ListaEnlazada<Vertice<T>>();
	private Vector<Vertice<T>> visitados;
	private Long index;

	public Grafo(ListaEnlazada<Vertice<T>> vertices) {
		super();
		this.vertices = vertices;
	}

	public Grafo() {
		this.vertices = new ListaEnlazada<Vertice<T>>();
		this.recorridoDFS = new ListaEnlazada<Vertice<T>>();
		this.recorridoBFS = new ListaEnlazada<Vertice<T>>();
		this.ciclosGrafo = new ListaEnlazada<ListaEnlazada<Vertice<T>>>();
		this.visitados = new Vector<Vertice<T>>();
		this.index = 0L;
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

	public void setCiclosGrafo(
			ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclosGrafo) {
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
		// TODO:Validaciones!!!
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

	/**
	 * Recorrido en profundidad
	 */
	public void recorridoDFS(ListaEnlazada<Vertice<T>> vertices) {

		Iterator<Vertice<T>> iterador = vertices.iterador();

		while (iterador.hasNext()) {
			Vertice<T> vert = iterador.next();
			if (!vert.isVisitado()) {
				vert.setVisitado(true);
				// System.out.println(vert);
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
				// System.out.println(vert);
				getRecorridoBFS().agregar(vert);
			}

			Iterator<Vertice<T>> iteVertice = vert.getAdyacentes().iterador();
			while (iteVertice.hasNext()) {
				Vertice<T> vertAdy = iteVertice.next();
				if (!vertAdy.isVisitado()) {
					vertAdy.setVisitado(true);
					// System.out.println(vertAdy);
					getRecorridoBFS().agregar(vertAdy);
				}
			}

		}

		return;
	}

	// Todavia no está terminado porque no calcula bien.
	// Hay que revisar.
	public void encontrarCiclos(Vertice<T> vert) {

		if (!vert.isVisitado()) {
			vert.setVisitado(true);
			vert.setIndex(index);
			vert.setLowLink(index);
			index++;
			visitados.add(vert);
			// System.out.println(vert);

			Iterator<Vertice<T>> iterAdyacente = vert.getAdyacentes()
					.iterador();

			while (iterAdyacente.hasNext()) {
				Vertice<T> vertAdyacente = iterAdyacente.next();

				if (!vertAdyacente.isVisitado()) {
					encontrarCiclos(vertAdyacente);
					vert.setLowLink(Math.min(vert.getLowLink(),
							vertAdyacente.getLowLink()));
				} else if (visitados.contains(vertAdyacente)) {
					vert.setLowLink(Math.min(vert.getLowLink(),
							vertAdyacente.getIndex()));
				}
			}
		}

		if (vert.getLowLink() == vert.getIndex()) { // Es el primero volviendo de la recursion
			int count =0;
			Vertice <T> verticeAux=vert;
			while (count < visitados.size()) {
				for (Vertice<T> ver : visitados) {
					if (ver.getLowLink() == verticeAux.getIndex()
							|| ver.getIndex() == verticeAux.getIndex()) {
						subset.agregar(ver);
					} else {
						verticeAux = ver;
						ciclosGrafo.agregar(subset);
						subset=new ListaEnlazada<Vertice<T>>();
						subset.agregar(ver);
					}
					count++;
				}
				ciclosGrafo.agregar(subset);

			}
			return;
		}
	}

}
