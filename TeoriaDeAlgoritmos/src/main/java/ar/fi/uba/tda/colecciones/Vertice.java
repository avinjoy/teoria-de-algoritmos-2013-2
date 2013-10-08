package ar.fi.uba.tda.colecciones;

public class Vertice {

	private Object contenido; //TODO:Debemos ver que tipo de contenido ubicar acá
	private boolean visitado;
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

	public boolean isVisitado() {
		return visitado;
	}

	public void setVisitado(boolean vistado) {
		this.visitado = vistado;
	}
	
	public Integer getGradoVertice(){
		return this.adyacentes.tamanio();
	}
	
	
}
