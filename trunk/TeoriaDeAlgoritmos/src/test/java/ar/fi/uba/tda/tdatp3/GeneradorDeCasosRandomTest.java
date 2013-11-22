package ar.fi.uba.tda.tdatp3;

import java.util.List;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;

import org.junit.Test;

public class GeneradorDeCasosRandomTest {

	@Test
	public void alGeneradorLePidoUnElementoEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(1);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(1));
		
		assertThat("el elemento", elementos, everyItem(allOf(greaterThan(0.0F), lessThanOrEqualTo(1.0F))));
		
	}
	
	@Test
	public void alGeneradorLePidoDosElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(2);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(2));
		
		assertThat("el elemento", elementos, everyItem(allOf(greaterThan(0.0F), lessThanOrEqualTo(1.0F))));
		
	}
	
	@Test
	public void alGeneradorLePidoDiezElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(10);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(10));
		
		assertThat("el elemento", elementos, everyItem(allOf(greaterThan(0.0F), lessThanOrEqualTo(1.0F))));
		
	}
	
	@Test
	public void alGeneradorLePidoCienElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(100);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(100));
		
		assertThat("el elemento", elementos, everyItem(allOf(greaterThan(0.0F), lessThanOrEqualTo(1.0F))));
		
	}
	
	@SuppressWarnings("unchecked")
	@Test
	public void alGeneradorLePidoMilElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(1000);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(1000));
		
		assertThat("el elemento", elementos, everyItem(allOf(greaterThan(0.0F), lessThanOrEqualTo(1.0F))));
		
		assertThat("el elemento", elementos, hasItem(anyOf(is(0.1F), is(0.2F), is(0.3F), is(0.4F), is(0.5F), 
														   is(0.6F), is(0.7F), is(0.8F), is(0.9F), is(1.0F))));
		
	}
	
	@SuppressWarnings("unchecked")
	@Test
	public void alGeneradorLePidoDiezMilElementosEntre0y1() {
		
		GeneradorDeCasosRandom generador = new GeneradorDeCasosRandom(10000);
		
		List<Float> elementos = generador.obtenerDatos();
		
		assertThat("la cantidad de elementos", elementos, hasSize(10000));
		
		assertThat("el elemento", elementos, everyItem(allOf(greaterThan(0.0F), lessThanOrEqualTo(1.0F))));
		
		assertThat("el elemento", elementos, hasItem(anyOf(is(0.1F), is(0.2F), is(0.3F), is(0.4F), is(0.5F), 
														   is(0.6F), is(0.7F), is(0.8F), is(0.9F), is(1.0F))));
		
	}
}
