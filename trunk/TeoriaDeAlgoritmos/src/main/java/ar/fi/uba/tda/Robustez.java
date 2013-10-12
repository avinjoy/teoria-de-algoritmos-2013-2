package ar.fi.uba.tda;

public class Robustez {

	public static void main(String[] args) {
		
		if (args.length == 0) {
			
			System.err.println("Se debe ingresar el grado de robustez y el nombre de archivo");
			System.err.println("O solo el grado de robustez");
			System.err.println("i.e.: java -jar Robustez.jar 3");
		}

	}

}
