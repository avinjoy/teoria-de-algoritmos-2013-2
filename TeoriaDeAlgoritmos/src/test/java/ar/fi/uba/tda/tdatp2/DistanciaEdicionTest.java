package ar.fi.uba.tda.tdatp2;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;
import static org.hamcrest.Matchers.notNullValue;

import java.util.HashMap;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp2.DistanciaEdicion;

public class DistanciaEdicionTest {

	private DistanciaEdicion distancia;
	private HashMap<String, Integer> costos;

	@Before
	public void setUp() throws Exception {
		costos = new HashMap<String, Integer>();
	}

	@After
	public void tearDown() throws Exception {
	}

	@Test
	public void laDistanciaNoEsNulaTest() {
		setCostos();
		distancia = new DistanciaEdicion("Algoritmo", "Altruista", costos);
		assertThat("La distancia de edicion no es nula ",
				distancia.calcularDistanciaEdicion(), notNullValue());
	}

	private void setCostos() {
		costos.put("Copiar", 40);
		costos.put("Reemplazar", 1);
		costos.put("Borrar", 1);
		costos.put("Insertar", 40);
		costos.put("Intercambiar", 1);
		costos.put("Terminar", 1);
	}

	@Test
	public void laDistanciaEsUnValorTest() {
		setCostos();
		distancia = new DistanciaEdicion("Algoritmo", "Altruista", costos);
		assertThat("La distancia de edicion es ",
				distancia.calcularDistanciaEdicion(), is(2));
	}

	@Test
	public void laDistanciaDevuelveElStringFinal() {
		setCostos();
		distancia = new DistanciaEdicion("Algoritmo", "Altruista", costos);
		distancia.calcularDistanciaEdicion();
		assertThat("La palabra obtenida es: ",
				distancia.getResultadoAsString(), is(distancia.getPalabraFin()));
	}

	// @Test
	// public void adnTest() {
	//
	// //copyCost, replaceCost, insertCost, switchCost, endCost, eraseCost
	// distancia = new DistanciaEdicion("G ATTCG GCAT",
	// "CAAT GTGAATC",40,-1,40,0,0,0);
	// assertThat("La distancia de edicion es ",
	// distancia.calcularDistanciaEdicion(), is(10));
	// }
}
