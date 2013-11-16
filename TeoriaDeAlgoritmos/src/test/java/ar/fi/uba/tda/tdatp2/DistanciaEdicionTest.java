package ar.fi.uba.tda.tdatp2;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tdatp2.CostoOperacion.TipoOperacion;
import ar.fi.uba.tdatp2.DistanciaEdicion;

public class DistanciaEdicionTest {

	private DistanciaEdicion distancia;

	@Before
	public void setUp() throws Exception {
		TipoOperacion.COPIAR.setCosto(1);
		TipoOperacion.REEMPLAZAR.setCosto(1);
		TipoOperacion.BORRAR.setCosto(1);
		TipoOperacion.INSERTAR.setCosto(1);
		TipoOperacion.INTERCAMBIAR.setCosto(1);
		TipoOperacion.TERMINAR.setCosto(1);
	}

	@After
	public void tearDown() throws Exception {
	}

	
	@Test
	public void versionAlternativa() {
		
		distancia = new DistanciaEdicion("CA", "ABC");
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(3));
		assertThat("El resultado", distancia.getPalabraResultante(), is("ABC"));
	}

	@Test
	public void versionAlternativaConIntercambio() {
		
		distancia = new DistanciaEdicion("CA", "AC");
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(1));
		assertThat("El resultado", distancia.getPalabraResultante(), is("AC"));
	}
	
	@Test
	public void versionAlternativaAlgoritmoAltruista() {
		
		distancia = new DistanciaEdicion("algoritmo", "altruista");
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(9));
		assertThat("El resultado", distancia.getPalabraResultante(), is("altruista"));
	}
	
	@Test
	public void versionAlternativaAlgoritmoAlga() {
		
		distancia = new DistanciaEdicion("algoritmo", "alga");
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(5));
		assertThat("El resultado", distancia.getPalabraResultante(), is("alga"));
	}
	
	@Test
	public void convertirAlgoritmoAlgaConPesoAltoEnTerminar() {
		
		TipoOperacion.TERMINAR.setCosto(100);
		distancia = new DistanciaEdicion("algoritmo", "alga");
		int distanciaEdicion = distancia.calcularDistanciaEdicion();
		assertThat("la distancia de edición", distanciaEdicion, is(9));
		assertThat("El resultado", distancia.getPalabraResultante(), is("alga"));
	}
	
	@Test
	public void adnTest() {
	
		TipoOperacion.COPIAR.setCosto(-1);
		TipoOperacion.REEMPLAZAR.setCosto(2);
		TipoOperacion.BORRAR.setCosto(2);
		TipoOperacion.INSERTAR.setCosto(2);
		TipoOperacion.INTERCAMBIAR.setCosto(1000);
		TipoOperacion.TERMINAR.setCosto(1000);
		
		distancia = new DistanciaEdicion("GATCGGCAT", "CAATGTGAATC");
		assertThat("La distancia de edicion es ", distancia.calcularDistanciaEdicion(), is(6));
		assertThat("El resultado", distancia.getPalabraResultante(), is("CAATGTGAATC"));
	}
	
	@Test
	public void casoDePrueba1() {
	
		TipoOperacion.COPIAR.setCosto(0);
		TipoOperacion.REEMPLAZAR.setCosto(1);
		TipoOperacion.BORRAR.setCosto(1);
		TipoOperacion.INSERTAR.setCosto(1);
		TipoOperacion.INTERCAMBIAR.setCosto(1);
		TipoOperacion.TERMINAR.setCosto(1);
		
		distancia = new DistanciaEdicion("mississipi", "minessossi");
		assertThat("La distancia de edicion es ", distancia.calcularDistanciaEdicion(), is(4));
		assertThat("El resultado", distancia.getPalabraResultante(), is("minessossi"));
	}
	
	@Test
	public void casoDePrueba2() {
	
		TipoOperacion.COPIAR.setCosto(0);
		TipoOperacion.REEMPLAZAR.setCosto(2);
		TipoOperacion.BORRAR.setCosto(3);
		TipoOperacion.INSERTAR.setCosto(3);
		TipoOperacion.INTERCAMBIAR.setCosto(1);
		TipoOperacion.TERMINAR.setCosto(1);
		
		distancia = new DistanciaEdicion("mississipi", "minessossi");
		assertThat("La distancia de edicion es ", distancia.calcularDistanciaEdicion(), is(9));
		assertThat("El resultado", distancia.getPalabraResultante(), is("minessossi"));
	}
	
	@Test
	public void casoDePrueba3() {
	
		TipoOperacion.COPIAR.setCosto(0);
		TipoOperacion.REEMPLAZAR.setCosto(5);
		TipoOperacion.BORRAR.setCosto(3);
		TipoOperacion.INSERTAR.setCosto(3);
		TipoOperacion.INTERCAMBIAR.setCosto(1);
		TipoOperacion.TERMINAR.setCosto(1);
		
		distancia = new DistanciaEdicion("mississipi", "minessossi");
		assertThat("La distancia de edicion es ", distancia.calcularDistanciaEdicion(), is(12));
		assertThat("El resultado", distancia.getPalabraResultante(), is("minessossi"));
	}
	
	@Test
	public void casoDePrueba4() {
	
		TipoOperacion.COPIAR.setCosto(-1);
		TipoOperacion.REEMPLAZAR.setCosto(1);
		TipoOperacion.BORRAR.setCosto(1);
		TipoOperacion.INSERTAR.setCosto(2);
		TipoOperacion.INTERCAMBIAR.setCosto(1000000);
		TipoOperacion.TERMINAR.setCosto(1000000);
		
		distancia = new DistanciaEdicion("mississipi", "minessossi");
		assertThat("La distancia de edicion es ", distancia.calcularDistanciaEdicion(), is(2));
		assertThat("El resultado", distancia.getPalabraResultante(), is("minessossi"));
	}
}
