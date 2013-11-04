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
	
	}

	@After
	public void tearDown() throws Exception {
	}

	
	@Test
	public void laDistanciaNoEsNulaTest() {
		distancia = new DistanciaEdicion("Algoritmo", "Altruista",1,1,1,1,1,1);
		assertThat("La distancia de edicion no es nula ", distancia.calcularDistanciaEdicion(), notNullValue());
	}
	
	@Test
	public void laDistanciaEsUnValorTest() {
		distancia = new DistanciaEdicion("Algoritmo", "Altruista",40,1,40,1,1,1);
		assertThat("La distancia de edicion es ", distancia.calcularDistanciaEdicion(), is(12));
	}
	
	@Test
	public void laDistanciaDevuelveElStringFinal() {
		distancia = new DistanciaEdicion("Algoritmo", "Altruista",40,1,40,1,1,1);
		distancia.calcularDistanciaEdicion();
		assertThat("La palabra obtenida es: ", distancia.getResultadoAsString(), is(distancia.getPalabraFin()));
	}

	@Test
	public void adnTest() {

		//copyCost, replaceCost, insertCost, switchCost, endCost, eraseCost
		distancia = new DistanciaEdicion("G ATTCG GCAT", "CAAT GTGAATC",40,-1,40,0,0,0);
		assertThat("La distancia de edicion es ", distancia.calcularDistanciaEdicion(), is(10));
	}
}
