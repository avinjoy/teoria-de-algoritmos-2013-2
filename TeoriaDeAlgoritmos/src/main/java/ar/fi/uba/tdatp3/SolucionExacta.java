package ar.fi.uba.tdatp3;

import java.math.BigDecimal;
import java.util.List;

public class SolucionExacta extends Solucion{

	private double[] espacioLibreEnvase;
	private boolean[][] estaEnvaseConItem;

	
	public SolucionExacta(FuenteDeDatos fuente) {
		
		super(fuente);
		this.espacioLibreEnvase = null;
	}

	public SolucionExacta(List<Float> elementos) {
		super(null);
		this.elementos = elementos;
		this.espacioLibreEnvase = new double[elementos.size()];
	}

	public SolucionExacta(List<Float> itemSize, int cantidadEnvases) {
		super(null);
		this.elementos = itemSize;
		this.espacioLibreEnvase = new double[cantidadEnvases];

		for (int i = 0; i < cantidadEnvases; i++) {
			this.espacioLibreEnvase[i] = 1.0F;
		}

		this.estaEnvaseConItem = new boolean[cantidadEnvases][this.elementos.size()];
	}

	public List<Float> getItems() {
		return elementos;
	}

	public void setItems(List<Float> items) {
		this.elementos = items;
	}

	public double[] getEspacioLibreEnvase() {
		return espacioLibreEnvase;
	}

	public void setEspacioLibreEnvase(double[] espacioLibreEnvase) {
		this.espacioLibreEnvase = espacioLibreEnvase;
	}

	public boolean[][] getEstaEnvaseConItem() {
		return estaEnvaseConItem;
	}

	public void setEstaEnvaseConItem(boolean[][] estaEnvaseConItem) {
		this.estaEnvaseConItem = estaEnvaseConItem;
	}
	
	public void setCantidadEnvases(int cantEnvases) {
		this.espacioLibreEnvase = new double[cantEnvases];
		for (int i = 0; i < cantEnvases; i++) {
			this.espacioLibreEnvase[i] = 1.0F;
		}

		this.estaEnvaseConItem = new boolean[cantEnvases][this.elementos.size()];
	}
	
	/**
	 * Algoritmo de fuerza bruta para la inserción de un elemento en los envases.
	 * Orden O (m^n) donde n es la cantidad de elementos a insertar y m la cantidad de 
	 * @param item
	 * @return
	 */
	public boolean pack(int item) {
		// Mostrar la solución si terminamos
		if (item == elementos.size()) {
			//showResults();
			return true;
		}

		// sino seguimos buscando los elementos
		for (int i = 0; i < espacioLibreEnvase.length; i++) {
			if (round(espacioLibreEnvase[i],2) >= round(elementos.get(item),2)) {
				estaEnvaseConItem[i][item] = true; // insertarlo en el envase
				espacioLibreEnvase[i]=round(espacioLibreEnvase[i] -= elementos.get(item),2);
				if (pack(item+1)) //Sigo con el proximo elemento
					return true;
				espacioLibreEnvase[i]=round(espacioLibreEnvase[i] += elementos.get(item),2); // No, entró el anterior, lo sacamos
				estaEnvaseConItem[i][item] = false;
			}
				
		
		}

		return false;
	}

	private void showResults() {
		for (int i = 0; i < espacioLibreEnvase.length; i++) {
			System.out.println("bag" + i);
			for (int j = 0; j < elementos.size(); j++)
				if (estaEnvaseConItem[i][j] == true)
					System.out.println("item" + j + "(" + elementos.get(j)
							+ ") ");
		}
	}

	

	/**
	 * Redondeo para manejo de floats
	 * @param value
	 * @param places
	 * @return
	 */
	public static double round(double value, int places) {
	    if (places < 0) throw new IllegalArgumentException();

	    BigDecimal bd = new BigDecimal(value);
	    bd = bd.setScale(places, BigDecimal.ROUND_HALF_UP);
	    return bd.doubleValue();
	}

	@Override
	/**
	 * Cantidad de envases utilizados.
	 */
	
	public Integer getEnvases() {
		Integer envases =0;
		if (this.espacioLibreEnvase != null)
			envases= this.espacioLibreEnvase.length;
		return envases;
	}

	/**
	 * Aplica el algoritmo de la solucion exacta.
	 * Va probando por fuerza bruta y de 1 en adelante la cantidad de envases a llenar para
	 * obtener el mínimo.
	 * Es de orden exponencial O(m x (n^n)) donde m es la cantidad de envases y n la cantidad de elementos 
	 */
	@Override
	public void aplicarAlgoritmo() {
		
		//Itero por la cantidad de envases hasta encontrar la que insume menos envases.
		//Asume que los elementos ya están cargados.
		boolean flag=false;

		if (!elementos.isEmpty()) {
			for (int cantEnvases=0; cantEnvases < this.elementos.size() && !flag; cantEnvases++) {
				this.setCantidadEnvases(cantEnvases+1);
				flag=this.pack(0);
			}
		}

	}



}
