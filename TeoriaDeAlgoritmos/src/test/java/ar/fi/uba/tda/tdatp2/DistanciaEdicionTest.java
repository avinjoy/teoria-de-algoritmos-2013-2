package ar.fi.uba.tda.tdatp2;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;
import static org.hamcrest.Matchers.notNullValue;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp2.DistanciaEdicion;

public class DistanciaEdicionTest {

	private DistanciaEdicion distancia;
	
	@Before
	public void setUp() throws Exception {
		distancia = new DistanciaEdicion("Algoritmo", "Altruista",1,1,1,1,1,1);
		
	}

	@After
	public void tearDown() throws Exception {
	}

	
	@Test
	public void laDistanciaNoEsNulaTest() {
		assertThat("La distancia de edicion no es nula ", distancia.calcularDistanciaEdicion(), notNullValue());
	}
	
	@Test
	public void laDistanciaEsUnValorTest() {
		assertThat("La distancia de edicion es ", distancia.calcularDistanciaEdicion(), is(9));
	}

}
