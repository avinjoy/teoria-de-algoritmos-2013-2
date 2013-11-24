package ar.fi.uba.tda.tdatp3;

import java.util.ArrayList;
import java.util.List;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp3.FuenteDeDatos;
import ar.fi.uba.tdatp3.Solucion;
import ar.fi.uba.tdatp3.SolucionAlternativa;

public class SolucionAlternativaTest {

	private FuenteDeDatos fuente;
	private Solucion sa;
	private List<Float> elementos;
	
	@Before
	public void setup() {
	
		fuente = mock(FuenteDeDatos.class);
		
		elementos = new ArrayList<Float>();
		when(fuente.obtenerDatos()).thenReturn(elementos);
		
		sa = new SolucionAlternativa(fuente);
	}
	
	
	@Test
	public void conUnElementoOcupamosUnEnvase() {
		
		elementos.add(0.8F);
		
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(1));
	}
	
	@Test
	public void conDosElementosChicosOcupamosUnEnvase() {
		
		elementos.add(0.8F);
		elementos.add(0.2F);
		
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(1));
	}
	
	@Test
	public void conDosElementosGrandesOcupamosDosEnvases() {
		
		elementos.add(0.8F);
		elementos.add(0.8F);
		
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(2));
	}
	
	@Test
	public void conDosElementosGrandesYUnoChicoOcupamosDosEnvases() {
		
		elementos.add(0.8F);
		elementos.add(0.8F);
		elementos.add(0.2F);
		
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(2));
	}
	
	@Test
	public void casoDelEnunciado() {
		
//		T={0,4; 0,8; 0,5; 0,1; 0,7; 0,6; 0,1; 0,4; 0,2; 0,2}
		elementos.add(0.4F);
		elementos.add(0.8F);
		elementos.add(0.5F);
		elementos.add(0.1F);
		elementos.add(0.7F);
		elementos.add(0.6F);
		elementos.add(0.1F);
		elementos.add(0.4F);
		elementos.add(0.2F);
		elementos.add(0.2F);
		
		sa.ejecutar();
		
		assertThat("la cantidad de envases", sa.getEnvases(), is(6));
	}
}
