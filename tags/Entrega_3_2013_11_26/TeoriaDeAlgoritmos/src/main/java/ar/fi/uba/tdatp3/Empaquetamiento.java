package ar.fi.uba.tdatp3;

public class Empaquetamiento {

	private static Empaquetamiento instancia;
	
	public static void main(String[] args) {

		System.out.println("Teoría de algoritmos - TP 3");
		System.out.println("Autores:");
		System.out.println("Alejo Vinjoy - 83.989");
		System.out.println("Santiago Nicolas Risaro Sesar - 84.623");
		
		Empaquetamiento instancia = getInstancia();
		
		String tipoDeSolucion = args[0];
		String tipoDeFuente = args[1];
		
		int cantidadDeEjecuciones = calcularCantidadDeEjecuciones(args);
		
		instancia.ejecutar(SelectorDeSolucion.obtenerSelector(tipoDeSolucion), SelectorDeFuente.obtenerFuente(tipoDeFuente), cantidadDeEjecuciones);
		
	}

	private static int calcularCantidadDeEjecuciones(String[] args) {
		int cantidadDeEjecuciones = 1;
		
		if (args.length > 2) {
			String ejecuciones = args[2].substring(2);
			cantidadDeEjecuciones = Integer.valueOf(ejecuciones);
		}
		return cantidadDeEjecuciones;
	}

	private static Empaquetamiento getInstancia() {
		
		if (instancia == null) {
			instancia = new Empaquetamiento();
		}
		
		return instancia;
	}
	
	public static void setInstancia(Empaquetamiento instancia) {
		Empaquetamiento.instancia = instancia;
	}

	public void ejecutar(SelectorDeSolucion selectorDeSolucion, FuenteDeDatos fuente, int cantidadDeEjecuciones) {
		
		Solucion solucion = selectorDeSolucion.obtenerSolucion(fuente);
		
		try {
			solucion.ejecutar(cantidadDeEjecuciones);
		} catch (NumberFormatException nfe) {
			System.err.println("El separador decimal del archivo no es el mismo que el de la configuración del sistema");
		}
		
		System.out.println(selectorDeSolucion.getMensaje() + ": " + solucion.getEnvases());
		System.out.println(solucion.getTiempoPromedio());
	}
}
