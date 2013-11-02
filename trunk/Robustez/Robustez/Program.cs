using System;
using System.IO;
using System.Text;

namespace Robustez
{
    class Program
    {
        private ArchivoGrafoManager _loader;
	    private Robustez<string> _aumentador;
	    private Grafo<string> _grafo;
	
	    public Program(Grafo<string> grafo, ArchivoGrafoManager loader, Robustez<string> aumentador) 
        {
	        Grafo = grafo;
		    Aumentador = aumentador;
            Loader = loader;
        }

        public Robustez<string> Aumentador
        {
            get { return _aumentador; }
            set { _aumentador = value; }
        }

        public Grafo<string> Grafo
        {
            get { return _grafo; }
            set { _grafo = value; }
        }

        public ArchivoGrafoManager Loader
        {
            get { return _loader; }
            set { _loader = value; }
        }


        public void Ejecutar(int robustezDeseada, StreamReader archivo) 
        {
            Loader.cargar(archivo);
            if (Grafo.Vertices.Tamanio <= robustezDeseada)
            {
                System.Console.Write(" " + System.Environment.NewLine);
                System.Console.Write(" " + System.Environment.NewLine);
                System.Console.Write("La cantidad de Vértices debe ser mayor al número de robustez deseado." + System.Environment.NewLine);
                System.Console.Write("Presione una tecla para terminar." + System.Environment.NewLine);
            }
            else
            {
                Grafo.RecorridoDFS();
                Grafo.EnlistarVerticesDiscontinuos();
                Aumentador.Aumentar(Grafo.CiclosGrafo, robustezDeseada);
                CompletarRobustezGrafo(Aumentador, robustezDeseada);

                ListaEnlazada<Arista<string>> aristas = Aumentador.GetAristasAgregadas();

                int numeroArista = 0;

                aristas.ResetIterator();
                ListaEnlazada<Arista<string>>.IteradorListaEnlazada itAristas = aristas.Iterador;
                //Open the File
                StreamWriter sw = new StreamWriter("salida.txt", false, Encoding.ASCII);

                while (itAristas.HasNext())
                {

                    numeroArista++;
                    Arista<string> arista = itAristas.Next();

                    sw.Write("Arista " + numeroArista + ": " + arista + System.Environment.NewLine);

                }
                //close the file
                sw.Close();
                System.Console.Write(" " + System.Environment.NewLine);
                System.Console.Write(" " + System.Environment.NewLine);
                System.Console.Write("Proceso terminado." + System.Environment.NewLine);
                System.Console.Write("Se ha creado el archivo de salida." + System.Environment.NewLine);
                System.Console.Write("Presione una tecla para terminar." + System.Environment.NewLine);
            }
	    }
              
        public void CompletarRobustezGrafo(Robustez<string> Aumentador, int robustezDeseada)
        {
            int[] vRobustez = new int[Grafo.CiclosGrafo.Tamanio+1];

            /*
            ListaEnlazada<Arista<string>> aristas = Aumentador.GetAristasAgregadas();
            ListaEnlazada<Arista<string>>.IteradorListaEnlazada itAristas = aristas.Iterador;

            while (itAristas.HasNext())
            {
                Arista<string> arista = itAristas.Next();

                vRobustez[arista.Origen.NroComponenteConexa]++;
                vRobustez[arista.Destino.NroComponenteConexa]++;
            }
            */

            Grafo.Vertices.ResetIterator();
            ListaEnlazada<Vertice<string>>.IteradorListaEnlazada itVertices = Grafo.Vertices.Iterador;
            while (itVertices.HasNext())
            {
                Vertice<string> v = itVertices.Next();

                v.Adyacentes.ResetIterator();
                ListaEnlazada<Vertice<string>>.IteradorListaEnlazada itAdy = v.Adyacentes.Iterador;

                while (itAdy.HasNext())
                {
                    Vertice<string> vAdy = itAdy.Next();

                    if (v.NroComponenteConexa != vAdy.NroComponenteConexa) 
                    {
                        vRobustez[v.NroComponenteConexa]++;
                    }
                }
            }

            for (int i = 1; i <= Grafo.CiclosGrafo.Tamanio; i++)
            {
                while (vRobustez[i] <= robustezDeseada) 
                {
                    Arista<string> arista = Grafo.obtenerVertice(i);
                    //Vertice<string> origen = Grafo.obtenerVertice(i, "origen");
                    //Vertice<string> dest = Grafo.obtenerVertice(i, "destino");

                    arista.Origen.Adyacentes.Agregar(arista.Destino);
                    arista.Destino.Adyacentes.Agregar(arista.Origen);
                    Aumentador.AristasAgregadas.Agregar(arista);

                    vRobustez[arista.Origen.NroComponenteConexa]++;
                    vRobustez[arista.Destino.NroComponenteConexa]++;
                }
                         
            }
        }

        static void Main(string[] args)
        {
            
            if (args.Length > 0)
            {
                presentacion();

                int robustezDeseada = Convert.ToInt32(args[0]);
                StreamReader archivo = new StreamReader(args[1]);

                Grafo<string> grafo = new Grafo<string>();
                ArchivoGrafoManager loader = new ArchivoGrafoManager(grafo);
                Robustez<string> aumentador = new Robustez<string>(grafo);

                new Program(grafo, loader, aumentador).Ejecutar(robustezDeseada, archivo);

                Console.ReadKey();
            }
            else
            {
                System.Console.Write("Se debe ingresar el grado de robustez y el nombre de archivo");
                Console.ReadKey();
            }
            
        }

        private static void presentacion()
        {

            System.Console.Write(" " + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write("*********************** TRABAJO PRACTICO NRO.1 *************************" + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write("*                                                                      *" + System.Environment.NewLine);
            System.Console.Write("* INTEGRANTES:                                                         *" + System.Environment.NewLine);
            System.Console.Write("*              SERGIO NICOLAS ORSIANI          85855                   *" + System.Environment.NewLine);
            System.Console.Write("*              JULIAN ANDRES D’AMBROSIO        90252                   *" + System.Environment.NewLine);
            System.Console.Write("*                                                                      *" + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);
            System.Console.Write("************************************************************************" + System.Environment.NewLine);

        }

    }
}
