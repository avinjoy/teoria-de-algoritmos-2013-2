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
        public void Aumentar(ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclos, int robustez)
        {

            ListaEnlazada<ListaEnlazada<Vertice<T>>>.IteradorListaEnlazada listaDeCiclos = ciclos.Iterador;
            ListaEnlazada<ListaEnlazada<Vertice<T>>>.IteradorListaEnlazada listaDeCiclosAuxiliar = ciclos.Iterador;

            //Mientras haya ciclos disponibles.
          while(listaDeCiclos.HasNext()){           
                 
                //Obtengo el primer ciclo.
                ListaEnlazada<Vertice<T>> ciclo = listaDeCiclos.Next();
                ListaEnlazada<Vertice<T>> siguienteCiclo = ObtenerSiguienteCiclo(ciclos, listaDeCiclos);
             
                //Mantego su referencia para no perderlo.
                ListaEnlazada<Vertice<T>> mantengoSiguienteCiclo = siguienteCiclo;


                //Para cada vertice del primer ciclo.
                for (int i = 0; i < ciclo.Tamanio; i++)
                {
                    siguienteCiclo = mantengoSiguienteCiclo;
                    siguienteCiclo.Iterador = new ListaEnlazada<Vertice<T>>.IteradorListaEnlazada(siguienteCiclo);

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

                            if (listaDeCiclosAuxiliar.HasNext())
                            {
                                siguienteCiclo = listaDeCiclosAuxiliar.Next();
                                if (siguienteCiclo == null)
                                {
                                    listaDeCiclosAuxiliar.Siguiente--;
                                    siguienteCiclo = listaDeCiclosAuxiliar.Next();
                                }
                            }
                            else
                            {
                                listaDeCiclosAuxiliar.Siguiente = 0;
                                siguienteCiclo = ciclos.Primero();
                            }
                            siguienteCiclo.ResetIterator();
                        }
                    }
                }
            }
        }



        //public void Aumentar(ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclos, int robustez)
        //{

        //    if (RobustezEsCompatibleConElGrafo(robustez))
        //    {

        //        ListaEnlazada<ListaEnlazada<Vertice<T>>>.IteradorListaEnlazada listaDeCiclos = ciclos.Iterador;

        //        while (listaDeCiclos.HasNext())
        //        {

        //            ListaEnlazada<Vertice<T>> ciclo = listaDeCiclos.Next();

        //            ListaEnlazada<Vertice<T>> siguienteCiclo = ObtenerSiguienteCiclo(ciclos, listaDeCiclos);

        //            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada verticesPrimerCiclo = ciclo.Iterador;
        //            ListaEnlazada<Vertice<T>>.IteradorListaEnlazada verticesSegundoCiclo = siguienteCiclo.Iterador;

        //            int robustezAlcanzada = 0;

        //            while (robustezAlcanzada < robustez && verticesPrimerCiclo.HasNext() && verticesSegundoCiclo.HasNext())
        //            {

        //                Vertice<T> verticeCicloUno = verticesPrimerCiclo.Next();
        //                Vertice<T> verticeCicloDos = verticesSegundoCiclo.Next();

        //                if (!verticeCicloUno.Adyacentes.Contiene(verticeCicloDos))
        //                {
        //                    _aristasAgregadas.Agregar(new Arista<T>(verticeCicloUno, verticeCicloDos));
        //                }

        //                robustezAlcanzada++;
        //            }

        //        }
        //    }
        //}

        private bool RobustezEsCompatibleConElGrafo(int robustez)
        {
            return _grafo.GetCantidadDeVertices() > robustez;
        }

        private ListaEnlazada<Vertice<T>> ObtenerSiguienteCiclo(ListaEnlazada<ListaEnlazada<Vertice<T>>> ciclos,
                                                                ListaEnlazada<ListaEnlazada<Vertice<T>>>.IteradorListaEnlazada listaDeCiclos)
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
            return _aristasAgregadas;
        }

    }

}
