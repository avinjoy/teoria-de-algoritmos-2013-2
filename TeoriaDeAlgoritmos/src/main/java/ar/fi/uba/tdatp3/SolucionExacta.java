package ar.fi.uba.tdatp3;

import java.math.BigDecimal;
import java.util.List;

public class SolucionExacta extends Solucion{

	private List<Float> items;
	private double[] espacioLibreEnvase;
	private boolean[][] estaEnvaseConItem;

	
	public SolucionExacta(FuenteDeDatos fuente) {
		
		super(fuente);
		this.espacioLibreEnvase = null;
	}

	public SolucionExacta(List<Float> elementos) {
		super(null);
		this.items = elementos;
		this.espacioLibreEnvase = new double[elementos.size()];
	}

	public SolucionExacta(List<Float> itemSize, int cantidadEnvases) {
		super(null);
		this.items = itemSize;
		this.espacioLibreEnvase = new double[cantidadEnvases];

		for (int i = 0; i < cantidadEnvases; i++) {
			this.espacioLibreEnvase[i] = 1.0F;
		}

		this.estaEnvaseConItem = new boolean[cantidadEnvases][this.items.size()];
	}

	public List<Float> getItems() {
		return items;
	}

	public void setItems(List<Float> items) {
		this.items = items;
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

		this.estaEnvaseConItem = new boolean[cantEnvases][this.items.size()];
	}
	
	public boolean pack(int item) {
		// Mostrar la solución si terminamos
		if (item == items.size()) {
			for (int i = 0; i < espacioLibreEnvase.length; i++) {
				System.out.println("bag" + i);
				for (int j = 0; j < items.size(); j++)
					if (estaEnvaseConItem[i][j] == true)
						System.out.println("item" + j + "(" + items.get(j)
								+ ") ");
			}
			return true;
		}

		// sino seguimos buscando los elementos
		for (int i = 0; i < espacioLibreEnvase.length; i++) {
			if (round(espacioLibreEnvase[i],2) >= round(items.get(item),2)) {
				estaEnvaseConItem[i][item] = true; // insertarlo en el envase
				espacioLibreEnvase[i]=round(espacioLibreEnvase[i] -= items.get(item),2);
				if (pack(item+1)) //Sigo con el proximo elemento
					return true;
				espacioLibreEnvase[i]=round(espacioLibreEnvase[i] += items.get(item),2); // No, entró el anterior, lo sacamos
				estaEnvaseConItem[i][item] = false;
			}
				
		
		}

		return false;
	}

	

	//Redondeo para manejo de floats
	public static double round(double value, int places) {
	    if (places < 0) throw new IllegalArgumentException();

	    BigDecimal bd = new BigDecimal(value);
	    bd = bd.setScale(places, BigDecimal.ROUND_HALF_UP);
	    return bd.doubleValue();
	}

	@Override
	public Integer getEnvases() {
		return this.espacioLibreEnvase.length;
	}

	@Override
	public void aplicarAlgoritmo() {
		
		//Itero por la cantidad de envases hasta encontrar la que insume menos envases.
		//Asume que los elementos ya están cargados.
		boolean flag=false;

		for (int cantEnvases=0; cantEnvases < this.items.size() && !flag; cantEnvases++) {
			this.setCantidadEnvases(cantEnvases);
			flag=this.pack(0);
		}

	}



}
