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
		assertThat("El grafo est� vac�o", grafo.getCantidadDeNodosGrafo(), is(0));
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
	
	@Test
	public void agregoUnVerticeTestYLoMarco() {
		Vertice verticeUno = new Vertice("VerticeUno");
		verticeUno.setVisitado(true);
		grafo.agregarVertice(verticeUno);
		assertThat("Agrego un vertice", grafo.getCantidadDeNodosGrafo(), is(1));
		assertThat("Esta marcado?", grafo.getVertices().primero().isVisitado(), is(true));
		
	}
	
	@Test
	public void alAgregarUnArcoSoloAgregaLosVerticesSiCorresponde() {
		
		Vertice verticeUno = new Vertice("VerticeUno");
		Vertice verticeDos = new Vertice("VerticeDos");
		
		grafo.agregarVertice(verticeUno);
		
		grafo.agregarArco(verticeUno, verticeDos);
		assertThat("Hay dos vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		assertThat("Hay un arco entre Vertice Uno y Dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
		
	}
	
	@Test
	public void alAgregarUnArcoSoloAgregaLosVerticesSiCorrespondeAunqueNoSeanLaMismaInstancia() {
		
		Vertice verticeUno = new Vertice("VerticeUno");
		Vertice verticeDos = new Vertice("VerticeDos");
		Vertice verticeDosBis = new Vertice("VerticeDos");
		
		grafo.agregarVertice(verticeUno);
		grafo.agregarVertice(verticeDosBis);
		
		grafo.agregarArco(verticeUno, verticeDos);
		assertThat("Hay dos vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		assertThat("Hay un arco entre Vertice Uno y Dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
		
	}

}
