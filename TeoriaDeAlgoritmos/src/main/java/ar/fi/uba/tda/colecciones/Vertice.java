package ar.fi.uba.tda.colecciones;

public class Vertice<T> {

	private T contenido; //TODO:Debemos ver que tipo de contenido ubicar ac�
	private boolean visitado;
	private ListaEnlazada<Vertice<T>> adyacentes;
		
	public Vertice() {
		super();
	}
	
	public Vertice(T contenido){
		super();
		this.contenido=contenido;
		this.adyacentes=new ListaEnlazada<Vertice<T>>();
	}
	
	public T getContenido() {
		return contenido;
	}
	public void setContenido(T contenido) {
		this.contenido = contenido;
	}
	public ListaEnlazada<Vertice<T>> getAdyacentes() {
		return adyacentes;
	}
	public void setAdyacentes(ListaEnlazada<Vertice<T>> adyacentes) {
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

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result
				+ ((contenido == null) ? 0 : contenido.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj) {
			return true;
		}
		if (obj == null) {
			return false;
		}
		if (!(obj instanceof Vertice)) {
			return false;
		}
		Vertice<T> other = (Vertice<T>) obj;
		if (contenido == null) {
			if (other.contenido != null) {
				return false;
			}
		} else if (!contenido.equals(other.contenido)) {
			return false;
		}
		return true;
	}
	
	
}
