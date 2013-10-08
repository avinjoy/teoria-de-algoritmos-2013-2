package ar.fi.uba.tda.colecciones;

public class Grafo {
	
	private ListaEnlazada<Vertice> vertices;
	
	
	public Grafo(ListaEnlazada<Vertice> vertices) {
		super();
		this.vertices = vertices;
	}
	
	public Grafo() {
		this.vertices = new ListaEnlazada<Vertice>();
	}

	public ListaEnlazada<Vertice> getVertices() {
		return vertices;
	}

	public void setVertices(ListaEnlazada<Vertice> vertices) {
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
	 * Agrega un vértice al grafo
	 * @param vert
	 */
	public void agregarVertice(Vertice vert){
		if (vert != null && vert.getContenido() != null){
			this.vertices.agregar(vert);
		}
		
	}
	
	/**
	 * Crea un arco entre 2 vértices (no es grafo dirigido)
	 * @param inicio
	 * @param fin
	 */
	public void agregarArco(Vertice inicio, Vertice fin){
		//TODO:Validaciones!!!	
		inicio.getAdyacentes().agregar(fin);
		fin.getAdyacentes().agregar(inicio);
		this.agregarVertice(inicio);
		this.agregarVertice(fin);
		
	}
	
	

}
