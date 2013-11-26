package ar.fi.uba.tda.tdatp3;

import java.util.List;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;

import org.hamcrest.Matcher;
import org.hamcrest.core.AnyOf;
import org.junit.Test;

import ar.fi.uba.tdatp3.GeneradorDeCasosRandom;

public class GeneradorDeCasosRandomTest {

	@Test
	public void alGeneradorLePidoUnElementoEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(1);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(1));
		
		chequearElementosEntreLimites(elementos);
		
	}

	@Test
	public void alGeneradorLePidoDosElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(2);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(2));
		
		chequearElementosEntreLimites(elementos);
		
	}
	
	@Test
	public void alGeneradorLePidoDosElementosEntre0y1DosVeces() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(2);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(2));
		
		elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(2));
		
	}
	
	@Test
	public void alGeneradorLePidoDiezElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(10);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(10));
		
		chequearElementosEntreLimites(elementos);
		
	}
	
	@Test
	public void alGeneradorLePidoCienElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(100);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(100));
		
		chequearElementosEntreLimites(elementos);
		
	}
	
	@Test
	public void alGeneradorLePidoMilElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(1000);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(1000));
		
		chequearElementosEntreLimites(elementos);
		
		chequearSicontieneTodosLosValores(elementos);
		
	}

	@Test
	public void alGeneradorLePidoDiezMilElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(10000);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(10000));
		
		chequearElementosEntreLimites(elementos);
		
		chequearSicontieneTodosLosValores(elementos);
		
	}
	
	private void chequearElementosEntreLimites(List<Float> elementos) {
		Matcher<Float> limites = allOf(greaterThan(0.0F), lessThanOrEqualTo(1.0F));
		Matcher<Iterable<Float>> cadaElemento = everyItem(limites);
		assertThat("el elemento", elementos, cadaElemento);
	}
	
	@SuppressWarnings("unchecked")
	private void chequearSicontieneTodosLosValores(List<Float> elementos) {
		
		AnyOf<Float> cualquiera = anyOf(is(0.1F), is(0.2F), is(0.3F), is(0.4F), is(0.5F), 
														   is(0.6F), is(0.7F), is(0.8F), is(0.9F), is(1.0F));
		Matcher<Iterable<? super Float>> contiene = hasItem(cualquiera);
		
		assertThat("el elemento", elementos, contiene);
	}
}
