package ar.fi.uba.tdatp2.util;

import java.io.BufferedReader;
import java.io.IOException;

import ar.fi.uba.tdatp2.CostoOperacion.TipoOperacion;

public class CargadorCostos {

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
