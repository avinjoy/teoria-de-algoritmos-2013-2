using System;
using System.Collections.Generic;
using System.Text;

namespace TeoriaDelAlgoritmosCSHARP
{
   public class Arista<T> {

       private Vertice<T> origen;
       private Vertice<T> destino;

       public Vertice<T> Origen
       {
           get { return origen; }
           set { origen = value; }
       }     

       public Vertice<T> Destino
       {
           get { return destino; }
           set { destino = value; }
       }
	
	
	public Arista(Vertice<T> verticeCicloUno, Vertice<T> verticeCicloDos) {
		this.origen = verticeCicloUno;
		this.destino = verticeCicloDos;
	}

	
}
}
