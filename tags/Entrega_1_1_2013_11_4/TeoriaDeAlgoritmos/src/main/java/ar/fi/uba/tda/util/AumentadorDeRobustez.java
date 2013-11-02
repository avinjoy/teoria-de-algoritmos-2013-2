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

	/**
	 * Método encargado de agregar aristas entre distintos vértices para aumentar la robustez del grafo.
	 * 
	 * Este algoritmo itera por los ciclos del grafo, en el peor caso (grafo completamente desconectado)
	 * tendremos |V| ciclos, e itera por cada  uno de los vértices de ese ciclo, en el peor caso (grafo con un solo ciclo)
	 * tendremos |V| vértices en un ciclo.
	 * 
	 * Para cada vértice de cada ciclo, conecta ese vértice con un vértice del "ciclo siguiente"(*) hasta que agrega
	 * tantos vértices como la robustez pedida, de esta forma aumentamos la robustez entre cada ciclo, al finalizar
	 * habremos aumentado la robustez total del grafo.
	 * 
	 * Dado que recorremos todos los ciclos, y para cada ciclo todos los vértices que lo componen y que un vértice esta
	 * en un único ciclo el costo de esta operación es O(|V|) (este algoritmo recorre dos veces el primer ciclo,
	 * pero dado que es un número relativamente pequeño comparado con el total es despreciable).
	 *  
	 * (*) A los efectos de este algoritmo consideramos la lista de ciclos como una lista circular por lo que 
	 * "ciclo siguiente" puede ser el ciclo que le sigue al actual o el primero en caso de estar en el 
	 * último ciclo de la lista.
	 * 
	 * @param ciclos
	 * @param robustez
	 */
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
					
					if (!verticeCicloUno.getAdyacentes().contiene(verticeCicloDos) && !verticeCicloUno.equals(verticeCicloDos)) {
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
