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
            Grafo.recorridoDFS(Grafo);
            EnlistarVerticesDiscontinuos(Grafo);
		    Aumentador.Aumentar(Grafo.CiclosGrafo, robustezDeseada);


            ListaEnlazada<Arista<string>> aristas = Aumentador.GetAristasAgregadas();
		    int numeroArista = 0;
		
		    ListaEnlazada<Arista<string>>.IteradorListaEnlazada itAristas = aristas.Iterador;
		    //Open the File
		    StreamWriter sw = new StreamWriter("salida.txt", false, Encoding.ASCII);

		    while (itAristas.HasNext()) {
			
			    numeroArista++;
			    Arista<string> arista = itAristas.Next();
				
                sw.Write("Arista " + numeroArista + ": " + arista + System.Environment.NewLine);
			
		    }
            //close the file
			sw.Close();
	    }

        private void EnlistarVerticesDiscontinuos(Grafo<string> Grafo)
        {
            ListaEnlazada<Vertice<string>> lista = Grafo.Vertices;
            lista.resetIterator();
            ListaEnlazada<Vertice<string>>.IteradorListaEnlazada iter = lista.Iterador;
            ListaEnlazada<Vertice<string>> _subset;

            while (iter.HasNext())
            {
                Vertice<string> vActual = iter.Next();
                if (vActual.LowLink == vActual.Index + 1 && !vActual.AgregadoEnListaCiclo) 
                {
                    Vertice<string> vAux = vActual.Padre;
                    _subset = new ListaEnlazada<Vertice<string>>();
                    _subset.Agregar(vActual);
                    while (vAux != null)
                    {
                        _subset.Agregar(vAux);
                        vAux = vAux.Padre;
                    }

                    Grafo.CiclosGrafo.Agregar(_subset);
                }
            }
        }


        static void Main(string[] args)
        {
            
            if (args.Length > 0)
            {
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

    }
}
