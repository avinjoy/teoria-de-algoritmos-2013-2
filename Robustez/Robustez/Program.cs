using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Robustez;


namespace Robustez
{
    class Program
    {
	    private AumentadorRobustez<Nodo> aumentador;
	    private Grafo<Nodo> grafo;
	
	    public Program(Grafo<Nodo> grafo, AumentadorRobustez<Nodo> aumentador) 
        {
		    this.grafo = grafo;
		    this.aumentador = aumentador;
	    }

        public static Grafo<Nodo> ReadTextFile(string archivo)
        {

            string line;

            Grafo<Nodo> grafo = new Grafo<Nodo>();

            // Lee el archivo linea por linea
            using (StreamReader file = new StreamReader(archivo))
            {
                while ((line = file.ReadLine()) != null)
                {

                    char[] delimiterNodo = new char[] { ':' };
                    string[] nodos = line.Split(delimiterNodo, StringSplitOptions.RemoveEmptyEntries);

                    Nodo nodo = new Nodo();
                    Vertice<Nodo> vNodo = new Vertice<Nodo>(nodo);

                    vNodo.Contenido.Nombre = nodos[0];

                    char[] delimiterAdy = new char[] { ',' };
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


        public void ejecutar(int robustezDeseada) 
        {
		    grafo.encontrarCiclos((Vertice<Nodo>) grafo.Vertices.Primero());
		    aumentador.Aumentar(grafo.CiclosGrafo, robustezDeseada);
	    }


        static void Main(string[] args)
        {
            int robustezDeseada = Convert.ToInt32("3");

            Grafo<Nodo> grafo = ReadTextFile("grafo1.txt");
            AumentadorRobustez<Nodo> aumentador = new AumentadorRobustez<Nodo>(grafo);

            new Program(grafo, aumentador).ejecutar(robustezDeseada);

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
