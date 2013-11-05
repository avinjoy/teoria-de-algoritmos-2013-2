package ar.fi.uba.tda.tdatp2.util;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

import java.io.BufferedReader;
import java.io.IOException;
import java.util.HashMap;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp2.util.CargadorCostos;

public class CargadorCostosTest {

	private HashMap<String, Integer> costos;
	private CargadorCostos cargador;

	@Before
	public void setup() {
	
		costos = new HashMap<String, Integer>();
		cargador = new CargadorCostos(costos);
	}
	
	@Test
	public void cargoUnInsertarNoNulo() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		when(reader.readLine()).thenReturn("Insertar:23", (String)null);
				
		cargador.cargar(reader);
		
		
		assertThat("la cantidad operaciones es 1", costos.keySet().size(), is(1));
		assertThat("La operacion cargada es insertar ", costos.keySet().contains("Insertar"), is(true));
		assertThat("La operacion Insertar tiene costo 23 ", costos.get("Insertar"), is(23));
	}
	
	@Test
	public void noAgregaOperacionesRepetidas() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		when(reader.readLine()).thenReturn("Insertar:23", (String)null);
		when(reader.readLine()).thenReturn("Insertar:222", (String)null);
		
		cargador.cargar(reader);
		
		assertThat("La cantidad de operaciones es 1", costos.keySet().size(), is(1));
	}
	
	@Test
	public void cargarDesdeArchivoOperaciones() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		
		when(reader.readLine()).thenReturn("Copiar: 1","Reemplazar: 4","Borrar: 45","Intercambiar: 1","Insertar: 44","Terminar: 1", (String)null);
		
		cargador.cargar(reader);
		
		assertThat("La cantidad de operaciones es 6", costos.keySet().size(), is(6));
		assertThat("Insertar está en los costos", costos.keySet().contains("Insertar"), is(true));
		assertThat("Borrar esta en los costos", costos.keySet().contains("Borrar"), is(true));
		assertThat("Borrar tiene valor 45", costos.get("Borrar"), is(45));
	}
	
}
