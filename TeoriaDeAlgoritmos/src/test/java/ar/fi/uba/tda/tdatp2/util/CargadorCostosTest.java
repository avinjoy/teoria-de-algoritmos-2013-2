package ar.fi.uba.tda.tdatp2.util;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

import java.io.BufferedReader;
import java.io.IOException;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp2.CostoOperacion.TipoOperacion;
import ar.fi.uba.tdatp2.util.CargadorCostos;

public class CargadorCostosTest {

	private CargadorCostos cargador;
	private BufferedReader reader;

	@Before
	public void setup() {
	
		cargador = new CargadorCostos();
		reader = mock(BufferedReader.class);
	}
	
	@Test
	public void cargoUnInsertarNoNulo() throws IOException {
		
		when(reader.readLine()).thenReturn("Insertar:23", (String)null);
				
		cargador.cargar(reader);
		
		assertThat("La operacion Insertar tiene costo 23 ", TipoOperacion.INSERTAR.getCosto(), is(23));
	}
	
	@Test
	public void cargarDesdeArchivoOperaciones() throws IOException {
		
		when(reader.readLine()).thenReturn( "Copiar: 1",
											"Reemplazar: 4",
											"Borrar: 45",
											"Intercambiar: 1",
											"Insertar: 44",
											"Terminar: 1", 
											(String)null);
		
		cargador.cargar(reader);
		
		assertThat("La operacion Copiar tiene costo 1 ", TipoOperacion.COPIAR.getCosto(), is(1));
		assertThat("La operacion Reemplazar tiene costo 4 ", TipoOperacion.REEMPLAZAR.getCosto(), is(4));
		assertThat("La operacion Borrar tiene costo 45 ", TipoOperacion.BORRAR.getCosto(), is(45));
		assertThat("La operacion Intercambiar tiene costo 1 ", TipoOperacion.INTERCAMBIAR.getCosto(), is(1));
		assertThat("La operacion Insertar tiene costo 44 ", TipoOperacion.INSERTAR.getCosto(), is(44));
		assertThat("La operacion Terminar tiene costo 1 ", TipoOperacion.TERMINAR.getCosto(), is(1));
	}
	
}
