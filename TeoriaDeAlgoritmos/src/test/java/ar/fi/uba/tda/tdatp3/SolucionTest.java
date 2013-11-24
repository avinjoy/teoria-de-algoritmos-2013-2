package ar.fi.uba.tda.tdatp3;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;
import static org.mockito.Mockito.*;

import java.util.ArrayList;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp3.FuenteDeDatos;
import ar.fi.uba.tdatp3.Solucion;
import ar.fi.uba.tdatp3.SolucionAlternativa;

public class SolucionTest {

	private FuenteDeDatos fuente;
	private Solucion solucion;
	private List<Float> elementos;

	@Before
	public void setup() {
	
		fuente = mock(FuenteDeDatos.class);
		
		elementos = new ArrayList<Float>();
		when(fuente.obtenerDatos()).thenReturn(elementos);
		
		solucion = new SolucionAlternativa(fuente);
	}
	
	@Test
	public void unaSolucionTieneUnaCantidadDeEnvases() {
		
		assertThat("la cantidad de envasese", solucion.getEnvases(), is(0));
	}
	
	@Test
	public void unaSolucionTieneUnaFuenteDeDatos() {
		
		solucion.ejecutar();
		
		verify(fuente).obtenerDatos();
	}
}
