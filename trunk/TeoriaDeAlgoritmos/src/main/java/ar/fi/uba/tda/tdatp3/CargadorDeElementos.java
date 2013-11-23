package ar.fi.uba.tda.tdatp3;

import java.io.BufferedReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class CargadorDeElementos {

	private final BufferedReader reader;
	private List<Float> elementos;

	public CargadorDeElementos(BufferedReader reader) {
		this.reader = reader;
	}

	public List<Float> obtenerDatos() {
		
		if (elementos == null) {
			elementos = new ArrayList<Float>();
			cargarElementos();
		}
		
		return elementos;
	}

	private void cargarElementos() {

		try {
			leerHeader();
			
			String linea = reader.readLine();
			
			while (linea != null) {
				
				float elemento = Float.valueOf(linea);
				elementos.add(elemento);
				
				linea = reader.readLine();
			}
			
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	private void leerHeader() throws IOException {
		reader.readLine();
		reader.readLine();
	}
}
