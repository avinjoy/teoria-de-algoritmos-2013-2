package ar.fi.uba.tdatp3;

import java.util.HashMap;
import java.util.Map;

public enum SelectorDeSolucion {

	SOLUCION_ALTERNATIVA {
	
		@Override
		public Solucion obtenerSolucion(FuenteDeDatos fuente) {
			return new SolucionAlternativa(fuente);
		}

		@Override
		public String getMensaje() {
			return "Solución Aproximada";
		}
	},
	SOLUCION_EXACTA {
		@Override
		public Solucion obtenerSolucion(FuenteDeDatos fuente) {
			return new SolucionExacta(fuente);
		}

		@Override
		public String getMensaje() {
			return "Solución Exacta";
		}
	};

	private static Map<String, SelectorDeSolucion> selectores = new HashMap<String, SelectorDeSolucion>();
	
	static {
	
		selectores.put("A", SOLUCION_ALTERNATIVA);
		selectores.put("E", SOLUCION_EXACTA);
	}
	
	public static SelectorDeSolucion obtenerSelector(String tipoDeSolucion) {
		return selectores.get(tipoDeSolucion);
	}

	public abstract Solucion obtenerSolucion(FuenteDeDatos fuente);

	public abstract String getMensaje();
		
}
