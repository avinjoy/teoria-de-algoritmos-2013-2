package ar.fi.uba.tdatp2;

import java.util.Arrays;
import java.util.Stack;

import ar.fi.uba.tdatp2.CostoOperacion.TipoOperacion;

import static ar.fi.uba.tdatp2.CostoOperacion.TipoOperacion.*;


public class DistanciaEdicion {

	private CostoOperacion[][] distance;
	private String palabraInicio;
	private String palabraFin;
	private Stack<CostoOperacion> resultado;
	
	private int costoFinal;
	
	private String palabraResultante;

	public DistanciaEdicion(String palabraInicio, String palabraFin) {
		this.distance = new CostoOperacion[palabraInicio.length() + 1][palabraFin.length() + 1];
		this.palabraInicio = palabraInicio;
		this.palabraFin = palabraFin;
		this.resultado = new Stack<CostoOperacion>();
	}
	
	/**
	 * Implementación de http://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance
	 * 
	 * Construye una matriz de mxn, siendo m la cantidad de letras de la palabra de inicio
	 * y n la cantidad de letras de la palabra a la que se quiere llegar.
	 * 
	 * Luego itera por cada celda de la matriz decidiendo cual es la operación óptima, esta 
	 * decisión tiene costo O(1), por lo que el costo de esta parte es O(mxn).
	 * 
	 * Por último debe aplicar las operaciones que detectó como óptimas, esto será tan costos
	 * como la palabra resultante O(n).
	 *
	 * El costo total es O(mxn + n) 
	 * 
	 */
	public int calcularDistanciaEdicion() {

		CostoOperacion casoBase;
		
		int i, j;
		
		cargarPrimeraColumna();
		
		cargarPrimeraFila();
		
		for(i = 1; i < distance.length; i++) {
			for (j = 1; j < distance[i].length; j++) {
				
				casoBase = casoBase(i, j);
				
				CostoOperacion eraseCost = new CostoOperacion(i-1, j, distance[i-1][j].getCosto() + BORRAR.getCosto(), BORRAR);
				CostoOperacion insertCost=new CostoOperacion(i, j-1, distance[i][j-1].getCosto() + INSERTAR.getCosto(), INSERTAR);
								
				CostoOperacion menorCosto = minimoCosto(insertCost, eraseCost, casoBase);
										
				distance[i][j]=menorCosto;
							
				if(sePuedeIntercambiar(i, j)) {

					intercambiar(i, j, menorCosto);
					
				}
			}
		}

		costoFinal = distance[palabraInicio.length()][palabraFin.length()].getCosto();
		
		recolectarOperaciones();

		aplicarOperaciones();
		
		return costoFinal;
		
	}
	
	private void cargarPrimeraColumna() {
		for (int k = 0; k < distance.length; k++) {
			distance[k][0] = new CostoOperacion((k-1 > 0)? k-1:0,0,(k-1 >= 0)? k*BORRAR.getCosto():0,BORRAR);
		}
	}
	
	private void cargarPrimeraFila() {
		for (int k = 0; k < distance[0].length; k++) {
			distance[0][k] = new CostoOperacion(0,(k-1 > 0)? k-1:0,(k-1 >= 0)? k*INSERTAR.getCosto():0,INSERTAR);
		}
	}

	private CostoOperacion casoBase(int i, int j) {
		
		CostoOperacion casoBase;
		
		if (palabraInicio.charAt(i - 1) == palabraFin.charAt(j - 1)) {
			casoBase = new CostoOperacion(i-1,j-1,distance[i-1][j-1].getCosto()+COPIAR.getCosto(),COPIAR);
		} else {
			casoBase = new CostoOperacion(i-1,j-1,distance[i-1][j-1].getCosto()+REEMPLAZAR.getCosto(),REEMPLAZAR);
		}
		return casoBase;
	}

