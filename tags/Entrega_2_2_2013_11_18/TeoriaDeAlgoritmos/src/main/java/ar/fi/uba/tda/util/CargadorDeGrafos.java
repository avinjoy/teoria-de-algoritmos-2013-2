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

	/**
	 * Método encargado de construir un grafo en base a la información obtenida de un archivo dado.
	 * 
	 * Este método recorre todas las lineas del archivo (vértices) y para cada una de ellas recorre
	 * la lista de vértices adyacentes (arcos) por lo que el costo, en tiempo, de cargar un grafo es O(|V| + |A|)
	 * @param reader
	 * @throws IOException
	 */
	public void cargar(BufferedReader reader) throws IOException {
		
		String linea = reader.readLine();
		
		while(linea != null) {
			
			String[] vertices = linea.split(":");
			
			String vertice = vertices[0].trim();
			
			if (vertices.length > 1) {
				
				String[] adyacentes = vertices[1].split(",");
				
				for (int i = 0; i < adyacentes.length; i++) {
					
					agregarArista(vertice, adyacentes[i].trim());
				}
				
			} else {
				
				grafo.agregarVertice(new Vertice<String>(vertice));
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
