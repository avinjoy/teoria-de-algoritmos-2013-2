package ar.fi.uba.tda.util;

import java.io.BufferedReader;
import java.io.IOException;

import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.Vertice;

public class CargadorDeGrafos {

	private final Grafo<String> grafo;

	public CargadorDeGrafos(Grafo<String> grafo) {
		this.grafo = grafo;
		
	}

	public void cargar(BufferedReader reader) throws IOException {
		
		String linea = reader.readLine();
		
		while(linea != null) {
			
			String[] vertices = linea.split(":");
			
			String vertice = vertices[0];
			String[] adyacentes = vertices[1].split(",");
			
			for (int i = 0; i < adyacentes.length; i++) {
				
				agregarArista(vertice, adyacentes[i]);
			}
			
			linea = reader.readLine();
		}
	}
	
	public void agregarArista(String verticeInicial, String verticeFinal) {
		
		Vertice<String> inicio = new Vertice<String>(verticeInicial);
		
		Vertice<String> fin = new Vertice<String>(verticeFinal);
		
		grafo.agregarArco(inicio, fin);
		
	}

}
