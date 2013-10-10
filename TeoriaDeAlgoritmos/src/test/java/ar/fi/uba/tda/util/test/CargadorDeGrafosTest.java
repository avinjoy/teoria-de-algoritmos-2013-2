package ar.fi.uba.tda.util.test;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;

import org.junit.Test;

import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.Vertice;
import ar.fi.uba.tda.util.CargadorDeGrafos;

public class CargadorDeGrafosTest {

	@Test
	public void agregaUnaAristaUniendoDosVerticesDados() {
		
		Grafo<String> grafo = new Grafo<String>();
		CargadorDeGrafos cargador = new CargadorDeGrafos(grafo);
		cargador.agregarArista("vertice1", "vertice2");
		
		assertThat("la cantidad de vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		assertThat("el vertice uno y el dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
	}
	
	@Test
	public void noAgregaVerticesRepetidos() {
		
		Grafo<String> grafo = new Grafo<String>();
		CargadorDeGrafos cargador = new CargadorDeGrafos(grafo);
		cargador.agregarArista("vertice1", "vertice2");
		cargador.agregarArista("vertice1", "vertice3");
		
		assertThat("la cantidad de vertices", grafo.getCantidadDeNodosGrafo(), is(3));
		assertThat("el vertice uno y el dos", grafo.getVertices().primero().getAdyacentes().primero(), is(new Vertice<String>("vertice2")));
	}
}
