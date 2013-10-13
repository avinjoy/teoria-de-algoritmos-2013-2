using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TeoriaDelAlgoritmosCSHARP;


namespace TeoriaDelAlgoritmosCSHARP
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadTextFile("grafo1.txt");

            Console.ReadKey();
        }

        public static void ReadTextFile(string archivo)
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

                        vNodo.Adyacentes.agregar(vAdy);
                    }

                    grafo.AgregarVertice(vNodo);

                }

                file.Close();
        }
   
        }

    }
}
