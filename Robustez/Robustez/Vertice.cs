using System;
using System.Collections.Generic;
using System.Text;

namespace TeoriaDelAlgoritmosCSHARP
{
    class Vertice <T>
    {
        private T contenido; //TODO:Debemos ver que tipo de contenido ubicar ac�

        public T Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }
        private bool visitado;

        public bool Visitado
        {
            get { return visitado; }
            set { visitado = value; }
        }
        private ListaEnlazada<Vertice<T>> adyacentes;

        public ListaEnlazada<Vertice<T>> Adyacentes
        {
            get { return adyacentes; }
            set { adyacentes = value; }
        }
		
	    public Vertice(): base() {
            
	    }
	
	    public Vertice(T contenido): base(){
		    this.contenido=contenido;
		    this.adyacentes=new ListaEnlazada<Vertice<T>>();
	    }
	
	    public T getContenido() {
		    return contenido;
	    }
	    public void setContenido(T contenido) {
		    this.contenido = contenido;
	    }
	    public ListaEnlazada<Vertice<T>> getAdyacentes() {
		    return adyacentes;
	    }
	    public void setAdyacentes(ListaEnlazada<Vertice<T>> adyacentes) {
		    this.adyacentes = adyacentes;
	    }

	    public bool isVisitado() {
		    return visitado;
	    }

	    public void setVisitado(bool vistado) {
		    this.visitado = vistado;
	    }
	
	    public Int32 getGradoVertice(){
            return this.adyacentes.GetTamanio();
	    }

	    public int hashCode() {
		    const int prime = 31;
		    int result = 1;
		    result = prime * result
				    + ((contenido == null) ? 0 : contenido.GetHashCode());
		    return result;
	    }

	    public bool equals(Object obj) 
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
