package ar.fi.uba.tdatp2;

import java.util.HashMap;


public class DistanciaEdicion {

	private int[][] distance;
	private String palabraInicio;
	private String palabraFin;
	private char[] resultado;
	private int copyCost;
	private int replaceCost;
	private int insertCost;
	private int switchCost;
	private int endCost;
	private int eraseCost;
	private int i = 0;
	private int j = 0;

	public DistanciaEdicion(String palabraInicio, String palabraFin, HashMap<String, Integer> costos) {
		this.distance = new int[palabraInicio.length()][palabraFin.length()];
		this.palabraInicio = palabraInicio;
		this.palabraFin = palabraFin;
		this.copyCost = costos.get("Copiar");
		this.replaceCost = costos.get("Reemplazar");
		this.insertCost = costos.get("Insertar");
		this.switchCost = costos.get("Intercambiar");
		this.endCost = costos.get("Terminar");
		this.eraseCost = costos.get("Borrar");
		this.resultado = new char[(palabraInicio.length() < palabraFin.length()) ? palabraFin
				.length() : palabraInicio.length()];
	}


	public int[][] getDistance() {
		return distance;
	}

	public void setDistance(int[][] distance) {
		this.distance = distance;
	}

	public String getPalabraInicio() {
		return palabraInicio;
	}

	public void setPalabraInicio(String palabraInicio) {
		this.palabraInicio = palabraInicio;
	}

	public String getPalabraFin() {
		return palabraFin;
	}

	public void setPalabraFin(String palabraFin) {
		this.palabraFin = palabraFin;
	}

	public char[] getResultado() {
		return resultado;
	}

	public String getResultadoAsString() {
		return new String(resultado);

	}

	public void setResultado(char[] resultado) {
		this.resultado = resultado;
	}

	public int calcularDistanciaEdicion() {
		// Casos base (si no viene la palabra inicial o la palabra final)
		if (palabraInicio.length() == 0) {
			resultado = palabraFin.toCharArray();
			return palabraFin.length() * insertCost; // Costo total de inserci�n
														// de cada letra de la
														// palabra final
		}
		if (palabraFin.length() == 0) {
			resultado = "".toCharArray();
			return palabraInicio.length() * eraseCost; // Costo total de
														// borrado de cada
														// letra de la palabra
														// inicial
		}

		// si son distintas hay que ver el min entre reemplazar, borrar y copiar
		// para el primer caracter
		if (palabraInicio.charAt(0) != palabraFin.charAt(0)) {
			distance[0][0] = Math.min(replaceCost, eraseCost + insertCost);
		}

		// Inicializo la columna de la palabra final con todas las minimas
		// distancias posibles
		for (int i = 1; i < palabraInicio.length(); i++) {

			int costoBorrar = distance[i - 1][0] + eraseCost;
			int costoInsertar = (i + 1) * eraseCost + insertCost;
			int costoRestoOp = (i* eraseCost)
					+ (palabraInicio.charAt(i) == palabraFin.charAt(0) ? 0
							: (copyCost <= replaceCost) ? copyCost
									: replaceCost);
			distance[i][0] = min(costoBorrar, costoInsertar, costoRestoOp);
		}

		// Inicializo la fila de la palabra inicial con todas las minimas
		// distancias posibles
		for (int j = 1; j < palabraFin.length(); j++) {
			int costoBorrar = distance[0][j - 1] + insertCost;
			int costoInsertar = (j + 1) * insertCost + eraseCost;
			int costoRestoOp = (j* insertCost)
							+ (palabraInicio.charAt(0) == palabraFin.charAt(j) ? 0
							: (copyCost <= replaceCost) ? copyCost
									: replaceCost);
			distance[0][j] = min(costoBorrar, costoInsertar, costoRestoOp);
		}

		for (int i = 1; i < palabraInicio.length(); i++) {
			for (int j = 1; j < palabraFin.length(); j++) {
				int costoBorrar = distance[i - 1][j] + borrar();
				int costoInsertar = distance[i][j - 1] + insertar();
				int costoRestoOp = distance[i - 1][j - 1];
				costoRestoOp += getOperacionesPosibles(i, j, costoRestoOp);
				distance[i][j] = min(costoBorrar, costoInsertar, costoRestoOp);
			}
			distance[i][j - 1] += terminar();
		}
		return distance[palabraInicio.length() - 1][palabraFin.length() - 1];
	}

