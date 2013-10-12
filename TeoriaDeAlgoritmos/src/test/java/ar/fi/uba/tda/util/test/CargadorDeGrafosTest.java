package ar.fi.uba.tda.util.test;

import static org.hamcrest.MatcherAssert.*;
import static org.hamcrest.Matchers.*;

import java.io.BufferedReader;
import java.io.IOException;

import org.junit.Before;
import org.junit.Test;
import static org.mockito.Mockito.*;

import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.ListaEnlazada;
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
	
	@Test
	public void cargaDesdeUnArchivoDosVerticeConDosAdyacentes() throws IOException {
		
		BufferedReader reader = mock(BufferedReader.class);
		when(reader.readLine()).thenReturn("A:B,C", "B:D,E", (String)null);
		
		cargador.cargar(reader);
		
		Vertice<String> verticeA = new Vertice<String>("A");
		Vertice<String> verticeB = new Vertice<String>("B");
		Vertice<String> verticeC = new Vertice<String>("C");
		Vertice<String> verticeD = new Vertice<String>("D");
		Vertice<String> verticeE = new Vertice<String>("E");
		
		assertThat("la cantidad de vertices", grafo.getCantidadDeNodosGrafo(), is(5));
		
		ListaEnlazada<Vertice<String>> vertices = grafo.getVertices();
		
		Vertice<String> verticeAEnElGrafo = vertices.obtener(verticeA);
		Vertice<String> verticeBEnElGrafo = vertices.obtener(verticeB);
		Vertice<String> verticeCEnElGrafo = vertices.obtener(verticeC);
		Vertice<String> verticeDEnElGrafo = vertices.obtener(verticeD);
		Vertice<String> verticeEEnElGrafo = vertices.obtener(verticeE);
		
		assertThat("el vertice A", verticeAEnElGrafo, is(verticeA));
		assertThat("arista entre A y B", verticeAEnElGrafo.getAdyacentes().primero(), is(verticeB));
		assertThat("arista entre A y C", verticeAEnElGrafo.getAdyacentes().ultimo(), is(verticeC));
		
		assertThat("el vertice B", verticeBEnElGrafo, is(verticeB));
		assertThat("arista entre B y A", verticeBEnElGrafo.getAdyacentes().primero(), is(verticeA));
		assertThat("arista entre B y E", verticeBEnElGrafo.getAdyacentes().ultimo(), is(verticeE));
		
		assertThat("el vertice C", verticeCEnElGrafo, is(verticeC));
		assertThat("arista entre C y A", verticeCEnElGrafo.getAdyacentes().primero(), is(verticeA));
		
		assertThat("el vertice D", verticeDEnElGrafo, is(verticeD));
		assertThat("arista entre D y B", verticeDEnElGrafo.getAdyacentes().primero(), is(verticeB));
		
		assertThat("el vertice E", verticeEEnElGrafo, is(verticeE));
		assertThat("arista entre E y B", verticeEEnElGrafo.getAdyacentes().primero(), is(verticeB));
		
	}
}
