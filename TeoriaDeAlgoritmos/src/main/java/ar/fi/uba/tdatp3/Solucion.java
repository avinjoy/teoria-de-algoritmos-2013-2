package ar.fi.uba.tdatp3;

import java.util.List;

public abstract class Solucion {

	protected List<Float> elementos;
	private FuenteDeDatos fuente;
	
	public Solucion(FuenteDeDatos fuente) {
		this.fuente = fuente;
	}

	public List<Float> getElementos() {
		return elementos;
	}

	public abstract Integer getEnvases();
	
	public void ejecutar() {
		
		this.elementos = fuente.obtenerDatos();
		
		aplicarAlgoritmo();
	}
	
	public abstract void aplicarAlgoritmo();


}
