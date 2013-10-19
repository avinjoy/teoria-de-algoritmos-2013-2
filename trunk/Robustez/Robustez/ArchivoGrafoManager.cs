using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text;

namespace Robustez
{
    class ArchivoGrafoManager
    {
        private Grafo<string> grafo;

	    public ArchivoGrafoManager(Grafo<string> grafo) {
		    this.grafo = grafo;
		
	    }

	    public void cargar(StreamReader reader) {
		
		    string line = reader.ReadLine();
            char[] delimiterstring = { ':' };
            char[] delimiterAdy = { ',' };

            while (line != null)
            {

                string[] vertices = line.Split(delimiterstring, StringSplitOptions.RemoveEmptyEntries);
			
			    string vertice = vertices[0].Trim();
			
			    if (vertices.Length > 1) {

                    string[] adyacentes = vertices[1].Split(delimiterAdy, StringSplitOptions.RemoveEmptyEntries);
				
				    for (int i = 0; i < adyacentes.Length; i++) {
					
					    agregarArista(vertice, adyacentes[i].Trim());
				    }
				
			    } else {
				
				    grafo.AgregarVertice(new Vertice<string>(vertice));
			    }
			
			    line = reader.ReadLine();
		    }
	    }
	
	    public void agregarArista(string verticeInicial, string verticeFinal) {
		
		    Vertice<string> inicio = new Vertice<string>(verticeInicial);
		
		    Vertice<string> fin = new Vertice<string>(verticeFinal);
		
		    grafo.AgregarArco(inicio, fin);
		
	    }
    }
}
