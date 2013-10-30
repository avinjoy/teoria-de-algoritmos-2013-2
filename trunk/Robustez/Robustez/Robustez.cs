using System;
using System.Collections.Generic;
using System.Text;


namespace Robustez
{
    public class Robustez<T>
    {

        private Grafo<T> _grafo;
        private ListaEnlazada<Arista<T>> _aristasAgregadas;

        public Grafo<T> Grafo
        {
            get { return _grafo; }
            set { _grafo = value; }
        }


        public ListaEnlazada<Arista<T>> AristasAgregadas
        {
            get { return _aristasAgregadas; }
            set { _aristasAgregadas = value; }
        }

        public Robustez(Grafo<T> grafo)
        {
            AristasAgregadas = new ListaEnlazada<Arista<T>>();
            Grafo = grafo;
        }

        /// <summary>
        /// Incrementa el grado de robustez segun el valor pasado por parametro.
        /// </summary>
        /// <param name="ciclos"></param>
        /// <param name="robustez"></param>
        public void Aumentar(ListaCircular<ListaCircular<Vertice<T>>> ciclos, int robustez)
        {

            ListaCircular<ListaCircular<Vertice<T>>>.IteradorListaCircular listaDeCiclos = ciclos.Iterador;

            //Obtengo el primer ciclo.
            ListaCircular<Vertice<T>> ciclo = listaDeCiclos.Next();
            //Mientras haya ciclos disponibles.
            for (int h = 0; h < ciclos.Tamanio; h++)
            {

                //Obtengo el segundo ciclo.
                ListaCircular<Vertice<T>> siguienteCiclo = listaDeCiclos.Next();

                //Mantego su referencia para no perderlo.
                ListaCircular<Vertice<T>> mantengoSiguienteCiclo = siguienteCiclo;


                //Para cada vertice del primer ciclo.
                for (int i = 0; i < ciclo.Tamanio; i++)
                {
                    siguienteCiclo = mantengoSiguienteCiclo;
                    siguienteCiclo.Iterador = new ListaCircular<Vertice<T>>.IteradorListaCircular(siguienteCiclo);

                    Vertice<T> verticeInicio = ciclo.Iterador.Next();

                    //Mientras no haya completado su grado.
                    bool agregarSinImportarGrado = false;
                    while (verticeInicio.GetGradoVertice() < robustez)
                    {
                        //Variable que seteo si no encontre ningun vertice fin menor al grado de robustez.


                        if (siguienteCiclo == ciclos.Primero())
                        {
                            agregarSinImportarGrado = true;
                        }

                        //Para cada vertice del segundo ciclo.
                        for (int j = 0; j < siguienteCiclo.Tamanio; j++)
                        {
                            Vertice<T> verticeFin = siguienteCiclo.Iterador.Next();

                            //Si no encontre ningun vertice fin con grado menor al de robustez, 
                            //lo uno siempre y cuando no haya sido agregado previamente.
                            if (agregarSinImportarGrado)
                            {
                                if (!verticeInicio.Adyacentes.Contiene(verticeFin) && !verticeInicio.Equals(verticeFin))
                                {
                                    //Uno los vertices.
                                    verticeInicio.Adyacentes.Agregar(verticeFin);
                                    verticeFin.Adyacentes.Agregar(verticeInicio);
                                    //Agrego la arista, a mi resultado de aristas agregadas.
                                    AristasAgregadas.Agregar(new Arista<T>(verticeInicio, verticeFin));

                                    //Si complete el grado, no sigo recorriendo, paso a otro vertice.
                                    if (verticeInicio.GetGradoVertice() == robustez)
                                        break;
                                }

                            }
                            else
                            {

                                if (!verticeInicio.Adyacentes.Contiene(verticeFin) && verticeFin.GetGradoVertice() < robustez)
                                {
                                    verticeInicio.Adyacentes.Agregar(verticeFin);
                                    verticeFin.Adyacentes.Agregar(verticeInicio);
                                    //Agrego la arista, a mi resultado de aristas agregadas.
                                    AristasAgregadas.Agregar(new Arista<T>(verticeInicio, verticeFin));
                                    //Si complete el grado, no sigo recorriendo, paso a otro vertice.
                                    if (verticeInicio.GetGradoVertice() == robustez)
                                        break;
                                }
                            }

                        }
                        if (verticeInicio.GetGradoVertice() < robustez)
                        {
                            //Si recorri todo el segundo ciclo, paso al ciclo siguiente, hasta poder completarlo.

                            siguienteCiclo = listaDeCiclos.Next();
                        }
                    }
                }
                ciclo = siguienteCiclo;

            }

        }



        private bool RobustezEsCompatibleConElGrafo(int robustez)
        {
            return _grafo.GetCantidadDeVertices() > robustez;
        }

        private ListaEnlazada<Vertice<T>> ObtenerSiguienteCiclo(ListaCircular<ListaEnlazada<Vertice<T>>> ciclos,
                                                                ListaCircular<ListaEnlazada<Vertice<T>>>.IteradorListaCircular listaDeCiclos)
        {

            ListaEnlazada<Vertice<T>> siguienteCiclo;

            if (listaDeCiclos.HasNext())
            {
                siguienteCiclo = listaDeCiclos.Next();


            }
            else
            {
                siguienteCiclo = ciclos.Primero();
            }

            return siguienteCiclo;
        }

        public ListaEnlazada<Arista<T>> GetAristasAgregadas()
        {
            return _aristasAgregadas;
        }

    }

}
