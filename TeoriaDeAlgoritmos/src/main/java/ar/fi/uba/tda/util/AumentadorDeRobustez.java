package ar.fi.uba.tda.util;

import java.util.Iterator;
import java.util.ListIterator;

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
	public void aumentar(ListaEnlazada<ListaEnlazada<Vertice>> ciclos, int robustez) {

		if (laRobustezEsCompatibleConElGrafo(robustez)) {
			
			ListIterator<ListaEnlazada<Vertice>> listaDeCiclos = ciclos.iterador();
			
			while (listaDeCiclos.hasNext()) {
				
				ListaEnlazada<Vertice> ciclo = listaDeCiclos.next();
				
				ListaEnlazada<Vertice> siguienteCiclo = obtenerSiguienteCiclo(ciclos, listaDeCiclos);
				
				Iterator<Vertice> verticesPrimerCiclo = ciclo.iterador();
				Iterator<Vertice> verticesSegundoCiclo = siguienteCiclo.iterador();
				
				int robustezAlcanzada = 0;
				
				while (robustezAlcanzada < robustez && verticesPrimerCiclo.hasNext() && verticesSegundoCiclo.hasNext()) {
					
					Vertice verticeCicloUno = verticesPrimerCiclo.next();
					Vertice verticeCicloDos = verticesSegundoCiclo.next();
					
					if (!verticeCicloUno.getAdyacentes().contiene(verticeCicloDos)) {
						aristasAgregadas.agregar(new Arista(verticeCicloUno, verticeCicloDos));
					}
					
					robustezAlcanzada++;
				}
				
			}
		}
	}

	private boolean laRobustezEsCompatibleConElGrafo(int robustez) {
		return grafo.getCantidadDeNodosGrafo() > robustez;
	}

	@SuppressWarnings("rawtypes")
	private ListaEnlazada<Vertice> obtenerSiguienteCiclo(ListaEnlazada<ListaEnlazada<Vertice>> ciclos,
															ListIterator<ListaEnlazada<Vertice>> listaDeCiclos) {
		
		ListaEnlazada<Vertice> siguienteCiclo;
		
		if (listaDeCiclos.hasNext()) {
			siguienteCiclo = listaDeCiclos.next();
			
			corregirIterador(listaDeCiclos);
		} else {
			siguienteCiclo = ciclos.primero();
		}
		
		return siguienteCiclo;
	}

	@SuppressWarnings("rawtypes")
	private void corregirIterador(
			ListIterator<ListaEnlazada<Vertice>> listaDeCiclos) {
		if (listaDeCiclos.hasNext()) {
			listaDeCiclos.previous();
		}
	}

	public ListaEnlazada<Arista> getAristasAgregadas() {
		return aristasAgregadas;
	}

}
