package ar.fi.uba.tdatp2.util;

import java.io.BufferedReader;
import java.io.IOException;

import ar.fi.uba.tdatp2.CostoOperacion.TipoOperacion;

public class CargadorCostos {

	/**
	 * Lee el archivo linea a linea y guarda en memoria el costo de cada operación
	 * El costo de ejecutar esta operación es proporcional a la cantidad de lineas
	 * del archivo O(L)
	 * 
	 */
	public void cargar(BufferedReader reader) throws IOException {
		
		String linea = reader.readLine();
		
		while(linea != null) {
			
			String[] lineaCosto = linea.split(":");
			
			String operacion = lineaCosto[0].trim();
			String costo = lineaCosto[1].trim();
			
			TipoOperacion.valueOf(operacion.toUpperCase()).setCosto(Integer.valueOf(costo));
			
			linea = reader.readLine();
		}
	}

}
