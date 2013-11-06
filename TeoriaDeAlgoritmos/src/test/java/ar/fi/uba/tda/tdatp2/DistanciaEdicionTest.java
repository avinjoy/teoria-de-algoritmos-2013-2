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
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(3));
	}

	@Test
	public void versionAlternativaConIntercambio() {
		
		distancia = new DistanciaEdicion("CA", "AC", costos);
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(1));
	}
	
	@Test
	public void versionAlternativaAlgoritmoAltruista() {
		
		distancia = new DistanciaEdicion("algoritmo", "altruista", costos);
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(9));
		assertThat("El resultado no es nulo", distancia.getCostoFinal(), is(9) );
	}
	
	@Test
	public void versionAlternativaAlgoritmoAlga() {
		
		distancia = new DistanciaEdicion("algoritmo", "alga", costos);
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(5));
		assertThat("El resultado no es nulo", distancia.getCostoFinal(), is(5) );
	}
	
	@Test
	public void convertirAlgoritmoAlgaConPesoAltoEnTerminar() {
		
		costos.put("Terminar", 100);
		distancia = new DistanciaEdicion("algoritmo", "alga", costos);
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(9));
		assertThat("El resultado no es nulo", distancia.getCostoFinal(), is(9) );
	}
	
	@Test
	public void adnTest() {
	
		costos = new HashMap<String, Integer>();
		costos.put("Copiar", -1);
		costos.put("Reemplazar", 2);
		costos.put("Borrar", 2);
		costos.put("Insertar", 2);
		costos.put("Intercambiar", 1000);
		costos.put("Terminar", 1000);
		distancia = new DistanciaEdicion("GATCGGCAT", "CAATGTGAATC",costos);
		assertThat("La distancia de edicion es ", distancia.calcularDistanciaEdicion(), is(6));
	}
}
