package ar.fi.uba.tda.util;

import java.util.Iterator;

import ar.fi.uba.tda.colecciones.Arista;
import ar.fi.uba.tda.colecciones.Grafo;
import ar.fi.uba.tda.colecciones.ListaEnlazada;
import ar.fi.uba.tda.colecciones.Vertice;

public class AumentadorDeRobustez {

	private final Grafo<?> grafo;
	private ListaEnlazada<Arista> aristasAgregadas = new ListaEnlazada<Arista>();

	public AumentadorDeRobustez(Grafo<?> grafo) {
		this.grafo = grafo;
	}

	@SuppressWarnings({ "unchecked", "rawtypes" })
	public void aumentar(ListaEnlazada<ListaEnlazada<Vertice<?>>> ciclos, int robustez) {

		if (laRobustezEsCompatibleConElGrafo(robustez)) {
			
			Iterator<ListaEnlazada<Vertice<?>>> listaDeCiclos = ciclos.iterador();
			
			while (listaDeCiclos.hasNext()) {
				
				ListaEnlazada<Vertice<?>> ciclo = listaDeCiclos.next();
				
				ListaEnlazada<Vertice<?>> siguienteCiclo = obtenerSiguienteCiclo(ciclos, listaDeCiclos);
				
				Iterator<Vertice<?>> verticesPrimerCiclo = ciclo.iterador();
				Iterator<Vertice<?>> verticesSegundoCiclo = siguienteCiclo.iterador();
				
				while (verticesPrimerCiclo.hasNext() && verticesSegundoCiclo.hasNext()) {
					
					Vertice verticeCicloUno = verticesPrimerCiclo.next();
					Vertice verticeCicloDos = verticesSegundoCiclo.next();
					
					if (!verticeCicloUno.getAdyacentes().contiene(verticeCicloDos)) {
						aristasAgregadas.agregar(new Arista(verticeCicloUno, verticeCicloDos));
					}
				}
				
			}
		}
	}

	private boolean laRobustezEsCompatibleConElGrafo(int robustez) {
		return grafo.getCantidadDeNodosGrafo() > robustez;
	}

	private ListaEnlazada<Vertice<?>> obtenerSiguienteCiclo(ListaEnlazada<ListaEnlazada<Vertice<?>>> ciclos,
															Iterator<ListaEnlazada<Vertice<?>>> listaDeCiclos) {
		
		ListaEnlazada<Vertice<?>> siguienteCiclo;
		
		if (listaDeCiclos.hasNext()) {
			siguienteCiclo = listaDeCiclos.next();
		} else {
			siguienteCiclo = ciclos.primero();
		}
		
		return siguienteCiclo;
	}

	public ListaEnlazada<Arista> getAristasAgregadas() {
		return aristasAgregadas;
	}

}
