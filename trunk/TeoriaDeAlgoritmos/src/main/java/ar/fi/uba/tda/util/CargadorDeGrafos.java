package ar.fi.uba.tda.util;

import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.Vertice;

public class CargadorDeGrafos {

	private final Grafo grafo;

	public CargadorDeGrafos(Grafo grafo) {
		this.grafo = grafo;
		
	}

	public void agregarArista(String verticeInicial, String verticeFinal) {
		
		Vertice inicio = new Vertice(verticeInicial);
		
		Vertice fin = new Vertice(verticeFinal);
		
		grafo.agregarArco(inicio, fin);
		
	}

}
