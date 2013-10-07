package ar.fi.uba.tda.colecciones;

public class Vertice {

	private Object contenido; //TODO:Debemos ver que tipo de contenido ubicar acá
	private ListaEnlazada<Vertice> adyacentes;
	
		
	public Vertice() {
		super();
	}
	
	public Vertice(Object contenido){
		super();
		this.contenido=contenido;
		this.adyacentes=new ListaEnlazada<Vertice>();
	}
	
	public Object getContenido() {
		return contenido;
	}
	public void setContenido(Object contenido) {
		this.contenido = contenido;
	}
	public ListaEnlazada<Vertice> getAdyacentes() {
		return adyacentes;
	}
	public void setAdyacentes(ListaEnlazada<Vertice> adyacentes) {
		this.adyacentes = adyacentes;
	}
	
	
}
