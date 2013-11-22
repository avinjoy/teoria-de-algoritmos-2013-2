package ar.fi.uba.tda.tdatp3;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class GeneradorDeCasosRandom {

	private final int cantidadDeElementos;
	private final List<Float> elementos;
	private Random random;
	private DecimalFormat format;

	public GeneradorDeCasosRandom(int cantidadDeElementos) {
		this.cantidadDeElementos = cantidadDeElementos;
		this.elementos = new ArrayList<Float>(cantidadDeElementos);
		random = new Random();
		format = new DecimalFormat("#.#");
	}

	public List<Float> obtenerDatos() {

		for (int i = 0; i < cantidadDeElementos; i++) {
			
			float numeroRandom = random.nextFloat() + 0.1F;
			
			if (numeroRandom > 1.0F) {
				numeroRandom = 1.0F;
			}
			
			String formateado = format.format(numeroRandom);
			float numeroFormateado = Float.valueOf(formateado);
			
			elementos.add(numeroFormateado);
		}
		return elementos;
	}

}
