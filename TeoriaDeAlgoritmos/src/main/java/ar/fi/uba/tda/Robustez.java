package ar.fi.uba.tda;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.Iterator;

import ar.fi.uba.tda.colecciones.Arista;
import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.ListaEnlazada;
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

	@SuppressWarnings({ "unchecked", "rawtypes" })
	public static void main(String[] args) throws IOException {
		
		System.out.println("Teoría de algoritmos - TP 1");
		System.out.println("Autores:");
		System.out.println("Alejo Vinjoy - 83.989");
		System.out.println("Santiago Nicolas Risaro Sesar - 84.623");
		
		if (args.length > 0) {
			
			int robustezDeseada = Integer.valueOf(args[0]);
			BufferedReader archivo = leerArchivo(args);
			
			Grafo grafo = new Grafo();
			CargadorDeGrafos cargador = new CargadorDeGrafos(grafo);
			AumentadorDeRobustez aumentador = new AumentadorDeRobustez(grafo);
			
			new Robustez(grafo, cargador, aumentador).ejecutar(robustezDeseada, archivo);

		} else {
		
			System.err.println("Se debe ingresar el grado de robustez y el nombre de archivo");
			System.err.println("O solo el grado de robustez");
			System.err.println("i.e.: java -jar Robustez.jar 3");
		}
	}

	private static BufferedReader leerArchivo(String[] args) throws FileNotFoundException {
		
		String rutaArchivo = "grafo.txt";
		
		if (args.length > 1) {
			rutaArchivo = args[1];
		}

		return new BufferedReader(new FileReader(rutaArchivo));
	}

	@SuppressWarnings({ "unchecked", "rawtypes" })
	public void ejecutar(int robustezDeseada, BufferedReader archivo) throws IOException {

		cargador.cargar(archivo);
		
		grafo.encontrarCiclos((Vertice) grafo.getVertices().primero());
		aumentador.aumentar(grafo.getCiclosGrafo(), robustezDeseada);
		
		ListaEnlazada<Arista> aristas = aumentador.getAristasAgregadas();
		int numeroArista = 0;
		
		Iterator<Arista> itAristas = aristas.iterador();
		
		while (itAristas.hasNext()) {
			
			numeroArista++;
			Arista arista = itAristas.next();
			
			System.out.println("Arista " + numeroArista + ": " + arista);
			
		}
		
		//System.out.println("FIN");
		
	}

}
