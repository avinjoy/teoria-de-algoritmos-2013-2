package ar.fi.uba.tdatp2.util;

import java.io.BufferedReader;
import java.io.IOException;
import java.util.HashMap;

public class CargadorCostos {

	private final HashMap<String, Integer> costos;

	public CargadorCostos(HashMap<String, Integer> costos) {
		this.costos = costos;
	}

	public void cargar(BufferedReader reader) throws IOException {
		
		String linea = reader.readLine();
		
		while(linea != null) {
			
			String[] lineaCosto = linea.split(":");
			
			String operacion = lineaCosto[0].trim();
			String costo = lineaCosto[1].trim();
			costos.put(operacion.trim(), Integer.valueOf(costo));			
			linea = reader.readLine();
		}
	}
	
	

}
