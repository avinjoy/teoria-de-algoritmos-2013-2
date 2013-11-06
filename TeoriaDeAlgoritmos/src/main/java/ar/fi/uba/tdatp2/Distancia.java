package ar.fi.uba.tdatp2;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

import ar.fi.uba.tdatp2.util.CargadorCostos;

public class Distancia {

	private final DistanciaEdicion distanciaEd;
	
	public Distancia(DistanciaEdicion distancia) {
		this.distanciaEd=distancia;
	}

	public static void main(String[] args) throws IOException {
		
		System.out.println("Teoría de algoritmos - TP 2");
		System.out.println("Autores:");
		System.out.println("Alejo Vinjoy - 83.989");
		System.out.println("Santiago Nicolas Risaro Sesar - 84.623");
		
		if (args.length > 0) {
			
			String palabraInicial= args[0];
			String palabraFinal = args[1];
			BufferedReader archivo = leerArchivo(args);
			
			CargadorCostos cargador = new CargadorCostos();
			cargador.cargar(archivo);
			DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicial,palabraFinal,cargador.getCostos());
			
						
			new Distancia(distanciaEdicion).ejecutar();

		} else {
		
			System.err.println("Se debe ingresar la palabra inicial, la palabra final y el nombre del archivo de costos");
			System.err.println("O solo las palabras inciales y finales");
			System.err.println("i.e.: java -jar Distancia.jar Algoritmo Altruista");
		}
	}

	private static BufferedReader leerArchivo(String[] args) throws FileNotFoundException {
		
		String rutaArchivo = "costos.txt";
		
		if (args.length > 2) {
			rutaArchivo = args[2];
		}

		return new BufferedReader(new FileReader(rutaArchivo));
	}

	public void ejecutar() throws IOException {

		int costo = distanciaEd.calcularDistanciaEdicion();
		
		System.out.println();
		System.out.println("Distancia de Edicion: "+costo);
		
	}

}
