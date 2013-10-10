package ar.fi.uba.tda.colecciones.test;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;

import org.junit.Before;
import org.junit.Test;

import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.Vertice;

public class GrafoTest {

	private Grafo<String> grafo;
	private Vertice<String> verticeUno;
	private Vertice<String> verticeDos;
	
	@Before
	public void setup() {
		
		grafo = new Grafo<String>();
		
		verticeUno = new Vertice<String>("VerticeUno");
		verticeDos = new Vertice<String>("VerticeDos");
	}
	
	@Test
	public void grafoVacioTest() {
		assertThat("El grafo est� vac�o", grafo.getCantidadDeNodosGrafo(), is(0));
	}
	
	@Test
	public void agregoUnVerticeTest() {

		grafo.agregarVertice(verticeUno);
		assertThat("Agrego un vertice", grafo.getCantidadDeNodosGrafo(), is(1));
	}
	
	//TODO:Tenemos que ver si la lista acepta repetidos
	@Test
	public void agregoUnArcoTest() {
		
		grafo.agregarArco(verticeUno, verticeDos);
		assertThat("Hay dos vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		assertThat("Hay un arco entre Vertice Uno y Dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
	}
	
	@Test
	public void agregoUnVerticeTestYLoMarco() {

		verticeUno.setVisitado(true);
		grafo.agregarVertice(verticeUno);
		assertThat("Agrego un vertice", grafo.getCantidadDeNodosGrafo(), is(1));
		assertThat("Esta marcado?", grafo.getVertices().primero().isVisitado(), is(true));
		
	}
	
	@Test
	public void alAgregarUnArcoSoloAgregaLosVerticesSiCorresponde() {
		
		grafo.agregarVertice(verticeUno);
		
		grafo.agregarArco(verticeUno, verticeDos);
		assertThat("Hay dos vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		assertThat("Hay un arco entre Vertice Uno y Dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
		
	}
	
	@Test
	public void alAgregarUnArcoSoloAgregaLosVerticesSiCorrespondeAunqueNoSeanLaMismaInstancia() {
		
		Vertice<String> verticeDosBis = new Vertice<String>("VerticeDos");
		
		grafo.agregarVertice(verticeUno);
		grafo.agregarVertice(verticeDosBis);
		
		grafo.agregarArco(verticeUno, verticeDos);
		assertThat("Hay dos vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		assertThat("Hay un arco entre Vertice Uno y Dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
		
	}
	
	@Test
	public void noAgregaVerticesRepetidos() {
		
		Vertice<String> verticeDosBis = new Vertice<String>("VerticeDos");
		
		grafo.agregarVertice(verticeDos);
		grafo.agregarVertice(verticeDosBis);
		
		assertThat("Hay dos vertices", grafo.getCantidadDeNodosGrafo(), is(1));
		
	}

}
