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
		
		solucion.ejecutar(1);
		
		verify(fuente).obtenerDatos();
	}
	
	@Test
	public void unaSolucionPuedeEjecutarseMultiplesVeces() {
		
		solucion.ejecutar(2);
		
		verify(fuente, times(2)).obtenerDatos();
	}
	
	@Test
	public void puedoSaberCuantasVecesSeEjecutoUnaSolucion() {
		
		solucion.ejecutar(2);
		
		assertThat("la cantidad de ejecuciones", solucion.getCantidadDeEjecuciones(), is(2));
	}

	@Test
	public void puedoSaberCuantoDemoroCadaEjecucion() {
		
		solucion.ejecutar(2);
		
		assertThat("la cantidad de ejecuciones", solucion.getEjecuciones(), hasSize(2));
		assertThat("el tiempo de la ejecucion", solucion.getEjecuciones().get(0), greaterThanOrEqualTo(0L));
		assertThat("el tiempo de la ejecucion", solucion.getEjecuciones().get(1), greaterThanOrEqualTo(0L));
	}
	
	@Test
	public void puedoSaberElPromedioDeLasEjecuciones() {
		
		solucion.ejecutar(2);
		
		assertThat("el promedio de las ejecuciones", solucion.getTiempoPromedio(), greaterThanOrEqualTo(0L));
	}
	
}
