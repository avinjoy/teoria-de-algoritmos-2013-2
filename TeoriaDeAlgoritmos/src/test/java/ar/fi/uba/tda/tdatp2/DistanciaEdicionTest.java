package ar.fi.uba.tda.tdatp2;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;

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
		costos.put("Copiar", 1);
		costos.put("Reemplazar", 1);
		costos.put("Borrar", 1);
		costos.put("Insertar", 1);
		costos.put("Intercambiar", 1);
		costos.put("Terminar", 1);
	}

	@After
	public void tearDown() throws Exception {
	}

	
	@Test
	public void versionAlternativa() {
		
		distancia = new DistanciaEdicion("CA", "ABC", costos);
		int distanciaEdicion = distancia.calcularDistanciaEdicion2();
		assertThat("la distancia de edición", distanciaEdicion, is(3));
	}

	@Test
	public void versionAlternativaConIntercambio() {
		
		distancia = new DistanciaEdicion("CA", "AC", costos);
		int distanciaEdicion = distancia.calcularDistanciaEdicion2();
		assertThat("la distancia de edición", distanciaEdicion, is(1));
	}
	
	@Test
	public void versionAlternativaAlgoritmoAltruista() {
		
		distancia = new DistanciaEdicion("algoritmo", "altruista", costos);
		int distanciaEdicion = distancia.calcularDistanciaEdicion2();
		assertThat("la distancia de edición", distanciaEdicion, is(9));
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
