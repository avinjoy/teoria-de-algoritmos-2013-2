using System;
using System.IO;
using System.Text;

namespace Robustez
{
    class Program
    {
	    private Robustez<Nodo> _aumentador;
	    private Grafo<Nodo> _grafo;
	
	    public Program(Grafo<Nodo> grafo, Robustez<Nodo> aumentador) 
        {
	        Grafo = grafo;
		    Aumentador = aumentador;
	        
        }

        public Robustez<Nodo> Aumentador
        {
            get { return _aumentador; }
            set { _aumentador = value; }
        }

        public Grafo<Nodo> Grafo
        {
            get { return _grafo; }
            set { _grafo = value; }
        }


        public static Grafo<Nodo> ReadTextFile(string archivo)
        {
            Grafo<Nodo> grafo = new Grafo<Nodo>();

            // Lee el archivo linea por linea
            using (StreamReader file = new StreamReader(archivo))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {

                    char[] delimiterNodo = { ':' };
                    string[] nodos = line.Split(delimiterNodo, StringSplitOptions.RemoveEmptyEntries);

                    Nodo nodo = new Nodo();
                    Vertice<Nodo> vNodo = new Vertice<Nodo>(nodo);

                    vNodo.Contenido.Nombre = nodos[0];

                    char[] delimiterAdy = { ',' };
                    string[] adyacentes = nodos[1].Split(delimiterAdy, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < adyacentes.Length; i++)
                    {
                        vNodo.Contenido.NroAdyacentes = adyacentes.Length;

                        Nodo ady = new Nodo();
                        ady.Nombre = adyacentes[i].Trim();
                        Vertice<Nodo> vAdy = new Vertice<Nodo>(ady);

                        vNodo.Adyacentes.Agregar(vAdy);
                    }

                    grafo.AgregarVertice(vNodo);

                }

                file.Close();
            }

            return grafo;
   
        }


        public void Ejecutar(int robustezDeseada) 
        {
		    Grafo.EncontrarCiclos(Grafo.Vertices.Primero());
		    Aumentador.Aumentar(Grafo.CiclosGrafo, robustezDeseada);


            ListaEnlazada<Arista<Nodo>> aristas = Aumentador.GetAristasAgregadas();
		    int numeroArista = 0;
		
		    ListaEnlazada<Arista<Nodo>>.IteradorListaEnlazada itAristas = aristas.Iterador;
		    //Open the File
		    StreamWriter sw = new StreamWriter("salida.txt", false, Encoding.ASCII);

		    while (itAristas.HasNext()) {
			
			    numeroArista++;
			    Arista<Nodo> arista = itAristas.Next();
				
                sw.Write("Arista " + numeroArista + ": " + arista + System.Environment.NewLine);
			
		    }
            //close the file
			sw.Close();
	    }


        static void Main(string[] args)
        {
            int robustezDeseada = Convert.ToInt32("3");

            Grafo<Nodo> grafo = ReadTextFile("grafo3.txt");
            Robustez<Nodo> aumentador = new Robustez<Nodo>(grafo);

            new Program(grafo, aumentador).Ejecutar(robustezDeseada);

            Console.ReadKey();
            /*
            if (args.Length > 0)
            {
                int robustezDeseada = Convert.ToInt32(args[0]);

                Grafo<Nodo> grafo = ReadTextFile(args[1]);
                AumentadorRobustez<Nodo> aumentador = new AumentadorRobustez<Nodo>(grafo);

                new Program(grafo, aumentador).ejecutar(robustezDeseada);

                Console.ReadKey();
            }
            else
            {
                System.Console.Write("Se debe ingresar el grado de robustez y el nombre de archivo");
            }
            */
        }

    }
}
