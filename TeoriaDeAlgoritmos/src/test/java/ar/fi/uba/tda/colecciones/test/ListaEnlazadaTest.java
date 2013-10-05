package ar.fi.uba.tda.colecciones.test;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;

import java.util.Iterator;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tda.colecciones.ListaEnlazada;

public class ListaEnlazadaTest {
	
	private ListaEnlazada<Object> lista;

	@Before
	public void setup() {
		
		lista = new ListaEnlazada<Object>();
	}
	
	@Test
	public void listaVacia() {
		
		
		assertThat("la lista no está vacía", lista.vacia(), is(true));
	}
	
	@Test
	public void enUnaListaVaciaElPrimerElementoEsNulo() {
		
		assertThat("el primer elemento", lista.primero(), nullValue());
	}
	
	@Test
	public void enUnaListaVaciaElUltimoElementoEsNulo() {
		
		assertThat("el primer elemento", lista.ultimo(), nullValue());
	}
	
	@Test
	public void enUnaListaVaciaElTamañoEsCero() {
		
		assertThat("el tamaño", lista.tamanio(), is(0));
	}
	
	@Test
	public void siAgregoUnElementoEsElPrimero() {
		
		Object elemento = new Object();
		lista.agregar(elemento);
		
		Object primero = lista.primero();
		
		assertThat("el primer elemento", primero, notNullValue());
		assertThat("el primer elemento", primero, is(elemento));
		
		assertThat("el tamaño", lista.tamanio(), is(1));
	}
	
	@Test
	public void siAgregoUnElementoEsElUltimo() {
		
		Object elemento = new Object();
		lista.agregar(elemento);
		
		assertThat("el primer elemento", lista.ultimo(), notNullValue());
		assertThat("el primer elemento", lista.ultimo(), is(elemento));
	}
	
	@Test
	public void puedoRecorrerLaListaEnOrden() {
		
		Object primero = new Object();
		Object segundo = new Object();
		
		lista.agregar(primero);
		lista.agregar(segundo);
		
		assertThat("el tamaño", lista.tamanio(), is(2));
		
		Iterator<Object> iterador = lista.iterador();
		
		assertThat("la lista tiene elementos", iterador.hasNext(), is(true));
		
		assertThat("el primer elemento", iterador.next(), is(primero));
		assertThat("el segundo elemento", iterador.next(), is(segundo));
		
	}

}
