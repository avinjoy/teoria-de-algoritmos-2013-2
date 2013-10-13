package ar.fi.uba.tda.colecciones;

public class Arista {

	private Vertice<?> origen;
	private Vertice<?> destino;
	
	
	public Arista(Vertice<?> verticeCicloUno, Vertice<?> verticeCicloDos) {
		this.origen = verticeCicloUno;
		this.destino = verticeCicloDos;
	}

	public Vertice<?> getOrigen() {
		return origen;
	}

	public Vertice<?> getDestino() {
		return destino;
	}

}
