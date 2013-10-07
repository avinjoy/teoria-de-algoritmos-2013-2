package ar.fi.uba.tda.colecciones.test;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.Vertice;

public class GrafoTest {

	private Grafo grafo;
	
	@Before
	public void setup() {
		
		grafo = new Grafo();
	}
	
	@Test
	public void grafoVacioTest() {
		assertThat("El grafo está vacío", grafo.getCantidadDeNodosGrafo(), is(0));
	}
	
	@Test
	public void agregoUnVerticeTest() {
		Vertice verticeUno = new Vertice("VerticeUno");
		grafo.agregarVertice(verticeUno);
		assertThat("Agrego un vertice", grafo.getCantidadDeNodosGrafo(), is(1));
	}
	
	//TODO:Tenemos que ver si la lista acepta repetidos
	@Test
	public void agregoUnArcoTest() {
		Vertice verticeUno = new Vertice("VerticeUno");
		Vertice verticeDos = new Vertice("VerticeDos");
		grafo.agregarArco(verticeUno, verticeDos);
		assertThat("Hay dos vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		assertThat("Hay un arco entre Vertice Uno y Dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
	}

}
