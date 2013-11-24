package ar.fi.uba.tdatp3;

import java.util.ArrayList;
import java.util.List;

public abstract class Solucion {

	protected List<Float> elementos;
	private FuenteDeDatos fuente;
	private int cantidadDeEjecuciones;
	private List<Long> ejecuciones;
	
	public Solucion(FuenteDeDatos fuente) {
		this.fuente = fuente;
		ejecuciones = new ArrayList<Long>();
	}

	public List<Float> getElementos() {
		return elementos;
	}

	public abstract Integer getEnvases();
	
	public void ejecutar(int cantidadDeseada) {
		
		for (int i = 0; i < cantidadDeseada; i++) {
			
			this.elementos = fuente.obtenerDatos();
			
			long millisAntes = System.currentTimeMillis();
			aplicarAlgoritmo();
			
			ejecuciones.add(System.currentTimeMillis() - millisAntes);
			cantidadDeEjecuciones++;
		}
		
	}
	
	public abstract void aplicarAlgoritmo();

	public Integer getCantidadDeEjecuciones() {
		return cantidadDeEjecuciones;
	}

	public List<Long> getEjecuciones() {
		return ejecuciones;
	}

	public Long getTiempoPromedio() {

		long tiempo = 0L;
		
		for (long ejecucion : ejecuciones) {
			tiempo += ejecucion;
		} 
		return tiempo/cantidadDeEjecuciones;
	}


}
