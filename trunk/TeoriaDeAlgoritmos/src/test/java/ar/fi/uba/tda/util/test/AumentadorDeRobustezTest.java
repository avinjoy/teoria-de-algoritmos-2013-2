package ar.fi.uba.tda.util.test;

import org.hamcrest.MatcherAssert;
import org.hamcrest.Matchers;
import org.junit.Test;

import ar.fi.uba.tda.colecciones.Arista;
import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.ListaEnlazada;
import ar.fi.uba.tda.colecciones.Vertice;
import ar.fi.uba.tda.util.AumentadorDeRobustez;

public class AumentadorDeRobustezTest {

	@Test
	public void siRecibeUnNodoYRobustez1NoAgregaAristas() {
		
		Grafo<String> grafo = new Grafo<String>();
		
		AumentadorDeRobustez aumentador = new AumentadorDeRobustez(grafo);
		
		ListaEnlazada<ListaEnlazada<Vertice<?>>> ciclos = new ListaEnlazada<ListaEnlazada<Vertice<?>>>();
		
		ListaEnlazada<Vertice<?>> primerCiclo = new ListaEnlazada<Vertice<?>>();
		
		primerCiclo.agregar(new Vertice<String>());
		ciclos.agregar(primerCiclo);
		int robustez = 1;
		
		aumentador.aumentar(ciclos, robustez);
		
		ListaEnlazada<Arista> aristasAgregadas = aumentador.getAristasAgregadas();
		
		MatcherAssert.assertThat("la cantidad de aristas agregadas", aristasAgregadas.tamanio(), Matchers.is(0));
	}
	
	@Test
	@SuppressWarnings("unchecked")
	public void siRecibeDosNodosYRobustez1AgregaUnaArista() {
		
		Grafo<String> grafo = new Grafo<String>();
		Vertice<String> verticeA = new Vertice<String>("A");
		Vertice<String> verticeB = new Vertice<String>("B");
		
		grafo.agregarVertice(verticeA);
		grafo.agregarVertice(verticeB);
		
		AumentadorDeRobustez aumentador = new AumentadorDeRobustez(grafo);
		
		ListaEnlazada<ListaEnlazada<Vertice<?>>> ciclos = new ListaEnlazada<ListaEnlazada<Vertice<?>>>();
		
		ListaEnlazada<Vertice<?>> primerCiclo = new ListaEnlazada<Vertice<?>>();
		primerCiclo.agregar(verticeA);
		
		ListaEnlazada<Vertice<?>> segundoCiclo = new ListaEnlazada<Vertice<?>>();
		segundoCiclo.agregar(verticeB);
		
		
		ciclos.agregar(primerCiclo);
		ciclos.agregar(segundoCiclo);
		
		int robustez = 1;
		
		aumentador.aumentar(ciclos, robustez);
		
		ListaEnlazada<Arista> aristasAgregadas = aumentador.getAristasAgregadas();
		
		MatcherAssert.assertThat("la cantidad de aristas agregadas", aristasAgregadas.tamanio(), Matchers.is(1));
		MatcherAssert.assertThat("el origen de la arista", (Vertice<String>) aristasAgregadas.primero().getOrigen(), Matchers.is(verticeA));
		MatcherAssert.assertThat("el destino de la arista", (Vertice<String>) aristasAgregadas.primero().getDestino(), Matchers.is(verticeB));
	}
	
	@Test
	public void siRecibeDosNodosYRobustez2NoAgregaArista() {
		
		Grafo<String> grafo = new Grafo<String>();
		Vertice<String> verticeA = new Vertice<String>("A");
		Vertice<String> verticeB = new Vertice<String>("B");
		
		grafo.agregarVertice(verticeA);
		grafo.agregarVertice(verticeB);
		
		AumentadorDeRobustez aumentador = new AumentadorDeRobustez(grafo);
		
		ListaEnlazada<ListaEnlazada<Vertice<?>>> ciclos = new ListaEnlazada<ListaEnlazada<Vertice<?>>>();
		
		ListaEnlazada<Vertice<?>> primerCiclo = new ListaEnlazada<Vertice<?>>();
		primerCiclo.agregar(verticeA);
		
		ListaEnlazada<Vertice<?>> segundoCiclo = new ListaEnlazada<Vertice<?>>();
		segundoCiclo.agregar(verticeB);
		
		
		ciclos.agregar(primerCiclo);
		ciclos.agregar(segundoCiclo);
		
		int robustez = 2;
		
		aumentador.aumentar(ciclos, robustez);
		
		ListaEnlazada<Arista> aristasAgregadas = aumentador.getAristasAgregadas();
		
		MatcherAssert.assertThat("la cantidad de aristas agregadas", aristasAgregadas.tamanio(), Matchers.is(0));
	}
	
