using System;
using System.Collections.Generic;
using System.Text;

namespace Robustez
{
    public class AumentadorRobustez<T>
    {

        private Grafo<T> grafo;
        private ListaEnlazada<Arista<T>> aristasAgregadas = new ListaEnlazada<Arista<T>>();

        public AumentadorRobustez(Grafo<T> grafo)
        {
            this.grafo = grafo;
        }


        public void Aumentar(ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclos, int robustez)
        {

            if (RobustezEsCompatibleConElGrafo(robustez))
            {

                ListaEnlazada<ListaEnlazada<Vertice<T>>>.IteradorListaEnlazada listaDeCiclos = ciclos.Iterador;

                while (listaDeCiclos.HasNext())
                {

                    ListaEnlazada<Vertice<T>> ciclo = listaDeCiclos.Next();

                    ListaEnlazada<Vertice<T>> siguienteCiclo = ObtenerSiguienteCiclo(ciclos, listaDeCiclos);

                    ListaEnlazada<Vertice<T>>.IteradorListaEnlazada verticesPrimerCiclo = ciclo.Iterador;
                    ListaEnlazada<Vertice<T>>.IteradorListaEnlazada verticesSegundoCiclo = siguienteCiclo.Iterador;

                    int robustezAlcanzada = 0;

                    while (robustezAlcanzada < robustez && verticesPrimerCiclo.HasNext() && verticesSegundoCiclo.HasNext())
                    {

                        Vertice<T> verticeCicloUno = verticesPrimerCiclo.Next();
                        Vertice<T> verticeCicloDos = verticesSegundoCiclo.Next();

                        if (!verticeCicloUno.Adyacentes.Contiene(verticeCicloDos))
                        {
                            aristasAgregadas.Agregar(new Arista<T>(verticeCicloUno, verticeCicloDos));
                        }

                        robustezAlcanzada++;
                    }

                }
            }
        }

        private bool RobustezEsCompatibleConElGrafo(int robustez)
        {
            return grafo.GetCantidadDeNodosGrafo() > robustez;
        }

        private ListaEnlazada<Vertice<T>> ObtenerSiguienteCiclo(ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclos,
                                                                ListaEnlazada<ListaEnlazada<Vertice<T>>>.IteradorListaEnlazada listaDeCiclos)
        {

            ListaEnlazada<Vertice<T>> siguienteCiclo;

            if (listaDeCiclos.HasNext())
            {
                siguienteCiclo = listaDeCiclos.Next();

                CorregirIterador(listaDeCiclos);
            }
            else
            {
                siguienteCiclo = ciclos.Primero();
            }

            return siguienteCiclo;
        }

        private void CorregirIterador(
                ListaEnlazada<ListaEnlazada<Vertice<T>>>.IteradorListaEnlazada listaDeCiclos)
        {
            if (listaDeCiclos.HasNext())
            {
                listaDeCiclos.Previous();
            }
        }

        public ListaEnlazada<Arista<T>> GetAristasAgregadas()
        {
            return aristasAgregadas;
        }

    }

}
