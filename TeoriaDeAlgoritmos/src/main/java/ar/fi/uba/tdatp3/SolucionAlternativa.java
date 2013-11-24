package ar.fi.uba.tdatp3;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class SolucionAlternativa {

	private final List<Float> elementos;
	private Map<Integer, Float> envases;

	public SolucionAlternativa(List<Float> elementos) {
		this.elementos = elementos;
		this.envases = new HashMap<Integer, Float>(elementos.size());
	}

	public List<Float> getElementos() {
		return elementos;
	}

	public Integer getEnvases() {
		return envases.size();
	}

	public void ejecutar() {
		
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