	@Test
	public void siRecibeDosNodosYaEnlazadosYRobustez1NoAgregaArista() {
		
		Grafo<String> grafo = new Grafo<String>();
		Vertice<String> verticeA = new Vertice<String>("A");
		Vertice<String> verticeB = new Vertice<String>("B");
		
		grafo.agregarVertice(verticeA);
		grafo.agregarVertice(verticeB);
		
		grafo.agregarArco(verticeA, verticeB);
		
		AumentadorDeRobustez aumentador = new AumentadorDeRobustez(grafo);
		
		ListaEnlazada<ListaEnlazada<Vertice<?>>> ciclos = new ListaEnlazada<ListaEnlazada<Vertice<?>>>();
		
		ListaEnlazada<Vertice<?>> primerCiclo = new ListaEnlazada<Vertice<?>>();
		primerCiclo.agregar(verticeA);
		
		ListaEnlazada<Vertice<?>> segundoCiclo = new ListaEnlazada<Vertice<?>>();
		segundoCiclo.agregar(verticeB);
		
		
		ciclos.agregar(primerCiclo);
		ciclos.agregar(segundoCiclo);
		
		int robustez = 1;
		
		aumentador.aumentar(ciclos, robustez);
		
		ListaEnlazada<Arista> aristasAgregadas = aumentador.getAristasAgregadas();
		
		MatcherAssert.assertThat("la cantidad de aristas agregadas", aristasAgregadas.tamanio(), Matchers.is(0));
	}
	
	@Test
	@SuppressWarnings("unchecked")
	public void siRecibeDosGruposDeDosNodosYRobustez2AgregaDosAristas() {
		
		Grafo<String> grafo = new Grafo<String>();
		Vertice<String> verticeA = new Vertice<String>("A");
		Vertice<String> verticeB = new Vertice<String>("B");
		Vertice<String> verticeC = new Vertice<String>("C");
		Vertice<String> verticeD = new Vertice<String>("D");
		
		grafo.agregarVertice(verticeA);
		grafo.agregarVertice(verticeB);
		grafo.agregarVertice(verticeC);
		grafo.agregarVertice(verticeD);
		
		grafo.agregarArco(verticeA, verticeB);
		grafo.agregarArco(verticeC, verticeD);
		
		AumentadorDeRobustez aumentador = new AumentadorDeRobustez(grafo);
		
		ListaEnlazada<ListaEnlazada<Vertice<?>>> ciclos = new ListaEnlazada<ListaEnlazada<Vertice<?>>>();
		
		ListaEnlazada<Vertice<?>> primerCiclo = new ListaEnlazada<Vertice<?>>();
		primerCiclo.agregar(verticeA);
		primerCiclo.agregar(verticeB);
		
		ListaEnlazada<Vertice<?>> segundoCiclo = new ListaEnlazada<Vertice<?>>();
		segundoCiclo.agregar(verticeC);
		segundoCiclo.agregar(verticeD);
		
		ciclos.agregar(primerCiclo);
		ciclos.agregar(segundoCiclo);
		
		int robustez = 2;
		
		aumentador.aumentar(ciclos, robustez);
		
		ListaEnlazada<Arista> aristasAgregadas = aumentador.getAristasAgregadas();
		
		MatcherAssert.assertThat("la cantidad de aristas agregadas", aristasAgregadas.tamanio(), Matchers.is(2));
		MatcherAssert.assertThat("el origen de la primera arista", (Vertice<String>) aristasAgregadas.primero().getOrigen(), Matchers.is(verticeA));
		MatcherAssert.assertThat("el destino de la primera arista", (Vertice<String>) aristasAgregadas.primero().getDestino(), Matchers.is(verticeC));
		
		MatcherAssert.assertThat("el origen de la segudna arista", (Vertice<String>) aristasAgregadas.ultimo().getOrigen(), Matchers.is(verticeB));
		MatcherAssert.assertThat("el destino de la segunda arista", (Vertice<String>) aristasAgregadas.ultimo().getDestino(), Matchers.is(verticeD));
	}
	
