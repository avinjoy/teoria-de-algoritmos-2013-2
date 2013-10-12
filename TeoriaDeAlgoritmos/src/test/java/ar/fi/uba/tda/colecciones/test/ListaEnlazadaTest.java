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
	public void enUnaListaVaciaElTamanioEsCero() {
		
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
	public void siAgregoDosElementosElTamanioEsDos() {
		
		Object primero = new Object();
		Object segundo = new Object();
		
		lista.agregar(primero);
		lista.agregar(segundo);
		
		assertThat("el tamaño de la lista", lista.tamanio(), is(2));
	}
	
	@Test
	public void siAgregoDosElementosElSegundoEsElUltimo() {
		
		Object primero = new Object();
		Object segundo = new Object();
		
		lista.agregar(primero);
		lista.agregar(segundo);
		
		assertThat("el primer elemento", lista.primero(), is(primero));
		assertThat("el ultimo elemento", lista.ultimo(), is(segundo));
	}
	
	@Test
	public void siLaListaTieneElementosElIteradorTieneSiguiente() {
		
		Object primero = new Object();
		
		lista.agregar(primero);
		
		Iterator<Object> iterador = lista.iterador();
		
		assertThat("la lista tiene elementos", iterador.hasNext(), is(true));
		
	}
	
	@Test
	public void siLaListaNoTieneElementosElIteradorNoTieneSiguiente() {
		
		Iterator<Object> iterador = lista.iterador();
		
		assertThat("la lista tiene elementos", iterador.hasNext(), is(false));
		
	}
	
	@Test
	public void puedoRecorrerLaListaEnOrden() {
		
		Object primero = new Object();
		Object segundo = new Object();
		
		lista.agregar(primero);
		lista.agregar(segundo);
		
		Iterator<Object> iterador = lista.iterador();
		
		assertThat("el primer elemento", iterador.next(), is(primero));
		assertThat("el segundo elemento", iterador.next(), is(segundo));
		
	}
	
	@Test
	public void despuesDeSacarElUltimoElementoYaNoPuedoIterar() {
		
		Object primero = new Object();
		Object segundo = new Object();
		
		lista.agregar(primero);
		lista.agregar(segundo);
		
		Iterator<Object> iterador = lista.iterador();
		
		assertThat("el primer elemento", iterador.next(), is(primero));
		assertThat("el segundo elemento", iterador.next(), is(segundo));
		
		assertThat("la lista tiene elementos", iterador.hasNext(), is(false));
		
	}
	
	@Test
	public void buscaUnElementoEnLaLista() {
		
		lista.agregar("Hola");
		
		boolean encontrado = lista.contiene("Hola");
		
		assertThat("el elemento", encontrado, is(true));
	}

	@Test
	public void siElElementoNoEstaDaBuscarloFalse() {
		
		lista.agregar("Hola");
		
		boolean encontrado = lista.contiene("Chau");
		
		assertThat("el elemento", encontrado, is(false));
	}
	
	@Test
	public void obtieneUnElementoEnLaLista() {
		
		lista.agregar("Hola");
		
		Object encontrado = lista.obtener("Hola");
		
		assertThat("el elemento", encontrado, is((Object)"Hola"));
	}

	@Test
	public void siElElementoNoEstaDaObteneroDevuelveNull() {
		
		lista.agregar("Hola");
		
		Object encontrado = lista.obtener("Chau");
		
		assertThat("el elemento", encontrado, nullValue());
	}
}
