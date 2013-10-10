package ar.fi.uba.tda.colecciones;

public class Vertice {

	private Object contenido; //TODO:Debemos ver que tipo de contenido ubicar ac�
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
		Vertice other = (Vertice) obj;
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
