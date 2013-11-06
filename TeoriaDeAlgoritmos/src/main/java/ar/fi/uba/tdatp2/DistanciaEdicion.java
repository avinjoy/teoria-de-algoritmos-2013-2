package ar.fi.uba.tdatp2;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Stack;

import ar.fi.uba.tdatp2.CostoOperacion.TipoOperacion;


public class DistanciaEdicion {

	private CostoOperacion[][] distance;
	private String palabraInicio;
	private String palabraFin;
	private Stack<CostoOperacion> resultado;
	private int copyCost;
	private int replaceCost;
	private int insertCost;
	private int switchCost;
	private int endCost;
	private int eraseCost;
	
	private int costoFinal;

	public DistanciaEdicion(String palabraInicio, String palabraFin, HashMap<String, Integer> costos) {
		this.distance = new CostoOperacion[palabraInicio.length() + 1][palabraFin.length() + 1];
		this.palabraInicio = palabraInicio;
		this.palabraFin = palabraFin;
		this.copyCost = costos.get("Copiar");
		this.replaceCost = costos.get("Reemplazar");
		this.insertCost = costos.get("Insertar");
		this.switchCost = costos.get("Intercambiar");
		this.endCost = costos.get("Terminar");
		this.eraseCost = costos.get("Borrar");
		this.resultado = new Stack<CostoOperacion>();
	}
	
	public DistanciaEdicion(String palabraInicio, String palabraFin) {
		this.distance = new CostoOperacion[palabraInicio.length() + 1][palabraFin.length() + 1];
		this.palabraInicio = palabraInicio;
		this.palabraFin = palabraFin;
		this.resultado = new Stack<CostoOperacion>();
	}


	private CostoOperacion min(CostoOperacion a, CostoOperacion b, CostoOperacion c) {
		
		int costoA= a.getCosto();
		int costoB= b.getCosto();
		int costoC= c.getCosto();
		
		if (costoA <= costoB && costoA <= costoC)
			return a;
		if (costoB <= costoA && costoB <= costoC)
			return b;
		return c;
	}

	
	/**
	 * Implementación de http://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance
	 * @return
	 */
	public int calcularDistanciaEdicion() {

		distance = new CostoOperacion[palabraInicio.length() + 1][palabraFin.length() + 1];
		CostoOperacion aux;
		int i, j;
		
		for (int k = 0; k < distance.length; k++) {
			distance[k][0] = new CostoOperacion((k-1 > 0)? k-1:0,0,(k-1 >= 0)? k*eraseCost:0,TipoOperacion.BORRAR);
		}
		
		for (int k = 0; k < distance[0].length; k++) {
			distance[0][k] = new CostoOperacion(0,(k-1 > 0)? k-1:0,(k-1 >= 0)? k*insertCost:0,TipoOperacion.INSERTAR);
		}
		
		for(i = 1; i < distance.length; i++) {
			for (j = 1; j < distance[i].length; j++) {
				
				if (palabraInicio.charAt(i - 1) == palabraFin.charAt(j - 1)) {
					aux = new CostoOperacion(i-1,j-1,distance[i-1][j-1].getCosto()+copyCost,TipoOperacion.COPIAR);
				} else {
//					if (palabraInicio.charAt(i - 1) == ' ' && palabraFin.charAt(j - 1) != ' '){
//						aux = new CostoOperacion(i-1,j-1,distance[i-1][j-1].getCosto()+((-2)*eraseCost),TipoOperacion.BORRAR);
//					}else{
//						if (palabraInicio.charAt(i - 1) != ' ' && palabraFin.charAt(j - 1) == ' '){
//							aux = new CostoOperacion(i-1,j-1,distance[i-1][j-1].getCosto()+((-2)*insertCost),TipoOperacion.INSERTAR);
//						}else {
							aux = new CostoOperacion(i-1,j-1,distance[i-1][j-1].getCosto()+replaceCost,TipoOperacion.REEMPLAZAR);
//						}
//					}
					
					
				}
				
				CostoOperacion eraseCost=new CostoOperacion(i-1,j,distance[i-1][j].getCosto()+this.eraseCost,TipoOperacion.BORRAR);
				CostoOperacion insertCost=new CostoOperacion(i,j-1,distance[i][j-1].getCosto()+this.insertCost,TipoOperacion.INSERTAR);
				
								
				CostoOperacion menorCosto = min(insertCost, eraseCost, aux);
										
				distance[i][j]=menorCosto;
							
				
				if(i > 1 && j > 1 && 
						palabraInicio.charAt(i - 1) == palabraFin.charAt(j - 2) && 
						palabraInicio.charAt(i - 2) == palabraFin.charAt(j - 1)) {
					CostoOperacion swapCost=new CostoOperacion(i-2,j-2,distance[i-2][j-2].getCosto()+this.switchCost,TipoOperacion.INTERCAMBIAR);
					distance[i][j] = (distance[i][j].getCosto() >  swapCost.getCosto())? swapCost:menorCosto;  // Intercambiar
				}
			}
		}

		costoFinal = distance[palabraInicio.length()][palabraFin.length()].getCosto();
		
		//Guardo el resultado de las operaciones en una pila antes de devolver el costo, recorridendo la matriz.
		int fila=palabraInicio.length();
		int col=palabraFin.length();
		
		do {
			CostoOperacion cOp= distance[fila][col];
			resultado.push(cOp);
			fila=cOp.getFilaAnterior();
			col=cOp.getColAnterior();
		}
		while (fila > 0 || col > 0);

		char[] chars;
		
		if (palabraFin.length() >= palabraInicio.length()) {
			chars = new char[palabraFin.length()];
		} else {
			chars = new char[palabraInicio.length()];
		}
		
		Arrays.fill(chars, ' ');
		
		StringBuilder palabraResultante = new StringBuilder(new String(chars));
		
		i = 0;
		j = 0;
		
		boolean terminado = false;
		
		while (!resultado.isEmpty() && !terminado) {
			
			CostoOperacion operacion = resultado.pop();
			TipoOperacion comando = operacion.getOp();
			comando.ejecutar(palabraInicio, palabraFin, palabraResultante, i, j);
			i = comando.nuevoI(i);
			j = comando.nuevoJ(j);
			
			if (palabraResultante.toString().trim().equals(palabraFin)) {
				
				int diferencia = palabraInicio.length() - palabraResultante.toString().trim().length();
				
				if (diferencia > 0) {
					
					int costoBorrar = diferencia * eraseCost;
					
					if (endCost <= costoBorrar) {
						TipoOperacion.TERMINAR.ejecutar(palabraInicio, palabraFin, palabraResultante, i, j);
		
						costoFinal -= costoBorrar;
						costoFinal += eraseCost;
						
						terminado = true;
					}
				}
			}
		}
		
		return costoFinal;
		
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

	public Stack<CostoOperacion> getResultado() {
		return resultado;
	}

	public void setResultado(Stack<CostoOperacion> resultado) {
		this.resultado = resultado;
	}

	public void setCostoFinal(int costoFinal) {
		this.costoFinal = costoFinal;
	}

	public int getCostoFinal() {
		return costoFinal;
	}

	
	

}
