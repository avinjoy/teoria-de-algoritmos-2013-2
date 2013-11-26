package ar.fi.uba.tdatp3;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Random;

public class GeneradorDeCasosRandom implements FuenteDeDatos{

	private final int cantidadDeElementos;
	private final List<Float> elementos;
	private Random random;
	private DecimalFormat format;

	public GeneradorDeCasosRandom(int cantidadDeElementos) {
		this.cantidadDeElementos = cantidadDeElementos;
		this.elementos = new ArrayList<Float>(cantidadDeElementos);
		random = new Random();
		Locale.setDefault(new Locale("us"));
		format = new DecimalFormat("#.#");
		
	}

	@Override
	public List<Float> obtenerDatos() {

		this.elementos.clear();
		for (int i = 0; i < cantidadDeElementos; i++) {
			
			float numeroRandom = random.nextFloat() + 0.1F;
			
			if (numeroRandom > 1.0F) {
				numeroRandom = 1.0F;
			}
			
			String formateado = String.format(Locale.US,"%s",format.format(numeroRandom));
			float numeroFormateado = Float.valueOf(formateado);
			
			elementos.add(numeroFormateado);
		}
		return elementos;
	}

}
