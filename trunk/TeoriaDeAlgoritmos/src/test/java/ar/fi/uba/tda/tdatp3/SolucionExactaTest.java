package ar.fi.uba.tda.tdatp3;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

import java.util.ArrayList;
import java.util.List;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp3.FuenteDeDatos;
import ar.fi.uba.tdatp3.Solucion;
import ar.fi.uba.tdatp3.SolucionAlternativa;
import ar.fi.uba.tdatp3.SolucionExacta;

public class SolucionExactaTest {

	private List<Float> datos;
	private FuenteDeDatos fuente;
	private Solucion se;
			
	@Before
	public void setUp() throws Exception {
		fuente = mock(FuenteDeDatos.class);
		datos = new ArrayList<Float>();
		when(fuente.obtenerDatos()).thenReturn(datos);
		se = new SolucionAlternativa(datos);

	}

	@After
	public void tearDown() throws Exception {
	}
	
	@Test
	public void conUnElementoOcupamosUnEnvase() {
		
		datos.add(0.8F);
		
		se.aplicarAlgoritmo();
		
		assertThat("la cantidad de envases", se.getEnvases(), is(1));
	}
	
	@Test
	public void conDosElementosChicosOcupamosUnEnvase() {
		
		datos.add(0.8F);
		datos.add(0.2F);
		
		se.aplicarAlgoritmo();
		
		assertThat("la cantidad de envases", se.getEnvases(), is(1));
	}
	
	@Test
	public void conDosElementosGrandesOcupamosDosEnvases() {
		
		datos.add(0.8F);
		datos.add(0.8F);
		
		se.aplicarAlgoritmo();
		
		assertThat("la cantidad de envases", se.getEnvases(), is(2));
	}
	
	@Test
	public void conDosElementosGrandesYUnoChicoOcupamosDosEnvases() {
		
		datos.add(0.8F);
		datos.add(0.8F);
		datos.add(0.2F);
		
		se.aplicarAlgoritmo();
		
		assertThat("la cantidad de envases", se.getEnvases(), is(2));
	}

	@Test
	public void test() {
		datos.add(0.4F);
		datos.add(0.8F);
		datos.add(0.5F);
		datos.add(0.1F);
		datos.add(0.7F);
		datos.add(0.6F);
		datos.add(0.1F);
		datos.add(0.4F);
		datos.add(0.2F);
		datos.add(0.2F);
		se = new SolucionExacta(datos);
		se.aplicarAlgoritmo();
		assertThat("la cantidad de envases", se.getEnvases(), is(4));
	}

}
