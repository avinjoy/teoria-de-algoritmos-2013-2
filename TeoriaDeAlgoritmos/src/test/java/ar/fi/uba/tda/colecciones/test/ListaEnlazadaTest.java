package ar.fi.uba.tda.colecciones.test;

import org.hamcrest.MatcherAssert;
import org.hamcrest.Matchers;
import org.junit.Test;

import ar.fi.uba.tda.colecciones.ListaEnlazada;

public class ListaEnlazadaTest {
	
	@Test
	public void listaVacia() {
		
		ListaEnlazada lista = new ListaEnlazada();
		
		MatcherAssert.assertThat("la lista es nula", lista, Matchers.notNullValue());
	}

}
