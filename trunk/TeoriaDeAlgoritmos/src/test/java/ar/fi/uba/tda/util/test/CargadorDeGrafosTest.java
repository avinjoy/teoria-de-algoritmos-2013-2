package ar.fi.uba.tda.util.test;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;

import java.io.BufferedReader;
import java.io.IOException;

import org.junit.Before;
import org.junit.Ignore;
import org.junit.Test;
import static org.mockito.Mockito.*;

import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.Vertice;
import ar.fi.uba.tda.util.CargadorDeGrafos;

public class CargadorDeGrafosTest {

	private Grafo<String> grafo;
	private CargadorDeGrafos cargador;

	@Before
	public void setup() {
	
		grafo = new Grafo<String>();
		cargador = new CargadorDeGrafos(grafo);
	}
	
	@Test
	public void agregaUnaAristaUniendoDosVerticesDados() {
		
		cargador.agregarArista("vertice1", "vertice2");
		
		assertThat("la cantidad de vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		assertThat("el vertice uno y el dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
	}
	
	@Test
	public void noAgregaVerticesRepetidos() {
		
		cargador.agregarArista("vertice1", "vertice2");
		cargador.agregarArista("vertice1", "vertice3");
		
		assertThat("la cantidad de vertices", grafo.getCantidadDeNodosGrafo(), is(3));
		assertThat("el vertice uno y el dos", grafo.getVertices().primero().getAdyacentes().primero(), is(new Vertice<String>("vertice2")));
	}
	
	@Test
	public void cargaDesdeUnArchivoUnVerticeConUnAdyacente() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		when(reader.readLine()).thenReturn("A:B", (String)null);
		
		cargador.cargar(reader);
		
		Vertice<String> verticeA = new Vertice<String>("A");
		Vertice<String> verticeB = new Vertice<String>("B");
		
		assertThat("la cantidad de vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		
		assertThat("el primer vertice", grafo.getVertices().primero(), is(verticeA));
		assertThat("el segundo vertice", grafo.getVertices().ultimo(), is(verticeB));
		
		assertThat("el vertice A y el B", grafo.getVertices().primero().getAdyacentes().primero(), is(verticeB));
	}
	
	@Test
	@Ignore("Hay que modificar el grafo para que busque el vértice a insertar y devuelva ese")
	public void cargaDesdeUnArchivoUnVerticeConDosAdyacentes() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		when(reader.readLine()).thenReturn("A:B,C", (String)null);
		
		cargador.cargar(reader);
		
		Vertice<String> verticeA = new Vertice<String>("A");
		Vertice<String> verticeB = new Vertice<String>("B");
		Vertice<String> verticeC = new Vertice<String>("C");
		
		assertThat("la cantidad de vertices", grafo.getCantidadDeNodosGrafo(), is(3));
		
		assertThat("el primer vertice", grafo.getVertices().primero(), is(verticeA));
		assertThat("el tercer vertice", grafo.getVertices().ultimo(), is(verticeC));
		
		assertThat("el vertice A y el B", grafo.getVertices().primero().getAdyacentes().primero(), is(verticeB));
		assertThat("el vertice A y el C", grafo.getVertices().primero().getAdyacentes().ultimo(), is(verticeC));
	}
}
