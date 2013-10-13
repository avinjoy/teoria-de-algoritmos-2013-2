using System;
using System.Collections.Generic;
using System.Text;

namespace TeoriaDelAlgoritmosCSHARP
{
    public class Vertice <T>
    {
        private T contenido; 
        private bool visitado;
        private ListaEnlazada<Vertice<T>> adyacentes;
        private long index;
        private long lowLink;

        public long Index
        {
            get { return index; }
            set { index = value; }
        }

        public long LowLink
        {
            get { return lowLink; }
            set { lowLink = value; }
        }
        
        public T Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
        

        public bool Visitado
        {
            get { return visitado; }
            set { visitado = value; }
        }
        

        public ListaEnlazada<Vertice<T>> Adyacentes
        {
            get { return adyacentes; }
            set { adyacentes = value; }
        }
		
	    public Vertice(): base() {
            
	    }
	
	    public Vertice(T contenido): base(){
		    Contenido=contenido;
		    Adyacentes=new ListaEnlazada<Vertice<T>>();
	    }
	
	  	
	    public Int32 GetGradoVertice(){
            return this.adyacentes.Tamanio;
	    }


        
	    public override int GetHashCode() {
		    const int prime = 31;
		    int result = 1;
		    result = prime * result
				    + ((contenido == null) ? 0 : contenido.GetHashCode());
		    return result;
	    }

	    public override bool Equals(Object obj) 
        {
		    if (this == obj) {
			    return true;
		    }
		    if (obj == null) {
			    return false;
		    }
		    if (!(obj is Vertice<T>)) {
			    return false;
		    }
		    Vertice<T> other = (Vertice<T>) obj;
		    if (contenido == null) {
			    if (other.contenido != null) {
				    return false;
			    }
		    } else if (!contenido.Equals(other.contenido)) {
			    return false;
		    }
		    return true;
	    }
    }
}