	private int getOperacionesPosibles(int i, int j, int costoRestoOp) {
		if (palabraInicio.charAt(i) == palabraFin.charAt(j)) {
			costoRestoOp += (copyCost <= replaceCost) ? copiar() : reemplazar();
		} else {
			if (palabraInicio.charAt(i) != palabraFin.charAt(j)) {
				if (esIntercambiable(i, j)) {
					costoRestoOp += intercambiar();
				} else {
					costoRestoOp += (copyCost <= replaceCost) ? copiar()
							: reemplazar();
				}
			}
		}
		return costoRestoOp;
	}

	private int intercambiar() {
		if (i > palabraInicio.length() || j > palabraFin.length())
			return 0;
		resultado[j] = palabraInicio.charAt(i + 1);
		resultado[j + 1] = palabraInicio.charAt(i);
		System.out.println("Intercambiando "+ resultado[j]+" con "+resultado[j + 1]);
		i += 2;
		j += 2;
		return switchCost;
	}

	private int reemplazar() {
		if (i >= palabraInicio.length() || j >= palabraFin.length())
			return 0;
		resultado[j] = palabraFin.charAt(i);
		System.out.println("Reemplazando "+ palabraFin.charAt(i)+" en el resultado");
		i++;
		j++;
		return replaceCost;
	}

	private int copiar() {
		if (i >= palabraInicio.length() || j >= palabraFin.length())
			return 0;
		resultado[j] = palabraInicio.charAt(i);
		System.out.println("Copiando "+ palabraInicio.charAt(i)+" al resultado");
		i++;
		j++;
		
		return copyCost;
	}

	private int insertar() {
		if (j >= palabraFin.length())
			return 0;
		resultado[j] = palabraFin.charAt(j);
		System.out.println("Insertando al "+palabraFin.charAt(j)+" al resultado ");
		j++;
		return 0;
	}

	private int borrar() {
		if (i >= palabraInicio.length() || j >= palabraFin.length())
			return 0;
		System.out.println("Borrando de la palabra de inicio: "+palabraInicio.charAt(i));
		i++;
		return eraseCost;
	}

	private int terminar() {
		i = palabraInicio.length() + 1;
		return endCost;
	}

	private boolean esIntercambiable(int i, int j) {
		return (i + 1) < palabraInicio.length()
				&& (j + 1) < palabraFin.length()
				&& palabraInicio.charAt(i + 1) == palabraFin.charAt(j)
				&& palabraInicio.charAt(i) == palabraFin.charAt(j + 1);
	}

	private int min(int a, int b, int c) {
		if (a <= b && a <= c)
			return a;
		if (b <= a && b <= c)
			return b;
		return c;
	}

	/**
	 * Implementación de http://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance
	 * @return
	 */
	public int calcularDistanciaEdicion2() {

		int[][] distance = new int[palabraInicio.length() + 1][palabraFin.length() + 1];
		
		int i, j, costo = 0;
		
		for (int k = 0; k < distance.length; k++) {
			distance[k][0] = k;
		}
		
		for (int k = 0; k < distance[0].length; k++) {
			distance[0][k] = k;
		}
		
		for(i = 1; i < distance.length; i++) {
			for (j = 1; j < distance[i].length; j++) {
				
				if (palabraInicio.charAt(i - 1) == palabraFin.charAt(j - 1)) {
					costo = 0;
				} else {
					costo = 1;
				}
				
				distance[i][j] = min(distance[i-1][j] + 1, // Borrar
									 distance[i][j - 1] + 1, // Insertar
									 distance[i - 1][j - 1] + costo); // Copiar
				
				if(i > 1 && j > 1 && 
						palabraInicio.charAt(i - 1) == palabraFin.charAt(j - 2) && 
						palabraInicio.charAt(i - 2) == palabraFin.charAt(j - 1)) {
					
					distance[i][j] = Math.min(distance[i][j],
	            		   					  distance[i-2][j-2] + costo); // Intercambiar
				}
			}
		}
		
		return distance[palabraInicio.length()][palabraFin.length()];
	}

}
