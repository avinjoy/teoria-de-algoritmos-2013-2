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
	private Vertice <String> verticeA = new Vertice<String>("A");
	private Vertice <String> verticeB = new Vertice<String>("B");
	private Vertice <String> verticeC = new Vertice<String>("C");
	private Vertice <String> verticeD = new Vertice<String>("D");
	private Vertice <String> verticeE = new Vertice<String>("E");
	private Vertice <String> verticeF = new Vertice<String>("F");
	private Vertice <String> verticeG = new Vertice<String>("G");
	private Vertice <String> verticeH = new Vertice<String>("H");
		
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
	
	@Test
	public void agregarGrafoEnunciadoYDFSTest() {
		crearGrafoEnunciado();
		grafo.recorridoDFS(this.grafo.getVertices());
		assertThat("Hay 8 vertices en el recorrido", grafo.getRecorridoDFS().tamanio(), is(8));
						
	}
	
	@Test
	public void agregarGrafoEnunciadoYBFSTest() {
		crearGrafoEnunciado();
		grafo.recorridoBFS(this.grafo.getVertices());
		assertThat("Hay 8 vertices en el recorridos", grafo.getRecorridoBFS().tamanio(), is(8));
	}
	
	@Test
	public void encontrarCiclosTest() {
		crearGrafoEnunciado();
		grafo.encontrarCiclos(this.grafo.getVertices());
		assertThat("Hay 8 vertices", grafo.getCantidadDeNodosGrafo(), is(8));
		assertThat("Hay 2 ciclos en el grafo", grafo.getCiclosGrafo().tamanio(), is(2));
		assertThat("El primer ciclo es de 4 ", grafo.getCiclosGrafo().primero().tamanio(), is(4));
		assertThat("El segundo ciclo es de 4 ", grafo.getCiclosGrafo().ultimo().tamanio(), is(4));
	}
	
	@Test
	public void encontrarCiclosEnGrafoAciclicoTest() {
		crearGrafoAciclico();
		grafo.encontrarCiclos(this.grafo.getVertices());
		assertThat("Hay 8 vertices", grafo.getCantidadDeNodosGrafo(), is(7));
		assertThat("Hay 0 ciclos en el grafo", grafo.getCiclosGrafo().tamanio(), is((0)));
	}

	private void crearGrafoEnunciado() {
		verticeA = new Vertice<String>("A");
		verticeB = new Vertice<String>("B");
		verticeC = new Vertice<String>("C");
		verticeD = new Vertice<String>("D");
		verticeE = new Vertice<String>("E");
		verticeF = new Vertice<String>("F");
		verticeG = new Vertice<String>("G");
		verticeH = new Vertice<String>("H");
		
		grafo.agregarArco(verticeA, verticeB);
		grafo.agregarArco(verticeA, verticeC);
		grafo.agregarArco(verticeB, verticeD);
		grafo.agregarArco(verticeC, verticeD);
		grafo.agregarArco(verticeD, verticeE);
		grafo.agregarArco(verticeE, verticeF);
		grafo.agregarArco(verticeE, verticeG);
		grafo.agregarArco(verticeF, verticeH);
		grafo.agregarArco(verticeG, verticeH);
	}
	
	private void crearGrafoAciclico() {
		verticeA = new Vertice<String>("A");
		verticeB = new Vertice<String>("B");
		verticeC = new Vertice<String>("C");
		verticeD = new Vertice<String>("D");
		verticeE = new Vertice<String>("E");
		verticeF = new Vertice<String>("F");
		verticeG = new Vertice<String>("G");
		
		grafo.agregarArco(verticeA, verticeB);
		grafo.agregarArco(verticeB, verticeC);
		grafo.agregarArco(verticeC, verticeD);
		grafo.agregarArco(verticeD, verticeE);
		grafo.agregarArco(verticeE, verticeF);
		grafo.agregarArco(verticeF, verticeG);
	}	
	

}
