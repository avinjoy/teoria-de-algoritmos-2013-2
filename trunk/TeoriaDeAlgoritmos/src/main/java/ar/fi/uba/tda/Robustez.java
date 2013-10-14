package ar.fi.uba.tda;

import java.io.BufferedReader;
import java.io.IOException;

import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.Vertice;
import ar.fi.uba.tda.util.AumentadorDeRobustez;
import ar.fi.uba.tda.util.CargadorDeGrafos;

public class Robustez {

	private final CargadorDeGrafos cargador;
	private final AumentadorDeRobustez aumentador;
	
	@SuppressWarnings("rawtypes")
	private final Grafo grafo;
	
	public Robustez(Grafo<String> grafo, CargadorDeGrafos cargador, AumentadorDeRobustez aumentador) {
		this.grafo = grafo;
		this.cargador = cargador;
		this.aumentador = aumentador;
	}

	public static void main(String[] args) {
		
		if (args.length == 0) {
			
			System.err.println("Se debe ingresar el grado de robustez y el nombre de archivo");
			System.err.println("O solo el grado de robustez");
			System.err.println("i.e.: java -jar Robustez.jar 3");
		}

	}

	@SuppressWarnings({ "unchecked", "rawtypes" })
	public void ejecutar(int robustezDeseada, BufferedReader archivo) throws IOException {

		cargador.cargar(archivo);
		
		grafo.encontrarCiclos((Vertice) grafo.getVertices().primero());
		aumentador.aumentar(grafo.getCiclosGrafo(), robustezDeseada);
	}

}