	private CostoOperacion minimoCosto(CostoOperacion a, CostoOperacion b, CostoOperacion c) {
		
		int costoA= a.getCosto();
		int costoB= b.getCosto();
		int costoC= c.getCosto();
		
		if (costoA <= costoB && costoA <= costoC)
			return a;
		if (costoB <= costoA && costoB <= costoC)
			return b;
		return c;
	}

	private boolean sePuedeIntercambiar(int i, int j) {
		return i > 1 && j > 1 && 
		palabraInicio.charAt(i - 1) == palabraFin.charAt(j - 2) && 
		palabraInicio.charAt(i - 2) == palabraFin.charAt(j - 1);
	}
	
	private void intercambiar(int i, int j, CostoOperacion menorCosto) {
		CostoOperacion swapCost=new CostoOperacion(i-2,j-2,distance[i-2][j-2].getCosto() + INTERCAMBIAR.getCosto(),INTERCAMBIAR);
		distance[i][j] = (distance[i][j].getCosto() >  swapCost.getCosto()) ? swapCost : menorCosto;
	}

	/**
	 * Guardo el resultado de las operaciones en una pila antes de devolver el costo, recorridendo la matriz. 
	 */
	private void recolectarOperaciones() {
		
		int col = palabraFin.length();
		int fila = obtenerFila(col);
		
		do {
			CostoOperacion cOp= distance[fila][col];
			resultado.push(cOp);
			fila=cOp.getFilaAnterior();
			col=cOp.getColAnterior();
		}
		while (fila > 0 || col > 0);
	}

	private int obtenerFila(int col) {
		
		int fila = palabraInicio.length();
		int costoCol = distance[fila][col].getCosto();
		
		for (int i = fila - 1; i >= 0; i--) {
			
			if (costoCol > distance[i][col].getCosto() + TERMINAR.getCosto()) {
				costoCol = distance[i][col].getCosto() + TERMINAR.getCosto();
				fila = i;
			}
		}
		
		return fila;
	}
	
	private void aplicarOperaciones() {
		
		int i = 0;
		int j = 0;
		
		StringBuilder palabraResultante = inicializarResultado();
		
		boolean terminado = false;
		
		this.costoFinal = 0;
		
		while (!resultado.isEmpty() && !terminado) {
			
			CostoOperacion operacion = resultado.pop();
			TipoOperacion comando = operacion.getOp();
			comando.ejecutar(palabraInicio, palabraFin, palabraResultante, i, j);
			i = comando.nuevoI(i);
			j = comando.nuevoJ(j);
			
			costoFinal = costoFinal + comando.getCosto();
			terminado = verificarSiTermina(i, j, palabraResultante);
			
		} 
		
		this.palabraResultante = palabraResultante.toString().trim();
	}

	private StringBuilder inicializarResultado() {
		
		char[] chars;
		
		if (palabraFin.length() >= palabraInicio.length()) {
			chars = new char[palabraFin.length()];
		} else {
			chars = new char[palabraInicio.length()];
		}
		
		Arrays.fill(chars, ' ');
		
		return new StringBuilder(new String(chars));
	}

	private boolean verificarSiTermina(int i, int j, StringBuilder palabraResultante) {
		
		boolean terminado = false;
		
		if (palabraResultante.toString().trim().equals(palabraFin)) {
			
			int diferencia = (palabraInicio.length()) - i;
			
			if (diferencia > 0) {
				
				int costoBorrar = diferencia * BORRAR.getCosto();
				
				if (TERMINAR.getCosto() <= costoBorrar) {
					
					TERMINAR.ejecutar(palabraInicio, palabraFin, palabraResultante, i, j);

					costoFinal = costoFinal + TERMINAR.getCosto();
					
					terminado = true;
				}
			}
		}
		
		return terminado;
	}
	
	public int getCostoFinal() {
		return costoFinal;
	}

	public String getPalabraResultante() {
		return palabraResultante;
	}

}
