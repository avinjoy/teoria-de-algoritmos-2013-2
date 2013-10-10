package ar.fi.uba.tda.colecciones;

public class Grafo<T> {
	
	private ListaEnlazada<Vertice<T>> vertices;
	
	
	public Grafo(ListaEnlazada<Vertice<T>> vertices) {
		super();
		this.vertices = vertices;
	}
	
	public Grafo() {
		this.vertices = new ListaEnlazada<Vertice<T>>();
	}

	public ListaEnlazada<Vertice<T>> getVertices() {
		return vertices;
	}

	public void setVertices(ListaEnlazada<Vertice<T>> vertices) {
		this.vertices = vertices;
	}
	
	public Integer getCantidadDeNodosGrafo(){
		return this.vertices.tamanio();
	}
	
	/**
	 * Recorrido en profundidad
	 */
	public void recorridoDFS(){
		return;
	}
	
	

	/**
	 * Recorrido en ancho
	 */
	public void recorridoBFS(){
		return;
		
	}
	
	/**
	 * Agrega un v�rtice al grafo
	 * @param vert
	 */
	public void agregarVertice(Vertice<T> vert){
		if (vert != null && vert.getContenido() != null && !this.contieneVertice(vert)){
			this.vertices.agregar(vert);
		}
		
	}
	
	/**
	 * Crea un arco entre 2 v�rtices (no es grafo dirigido)
	 * @param inicio
	 * @param fin
	 */
	public void agregarArco(Vertice<T> inicio, Vertice<T> fin){
		//TODO:Validaciones!!!	
		inicio.getAdyacentes().agregar(fin);
		fin.getAdyacentes().agregar(inicio);
		
		this.agregarVertice(inicio);
		this.agregarVertice(fin);
		
	}

	public boolean contieneVertice(Vertice<T> verticeBuscado) {
		
		return vertices.contiene(verticeBuscado);
	}

}
