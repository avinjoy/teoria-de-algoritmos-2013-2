package ar.fi.uba.tdatp3;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class SolucionAlternativa extends Solucion {

	private Map<Integer, Float> envases;

	public SolucionAlternativa(FuenteDeDatos fuente) {
		
		super(fuente);
		this.envases = new HashMap<Integer, Float>();
	}

	public SolucionAlternativa(List<Float> elementos) {
		
		super(null);
		this.elementos = elementos;
		this.envases = new HashMap<Integer, Float>(elementos.size());
	}

	@Override
	public Integer getEnvases() {
		return envases.size();
	}

	@Override
	public void aplicarAlgoritmo() {
		
		envases.clear();
		
		int envaseActual = 1;
		envases.put(envaseActual, 0F);
		
		for (Float elemento : elementos) {
			
			Float elementosEnElEnvase = envases.get(envaseActual);
			
			if (elementosEnElEnvase + elemento <= 1) {
				envases.put(envaseActual, elementosEnElEnvase + elemento);
			} else {
				envaseActual++;
				envases.put(envaseActual, elemento);
			}
		}
	}

}