	@Test
	@SuppressWarnings("unchecked")
	public void siRecibeDosGruposDeDosNodosYRobustez1AgregaUnaArista() {
		
		Grafo<String> grafo = new Grafo<String>();
		Vertice<String> verticeA = new Vertice<String>("A");
		Vertice<String> verticeB = new Vertice<String>("B");
		Vertice<String> verticeC = new Vertice<String>("C");
		Vertice<String> verticeD = new Vertice<String>("D");
		
		grafo.agregarVertice(verticeA);
		grafo.agregarVertice(verticeB);
		grafo.agregarVertice(verticeC);
		grafo.agregarVertice(verticeD);
		
		grafo.agregarArco(verticeA, verticeB);
		grafo.agregarArco(verticeC, verticeD);
		
		AumentadorDeRobustez aumentador = new AumentadorDeRobustez(grafo);
		
		ListaEnlazada<ListaEnlazada<Vertice<?>>> ciclos = new ListaEnlazada<ListaEnlazada<Vertice<?>>>();
		
		ListaEnlazada<Vertice<?>> primerCiclo = new ListaEnlazada<Vertice<?>>();
		primerCiclo.agregar(verticeA);
		primerCiclo.agregar(verticeB);
		
		ListaEnlazada<Vertice<?>> segundoCiclo = new ListaEnlazada<Vertice<?>>();
		segundoCiclo.agregar(verticeC);
		segundoCiclo.agregar(verticeD);
		
		ciclos.agregar(primerCiclo);
		ciclos.agregar(segundoCiclo);
		
		int robustez = 1;
		
		aumentador.aumentar(ciclos, robustez);
		
		ListaEnlazada<Arista> aristasAgregadas = aumentador.getAristasAgregadas();
		
		MatcherAssert.assertThat("la cantidad de aristas agregadas", aristasAgregadas.tamanio(), Matchers.is(1));
		MatcherAssert.assertThat("el origen de la primera arista", (Vertice<String>) aristasAgregadas.primero().getOrigen(), Matchers.is(verticeA));
		MatcherAssert.assertThat("el destino de la primera arista", (Vertice<String>) aristasAgregadas.primero().getDestino(), Matchers.is(verticeC));
		
	}
	
	@Test
	@SuppressWarnings("unchecked")
	public void siRecibeTresGruposDeDosNodosYRobustez1AgregaDosAristas() {
		
		Grafo<String> grafo = new Grafo<String>();
		Vertice<String> verticeA = new Vertice<String>("A");
		Vertice<String> verticeB = new Vertice<String>("B");
		Vertice<String> verticeC = new Vertice<String>("C");
		Vertice<String> verticeD = new Vertice<String>("D");
		Vertice<String> verticeE = new Vertice<String>("E");
		Vertice<String> verticeF = new Vertice<String>("F");
		
		grafo.agregarVertice(verticeA);
		grafo.agregarVertice(verticeB);
		grafo.agregarVertice(verticeC);
		grafo.agregarVertice(verticeD);
		grafo.agregarVertice(verticeE);
		grafo.agregarVertice(verticeF);
		
		grafo.agregarArco(verticeA, verticeB);
		grafo.agregarArco(verticeC, verticeD);
		grafo.agregarArco(verticeE, verticeF);
		
		AumentadorDeRobustez aumentador = new AumentadorDeRobustez(grafo);
		
		ListaEnlazada<ListaEnlazada<Vertice<?>>> ciclos = new ListaEnlazada<ListaEnlazada<Vertice<?>>>();
		
		ListaEnlazada<Vertice<?>> primerCiclo = new ListaEnlazada<Vertice<?>>();
		primerCiclo.agregar(verticeA);
		primerCiclo.agregar(verticeB);
		
		ListaEnlazada<Vertice<?>> segundoCiclo = new ListaEnlazada<Vertice<?>>();
		segundoCiclo.agregar(verticeC);
		segundoCiclo.agregar(verticeD);
		
		ListaEnlazada<Vertice<?>> tercerCiclo = new ListaEnlazada<Vertice<?>>();
		tercerCiclo.agregar(verticeE);
		tercerCiclo.agregar(verticeF);
		
		ciclos.agregar(primerCiclo);
		ciclos.agregar(segundoCiclo);
		ciclos.agregar(tercerCiclo);
		
		int robustez = 1;
		
		aumentador.aumentar(ciclos, robustez);
		
		ListaEnlazada<Arista> aristasAgregadas = aumentador.getAristasAgregadas();
		
		MatcherAssert.assertThat("la cantidad de aristas agregadas", aristasAgregadas.tamanio(), Matchers.is(2));
		MatcherAssert.assertThat("el origen de la primera arista", (Vertice<String>) aristasAgregadas.primero().getOrigen(), Matchers.is(verticeA));
		MatcherAssert.assertThat("el destino de la primera arista", (Vertice<String>) aristasAgregadas.primero().getDestino(), Matchers.is(verticeC));
		
		MatcherAssert.assertThat("el origen de la segudna arista", (Vertice<String>) aristasAgregadas.ultimo().getOrigen(), Matchers.is(verticeC));
		MatcherAssert.assertThat("el destino de la segunda arista", (Vertice<String>) aristasAgregadas.ultimo().getDestino(), Matchers.is(verticeE));
		
	}
}
