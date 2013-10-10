package ar.fi.uba.tda.util.test;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.is;

import org.junit.Ignore;
import org.junit.Test;

import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.util.CargadorDeGrafos;

public class CargadorDeGrafosTest {

	@Test
	public void agregaUnaAristaUniendoDosVerticesDados() {
		
		Grafo grafo = new Grafo();
		CargadorDeGrafos cargador = new CargadorDeGrafos(grafo);
		cargador.agregarArista("vertice1", "vertice2");
		
		assertThat("Hay dos vertices", grafo.getCantidadDeNodosGrafo(), is(2));
		assertThat("Hay un arco entre Vertice Uno y Dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
	}
	
	@Test
	public void noAgregaVerticesRepetidos() {
		
		Grafo grafo = new Grafo();
		CargadorDeGrafos cargador = new CargadorDeGrafos(grafo);
		cargador.agregarArista("vertice1", "vertice2");
		cargador.agregarArista("vertice1", "vertice3");
		
		assertThat("Hay dos vertices", grafo.getCantidadDeNodosGrafo(), is(3));
		assertThat("Hay un arco entre Vertice Uno y Dos", grafo.getVertices().primero().getAdyacentes().primero(), is(grafo.getVertices().ultimo()));
	}
}
