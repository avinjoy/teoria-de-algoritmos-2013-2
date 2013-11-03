package ar.fi.uba.tda.colecciones;

import java.util.Iterator;
import java.util.Vector;

/**
 * @author santiago
 *
 * @param <T>
 */
public class Grafo<T> {

	private ListaEnlazada<Vertice<T>> vertices;
	private ListaEnlazada<Vertice<T>> recorridoDFS;
	private ListaEnlazada<Vertice<T>> recorridoBFS;
	private ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclosGrafo;
	ListaEnlazada<Vertice<T>> subset = new ListaEnlazada<Vertice<T>>();
	private Vector<Vertice<T>> visitados;
	private Long index;

	/**
	 * Inicializa el grafo y las estructuras de datos auxiliares por el usadas.
	 * 
	 * El orden de esta operación es O(1).
	 */
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
	 * Agrega un vértice al grafo solo si no se encuentra previamente agregado.
	 * 
	 * Tanto las operaciones de agregar como de verificar si un elemento está contenido o no
	 * en la lista son constantes por lo que el costo de esta operación es O(1).
	 * 
	 * @see ListaEnlazada#contiene(Object)
	 * @see ListaEnlazada#agregar(Object)
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
	 * Crea un arco entre 2 vértices (no es grafo dirigido)
	 * Si los vértices no pertenecen al grafo los agrega.
	 * 
	 * Las operaciones para obtener y agregar un vértice son O(1), este método
	 * solo hace uso de esas operaciones por lo que el orden de este método es O(1).
	 * 
	 * @param inicio
	 * @param fin
	 */
	public void agregarArco(Vertice<T> inicio, Vertice<T> fin) {
		
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

	/**
	 * Recupera una referencia a un vértice dado.
	 * 
	 * @see ListaEnlazada#obtener(Object)
	 * 
	 */
	private Vertice<T> obtener(Vertice<T> buscado) {

		return this.vertices.obtener(buscado);
	}

	/**
	 * Verifica si un vértice está o no en el grafo.
	 * 
	 * @see ListaEnlazada#contiene(Object)
	 */
	public boolean contieneVertice(Vertice<T> verticeBuscado) {

		return vertices.contiene(verticeBuscado);
	}

	/**
	 * Recorrido en profundidad del grafo. 
	 * Su costo es O(|V|) pues recorre todos los vértices.
	 */
	public void recorridoDFS(ListaEnlazada<Vertice<T>> vertices) {

		Iterator<Vertice<T>> iterador = vertices.iterador();

		while (iterador.hasNext()) {
			Vertice<T> vert = iterador.next();
			if (!vert.isVisitado()) {
				vert.setVisitado(true);
				getRecorridoDFS().agregar(vert);
				recorridoDFS(vert.getAdyacentes());
			}
		}
		return;
	}

	/**
	 * Recorrido en ancho
	 * Su costo es O(|V|) pues recorre todos los vértices.
	 * 
	 */
	public void recorridoBFS(ListaEnlazada<Vertice<T>> vertices) {

		Iterator<Vertice<T>> iterador = vertices.iterador();

		while (iterador.hasNext()) {
			Vertice<T> vert = iterador.next();

			if (!vert.isVisitado()) {
				vert.setVisitado(true);
				getRecorridoBFS().agregar(vert);
			}

			Iterator<Vertice<T>> iteVertice = vert.getAdyacentes().iterador();
			while (iteVertice.hasNext()) {
				Vertice<T> vertAdy = iteVertice.next();
				if (!vertAdy.isVisitado()) {
					vertAdy.setVisitado(true);
					getRecorridoBFS().agregar(vertAdy);
				}
			}

		}

		return;
	}

	public void encontrarCiclos(ListaEnlazada<Vertice<T>> vertices){
		encontrarCiclosWrapper(vertices);
		cargarCiclos();
	}
	
	
	/**
	 * Encuentra los ciclos en el grafo.
	 * Utilizado para determinar sobre que vertices crear los arcos para
	 * la robustez.
	 * 
	 * El método para encontrar ciclos en los grafos se basa en el algoritmo de
		Tarjan (aunque no es el mismo) (http://en.wikipedia.org/wiki/Tarjan
		%27s_strongly_connected_components_algorithm)
		La idea básica de este algoritmo es la siguiente: Se parte de algún nodo del grafo y
		se realiza un recorrido DFS, marcándolo con un índice y para mantener una
		identificación de la rama desde donde ha venido se utiliza un indicador llamado
		lowLink. Como cualquier recorrido DFS, cada nodo se visita sólo una vez ,
		descartando la revisita del nodo ya explorado. Cada vez que se encuentre un ciclo
		cerrado se guardará en una vector los nodos visitados, cada uno de ellos tendrá su
		índice de visita y un lowLink que indica desde que rama se llamó.

		En esta implementación el algoritmo se llama, como máximo 2 veces para cada
		vértice por lo que el orden sería O (2|V|), pero al final nos encontramos con la parte
		que carga los diferentes ciclos encontrados la cual itera utilizando dos ciclos por
		todos los vétices, siendo su peor caso O (|V|x|V|).
	 */
	private void encontrarCiclosWrapper(ListaEnlazada<Vertice<T>> vertices) {

		Iterator<Vertice<T>> iterador = vertices.iterador();

		while (iterador.hasNext()) {
			Vertice<T> vert = iterador.next();

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
					encontrarCiclosWrapper(vert.getAdyacentes());
					vert.setLowLink(Math.min(vert.getLowLink(),
							vertAdyacente.getLowLink()));
				} else if (visitados.contains(vertAdyacente)) {
					vert.setLowLink(Math.min(vert.getLowLink(),
							vertAdyacente.getIndex()));
				}
			}
		}
		}
		return;
	}

	private void cargarCiclos(){
				Vertice<T> verticeAux=visitados.get(0);
				for (Vertice<T> ver : visitados) {
					if (ver.getLowLink() == verticeAux.getIndex()
							|| ver.getIndex() == verticeAux.getIndex()) {
						subset.agregar(ver);
					} else {
						verticeAux=ver;
						if (subset.tamanio() > 2)
							ciclosGrafo.agregar(subset);
						subset=new ListaEnlazada<Vertice<T>>();
						subset.agregar(ver);
					}
				}
				if (subset.tamanio() > 2)
					ciclosGrafo.agregar(subset);

			}
}

